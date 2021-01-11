using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebCamAforge
{
    /// <summary>
    /// AFORGE.net нужно подключить в референс библиотеки афордж.
    /// 1. Запуск конструктора.
    /// 2. Проверить IsCameraConfigured == true
    /// 3. Запуск формы с видеопотоком StartVideo()
    /// 4. Готовое изображение из метода GetBitmap
    /// 5. Настройки
    /// </summary>
    public class AforgeWraper
    {
        #region /// ПОЛЯ

        private string _monikerString;
        private Bitmap _cameraBitmap;
        private WebCamForm _webCamForm;

        private FilterInfoCollection WebCamDevices { get; }
        private VideoCaptureDevice CaptureDevice { get; set; }

        /// Список вебкамер
        private readonly List<FilterInfo> _camList = new List<FilterInfo>();

        // Каждый апдейт с камеры сохраняется тут. 
        private Bitmap CameraFrame
        {
            get
            {
                return (Bitmap)_cameraBitmap?.Clone();
            }
            set
            {
                _cameraBitmap = value;
                OnCameraBitmapChanged();
            }
        }

        public bool IsCameraConfigured { get; private set; }

        #endregion

        #region /// СОБЫТИЯ ///
        /// <summary>
        /// Событие при изменении картинки CameraFrame
        /// </summary>
        [field: NonSerialized]
        public event EventHandler ImageRecieved;

        private void OnCameraBitmapChanged()
        {
            ImageRecieved?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region /// КОНСТРУКТОРЫ 

        /// <inheritdoc />
        /// <summary>
        /// Конструктор когда не известен моникер камеры
        /// </summary>
        public AforgeWraper() : this("")
        { }

        /// <summary>
        /// Конструктор. Принимает Моникер строку камеры. Если передать пустую строку или камеры с таким моникером нет, то возьмется первая
        /// по умолчанию камера в системе
        /// </summary>
        /// <param name="monikerString"></param>
        public AforgeWraper(string monikerString)
        {
            _monikerString = monikerString ?? string.Empty;
            IsCameraConfigured = false;

            try
            {
                _cameraBitmap = null;
                WebCamDevices = null;

                // Получаем список устройств видео
                WebCamDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                // Get All VideoCam Devices
                foreach (FilterInfo device in WebCamDevices)
                {
                    _camList.Add(device);
                }

                if (_camList.Count == 0)
                {
                    MessageBox.Show(@"Веб камера не найдена!");
                    IsCameraConfigured = false;
                    return;
                }

                TryInitCamera(_monikerString);

            }
            catch (Exception e)
            {
                MessageBox.Show(@"Ошибка камеры. " + e.Message + @"line 109 " + typeof(AforgeWraper));
            }
        }
        #endregion

        #region /// МЕТОДЫ

        #region ПУБЛИЧНЫЕ

        /// <summary>
        /// Главный метод класса
        /// Запуск формы получения картинки с камеры.
        /// Возвращает true если снимок сделан и сохранен
        /// </summary>
        public bool StartVideo()
        {
            if (CaptureDevice == null || !IsCameraConfigured)
            {
                MessageBox.Show(@"Камера не инициализирована. Запуск не возможен");
                return false;
            }

            if (!CaptureDevice.IsRunning)
                CaptureDevice.Start();

            _webCamForm = new WebCamForm(this);
            var dlgResult = _webCamForm.ShowDialog();
            var result = dlgResult == DialogResult.OK;

            StopVideo();

            // Получаем выбранное изображение с формы
            if (result)
            {
                CameraFrame = _webCamForm.GetBitmap();
            }

            return result;
        }

        /// <summary>
        /// Остановка видео. Закрытие устройства.
        /// </summary>
        public void StopVideo()
        {
            try
            {
                if (CaptureDevice == null /*|| !CaptureDevice.IsRunning*/) return;
                CaptureDevice.NewFrame -= ImageRecievedUpdater;
                CaptureDevice.SignalToStop();

                // CaptureDevice = null;
                IsCameraConfigured = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + @" line 165" + typeof(AforgeWraper).ToString());
            }
        }

        /// <summary>
        /// Возвращает список Веб Камер в системе. Каждый элемент содержит имя камеры и Моникер
        /// </summary>
        /// <returns></returns>
        public List<FilterInfo> GetListOfCams()
        {
            return _camList;
        }

        /// <summary>
        /// Возвращает ссылку на активную сконфигурированную камеру в классе 
        /// </summary>
        /// <returns></returns>
        public VideoCaptureDevice GetCurrentCamera()
        {
            return CaptureDevice;
        }

        /// <summary>
        /// Возвращает копию картинки с последнего апдейта
        /// </summary>
        /// <returns></returns>
        public Bitmap GetCurentBitmap()
        {
            return CameraFrame;
        }

        /// <summary>
        /// Пробуем инициализировать камеру с заданным моникером. Если не найдена такая камера - используется первая в системе.
        /// </summary>
        /// <param name="moniker"></param>
        /// <returns></returns>
        public bool TryInitCamera(string moniker)
        {
            var camMoniker = string.IsNullOrEmpty(moniker) ? string.Empty : moniker;

            IsCameraConfigured = false;

            try
            {
                // Пробуем найти такую камеру в устройствах
                var resultCam = _camList?.Find(x => x.MonikerString.Equals(camMoniker));

                _monikerString = (resultCam == null) ? _camList?.FirstOrDefault()?.MonikerString : resultCam.MonikerString;

                if (string.IsNullOrEmpty(_monikerString))
                {
                    return false;
                }

                CaptureDevice = new VideoCaptureDevice(_monikerString);

                // Подписываемся на получение нового фрейма 
                if (CaptureDevice != null)
                {
                    IsCameraConfigured = true;
                    CaptureDevice.NewFrame -= ImageRecievedUpdater;
                    CaptureDevice.NewFrame += ImageRecievedUpdater;

                    if (!CaptureDevice.IsRunning)
                        CaptureDevice.Start();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + @" line 236 " + typeof(AforgeWraper));
            }

            return true;
        }

        /// <summary>
        /// Возвращает коллекцию РазрешениеКамеры - ПараметрыДляУстановкиРазрешения. Подается на вход функции SetResolution
        /// </summary>
        /// <returns></returns>
        public List<VideoCapabilities> GetAvailableResolutions()
        {
            var resolutions = CaptureDevice?.VideoCapabilities?.ToList();
            return resolutions;
        }

        /// <summary>
        /// Устанавливает разрешение для активной камеры
        /// </summary>
        /// <param name="сapabilitiesWithResolution"></param>
        public void SetResolution(VideoCapabilities сapabilitiesWithResolution)
        {
            if (CaptureDevice == null || сapabilitiesWithResolution == null) return;
            try
            {
                CaptureDevice.VideoResolution = сapabilitiesWithResolution;
            }
            catch (Exception e)
            {
                MessageBox.Show(typeof(AforgeWraper) + @"  " + e.Message);
            }
        }


        /// <summary>
        /// Установка экспозиции для текущей камеры
        /// </summary>
        /// <param name="value"></param>
        public void SetExpo(int value)
        {
            int minValue = 0;
            int maxValue = 0;
            CaptureDevice?.GetCameraPropertyRange(CameraControlProperty.Iris, out minValue, out maxValue, out int step, out int defValue, out CameraControlFlags cameraControl);

            if (value >= minValue && value <= maxValue)
                CaptureDevice?.SetCameraProperty(CameraControlProperty.Exposure, value, CameraControlFlags.Manual);
        }


        /// <summary>
        /// Возвращает моникер активной настроенной камеры
        /// </summary>
        /// <returns></returns>
        public string GetCameraMoniker()
        {
            return _monikerString;
        }

        #endregion

        #region ПРИВАТНЫЕ

        /// <summary>
        /// Обработчик, обновляет общедоступную переменную CameraFrame если получен новый фрейм с камеры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void ImageRecievedUpdater(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                CameraFrame = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + @" " + typeof(AforgeWraper));
            }
        }

        #endregion

        #endregion

    }
}
