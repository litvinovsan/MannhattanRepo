using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;
using PersonsBase.MyControllers;

namespace PersonsBase.control
{
    public class SerializableSaver : IDataSaver
    {
        public async void Save<T>(Dictionary<string, List<T>> dict) where T : class
        {
            await Task.Run(() => SerializeClass.Serialize(dict, SaverBase.GetPath<T>("bin")));
        }

        public Dictionary<string, List<T>> Load<T>() where T : class
        {
            var loadeDictionary = new Dictionary<string, List<T>>();
            SerializeClass.DeSerialize(ref loadeDictionary, SaverBase.GetPath<T>("bin"));

            return loadeDictionary;
        }
    }
}


