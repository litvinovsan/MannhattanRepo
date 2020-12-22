using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebCamAforge
{
    public struct CameraItem
    {
        public string CameraName;
        public string Moniker;
    }

    /// <summary>
    /// AFORGE.net нужно подключить в референс библиотеки афордж
    /// </summary>
    public class AforgeClass
    {
        #region /// ПОЛЯ

        private string _monikerString;
        private Bitmap _cameraBitmap;

        public FilterInfoCollection VideoCaptureDevices { get; }
        public VideoCaptureDevice CaptureDevice { get; set; }
        public readonly List<FilterInfo> DevicesList = new List<FilterInfo>();

        public Bitmap CameraBitmap
        {
            get
            {
                return (Bitmap)_cameraBitmap.Clone();
            }
            private set
            {
                _cameraBitmap = value;
                OnCameraBitmapChanged();
            }
        }

       

        #endregion

        #region /// СОБЫТИЯ ///
        /// <summary>
        /// Событие при изменении картинки CameraBitmap
        /// </summary>
        [field: NonSerialized]
        public event EventHandler CameraBitmapChanged;

        private void OnCameraBitmapChanged()
        {
            CameraBitmapChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region /// КОНСТРУКТОРЫ 

        public AforgeClass()
        {

            try
            {
                _cameraBitmap = null;
                VideoCaptureDevices = null;

                // Получаем список устройст видео
                VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                // Get All VideoCam Devices
                foreach (FilterInfo device in VideoCaptureDevices)
                {
                    DevicesList.Add(device);
                }

                if (DevicesList.Count == 0) return;

                CaptureDevice = new VideoCaptureDevice(DevicesList.First().MonikerString);

                // Подписываемся на получение нового фрейма 
                CaptureDevice.NewFrame += UpdateCameraBitmap;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка записи видео. " + e.Message + " " + typeof(AforgeClass));
            }

            CaptureDevice.Start();
            //  FinalVideo.Stop();

        }
        #endregion

        #region /// МЕТОДЫ

        /// <summary>
        /// Обработчик, обновляет общедоступную переменную CameraBitmap если получен новый фрейм с камеры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void UpdateCameraBitmap(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                CameraBitmap = (Bitmap)eventArgs.Frame.Clone();
                //  Bitmap video = (Bitmap)eventArgs.Frame.Clone();
                // pictureBox1.Image = video;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " " + typeof(AforgeClass));
            }
        }

        public void CloseVideoSource()
        {
            if (CaptureDevice == null || !CaptureDevice.IsRunning) return;
            CaptureDevice.SignalToStop();
            CaptureDevice = null;
        }

      //  public bool TryStartVideo(string )


        #endregion

    }
}
