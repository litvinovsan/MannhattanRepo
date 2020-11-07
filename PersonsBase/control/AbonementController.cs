using System;
using System.Collections.Generic;
using System.Linq;
using PersonsBase.data.Abonements;

namespace PersonsBase.control
{
    [Serializable]
    public class AbonementController : ControllerBase
    {
        #region/// Синглтон ////
        [NonSerialized]
        private static AbonementController _instance;  //Singleton.

        public static AbonementController GetInstance()
        {
            return _instance ?? (_instance = new AbonementController());
        }

        #endregion

        #region /// СОБЫТИЯ ///
        /// <summary>
        /// Изменение основной коллекции с абонементами всех клиентов.
        /// Срабатывает при добавлении, удалении клиентов и их абонементов.
        /// </summary>
        [field: NonSerialized] public event EventHandler CollectionChanged;
        private void OnAbonementsDictChanged()
        {
            CollectionChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region ПОЛЯ и СВОЙСТВА

        private Dictionary<string, List<AbonementBasic>> _abonementsDictionary;

        #endregion

        #region /// КОНСТРУКТОР и ДЕСТРУКТОР Загрузка Сохранение ///
        private AbonementController()
        {
            Load();
        }

        /// <summary>
        /// Сохранения коллекции Пользователь- Список абонементов
        /// </summary>
        public void Save()
        {
            Save(_abonementsDictionary);
        }

        private void Load()
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
        #endregion

        #region /// МЕТОДЫ ///

        /// <summary>
        /// Возвращает ссылку на главный словарь этого класса. Содержит всех пользователей и их списки абонементов
        /// </summary>
        /// <returns></returns>
        public ref Dictionary<string, List<AbonementBasic>> GetPersonsDictn()
        {
            return ref _abonementsDictionary;
        }

        /// <summary>
        /// Возвращает список всех абонементов действующих и закончившихся.
        /// Если Имя не найдено- вернёт null
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public List<AbonementBasic> GetList(string personName)
        {
            if (personName == null) return null;

            if (_abonementsDictionary != null && (!string.IsNullOrEmpty(personName)) && !_abonementsDictionary.ContainsKey(personName))
            {
                _abonementsDictionary.Add(personName, new List<AbonementBasic>());
            }
            return _abonementsDictionary?[personName];
        }

        /// <summary>
        /// Возвращает список абонементов, которые ещё валидны.
        /// Если Действующих абонементов нет или нет абонементов вообще - возвращает
        /// пустую коллекцию c численностью 0.
        ///  </summary>
        /// <param name="personName">Если null вернет null </param>
        /// <returns></returns>
        public List<AbonementBasic> GetListValid(string personName)
        {
            if (string.IsNullOrEmpty(personName)) return null;

            return GetList(personName)?.Where(x => x.IsValid()).ToList();
        }

        /// <summary>
        /// Возвращает список закончившихся абонементов
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public List<AbonementBasic> GetListNotValid(string personName)
        {
            if (string.IsNullOrEmpty(personName)) return null;

            return GetList(personName)?.Where(x => !x.IsValid()).ToList();
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
            OnAbonementsDictChanged();
        }

        /// <summary>
        /// Удаляет для Персоны поданый параметром абонемент
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="abonToDelete"></param>
        public void RemoveAbonement(string personName, AbonementBasic abonToDelete)
        {
            if (string.IsNullOrEmpty(personName) || abonToDelete == null || !_abonementsDictionary.ContainsKey(personName)) return;

            _abonementsDictionary[personName]?.Remove(abonToDelete);
            OnAbonementsDictChanged();
        }

        public void AddNewPerson(string personName)
        {
            if (_abonementsDictionary.ContainsKey(personName)) return;

            _abonementsDictionary.Add(personName, new List<AbonementBasic>());
        }

        /// <summary>
        /// Возвращает абонемент по индексу из коллекции которую сюда передаем в качестве параметра
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public AbonementBasic GetByIndex(List<AbonementBasic> inputList, int index)
        {
            if (inputList == null) throw new ArgumentNullException(nameof(inputList));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (index > inputList.Count) throw new ArgumentOutOfRangeException(nameof(index));

            return inputList[index];
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
            if (string.IsNullOrEmpty(personName) || (inputAbonement == null) || !_abonementsDictionary.ContainsKey(personName))
                return -1;

            var index = _abonementsDictionary[personName].IndexOf(inputAbonement);
            return index;
        }


        #endregion
    }
}
