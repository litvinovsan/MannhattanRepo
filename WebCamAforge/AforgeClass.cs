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

        public FilterInfoCollection WebCamDevices { get; }
        public VideoCaptureDevice CaptureDevice { get; set; }

        /// Список вебкамер
        public readonly List<FilterInfo> CamList = new List<FilterInfo>();

        // Итоговое изображение с вебки
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
        public event EventHandler ImageRecieved;

        private void OnCameraBitmapChanged()
        {
            ImageRecieved?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region /// КОНСТРУКТОРЫ 

        /// <summary>
        /// Конструктор когда не известен моникер камеры
        /// </summary>
        public AforgeClass() : this("")
        { }

        /// <summary>
        /// Конструктор. Принимает Моникер строку камеры. Если передать пустую строку или камеры с таким моникером нет, то возьмется первая
        /// по умолчанию камера в системе
        /// </summary>
        /// <param name="monikerString"></param>
        public AforgeClass(string monikerString)
        {
            _monikerString = monikerString ?? string.Empty;

            try
            {
                _cameraBitmap = null;
                WebCamDevices = null;

                // Получаем список устройств видео
                WebCamDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                // Get All VideoCam Devices
                foreach (FilterInfo device in WebCamDevices)
                {
                    CamList.Add(device);
                }

                if (CamList.Count == 0)
                {
                    MessageBox.Show("Веб камера не найдена!");
                    return;
                }

                TryInitCamera(_monikerString);

            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка записи видео. " + e.Message + " " + typeof(AforgeClass));
            }


        }
        #endregion

        #region /// МЕТОДЫ

        #region ПУБЛИЧНЫЕ

        /// <summary>
        /// Закрывает источник видео сигнала с камеры. Удаляет настройки выбранной камеры
        /// </summary>
        public void CloseVideoSource()
        {
            try
            {
                if (CaptureDevice == null || !CaptureDevice.IsRunning) return;
                CaptureDevice.SignalToStop();
                CaptureDevice = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Запуск формы и старт видео
        /// </summary>
        public void StartVideo()
        {
            try
            {
                if (CaptureDevice == null || !CaptureDevice.IsRunning)
                {
                    MessageBox.Show("Камера не инициализирована. Запуск не возможен");
                    return;
                }
                CaptureDevice.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Остановка видео. Закрытие устройства
        /// </summary>
        public void StopVideo()
        {
            try
            {
                if (CaptureDevice == null || !CaptureDevice.IsRunning) return;
                CaptureDevice.Stop();
                CloseVideoSource();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ПРИВАТНЫЕ

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


        /// <summary>
        /// Пробуем инициализировать камеру с заданным моникером. Если не найдена такая камера - используется первая в системе.
        /// </summary>
        /// <param name="moniker"></param>
        /// <returns></returns>
        private bool TryInitCamera(string moniker)
        {
            string camMoniker = string.IsNullOrEmpty(moniker) ? string.Empty : moniker;

            // Пробуем найти такую камеру в устройствах
            var resultCam = CamList?.Find(x => x.MonikerString.Equals(camMoniker));

            _monikerString = (resultCam == null) ? CamList?.First()?.MonikerString : resultCam.MonikerString;

            if (string.IsNullOrEmpty(_monikerString))
            {
                return false;
            }

            CaptureDevice = new VideoCaptureDevice(_monikerString);

            // Подписываемся на получение нового фрейма 
            if (CaptureDevice != null)
                CaptureDevice.NewFrame += UpdateCameraBitmap;

            return true;
        }

        #endregion

        #endregion

    }
}
