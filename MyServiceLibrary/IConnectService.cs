using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PersonsBase;
using PersonsBase.data.Abonements;

namespace MyServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConnectService" in both code and config file together.
    [ServiceContract]
    public interface IConnectService
    {
        [OperationContract]
        string GetData(string value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        AbonementBasic GetAbonement(string personName);

        [OperationContract]
        void SetAbonement(AbonementBasic abonement, string personName);

        [OperationContract]
        string GetText();

        [OperationContract]
        bool SetText(string text);

        //[OperationContract]
        //string GetVisits();
        //// Списки с посещениями по разным типам. Тренажерка, Аэробный и Персоналки
        //public List<GymItem> GymList = new List<GymItem>();
        //public List<StandartItem> PersonalList = new List<StandartItem>();
        //public List<StandartItem> MiniGroupList = new List<StandartItem>();
        //public List<AerobItem> AerobList = new List<AerobItem>();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "MyServiceLibrary.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
