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
            _abonementsDictionary = Load<AbonementBasic>();
        }

        /// <summary>
        /// Возвращает список всех абонементов. действующих и закончившихся
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public List<AbonementBasic> GetList(string personName)
        {
            if (!string.IsNullOrEmpty(personName) && _abonementsDictionary != null)
            {
                return _abonementsDictionary[personName];
            }
            return null;
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

        public void AddAbonement(string personName, AbonementBasic abonement)
        {
            if (string.IsNullOrEmpty(personName) || abonement == null) return;

            if (!_abonementsDictionary.ContainsKey(personName))
            {
                _abonementsDictionary.Add(personName, new List<AbonementBasic>());
            }
            _abonementsDictionary[personName].Add(abonement);
        }

        #endregion
    }
}
