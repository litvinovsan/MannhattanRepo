using System.Collections.Generic;

namespace PersonsBase.data
{
    public static class PersonObject
    {
        private static Person _person;
        private static DataBaseLevel _dataBase;
        static PersonObject()
        {
            _dataBase = DataBaseLevel.GetInstance();
        }

        public static Person GetLink(string name)
        {
            if (!DataBaseLevel.ContainsNameKey(name)) return null;
            _person = DataBaseLevel.GetListPersons()[name];
            return _person;
        }

        public static  List<Visit> GetVisitsList(string name)
        {
            var dictVisits = DataBaseLevel.GetDictVisits();

            return !dictVisits.ContainsKey(name) ? null : DataBaseLevel.GetDictVisits()[name];
        }
    }
}
