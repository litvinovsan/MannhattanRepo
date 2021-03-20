using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonsBase.data
{
    [Serializable]
    public class MyEmploee
    {
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude, JsonPropertyName("EmploeeName")]
        public string Name { get; private set; }
        [JsonInclude, JsonPropertyName("EmploeePhone")]
        public string Phone { get; set; }
        [JsonInclude]
        public EmploeeType EmploeeType { get; set; }

        public MyEmploee(string name, EmploeeType type, string phone = "")
        {
            if (!Enum.IsDefined(typeof(EmploeeType), type))
                throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(EmploeeType));

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Phone = phone;
            EmploeeType = type;
        }

        public MyEmploee()
        {
            Name = string.Empty;
            Phone = string.Empty;
            EmploeeType = EmploeeType.Администратор;
        }
    }
}
