using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.MyControllers
{
    // FIXME ПОменять имена файлов на те что  в ОПЦИЯХ
    public class EmploeesController : SaverBase
    {
        const string FName = "Emploees";
        private const string FNameAdmin = "CurrentAdmin";
        #region Синглтон
        [NonSerialized]
        private static EmploeesController _instance;  //Singleton.

        public static EmploeesController GetInstance()
        {
            return _instance ?? (_instance = new EmploeesController());
        }
        #endregion

        #region Поля
        public MyEmploee CurrentAdministrator;
        public Dictionary<string, MyEmploee> Emploees { get; set; }
        private static int IdCounter { get; set; }

        #endregion

        #region Конструктор
        private EmploeesController()
        {
            CurrentAdministrator = null;
            Emploees = new Dictionary<string, MyEmploee>();
        }


        #endregion

        #region Сохранение Загрузка
        public void Save()
        {
            //  сохраняем весь персонал
            if (Emploees != null && Emploees.Count != 0)
                Save(Emploees, GetPath(FName));

            // Сохраняем текущего Админа
            if (CurrentAdministrator != null)
                Save(CurrentAdministrator, GetPath(FNameAdmin));
        }

        public void Load()
        {
            //  Last Admin
            string filename = GetPath(FNameAdmin);
            if (MyFile.IsFileExist(filename))
                CurrentAdministrator = Load<MyEmploee>(filename);

            // List of Emploeers
            filename = GetPath(FName);
            if (MyFile.IsFileExist(filename))
                Emploees = Load<Dictionary<string, MyEmploee>>(filename);
        }
        #endregion

        #region Методы



        #endregion

        #region FIXME MIGRATIONS

        // FIXME Удалить когда будет готова вся миграция
        public void StartMigration()
        {
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase + "\\";

            // База Тренеров
            var trenersList = new List<Trener>();
            SerializeClass.DeSerialize(ref trenersList, currentPath + Options.TrenersDbFile);

            // База Администраторов 
            var adminsList = new List<Administrator>();
            SerializeClass.DeSerialize(ref adminsList, currentPath + Options.AdminsDbFile);

            // Текущий Администратор на Ресепшн
            var adminCurrent = new Administrator();
            SerializeClass.DeSerialize(ref adminCurrent, currentPath + Options.AdminCurrFile);

            int id = 0;

            foreach (var item in trenersList)
            {
                Emploees.Add(item.Name, new MyEmploee(item.Name, EmploeeType.Тренер, item.Phone) { Id = ++id });
            }

            foreach (var item in adminsList)
            {
                Emploees.Add(item.Name, new MyEmploee(item.Name, EmploeeType.Администратор, item.Phone) { Id = ++id });
            }

            Emploees.TryGetValue(adminCurrent.Name, out CurrentAdministrator);
            IdCounter = ++id;
            Save();
        }
        #endregion
    }
}
