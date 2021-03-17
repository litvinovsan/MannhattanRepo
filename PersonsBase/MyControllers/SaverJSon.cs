using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonsBase.MyControllers
{
    // [JsonPropertyName("firstname")]
    // [JsonIgnore]
    // [JsonInclude]


    public class SaverJSon : ISaver
    {
        #region Опции
        static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true,
            IgnoreNullValues = false,
            IgnoreReadOnlyFields = false,
            IgnoreReadOnlyProperties = false,
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

            try
            {
                var jsonString = JsonSerializer.Serialize(obj, Options);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void SaveAsync<T>(T obj, string fileName)
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
            catch (Exception)
            {

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
            catch (Exception)
            {

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
