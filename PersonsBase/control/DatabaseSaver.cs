using System;
using System.Collections.Generic;
using System.Linq;
using PersonsBase.data.Abonements;

namespace PersonsBase.control
{
    public class DatabaseSaver : IDataSaver
    {
        public void Save<T>(Dictionary<string, List<T>> dict) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange((IEnumerable<T>) dict);
                db.SaveChanges();
            }
        }

        public Dictionary<string, List<T>> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                Dictionary<string, List<T>> result = new Dictionary<string, List<T>>();
                throw  new Exception("CСохранение в базу не готово");
                return result;
            }
        }
    }
}
