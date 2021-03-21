using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.MyControllers
{
    public class SaverBinary : ISaver
    {
        public string FileExtension { get; } = ".bin";

        public T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                return (T)formatter.Deserialize(fileStream);
            }

        }

        public Task<T> LoadAsync<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save<T>(T obj, string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fileStream, obj);
            }
        }

        public Task SaveAsync<T>(T obj, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
