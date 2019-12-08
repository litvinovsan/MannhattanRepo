using System;
using System.IO;
using DocumentFormat.OpenXml.Drawing;

namespace PersonsBase.data
{
    /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
    [Serializable]
    public class Options
    {
        #region/// Синглтон ///////////////////////////
        public static Options GetInstance()
        {
            return _optionsInstance ?? (_optionsInstance = new Options());
        }
        #endregion

        #region///  События ///////////////////////////////////////

        #endregion

        #region/// ОБЬЕКТЫ Приватные ////

        [NonSerialized]
        private static Options _optionsInstance;  //Singleton.

        private static bool _checkPasspDrivEnbld;
        #endregion

        #region /// КОНСТРУКТОР ///////////////////////////
        private Options()
        {
            _checkPasspDrivEnbld = true;
        }
        #endregion

        #region /// МЕТОДЫ ИНИЦИАЛИЗАЦИИ и НАСТРОЙКИ ОПЦИЙ ///

        /// <summary>
        /// Разрешает проверку Пасспорта и Прав при создании нового Клиента. TRUE - Проверка будет производиться
        /// </summary>
        /// <param name="val"></param>
        public static void SetPasspDriveIdCheck(bool val)
        {
            _checkPasspDrivEnbld = val;
        }

        /// <summary>
        /// Возвращает состояние  Разрешена ли проверка паспорта и прав во время Создания клиента. Запрет проверки будет производиться
        /// Автоматически в классе CreatePersonForm
        /// </summary>
        /// <returns></returns>
        public static bool GetPasspDriveCheck()
        {
            return _checkPasspDrivEnbld;
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
