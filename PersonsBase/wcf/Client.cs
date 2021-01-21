using System;
using System.ServiceModel;

namespace PersonsBase.wcf
{
    public class Client
    {
        private Uri Address { get; }
        private BasicHttpBinding Binding { get; }
        private EndpointAddress Endpoint { get; }

        private IContract Channel { get; }

        public Client(string addr)
        {
            // Указание адреса где ожидать входящие сообщения
            var addrPath = addr;
            Address = new Uri(addrPath);
            // Указания привязки, как обмениваться сообщениями
            Binding = new BasicHttpBinding();
            Endpoint = new EndpointAddress(Address);

            var factory = new ChannelFactory<IContract>(Binding, Endpoint);
            Channel = factory.CreateChannel();
        }

        public IContract GetChannel()
        {
            return Channel;
        }
    }
}
