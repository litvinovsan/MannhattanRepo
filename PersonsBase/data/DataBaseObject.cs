using System;
using System.Collections.Generic;

namespace PBase
{
    public static class DataObjects
    {
        private static readonly DataBaseClass DataBase;
        private static readonly SortedList<string, Person> CollectionObj;

        private static Person _person;

        private static readonly ManhattanInfo ManhattanInfo;

        static DataObjects()
        {
            DataBase = DataBaseClass.GetInstance();
            CollectionObj = DataBase.GetListPersons();
            ManhattanInfo = DataBase.GetManhattanInfo();
        }

        public static Person GetPersonLink(string name)
        {
            if (!DataBase.ContainsKey(name)) return null;
            _person = CollectionObj[name];
            return _person;
        }

        public static ManhattanInfo GetManhattanInfo()
        {
            return ManhattanInfo;
        }

    }
}
