using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PersonsBase.data
{
    [Serializable]
    public class Administrator
    {
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude, JsonPropertyName("AdministratorName")]
        public string Name { get; private set; }
        [JsonInclude, JsonPropertyName("AdministratorPhone")]
        public string Phone { get; set; }
        public Administrator(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public Administrator()
        {
            Name = "";
            Phone = "";
        }
    }
}
