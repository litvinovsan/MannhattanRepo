using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.MyControllers
{
    // [JsonPropertyName("firstname")]
    // [JsonIgnore]
    // [JsonInclude]


    public class SaverJSon : ISaver
    {
        #region Опции

        public string FileExtension { get; } = ".json";

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true,
            IncludeFields = true,
            IgnoreNullValues = false,
            IgnoreReadOnlyFields = false,
            IgnoreReadOnlyProperties = false,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            Converters = { new JsonStringEnumConverter() }
        };

        [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
        public class JsonInterfaceConverterAttribute : JsonConverterAttribute
        {
            public JsonInterfaceConverterAttribute(Type converterType)
                : base(converterType)
            {
            }
        }

        // Дальше нужно декорировать нужный интерфейся этим Атрибутом
        //[JsonInterfaceConverter(typeof(ThingConverter))]
        //public interface IThing
        //{
        //    public string Name { get; set; }
        //}

        #endregion

        #region Save
        public void Save<T>(T obj, string fileName)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            var jsonString = JsonSerializer.Serialize(obj, Options);
            File.WriteAllText(fileName, jsonString);
        }

        public async Task SaveAsync<T>(T obj, string fileName)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            try
            {
                using (var createStream = File.Create(fileName))
                {
                    await JsonSerializer.SerializeAsync(createStream, obj, Options);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, typeof(T).Name);
                throw;
            }
        }
        #endregion

        #region Load
        public T Load<T>(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            try
            {
                var jsonString = File.ReadAllText(fileName);
                T result = JsonSerializer.Deserialize<T>(jsonString, Options);
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, typeof(T).Name);
                throw;
            }
        }

        public async Task<T> LoadAsync<T>(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            using (var openStream = File.OpenRead(fileName))
            {
                return await JsonSerializer.DeserializeAsync<T>(openStream, Options);
            }
        }
        #endregion
    }
}
