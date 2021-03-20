using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.data;

namespace PersonsBase.MyControllers
{
    public abstract class SaverBase
    {
        private readonly ISaver _saveManager = new SaverJSon();

        protected void Save<T>(T obj, string fileName)
        {
            _saveManager.Save<T>(obj, fileName);
        }

        protected T Load<T>(string fileName)
        {
            try
            {
                return _saveManager.Load<T>(fileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, typeof(T).FullName);
                throw;
            }
        }

        /// <summary>
        /// Возвращает строку с полным путём до папки сохранения из Опций. Указывается имя файла без расширения и пути
        /// </summary>
        /// <param name="filename">Имя файла без расширения</param>
        /// <returns></returns>
        public string GetPath(string filename)
        {
            StringBuilder currentPath = new StringBuilder(Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase + "\\");
            currentPath.Append(filename);
            currentPath.Append(_saveManager.FileExtension);
            return currentPath.ToString();
        }

        /// <summary>
        ///  Возвращает строку с полным путём до папки сохранения из Опций
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extension">Без точки, например "json" или "bin" </param>
        /// <returns></returns>
        public static string GetPath<T>(string extension) where T : class
        {
            StringBuilder currentPath = new StringBuilder(Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase + "\\");
            currentPath.Append(typeof(T).Name);
            currentPath.Append(".");
            currentPath.Append(extension);
            return currentPath.ToString();
        }
    }
}
