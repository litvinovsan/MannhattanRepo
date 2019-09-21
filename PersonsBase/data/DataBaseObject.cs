using System;
using System.Collections.Generic;
using static PBase.DataBaseClass;

namespace PBase
{
    public static class DataObjects
    {
        private static readonly SortedList<string, Person> CollectionObj;

        private static Person _person;

        private static readonly ManhattanInfo ManhattanInfo;

        static DataObjects()
        {
            CollectionObj = GetListPersons();
            ManhattanInfo = DataBaseClass.GetManhattanInfo();
        }

        public static Person GetPersonLink(string name)
        {
            if (!ContainsNameKey(name)) return null;
            _person = CollectionObj[name];
            return _person;
        }

        public static ManhattanInfo GetManhattanInfo()
        {
            return ManhattanInfo;
        }

    }
}
