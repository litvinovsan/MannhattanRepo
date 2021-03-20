namespace PersonsBase.MyControllers
{
    public interface ISaver
    {
        string FileExtension { get; }
        T Load<T>(string fileName);
        void Save<T>(T obj, string fileName);
    }
}