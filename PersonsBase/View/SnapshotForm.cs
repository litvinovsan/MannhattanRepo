using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.VideoStab;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu.CV.Util;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class SnapshotForm : Form
    {
        private readonly EmguCv _myCv;
        private Image _capturedPersonImg;
        public SnapshotForm()
        {
            InitializeComponent();
            _myCv = new EmguCv();
            _capturedPersonImg = null;
        }

        // Форма загрузилась
        private void SnapshotForm_Shown(object sender, EventArgs e)
        {
            if (!_myCv.TryInitCamera(0))
            {
                MessageBox.Show(@"Ошибка камеры. Попробуйте переподключить камеру");
                return;
            };

            _myCv.StartCapturing();
            _myCv.FrameChanged += delegate
            {
                pictureBox_Original.Image = _myCv.GetImageWithFaces(_myCv.FrameMat, false, true, true);
            };
            button_TakePicture.Enabled = true;
            button_Ok.Enabled = true;
        }

        /// <summary>
        /// Главный метод. Вызывается после закрытия формы. Возвращает сделанный снимок. Или возвращает null
        ///
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {
            return _capturedPersonImg;
        }

        private void button_TakePicture_Click(object sender, EventArgs e)
        {
            var finalCvObject = new EmguCv();
            try
            {
                var facesList = finalCvObject.GetFaces(_myCv.FrameImage.Convert<Gray, Byte>());
                if (facesList.Count > 1)
                {
                    MessageBox.Show(@"В кадре несколько лиц!");
                    return;
                }

                var imgFaces = _myCv.FrameImage;
                

                _capturedPersonImg = (Bitmap)imgFaces.ToBitmap();
                pictureBox_Final.Image = (Bitmap)_capturedPersonImg.Clone();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Ошибка сохранения2");

            }
            finally
            {
                finalCvObject.DisposeAll();
                GC.Collect();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SnapshotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _myCv.DisposeAll();
            GC.Collect();
        }
    }
}
