using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebCamAforge
{
    /// <summary>
    /// AFORGE.net нужно подключить в референс библиотеки афордж.
    /// 1. Запуск конструктора.
    /// 2. Проверить IsCameraConfigured == true
    /// 3. Запуск формы с видеопотоком StartFormAndGetImage()
    /// 4. Готовое изображение в публичном CameraBitmap
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

        public bool IsCameraConfigured;

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
                MessageBox.Show(@"Ошибка камеры. " + e.Message + @" " + typeof(AforgeWraper));
            }
        }
        #endregion

        #region /// МЕТОДЫ

        #region ПУБЛИЧНЫЕ

        /// <summary>
        /// Запуск формы получения картинки с камеры. Возвращает true если снимок сделан и сохранен в переменную CameraBitmap
        /// </summary>
        public bool StartFormAndGetImage()
        {
            try
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
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Остановка видео. Закрытие устройства.
        /// </summary>
        public void StopVideo()
        {
            try
            {
                if (CaptureDevice == null /*|| !CaptureDevice.IsRunning*/) return;
                CaptureDevice.NewFrame -= UpdateCameraBitmap;
                CaptureDevice.SignalToStop();

                // CaptureDevice = null;
                IsCameraConfigured = false;
            }
            catch (Exception)
            {
                throw;
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
        public VideoCaptureDevice GetCurrentWebCam()
        {
            return CaptureDevice;
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

                CaptureDevice.SetCameraProperty(CameraControlProperty.Exposure, 50, CameraControlFlags.Auto);

                // Подписываемся на получение нового фрейма 
                if (CaptureDevice != null)
                {
                    IsCameraConfigured = true;
                    CaptureDevice.NewFrame -= UpdateCameraBitmap;
                    CaptureDevice.NewFrame += UpdateCameraBitmap;

                    if (!CaptureDevice.IsRunning)
                        CaptureDevice.Start();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// Возвращает коллекцию РазрешениеКамеры - ПараметрыДляУстановкиРазрешения. Подается на вход функции SetResolution
        /// </summary>
        /// <returns></returns>
        public Dictionary<Size, VideoCapabilities> GetCamResolutions()
        {
            var dictionary = new Dictionary<Size, VideoCapabilities>();

            var resolutions = CaptureDevice?.VideoCapabilities?.ToDictionary(x => x.FrameSize, x => x);

            return resolutions;
        }

        /// <summary>
        /// Устанавливает разрешение для активной камеры
        /// </summary>
        /// <param name="camCapabilitiesWithResolution"></param>
        public void SetResolution(VideoCapabilities camCapabilitiesWithResolution)
        {
            if (CaptureDevice == null || camCapabilitiesWithResolution == null) return;
            try
            {
                CaptureDevice.VideoResolution = camCapabilitiesWithResolution;
            }
            catch (Exception e)
            {
                MessageBox.Show(typeof(AforgeWraper) + @"  " + e.Message);
                throw;
            }
        }


        /// <summary>
        /// Установка экспозиции для текущей камеры
        /// </summary>
        /// <param name="value"></param>
        public void SetExpo(int value)
        {
            CaptureDevice?.SetCameraProperty(CameraControlProperty.Exposure, value, CameraControlFlags.Auto);
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
