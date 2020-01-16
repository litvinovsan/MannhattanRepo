using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PersonsBase.myStd;

namespace PersonsBase.data
{
    public class Photo
    {
        // Конструктор
        public Photo()
        {
            MyFile.CreateFolder(Options.UserPhotoFolderName);
        }

        /// <summary>
        /// Открыть файл с диалогом выбора
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static bool OpenPhoto(out Image img)
        {
            var result = false;

            img = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = @"Image Files (*.BMP; *.JPG; *.JPEG; *.GIF; *.PNG)| *.BMP; *.JPG; *.JPEG; *.GIF; *.PNG | All files(*.*) | *.*";

                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var originalFilePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    using (var fs = new FileStream(originalFilePath, FileMode.Open))
                    {
                        img = Image.FromStream(fs);
                        result = true;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Открыть из файла. Используется безопасный стрим.
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <returns></returns>
        public static Image OpenPhoto(string inputFilePath)
        {
            Image img;

            using (var fs = new FileStream(inputFilePath, FileMode.Open))
            {
                img = Image.FromStream(fs);
            }
            return img;
        }

        public static string SaveToPicturesFolder(Image inputImg, string fileName)
        {
            string pth = Directory.GetCurrentDirectory() + "\\" + Options.UserPhotoFolderName + "\\" + fileName?.Trim() + ".jpg";

            if (inputImg == null) return "";
            var bmp = new Bitmap(inputImg);

            if (File.Exists(pth))
            {
                var dlgResult = MessageBox.Show(@"Файл существует! Перезаписать?", @"Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    File.Delete(pth);
                    bmp.Save(pth, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else
            {
                bmp.Save(pth, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            bmp.Dispose();
            return pth;
        }

        /// <summary>
        /// Возвращает путь до директории с фотографиями клиентов "UserPhoto\\". Есть \\
        /// </summary>
        /// <returns></returns>
        public static string GetPathToPhotoDir()
        {
            return Directory.GetCurrentDirectory() + "\\" + Options.UserPhotoFolderName + "\\";
        }
    }
}
