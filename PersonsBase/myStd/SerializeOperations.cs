using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Soap;
using System.Reflection;
using Newtonsoft.Json;

/// <summary>
///  Для JSON сериализации необходимо подключить NUGET Packet в менеджере Нугет Пакетов
///  Для STATIC сериализации добавить в Reference проекта System.Runtime.Serialization.Formatters.Soap;
/// </summary>

namespace PBase
{
    static class SerializeClass
    {
        #region // Стандартная Сериализация

        public static bool Serialize<T>(T objectToSerialize, string nameFile)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, objectToSerialize);// Если ошибка, вываливаемся тут и не стираем файл базы
                                                               // Сохраняем в файл поток из памяти
                    using (FileStream fileStream = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        formatter.Serialize(fileStream, objectToSerialize);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeSerialize<T>(ref T objectToDeSerialize, string nameFile)
        {
            try
            {
                var formatter = new BinaryFormatter();

                using (FileStream fileStream = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    objectToDeSerialize = (T)formatter.Deserialize(fileStream);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region // JSON Сериализация
        public static bool SerializeJson<T>(T objectToSerialize, string nameOutFile)
        {
            bool result = false;
            try
            {
                // "JSON documents|*.json";
                var objectAsJson = JsonConvert.SerializeObject(objectToSerialize, Newtonsoft.Json.Formatting.Indented);

                using (FileStream file = new FileStream(nameOutFile, FileMode.Create, FileAccess.Write))
                {
                    StreamWriter streamWriter = new StreamWriter(file);
                    streamWriter.Write(objectAsJson);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка Сериализации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static bool DeSerializeJson<T>(ref T objectToDeSerialize, string nameFile)
        {
            bool result = false;
            string objAsJson = string.Empty;
            try
            {
                objAsJson = File.ReadAllText(nameFile);

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Ошибка Файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка Доступа к файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!string.IsNullOrEmpty(objAsJson))
            {
                objectToDeSerialize = JsonConvert.DeserializeObject<T>(objAsJson);
                result = true;
            }
            return result;
        }
        #endregion

        #region // STATIC Сериализация

        #region // Пример запуска статической сериализации
        ///
        //    public static class A
        //    {
        //    public static string s;
        //    public static int i;
        //    public static double z;
        //    }

        //  bool ok = SerializeStatic.Save(typeof(A), "c:\\tests\\a.dat");
        //  bool ok2 = SerializeStatic.Load(typeof(A), "c:\\tests\\a.dat");

        ///
        #endregion

        public static bool StaticSave(Type static_class, string filename)
        {
            try
            {
                FieldInfo[] fields = static_class.GetFields(BindingFlags.Static | BindingFlags.Public);
                object[,] a = new object[fields.Length, 2];
                int i = 0;
                foreach (FieldInfo field in fields)
                {
                    a[i, 0] = field.Name;
                    a[i, 1] = field.GetValue(null);
                    i++;
                };
                Stream f = File.Open(filename, FileMode.Create);
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(f, a);
                f.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool StaticLoad(Type static_class, string filename)
        {
            try
            {
                FieldInfo[] fields = static_class.GetFields(BindingFlags.Static | BindingFlags.Public);
                object[,] a;
                Stream f = File.Open(filename, FileMode.Open);
                SoapFormatter formatter = new SoapFormatter();
                a = formatter.Deserialize(f) as object[,];
                f.Close();
                if (a.GetLength(0) != fields.Length) return false;
                int i = 0;
                foreach (FieldInfo field in fields)
                {
                    if (field.Name == (a[i, 0] as string))
                    {
                        field.SetValue(null, a[i, 1]);
                    }
                    i++;
                };
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
