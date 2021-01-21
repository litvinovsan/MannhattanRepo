using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PersonsBase.wcf;

namespace PersonsBase
{
    public class Server
    {
        private Uri Address { get; }
        private BasicHttpBinding Binding { get; }
        private Type Contract { get; }

        private string AddrPath { get; set; }
        private ServiceHost Host { get; set; }

        public Server(string addr)
        {
            // Указание адреса где ожидать входящие сообщения
            var addrs = addr;
            Address = new Uri(addrs);
            // Указания привязки, как обмениваться сообщениями
            Binding = new BasicHttpBinding();
            // Указание контракта
            Contract = typeof(IContract);

            Host = new ServiceHost(typeof(Service));
            Host.AddServiceEndpoint(Contract, Binding, Address);
            Host.Open();
        }


        ~Server()
        {
            //   Host.Close();
        }
    }
}
