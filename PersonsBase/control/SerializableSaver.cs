using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;
namespace PersonsBase.control
{
    public class SerializableSaver : IDataSaver
    {
        public async void Save<T>(Dictionary<string, List<T>> dict) where T : class
        {
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase;
            var fileName = typeof(T).Name;

            await Task.Run(() => SerializeClass.Serialize(dict, currentPath + "\\" + fileName + ".bin"));
        }

        public Dictionary<string, List<T>> Load<T>() where T : class
        {
            var loadeDictionary = new Dictionary<string, List<T>>();
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase;
            var fileName = typeof(T).Name;
            SerializeClass.DeSerialize(ref loadeDictionary, currentPath + "\\" + fileName + ".bin");

            return loadeDictionary;
        }
    }
}


