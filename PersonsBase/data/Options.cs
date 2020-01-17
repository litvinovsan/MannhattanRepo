using System;

namespace PersonsBase.data
{
    /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
    [Serializable]
    public class Options
    {
        #region/// Синглтон /////
        public static Options GetInstance()
        {
            return _optionsInstance ?? (_optionsInstance = new Options());
        }
        #endregion

        #region/// ОБЬЕКТЫ Приватные ////

        [NonSerialized]
        private static Options _optionsInstance;  //Singleton.

        private bool _checkPasspDrivEnbld;
        private bool _simpsonsPhotoAllowed;
        #endregion

        #region /// КОНСТРУКТОР ////
        private Options()
        {
          //  _checkPasspDrivEnbld = true;
          //  _simpsonsPhotoAllowed = true;
        }
        #endregion

        #region /// МЕТОДЫ ИНИЦИАЛИЗАЦИИ и НАСТРОЙКИ ОПЦИЙ ///

        /// <summary>
        /// Разрешает проверку Пасспорта и Прав при создании нового Клиента. TRUE - Проверка будет производиться
        /// </summary>
        /// <param name="val"></param>
        public void SetPasspDriveIdCheck(bool val)
        {
            _checkPasspDrivEnbld = val;
        }

        /// <summary>
        /// Возвращает состояние  Разрешена ли проверка паспорта и прав во время Создания клиента. Запрет проверки будет производиться
        /// Автоматически в классе CreatePersonForm
        /// </summary>
        /// <returns></returns>
        public bool GetPasspDriveCheck()
        {
            return _checkPasspDrivEnbld;
        }

        /// <summary>
        /// Разрешает рандомное присвоение фоток из Симпсонов если не выбрана Настоящая фотография
        /// при создании нового Клиента. TRUE - Симсон фото будет присвоено.
        /// </summary>
        /// <param name="val"></param>
        public void SetSimpsonState(bool val)
        {
            _simpsonsPhotoAllowed = val;
        }
        /// <summary>
        /// Статус рандомного присвоение фоток из Симпсонов если не выбрана Настоящая фотография
        /// при создании нового Клиента. TRUE - Симсон фото будет присвоено.
        /// </summary>
        public bool GetSimpsonState()
        {
            return _simpsonsPhotoAllowed;
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
        public readonly object[] NumAvailTrenToBuy = { "1", "5", "10" };
        public static readonly string CorrectPassword = "1234";

        #endregion
    }
}
// FIXME сохранять текущую дату. При запуске программы смотреть изменилась ли дата и если да, обнулять/загружать данные в списки на главной страничке
