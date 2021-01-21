using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.wcf
{
    public class Server
    {
        public readonly string AddrPath;
        public Uri Address;
        public BasicHttpBinding Binding;
        public Type Contract;

        public Server()
        {
            // Указание адреса где ожидать входящие сообщения
            AddrPath = "http://localhost:8181/IContract/";
            Address = new Uri(AddrPath);

            // Указания привязки, как обмениваться сообщениями
            Binding = new BasicHttpBinding();

            // Указание контракта
            Contract = typeof(IContract);
        }
    }
}
