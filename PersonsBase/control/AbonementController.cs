using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.control
{
    [Serializable]
    public class AbonementController : ControllerBase
    {
        #region/// Синглтон ////
        [NonSerialized]
        private static AbonementController _instance = null;  //Singleton.

        public static AbonementController GetInstance()
        {
            return _instance ?? (_instance = new AbonementController());
        }

        #endregion

        #region ПОЛЯ и СВОЙСТВА

        private Dictionary<string, List<AbonementBasic>> _abonementsDictionary;

        #endregion

        #region КОНСТРУКТОР и ДЕСТРУКТОР
        private AbonementController()
        {
            Load();
        }

        ~AbonementController()
        {
            Save();
        }
        #endregion

        #region МЕТОДЫ

        /// <summary>
        /// Возвращает ссылку на главный словарь этого класса. Содержит всех пользователей и их списки абонементов
        /// </summary>
        /// <returns></returns>
        public ref Dictionary<string, List<AbonementBasic>> GetDictionary()
        {
            return ref _abonementsDictionary;
        }

        /// <summary>
        /// Сохранения коллекции Пользователь- Список абонементов
        /// </summary>
        public void Save()
        {
            Save<AbonementBasic>(_abonementsDictionary);
        }
        public void Load()
        {
            _abonementsDictionary = new Dictionary<string, List<AbonementBasic>>();
            try
            {
                _abonementsDictionary = Load<AbonementBasic>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Возвращает список всех абонементов. действующих и закончившихся
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public List<AbonementBasic> GetList(string personName)
        {
            if (!string.IsNullOrEmpty(personName) && _abonementsDictionary != null && _abonementsDictionary.ContainsKey(personName))
            {
                return _abonementsDictionary[personName];
            }
            return new List<AbonementBasic>();
        }

        /// <summary>
        /// Возвращает список абонементов, которые ещё валидны
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public List<AbonementBasic> GetListValid(string personName)
        {
            return GetList(personName)?.Where(x => x.IsValid()).ToList();
        }

        /// <summary>
        /// Возвращает список закончившихся абонементов
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public List<AbonementBasic> GetListNotValid(string personName)
        {
            var result = GetList(personName).Where(x => !x.IsValid()).ToList();

            return result;
        }

        /// <summary>
        /// Добавляет абонемент к указанному Человеку.
        /// Если человек не существует, то создает его в коллекции
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="abonement"></param>
        public void AddAbonement(string personName, AbonementBasic abonement)
        {
            if (string.IsNullOrEmpty(personName) || abonement == null) return;

            if (!_abonementsDictionary.ContainsKey(personName))
            {
                _abonementsDictionary.Add(personName, new List<AbonementBasic>());
            }
            _abonementsDictionary[personName].Add(abonement);
        }

        /// <summary>
        /// Удаляет для Персоны поданый параметром абонемент
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="abonToDelete"></param>
        public void RemoveAbonement(string personName, AbonementBasic abonToDelete)
        {
            if (string.IsNullOrEmpty(personName) || abonToDelete == null || !_abonementsDictionary.ContainsKey(personName)) return;

            _abonementsDictionary[personName].Remove(abonToDelete);
        }

        /// <summary>
        /// Возвращает абонемент по индексу из коллекции которую сюда передаем в качестве параметра
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="cList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public AbonementBasic GetByIndex(string personName, List<AbonementBasic> cList, int index)
        {
            if (personName == null) throw new ArgumentNullException(nameof(personName));
            if (cList == null) throw new ArgumentNullException(nameof(cList));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            return cList[index];
        }

        /// <summary>
        /// Возвращает индекс абонемента в основной коллекции,где хранятся и старые и новые абонементы.
        /// Возвращает -1 если нет пользователя или такого абонемента не существует.
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="inputAbonement"></param>
        /// <returns></returns>
        public int GetGlobalIndex(string personName, AbonementBasic inputAbonement)
        {
            if (personName == null || (inputAbonement == null) || !_abonementsDictionary.ContainsKey(personName))
                return -1;

            var index = _abonementsDictionary[personName].IndexOf(inputAbonement);
            return index;
        }

        
        #endregion
    }
}
