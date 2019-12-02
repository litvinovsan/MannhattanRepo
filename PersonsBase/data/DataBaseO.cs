using System.Collections.Generic;

namespace PersonsBase.data
{
    public static class DataBaseO
    {
        private static readonly SortedList<string, Person> CollectionObj;

        private static Person _person;

        private static readonly ManhattanInfo ManhattanInfo;

        static DataBaseO()
        {
            CollectionObj = DataBaseLevel.GetListPersons();
            ManhattanInfo = DataBaseLevel.GetManhattanInfo();
        }

        public static Person GetPersonLink(string name)
        {
            if (!DataBaseLevel.ContainsNameKey(name)) return null;
            _person = CollectionObj[name];
            return _person;
        }

        public static ManhattanInfo GetManhattanInfo()
        {
            return ManhattanInfo;
        }
    }
}
