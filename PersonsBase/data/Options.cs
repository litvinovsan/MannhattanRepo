using System;

namespace PersonsBase.data
{
    /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
    [Serializable]
    public static class Options
    {
        #region/// ОБЬЕКТЫ  ////

        private static bool _checkPasspAndDriveId;
        private static bool _simpsonsPhoto;

        public static bool SimpsonsPhoto
        {
            get { return _simpsonsPhoto; }
            set { _simpsonsPhoto = value; }
        }

        public static bool CheckPasspAndDriveId
        {
            get { return _checkPasspAndDriveId; }
            set
            {
                _checkPasspAndDriveId = value;
            }
        }

        public static void SaveProperties()
        {
            Properties.Settings.Default.SimpsonMode = SimpsonsPhoto;
            Properties.Settings.Default.PassAndDriveIdCheck = CheckPasspAndDriveId;

            Properties.Settings.Default.Save();
        }

        public static void LoadProperties()
        {
            Properties.Settings.Default.Reload();

            SimpsonsPhoto = Properties.Settings.Default.SimpsonMode;
            CheckPasspAndDriveId = Properties.Settings.Default.PassAndDriveIdCheck;
        }

        #endregion

        #region/// ИМЕНА ФАЙЛОВ и АДРЕСА ДИРЕКТОРИЙ///

        // Файлы базы данных для сериализации
        public const string PersonsDbFile = "ClientsDataBase.bin";
        public const string TrenersDbFile = "TrenersDataBase.bin";
        public const string AdminsDbFile = "AdminsDataBase.bin";
        public const string AdminCurrFile = "AdminToday.bin";
        public const string GroupSchFile = "GroupSchedule.bin";

        // Названия ПАПОК
        public const string FolderNameUserPhoto = "UsersPhoto";
        public const string FolderNameDataBase = "DataBase";
        public const string FolderNameStdPhoto = "StandartPhotos";


        #endregion

        #region /// Разные текстовые и около того данные
        // Число тренировок для покупки
        public static readonly object[] NumAvailTrenToBuy = { "1", "5", "10" };
        public static readonly string CorrectPassword = "1234";

        #endregion


    }
}
// FIXME сохранять текущую дату. При запуске программы смотреть изменилась ли дата и если да, обнулять/загружать данные в списки на главной страничке
