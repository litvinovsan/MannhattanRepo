using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.MyControllers
{
    // FIXME ПОменять имена файлов на те что  в ОПЦИЯХ
    public class PersonsController : SaverBase
    {
        const string FName = "Persons";
        #region Синглтон
        [NonSerialized]
        private static PersonsController _instance;  //Singleton.

        public static PersonsController GetInstance()
        {
            return _instance ?? (_instance = new PersonsController());
        }
        #endregion

        #region Поля
        public SortedList<string, Person> Persons { get; set; }
        private static int IdCounter { get; set; }
        #endregion

        #region Конструктор

        private PersonsController()
        {
            Persons = new SortedList<string, Person>();
        }

        #endregion

        #region Сохранение Загрузка

        public void Save()
        {
            //  сохраняем весь персонал
            if (Persons != null && Persons.Count != 0)
                Save(Persons, GetPath(FName));
        }

        public void Load()
        {
            // List of Emploeers
            var filename = GetPath(FName);
            if (MyFile.IsFileExist(filename))
                Persons = Load<SortedList<string, Person>>(filename);
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

            // База Клиентов
            var dataBaseList = new SortedList<string, Person>(StringComparer.OrdinalIgnoreCase);
            SerializeClass.DeSerialize(ref dataBaseList, currentPath + Options.PersonsDbFile);

            int id = 0;
            var abonCntrl = AbonementController.GetInstance();
            foreach (var item in dataBaseList)
            {
                var itmVal = item.Value;
                Persons.Add(item.Key, new Person(itmVal.Name)
                {
                    Id = ++id,
                    Phone = itmVal.Phone,
                    AbonementCurent = abonCntrl.GetFirstValid(itmVal.Name),
                    BirthDate = itmVal.BirthDate,
                    DriverIdNum = itmVal.DriverIdNum,
                    GenderType = itmVal.GenderType,
                    IdString = itmVal.IdString,
                    Passport = itmVal.Passport,
                    PathToPhoto = itmVal.PathToPhoto,
                    SpecialNotes = itmVal.SpecialNotes,
                    Status = itmVal.Status
                });
            }

            IdCounter = ++id;
            Save();
        }
        #endregion
    }
}
