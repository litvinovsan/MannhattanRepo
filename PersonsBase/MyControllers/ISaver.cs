namespace PersonsBase.MyControllers
{
    public interface ISaver
    {
        T Load<T>(string fileName);
        void Save<T>(T obj, string fileName);
    }
}