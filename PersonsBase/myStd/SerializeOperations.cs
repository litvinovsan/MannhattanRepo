using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;


//  Для STATIC сериализации добавить в Reference проекта System.Runtime.Serialization.Formatters.Soap;

// [OtionalField] Для добавления новых полей, чтобы открылись старые файлы сериализации, где этих полей нет

namespace PersonsBase.myStd
{
    public static class SerializeClass
    {
        #region // СТАНДАРТНАЯ БИНАРНАЯ СЕРИАЛИЗАЦИЯ

        public static bool Serialize<T>(T objectToSerialize, string nameFile)
        {
            try
            {
                if (objectToSerialize == null) return false;

                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, objectToSerialize);// Если ошибка, вываливаемся тут и не стираем файл базы
                                                               // Сохраняем в файл поток из памяти
                    using (var fileStream = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        formatter.Serialize(fileStream, objectToSerialize);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ошибка в файле {nameFile}: " + e.Message, @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeSerialize<T>(ref T objectToDeSerialize, string nameFile)
        {
            try
            {
                var formatter = new BinaryFormatter();

                using (var fileStream = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    objectToDeSerialize = (T)formatter.Deserialize(fileStream);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ошибка в файле {nameFile}: " + e.Message, @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region // STATIC Сериализация

        #region // Пример запуска статической сериализации
        //
        //    public static class A
        //    {
        //    public static string s;
        //    public static int i;
        //    public static double z;
        //    }

        //  bool ok = SerializeStatic.Save(typeof(A), "c:\\tests\\a.dat");
        //  bool ok2 = SerializeStatic.SetDataOnForm(typeof(A), "c:\\tests\\a.dat");

        //
        #endregion

        public static bool StaticSave(Type staticClass, string filename)
        {
            try
            {
                FieldInfo[] fields = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);
                object[,] a = new object[fields.Length, 2];
                int i = 0;
                foreach (FieldInfo field in fields)
                {
                    a[i, 0] = field.Name;
                    a[i, 1] = field.GetValue(null);
                    i++;
                }

                Stream f = File.Open(filename, FileMode.Create);
                var formatter = new SoapFormatter();
                formatter.Serialize(f, a);
                f.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool StaticLoad(Type staticClass, string filename)
        {
            try
            {
                var fields = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);
                Stream f = File.Open(filename, FileMode.Open);
                var formatter = new SoapFormatter();
                var a = formatter.Deserialize(f) as object[,];
                f.Close();
                if (a != null && a.GetLength(0) != fields.Length) return false;
                var i = 0;
                foreach (var field in fields)
                {
                    if (a != null && field.Name == (a[i, 0] as string))
                    {
                        field.SetValue(null, a[i, 1]);
                    }
                    i++;
                }

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
