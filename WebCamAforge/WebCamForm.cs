using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace WebCamAforge
{
    public partial class WebCamForm : Form
    {
        #region /// СОБЫТИЯ ///

        #endregion

        #region /// ПОЛЯ

        private readonly AforgeWraper _aforgeWraper;
        private Bitmap CurrentBitmap { get; set; }

        #endregion

        #region /// КОНСТРУКТОР

        public WebCamForm(AforgeWraper aforgeWraper)
        {
            if (aforgeWraper == null)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            InitializeComponent();

            _aforgeWraper = aforgeWraper;

            try
            {
                // Получаем Список Камер
                InitCamListComboBox(_aforgeWraper.GetListOfCams());

                // Выводим изображение когда получен снимок
                _aforgeWraper.ImageRecieved += Update_PictureBox;

                // Изменилась текущая камера, обработчик ниже
                // comboBox_CamList.SelectedIndexChanged += Camera_Changed;
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Ошибка 50 WebCamForm /" + e.Message);
            }
        }

        #endregion

        #region /// ОБРАБОТЧИКИ

        private void WebCamForm_Load(object sender, EventArgs e)
        {

        }

        private void WebCamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _aforgeWraper.ImageRecieved -= Update_PictureBox;
            comboBox_CamList.SelectedIndexChanged -= Camera_Changed;
        }

        private void button_save_picture_Click(object sender, EventArgs e)
        {
            CurrentBitmap = _aforgeWraper.GetCurentBitmap();
            pictureBox_Final.Image = (Bitmap)CurrentBitmap.Clone();
        }

        private void Camera_Changed(object sender, EventArgs e)
        {
            var curentMoniker = _aforgeWraper.GetCurrentCamera().Source;

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
                MessageBox.Show(@"Ошибка смены веб камеры" + typeof(WebCamForm));
            }
        }

        private void Update_PictureBox(object sender, EventArgs e)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    if (_aforgeWraper != null && pictureBox_img != null)
                        pictureBox_img.Image = _aforgeWraper.GetCurentBitmap();
                });
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = (CurrentBitmap == null) ? DialogResult.Cancel : DialogResult.OK;
            _aforgeWraper.ImageRecieved -= Update_PictureBox;
            Close();
        }

        #endregion

        #region /// МЕТОДЫ

        /// <summary>
        /// Возвращает копию изображения, выбранного пользователем
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBitmap()
        {
            return (Bitmap)CurrentBitmap?.Clone();
        }

        /// <summary>
        /// Обновляет комбо бокс со список камер в системе
        /// </summary>
        private void InitCamListComboBox(List<FilterInfo> camsList)
        {
            comboBox_CamList.SelectedIndexChanged -= Camera_Changed;
            comboBox_CamList.DataSource = camsList;
            comboBox_CamList.DisplayMember = "Name";
            comboBox_CamList.ValueMember = "MonikerString";
            comboBox_CamList.SelectedIndexChanged += Camera_Changed;
        }

        #endregion
    }
}
