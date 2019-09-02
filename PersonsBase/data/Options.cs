using PersonsBase.data;
using System;
using System.Collections.Generic;

namespace PBase
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

    }
}
