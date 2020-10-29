using System.Collections.Generic;
using PersonsBase.data.Abonements;

namespace PersonsBase.control
{
    public interface IDataSaver
    {
        void Save<T>(Dictionary<string, List<T>> dict) where T : class;
        Dictionary<string, List<T>> Load<T>() where T : class;
    }
}
