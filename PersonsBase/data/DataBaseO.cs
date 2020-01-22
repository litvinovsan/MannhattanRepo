using System.Collections.Generic;

namespace PersonsBase.data
{
    public static class DataBaseO
    {
        private static Person _person;

        static DataBaseO()
        {
        }

        public static Person GetPersonLink(string name)
        {
            if (!DataBaseLevel.ContainsNameKey(name)) return null;
            _person = DataBaseLevel.GetListPersons()[name];
            return _person;
        }

        //public static List<Visit> GetPersonVisits(string name)
        //{
        //    if (!DataBaseLevel.ContainsNameKey(name)) return new List<Visit>();

        //}
    }
}
