using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PersonsBase.wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Contract" in both code and config file together.
    public class MyService : IContract
    {
        public void DoWork()
        {
        }

        public string GetData(string value)
        {
            throw new NotImplementedException();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
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
