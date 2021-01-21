using System;

namespace PersonsBase.wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Contract" in both code and config file together.
    public class Service : IContract
    {
        public void DoWork()
        {
        }

        public string GetData(string value)
        {
            return value;
        }

        public CompositeType GetCompositeData(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        public string GetText()
        {
            throw new NotImplementedException();
        }

        public bool SetText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
