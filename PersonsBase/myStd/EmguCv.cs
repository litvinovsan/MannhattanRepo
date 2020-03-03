using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.VideoStab;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu.CV.Ocl;
using Emgu.CV.Util;
using Gray = Emgu.CV.Structure.Gray;


namespace PersonsBase.myStd
{
    public class EmguCv
    {
        #region /// СОБЫТИЯ ///
        /// <summary>
        /// Событие при изменении картинки CameraBitmap
        /// </summary>
        [field: NonSerialized] public event EventHandler FrameChanged;
        private void OnFrameChanged()
        {
            FrameChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region /// ПОЛЯ ///
        private VideoCapture _capture;

        //Pre-trained cascade
        private readonly CascadeClassifier _faceCascade;
        private readonly CascadeClassifier _eyeCascade;
        private Image<Bgr, Byte> _frameImage;

        // Готовое чистое изображение с камеры
        //  private Bitmap _frameBitmap = null;

        //public Bitmap FrameBitmap
        //{
        //    get { return (Bitmap)_frameBitmap.Clone(); }
        //    private set
        //    {
        //        _frameBitmap = value;
        //        OnFrameChanged();
        //    }
        //}

        public Mat FrameMat { get; }

        public Image<Bgr, byte> FrameImage
        {
            get { return _frameImage; }
            set
            {
                _frameImage = value;
                OnFrameChanged();
            }
        }

        #endregion

        #region /// КОНСТРУКТОРЫ

        public EmguCv()
        {
            FrameMat = new Mat();
            _faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");
            _eyeCascade = new CascadeClassifier("haarcascade_eye.xml");
        }

        ~EmguCv()
        {
            DisposeAll();
        }

        public void DisposeAll()
        {
            FrameMat?.Dispose();
            _capture?.Stop();
            _capture?.Dispose();
            GC.Collect();
        }

        #endregion

        #region /// МЕТОДЫ ИНИЦИАЛИЗАЦИИ

        /// <summary>
        /// Устанавливает параметры камеры. Обязателен к запуску. Возвращает True если успешно
        /// Возвращает False если ошибка либо если камеры не найдено
        /// </summary>
        /// <param name="cameraId"></param>
        /// <returns></returns>
        public bool TryInitCamera(int cameraId)
        {
            var result = false;
            try
            {
                if (_capture == null)
                {
                    _capture = new VideoCapture(cameraId);

                    _capture.SetCaptureProperty(CapProp.FrameWidth, 1024);
                    _capture.SetCaptureProperty(CapProp.FrameHeight, 768);
                    _capture.FlipHorizontal = true;
                    _capture.ImageGrabbed += ProcessFrame;
                }
                result = true;
            }
            catch
            {
                _capture?.Stop();
                _capture?.Dispose();
                _capture = null;
            }

            return result;
        }

        /// <summary>
        /// Запускает процесс постоянной сьемки. Генерируются события при получении каждого кадра.
        /// Новый кадр изображения будет добавлен в FrameBitmap. При этом будет событие FrameChanged
        /// </summary>
        public void StartCapturing()
        {
            if (_capture == null) return;
            if (!_capture.IsOpened) return;

            try
            {
                _capture?.Start();
            }
            catch (Exception ex)
            {
                _capture?.Dispose();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Вызывается когда получен новый фрейм с камеры. Копирует изображение в FrameBitmap.
        /// Так же копирует маленькое изображение в _smallFrame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero && _capture.IsOpened)
            {
                _capture.Retrieve(FrameMat, 0);
                FrameImage = FrameMat.ToImage<Bgr, Byte>();
            }
        }

        #endregion

        #region /// МЕТОДЫ ОБРАБОТКИ ИЗОБРАЖЕНИЙ

        /// <summary>
        /// Возвращает Изображение с Выделенными лицами, если лица найдены. Иначе просто изображение
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="showEye"></param>
        /// <returns></returns>
        public Bitmap GetImageWithFaces(Mat frame, bool showEye, bool drawRect, bool reduceSizeImg)
        {
            Image<Bgr, Byte> image = null;
            try
            {
                image = FaceDetection(frame, showEye, drawRect, reduceSizeImg);
            }
            catch (Exception e)
            {
                image = new Image<Bgr, byte>(1, 1);
                MessageBox.Show(@"Ошибка поиска лица 1");
            }
            return image.ToBitmap();
        }

        public Image<Bgr, byte> FaceDetection(Mat frame, bool showEye, bool drawRect, bool reduceSizeImg)
        {
            //Load the image
            Image<Bgr, Byte> image = reduceSizeImg ? frame.ToImage<Bgr, Byte>().Resize(400, 200, Inter.Linear) : frame.ToImage<Bgr, Byte>();

            var imgResult = FaceDetection(image, showEye, drawRect, reduceSizeImg);

            return imgResult;
        }

        private Image<Bgr, byte> FaceDetection(Image<Bgr, Byte> imageInput, bool showEye, bool drawRect, bool reduceSizeImg)
        {
            Image<Bgr, Byte> image = imageInput;

            //The input image of Cascadeclassifier must be grayscale
            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            //Use List to store faces and eyes
            var facesList = GetFaces(grayImage);
            var eyesList = showEye ? GetEyesList(facesList, grayImage) : new List<Rectangle>();

            if (drawRect)
            {
                DrawRectangleOnImage(facesList, ref image, Color.Red);
                DrawRectangleOnImage(eyesList, ref image, Color.Blue);
            }
            GC.Collect();
            //Show image
            return image;
        }

        private void DrawRectangleOnImage(List<Rectangle> listRectangles, ref Image<Bgr, byte> image, Color colr)
        {
            //Draw detected area
            foreach (Rectangle face1 in listRectangles)
                image.Draw(face1, new Bgr(colr), 2);
        }

        public List<Rectangle> GetFaces(Image<Gray, byte> grayImage)
        {
            //Face detection
            var facesDetectedList = _faceCascade.DetectMultiScale(
                grayImage, //image
                1.1, //scaleFactor
                10, //minNeighbors
                new Size(20, 20), //minSize
                Size.Empty); //maxSize
            GC.Collect();
            return facesDetectedList.ToList<Rectangle>();
        }

        private List<Rectangle> GetEyesList(List<Rectangle> facesDetected, Image<Gray, byte> gray)
        {
            var eyesList = new List<Rectangle>();
            //Eyes detection
            foreach (Rectangle f in facesDetected)
            {
                gray.ROI = f;
                Rectangle[] eyesDetected = _eyeCascade.DetectMultiScale(
                    gray,
                    1.1,
                    10,
                    new Size(20, 20),
                    Size.Empty);
                gray.ROI = Rectangle.Empty;
                foreach (Rectangle ey in eyesDetected)
                {
                    Rectangle eyeRect = ey;
                    eyeRect.Offset(f.X, f.Y);
                    eyesList.Add(eyeRect);
                }
            }
            GC.Collect();
            return eyesList;
        }

        #endregion
    }
}
///// <summary> СПИСОК КАМЕР. НЕ ТЕСТИРОВАНО
///// Возвращает список камер,доступных в системе. Индекс- Имя
///// </summary>
///// <returns></returns>
//public List<KeyValuePair<int, string>> GetCamersList()
//{
//    CvInvoke.UseOpenCL = false;
//    var sysCams = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

//    var camList = sysCams.Select((camera, camIndex) => new KeyValuePair<int, string>(camIndex, camera.Name)).ToList();
//    return camList;
//}

/*
 private Image<Bgr, byte> FaceDetection(Mat frame)
        {
            //Load the image
            Image<Bgr, Byte> image = frame.ToImage<Bgr, Byte>();

            //Use List to store faces and eyes
            var faces = new List<System.Drawing.Rectangle>();
            var eyes = new List<Rectangle>();
            //Pre-trained cascade
            var face = new CascadeClassifier("haarcascade_frontalface_default.xml");
            var eye = new CascadeClassifier("haarcascade_eye.xml");
            //The input image of Cascadeclassifier must be grayscale
            Image<Gray, Byte> gray = image.Convert<Gray, Byte>();
            //Face detection
            var facesDetected = face.DetectMultiScale(
                gray, //image
                1.1, //scaleFactor
                10, //minNeighbors
                new Size(20, 20), //minSize
                Size.Empty); //maxSize
            faces.AddRange(facesDetected);
            //Eyes detection
            foreach (Rectangle f in facesDetected)
            {
                gray.ROI = f;
                Rectangle[] eyesDetected = eye.DetectMultiScale(
                    gray,
                    1.1,
                    10,
                    new Size(20, 20),
                    Size.Empty);
                gray.ROI = Rectangle.Empty;
                foreach (Rectangle ey in eyesDetected)
                {
                    Rectangle eyeRect = ey;
                    eyeRect.Offset(f.X, f.Y);
                    eyes.Add(eyeRect);
                }
            }

            //Draw detected area
            foreach (Rectangle face1 in faces)
                image.Draw(face1, new Bgr(Color.Red), 2);
            foreach (Rectangle eye1 in eyes)
                image.Draw(eye1, new Bgr(Color.Blue), 2);

            GC.Collect();
            //Show image
            return image;
        }



 */
