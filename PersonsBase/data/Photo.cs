using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PersonsBase.myStd;
using System;
using System.Collections.Generic;

namespace PersonsBase.data
{
    public class Photo
    {
        // Конструктор
        public Photo()
        {
            MyFile.CreateFolder(Options.FolderNameUserPhoto);
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

        /// <summary>
        /// Cохраняет копию изображения в папку с Клиентскими фотографиями. Возвращает путь до новой фотки
        /// </summary>
        /// <param name="inputImg"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string SaveToPhotoDir(Image inputImg, string fileName)
        {
            var pth = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameUserPhoto + "\\" + fileName?.Trim() + ".jpg";

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
        private static string GetPathUsersPhotoDir()
        {
            return Directory.GetCurrentDirectory() + "\\" + Options.FolderNameUserPhoto + "\\";
        }
        /// <summary>
        /// Возвращает путь до директории с стандартными симпсон фотографиями клиентов "StandartPhotos\\".
        /// </summary>
        /// <returns></returns>
        private static string GetPathStandartPhotoDir()
        {
            return Directory.GetCurrentDirectory() + "\\" + Options.FolderNameStdPhoto + "\\";
        }

        public static string GetFullPathToPhoto(string photoNameWithExtens)
        {
            var fName = Path.GetFileName(photoNameWithExtens);
            var stdPath = GetPathStandartPhotoDir() + fName;
            var userPhotoPath = GetPathUsersPhotoDir() + fName;

            if (MyFile.IsFileExist(userPhotoPath))
            {
                return userPhotoPath;
            }

            return MyFile.IsFileExist(stdPath) ? stdPath : string.Empty;
        }

        #region /// Генератор случайных фото

        private static readonly List<string> MaleFileNames = new List<string>
        {
            { "Апу Нахасапима.jpg"},
            { "Бёрнс Монтгомери.jpg"},
            {"Гомер Симпсон.jpg" },
            {"Директор Скиннер.jpg" },
            {"Кент Брокман.jpg" },
            {"КлоунКрасти.jpg" },
            {"Садовник Вилли.jpg" },
            {"Симпсон Барт.jpg" },
            {"Симпсон Эйбрахам.jpg" },
            {"Скиннер Сеймур.jpeg" },
            {"Трактирщик Мо.jpg" },
            {"Фландерс Нед.jpg" },
            {"Джаспер Бердли.jpg" },
            {"Ленни Леонард.jpg" },
            {"Джон Сноу.jpg" },
            "Ральф.jpg",
            "Водитель Оттоо.jpg",
            "Обиван.JPG",
            "Повар.jpg",
            "Mer.JPG"
        };
        private static readonly List<string> FeMaleFileNames = new List<string>
        {
            {"АникаВанХуттен.png"},
            {"СельмаБульве.png"},
            {"Симпсон Мардж.jpg" },
            {"Симспон Лиза.jpg" },
            {"Эдна Крабапл.jpg" },
            {"КлоунКрасти.jpg" },
            {"Терри Макльберри.jpg" },
            {"Элизабет Гувер.jpg" },
            {"Симспон Лиза язык.jpg" },
            {"Дженни.png" },
            {"Красная Дама.jpg" },
            {"Леди.jpg" },
            "Леди2.jpg",
            "Леди3.jpg",
            "Леди4.jpg",
            "Леди5.jpg",
            "Леди6.jpg",
            "Леди7.jpg",
            "МатьДраконов.JPG"

        };
        /// <summary>
        /// Возвращает имя Симпсон фотки. Выбирает рандомно в зависимости от Пола и Возраста
        /// В базу дальше сохранится только имя. Путь подстраивается автоматически. Поиск совпадения в станд папке с фотками.
        /// 
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static string GetRndPhoto(Gender gender)
        {
            var random = new Random(DateTime.Now.Millisecond);

            var name = "";
            try
            {
                switch (gender)
                {
                    case Gender.Мужской:
                        {
                            var index = random.Next(1, MaleFileNames.Count);
                            name = MaleFileNames[index];
                            break;
                        }
                    case Gender.Женский:
                        {
                            var index = random.Next(1, FeMaleFileNames.Count);
                            name = FeMaleFileNames[index];
                            break;
                        }
                    default:
                        {
                            var index = random.Next(1, MaleFileNames.Count);
                            name = MaleFileNames[index];
                            break;
                        }

                }
            }
            catch (Exception)
            {
                // ignored
            }

            var simpsonFileName = name;

            return simpsonFileName;
        }
        #endregion

    }
}
