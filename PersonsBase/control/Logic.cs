using PersonsBase.View;
using System;
using System.Collections.Generic;

namespace PBase
{
    [Serializable]
    public class Logic
    {
        private Options _options;
        private DataBaseClass _dataBase;
        private SortedList<string, Person> _collection;

        public Logic(Options opt, DataBaseClass dataB)
        {
            _options = opt;
            _dataBase = dataB;
            _collection = _dataBase.GetListPersons();
        }

        #region /// МЕТОДЫ ///
        
        /// <summary>
        /// Запрос Пароля Суперпользователя если необходимо. Запускает событие LockChangedEvent. 
        /// </summary>
        public void AccessRoot()
        {
            FormsRunner.RunPasswordForm();
        }

        #endregion
    }
}
