namespace PersonsBase.data
{
    public static class DataBaseO
    {
        private static Person _person;
        private static readonly ManhattanInfo ManhattanInfo;

        static DataBaseO()
        {
            ManhattanInfo = DataBaseLevel.GetManhattanInfo();
        }

        public static Person GetPersonLink(string name)
        {
            if (!DataBaseLevel.ContainsNameKey(name)) return null;
            _person = DataBaseLevel.GetListPersons()[name];
            return _person;
        }

        public static ManhattanInfo GetManhattanInfo()
        {
            return ManhattanInfo;
        }
    }
}
