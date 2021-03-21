using System.Threading.Tasks;

namespace PersonsBase.MyControllers
{
    public interface ISaver
    {
        string FileExtension { get; }

        T Load<T>(string fileName);
        Task<T> LoadAsync<T>(string fileName);

        void Save<T>(T obj, string fileName);
        Task SaveAsync<T>(T obj, string fileName);
    }
}