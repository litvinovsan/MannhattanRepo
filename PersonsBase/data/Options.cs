using System;
using System.IO;
using DocumentFormat.OpenXml.Drawing;

namespace PersonsBase.data
{
    /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
    [Serializable]
    public class Options
    {
        #region/// ОБЬЕКТЫ Приватные //////////////////////////////

        [NonSerialized]
        private static Options _optionsInstance;  //Singleton.

        #endregion

        #region/// Синглтон ///////////////////////////
        public static Options GetInstance()
        {
            return _optionsInstance ?? (_optionsInstance = new Options());
        }
        #endregion

        #region///  События ///////////////////////////////////////

        #endregion

        #region /// КОНСТРУКТОР ///////////////////////////
        private Options()
        {


        }
        #endregion

        #region/// ИМЕНА ФАЙЛОВ и АДРЕСА ДИРЕКТОРИЙ///

        // Файлы базы данных для сериализации
        public const string PersonsDbFile = "ClientsDataBase.bin";
        public const string TrenersDbFile = "TrenersDataBase.bin";
        public const string AdminsDbFile = "AdminsDataBase.bin";
        public const string AdminCurrFile = "AdminToday.bin";
        public const string GroupSchFile = "GroupSchedule.bin";

        // Сохранение пользовательских фоток
        public const string UserPhotoFolderName = "UsersPhoto";
        public const string DataBaseFolderName = "DataBase";

        #endregion
    }
}
// FIXME сохранять текущую дату. При запуске программы смотреть изменилась ли дата и если да, обнулять/загружать данные в списки на главной страничке
