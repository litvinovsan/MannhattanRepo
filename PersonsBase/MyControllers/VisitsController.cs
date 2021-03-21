using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.MyControllers
{
    // FIXME ПОменять имена файлов на те что  в ОПЦИЯХ

    public class VisitsController : SaverBase
    {
        private const string FName = "Visits";
        private const string FNameList = "VisitsList";

        #region Синглтон
        [NonSerialized]
        private static VisitsController _instance;  //Singleton.
        public static VisitsController GetInstance()
        {
            return _instance ?? (_instance = new VisitsController());
        }
        #endregion

        #region Поля

        public Dictionary<string, List<Visit>> Visits { get; set; }
        /// <summary>
        /// Для будущего ЭнтитиФреймворка. Каждая запись визита содержит Id персоны и Id Абонемента
        /// </summary>
        public List<Visit> VisitsList { get; set; }

        private static int _idCounter;
        private static int IdCounter
        {
            get { return ++_idCounter; }
            set { _idCounter = value; }
        }
        #endregion

        #region Конструктор

        private VisitsController()
        {
            Visits = new Dictionary<string, List<Visit>>();
            VisitsList = new List<Visit>();
        }

        #endregion

        #region Сохранение Загрузка

        public void Save()
        {
            if (Visits != null && Visits.Count != 0)
                SaveAsync(Visits, GetPath(FName));

            if (VisitsList != null && VisitsList.Count != 0)
                SaveAsync(VisitsList, GetPath(FNameList));
        }

        public async void Load()
        {
            var filename = GetPath(FName);

            if (MyFile.IsFileExist(filename))
            {
                Visits = await LoadAsync<Dictionary<string, List<Visit>>>(filename);
            }

            filename = GetPath(FNameList);
            if (MyFile.IsFileExist(filename))
            {
                VisitsList = await LoadAsync<List<Visit>>(filename);
                IdCounter = VisitsList.Count;
            }
        }

        #endregion

        #region Методы
        // FIXME Переместить методы сюда по удалению добавлению изменению клиентво
        #endregion

        #region FIXME MIGRATIONS

        // FIXME Удалить когда будет готова вся миграция
        public void StartMigration()
        {
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase + "\\";

            // Журнал посещений клиентов
            var visitsDictionary = DataBaseLevel.GetPersonsVisitDict();

            Visits.Clear();
            VisitsList.Clear();
            IdCounter = 0;
            PersonsController personsController = PersonsController.GetInstance();

            foreach (var item in visitsDictionary)
            {
                foreach (var tmpVisit in item.Value)
                {
                    tmpVisit.Id = IdCounter;
                    tmpVisit.PersonId = personsController.GetId(item.Key);

                    VisitsList.Add(tmpVisit);
                }
                Visits.Add(item.Key, item.Value);
            }
            Save();
        }
        #endregion
    }
}

