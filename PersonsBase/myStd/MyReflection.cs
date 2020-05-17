using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace PersonsBase.myStd
{
    // Для енумов сделать enum
    // https://shwanoff.ru/enum-to-string/

    #region /// Вариант 1. Создание наследника от Атрибута

    public class MyFieldName : Attribute
    {
        public string FieldName { get; set; }

        public MyFieldName(string name)
        {
            FieldName = name;
        }
        public MyFieldName() : this(" ")
        {
        }
    }


    #endregion


    public static class MyReflection
    {
        #region // Вариант 1. С созданным наследником класса Атрибута.
        /* Пример использования
            class MyPerson // Класс в котором указывются имена полей
            {
                [MyFieldName("Имя ID")]
                public string MyId { get; private set; }

                [MyFieldName("Имя клиента")]
                public string MyName { get; set; }

                public MyPerson(string id, string name)
                {
                    MyId = id;
                    MyName = name;
                }
            }
     
        Вызов:
             // Получение массива с названием всех полей
             var headerStrings = MyReflection.GetPropertiesName(typeof(AbonHistory));
       */


        /// <summary>
        /// Возвращает описание одного поля из класса.
        /// У поля в классе должен быть установлен атрибут [MyFieldName("Имя ID")]
        /// </summary>
        /// <param name="propertyInfo">Получается так: typeof(MyPerson).GetProperties()[0] </param>
        /// <returns></returns>
        private static string GetPropertyDescription(PropertyInfo propertyInfo)
        {
            string propertyName = String.Empty;
            Attribute description = propertyInfo.GetCustomAttribute(typeof(MyFieldName));
            if (description != null && (description is MyFieldName name))
            {
                propertyName = name?.FieldName;
            }

            return propertyName;
        }

        /// <summary>
        /// Возвращает массив с полями класса.
        /// На вход подать GetProperties(typeof(MyPersonsClass))
        /// </summary>
        /// <param name="typeClass"></param>
        private static PropertyInfo[] GetProperties(Type typeClass)
        {
            return typeClass.GetProperties();
        }

        /// <summary>
        /// Возвращает массив с именами полей класса.
        /// Поля в классе должны быть помечены атрибутом [MyFieldName("Имя ID")]
        /// </summary>
        /// <returns></returns>
        public static string[] GetPropertiesName(Type type)
        {
            try
            {
                var properties = GetProperties(type);
                string[] names = new string[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    names[i] = GetPropertyDescription(properties[i]);
                }
                return names;
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Ошибка получения заголовков для вкладки Архив Абонементов" + e.Message);
                return new[] { "" };
            }
        }
        #endregion

        #region // Вариант 2. Простой вариант. Получение списка имен полей в классе
        // В этом варианте не нужно создавать свой класс Атрибут с полями или использовать готовый класс MyFieldName.
        // Тут используется стандартный атрибут Description  и System.ComponentModel

        // Пример использования:

        //  В классе добавить атрибут 
        //   [Description("Название")]
        //    public string AbonementName { get; set; }

        // А в нужном месте вызывать...   Где AbonHistory - имя класса в котором нужно узнать имена
        //  var headerStrings = MyReflection.GetPropertiesNameSimple(typeof(AbonHistory));

        /// <summary>
        /// Возвращает массив с именами всех полей класса.
        /// Поля в классе должны быть помечены атрибутом [Description("Название")]
        /// </summary>
        /// <param name="type">typeof(MyPerson)</param>
        /// <returns></returns>
        public static string[] GetPropertyDescriptions(Type type)
        {
            try
            {
                // Имена всех полей как в коде. Это не описание из атрибутов
                var properties = GetProperties(type).Select(x => x.Name).ToList();
                var result = new List<string>(properties.Count);

                foreach (var property in properties)
                {
                    var info = type.GetMember(property);
                    var customAtrrs = info[0].GetCustomAttributes();
                    string tempStr = string.Empty;
                    foreach (var item in customAtrrs)
                    {
                        if (item is DescriptionAttribute s)
                        {
                            tempStr = string.Copy(s.Description);
                        }
                    }

                    result.Add(string.IsNullOrEmpty(tempStr) ? "" : tempStr);
                }

                return result.ToArray();
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Ошибка получения заголовков для вкладки Архив Абонементов" + e.Message);
                return new[] { "" };
            }
        }


        #endregion

    }
}
