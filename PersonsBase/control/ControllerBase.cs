using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.data.Abonements;

namespace PersonsBase.control
{

    public abstract class ControllerBase
    {
        private readonly IDataSaver _manager = new SerializableSaver();
        protected void Save<T>(Dictionary<string, List<T>> item) where T : class
        {
            if (item != null) _manager.Save<T>(item);
            else MessageBox.Show(@"Коллекция абонементов пустая");
        }

        /// <summary>
        ///  Загружает Словарь,где ключ - имя клиента,а значение - коллекция
        /// </summary>
        /// <typeparam name="T">Класс для обобщенной коллекции List</typeparam>
        /// <returns></returns>
        protected Dictionary<string, List<T>> Load<T>() where T : class
        {
            return _manager.Load<T>();
        }
    }
}
