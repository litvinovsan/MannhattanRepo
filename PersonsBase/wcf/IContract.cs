using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PersonsBase
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        string GetData(string value);

        [OperationContract]
        CompositeType GetCompositeData(CompositeType composite);

        [OperationContract]
        string GetText();

        [OperationContract]
        bool SetText(string text);
    }
}

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