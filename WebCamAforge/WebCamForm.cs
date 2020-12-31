using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace WebCamAforge
{
    public partial class WebCamForm : Form
    {
        #region /// СОБЫТИЯ ///
        
        /// <summary>
        /// Событие при изменении текущей камеры
        /// </summary>
        [field: NonSerialized]
        public event EventHandler CameraChanged;

        private void OnCameraChanged()
        {
            CameraChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region /// ПОЛЯ

        private readonly AforgeWraper _aforgeWraper;
        private VideoCaptureDevice _currentCamera;

        public VideoCaptureDevice CurrentCamera
        {
            get { return _currentCamera; }
            set
            {
                _currentCamera = value;
                OnCameraChanged();
            }
        }

        #endregion


        #region /// КОНСТРУКТОР

        public WebCamForm(AforgeWraper aforgeWraper)
        {
            if (aforgeWraper == null)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            InitializeComponent();

            _aforgeWraper = aforgeWraper;
            _currentCamera = _aforgeWraper.GetCurrentWebCam();

            try
            {
                // Список Камер
                InitializeCamListComboBox();

                // Выбор доступных разрешений для камеры по умолчанию
                InitializeResolutionsComboBox();

                // Выводим изображение когда получен снимок
                _aforgeWraper.ImageRecieved += Update_PictureBox;


            }
            catch (Exception)
            {

                throw;
            }
        }



        #endregion

        #region /// ОБРАБОТЧИКИ

        private void Camera_Changed(object sender, EventArgs e)
        {
            var curentMoniker = _aforgeWraper.GetCurrentWebCam().Source;

            var selectedIndex = comboBox_CamList.SelectedIndex;
            // Если не выбрано ничего - выходим
            if (selectedIndex == -1 || comboBox_CamList.Items.Count == 0) return;

            try
            {
                // Проверяем, изменилась ли выбранная камера
                string selectedMoniker = (comboBox_CamList.SelectedItem as FilterInfo)?.MonikerString;
                if (curentMoniker.Equals(selectedMoniker)) return;

                _aforgeWraper.StopVideo();
                _aforgeWraper.TryInitCamera(selectedMoniker);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Ошибка смены веб камеры");
                throw;
            }
        }

        private void WebCamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Вы точно хотите выйти из окна работы с камерой?", @"?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                this.DialogResult = DialogResult.No;
                return;
            }

            _aforgeWraper.ImageRecieved -= Update_PictureBox;
            comboBox_CamList.SelectedIndexChanged -= Camera_Changed;
        }

        private void button_save_picture_Click(object sender, EventArgs e)
        {
            //pictureBox_img.Image.Save("c:\\image\\image1.jpg");
            var vCap = _aforgeWraper.GetCurrentWebCam().VideoCapabilities;
            var vR = _aforgeWraper.GetCurrentWebCam().VideoResolution;

            var resolutionList = vCap.Select(x => x.FrameSize).ToList();
            comboBox_Resolution.DataSource = resolutionList;
            comboBox_Resolution.DisplayMember = "FrameSize";
            _aforgeWraper.GetCurrentWebCam().VideoResolution = vCap[6];
            //= vCap[3].FrameSize;


            _aforgeWraper.GetCurrentWebCam()
                .SetCameraProperty(CameraControlProperty.Exposure, 70, CameraControlFlags.Auto);
        }



        private void comboBox_Resolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = comboBox_Resolution.SelectedIndex;
            // Если не выбрано ничего - выходим
            if (selectedIndex == -1 || comboBox_Resolution.Items.Count == 0) return;




        }
        private void Update_PictureBox(object sender, EventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (_aforgeWraper != null && pictureBox_img != null)
                        pictureBox_img.Image = _aforgeWraper.CameraBitmap;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        #endregion

        #region МЕТОДЫ

        /// <summary>
        /// Обновляет комбо бокс со список камер в системе
        /// </summary>
        private void InitializeCamListComboBox()
        {
            comboBox_CamList.DataSource = _aforgeWraper.GetListOfCams();
            comboBox_CamList.DisplayMember = "Name";
            comboBox_CamList.ValueMember = "MonikerString";
            comboBox_CamList.SelectedIndexChanged -= Camera_Changed;
            comboBox_CamList.SelectedIndexChanged += Camera_Changed;
        }

        private void InitializeResolutionsComboBox()
        {
            comboBox_Resolution.DataSource = _aforgeWraper.GetCamResolutions();
            comboBox_Resolution.DisplayMember = "Size";
            comboBox_Resolution.ValueMember = "VideoCapabilities";
        }

        


        #endregion

       
    }
}
