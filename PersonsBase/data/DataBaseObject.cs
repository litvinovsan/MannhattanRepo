using System;
using System.Collections.Generic;

namespace PBase
{
    public static class DataObjects
    {
        private static readonly DataBaseClass _dataBase;
        private static readonly SortedList<string, Person> _collectionObj;

        private static Person _person;

        private static ManhattanInfo _manhattanInfo;

        static DataObjects()
        {
            _dataBase = DataBaseClass.GetInstance();
            _collectionObj = _dataBase.GetListPersons();
            _manhattanInfo = _dataBase.GetManhattanInfo();
        }

        public static Person GetPersonLink(string name)
        {
            if (_dataBase.ContainsKey(name))
            {
                _person = _collectionObj[name];
                return _person;
            }
            return null;
        }

        public static ManhattanInfo GetManhattanInfo()
        {
            return _manhattanInfo;
        }

    }
}
