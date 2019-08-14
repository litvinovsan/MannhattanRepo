using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{// FIXME Сделать переименование файлов фотографий при переименовании имени

   public class Photo
   {
      private readonly string FolderName = "UsersPhoto";
      private static string PathToPhotoDir;

      // Конструктор
      public Photo()
      {
         CreateFoldert(FolderName);
         PathToPhotoDir = Directory.GetCurrentDirectory() + "\\" + FolderName + "\\";
      }

      // Методы
      public void CreateFoldert(string fldrName)
      {
         if (!Directory.Exists(fldrName)) Directory.CreateDirectory(fldrName);
      }
      /// <summary>
      /// Открыть файл с диалогом выбора
      /// </summary>
      /// <param name="img"></param>
      /// <param name="originalFilePath"></param>
      /// <returns></returns>
      public static bool OpenPhoto(out Image img, out string originalFilePath)
      {
         bool result = false;

         originalFilePath = string.Empty;
         img = null;

         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Image Files (*.BMP; *.JPG; *.JPEG; *.GIF; *.PNG)| *.BMP; *.JPG; *.JPEG; *.GIF; *.PNG | All files(*.*) | *.*";

            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               //Get the path of specified file
               originalFilePath = openFileDialog.FileName;

               //Read the contents of the file into a stream
               using (FileStream fs = new FileStream(originalFilePath, FileMode.Open))
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
         Image img = null;

         using (FileStream fs = new FileStream(inputFilePath, FileMode.Open))
         {
            img = Image.FromStream(fs);
         }
         return img;
         /*
          Image tmp = Image.FromFile(@"C:\pics\logo.png");
          Image CurrentWM = new Bitmap(tmp);
          tmp.Dispose();
          */
      }

      public static string SaveToPicturesFolder(Image inputImg, string fileName)
      {
         string pth = PathToPhotoDir + fileName?.Trim() + ".jpg";
         Bitmap bmp;

         if (inputImg == null) return "";
         else bmp = new Bitmap(inputImg);

         if (File.Exists(pth))
         {
            var dlgResult = MessageBox.Show("Файл существует! Перезаписать?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

      public static bool IsPhotoExist(string fileName)
      {
         return File.Exists(fileName);
      }
   }
}
