using System;
using System.Collections.Generic;
using static PBase.DataBaseLevel;

namespace PBase
{
    public static class DataBaseO
    {
        private static readonly SortedList<string, Person> CollectionObj;

        private static Person _person;

        private static readonly ManhattanInfo ManhattanInfo;

        static DataBaseO()
        {
            CollectionObj = GetListPersons();
            ManhattanInfo = DataBaseLevel.GetManhattanInfo();
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
