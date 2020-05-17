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
        private static bool _faceDetectorEn;
        private static bool _correctableAbonOnCreate;

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

        public static bool CorrectableAbonOnCreate
        {
            get { return _correctableAbonOnCreate; }
            set
            {
                _correctableAbonOnCreate = value;
            }
        }

        public static bool FaceDetectorEn
        {
            get { return _faceDetectorEn; }
            set { _faceDetectorEn = value; }
        }

        public static void SaveProperties()
        {
            Properties.Settings.Default.SimpsonMode = SimpsonsPhoto;
            Properties.Settings.Default.PassAndDriveIdCheck = CheckPasspAndDriveId;
            Properties.Settings.Default.curentDate = DateTime.Now.Date.ToString("MM/dd/yyyy");
            Properties.Settings.Default.SimpsonMode = CorrectableAbonOnCreate;
            Properties.Settings.Default.FaceDetect = FaceDetectorEn;


            Properties.Settings.Default.Save();
        }

        public static void LoadProperties()
        {
            Properties.Settings.Default.Reload();

            SimpsonsPhoto = Properties.Settings.Default.SimpsonMode;
            FaceDetectorEn = Properties.Settings.Default.FaceDetect;
            CorrectableAbonOnCreate = Properties.Settings.Default.AbonCorrectable;
            CheckPasspAndDriveId = Properties.Settings.Default.PassAndDriveIdCheck;
        }

        #endregion

        #region/// ИМЕНА ФАЙЛОВ и АДРЕСА ДИРЕКТОРИЙ///

        // Файлы базы данных для сериализации
        public const string PersonsDbFile = "DataBase_Clients.bin";
        public const string PersonVisitsDbFile = "DataBase_Clients_Visits.bin";
        public const string PersonAbonHistDbFile = "DataBase_Abonement_History.bin";
        public const string TrenersDbFile = "DataBase_Treners.bin";
        public const string AdminsDbFile = "DataBase_Admins.bin";
        public const string AdminCurrFile = "DataBase_AdminToday.bin";
        public const string GroupSchFile = "GroupSchedule.bin";

        public const string DailyVisitAerobFile = "DailyVisits_Aerobic.bin";
        public const string DailyVisitPersonalsFile = "DailyVisits_Personal.bin";
        public const string DailyVisitGymFile = "DailyVisits_Gym.bin";
        public const string DailyMiniGroupFile = "DailyVisits_MiniGroup.bin";


        // Названия ПАПОК
        public const string FolderNameUserPhoto = "UsersPhoto";
        public const string FolderNameDataBase = "DataBase";
        public const string FolderNameStdPhoto = "StandartPhotos";
        public const string FolderNameExcel = "Excel";


        #endregion

        #region /// Разные текстовые и около того данные
        // Число тренировок для покупки
        public static readonly object[] NumAvailTrenToBuy = { "1", "5", "8", "10" };
        public static readonly object[] NumAvailMiniGroup = { "8" };
        public const int ValidPeriod3Month = 3;// нужны для расчета даты окончания абонемента. Срок годности абонемента 2 месяца
        public const int ValidPeriod12Month = 12;// нужны для расчета даты окончания абонемента. Срок годности абонемента 12 месяца


        public const string CorrectPassword = "1234";

        #endregion


    }
}
