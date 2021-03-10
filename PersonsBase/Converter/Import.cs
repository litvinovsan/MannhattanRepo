using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.data;

namespace PersonsBase.Converter
{
    public class PersonInfoPhoneComparer : IEqualityComparer<PersonInfo>
    {
        public bool Equals(PersonInfo x, PersonInfo y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Phone.Equals(y.Phone);
        }

        public int GetHashCode(PersonInfo obj)
        {
            unchecked
            {
                //Check whether the object is null
                if (Object.ReferenceEquals(obj, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = obj.Phone == null ? 0 : obj.Phone.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ 397;
            }
        }
    }

    public class PersonInfo : IEquatable<PersonInfo>
    {
        public PersonInfo(string name, string phone, string notes)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Notes = notes;
        }

        public string Name { get; }
        public string Phone { get; }
        public string Notes { get; }

        public static bool operator ==(PersonInfo left, PersonInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PersonInfo left, PersonInfo right)
        {
            return !Equals(left, right);
        }

        public bool Equals(PersonInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Phone, other.Phone);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PersonInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
            }
        }
    }


    public static class Import
    {
        #region Фильтрация входных списков. Асинхронно

        /// <summary>
        /// Возвращает список людей из новой коллекции с уникальными номерам ителефонов
        /// </summary>
        /// <param name="dataBase"></param>
        /// <param name="fileOpenedList"></param>
        /// <returns></returns>
        private static IEnumerable<PersonInfo> GetNewPhonesList(SortedList<string, Person> dataBase, List<PersonInfo> fileOpenedList)
        {
            if (dataBase == null) throw new ArgumentNullException(nameof(dataBase));
            if (fileOpenedList == null) throw new ArgumentNullException(nameof(fileOpenedList));

            List<PersonInfo> resList = new List<PersonInfo>();

            foreach (var fItem in fileOpenedList)
            {
                var isPhoneNotExists = dataBase.Values.Count((x => (x.Phone.Equals(fItem.Phone)))) == 0;
                if (isPhoneNotExists)
                {
                    resList.Add(fItem);
                }
            }
            return resList.Distinct().ToList();
        }

        private static IEnumerable<PersonInfo> PhonesAlreadyExists(SortedList<string, Person> dataBase, List<PersonInfo> fileOpenedList)
        {
            if (dataBase == null) throw new ArgumentNullException(nameof(dataBase));
            if (fileOpenedList == null) throw new ArgumentNullException(nameof(fileOpenedList));

            List<PersonInfo> resList = new List<PersonInfo>();

            foreach (var fItem in fileOpenedList)
            {
                var isPhoneExists = dataBase.Values.Count((x => (x.Phone.Equals(fItem.Phone)))) != 0;
                if (isPhoneExists)
                {
                    resList.Add(fItem);
                }
            }

            return resList.Distinct().ToList();
        }

        /// <summary>
        /// Эти клиенты не находятся в текущей базе по Имени и Номеру телефона
        /// </summary>
        /// <param name="dataBase"></param>
        /// <param name="fileOpenedList"></param>
        /// <returns></returns>
        private static IEnumerable<PersonInfo> GetUnicPersons(SortedList<string, Person> dataBase, List<PersonInfo> fileOpenedList)
        {
            if (dataBase == null) throw new ArgumentNullException(nameof(dataBase));
            if (fileOpenedList == null) throw new ArgumentNullException(nameof(fileOpenedList));

            List<PersonInfo> resList = new List<PersonInfo>();

            foreach (var fItem in fileOpenedList)
            {
                var isPhoneNotExists = dataBase.Values.Count((x => (x.Phone.Equals(fItem.Phone)))) == 0;
                if (!dataBase.ContainsKey(fItem.Name) && isPhoneNotExists)
                {
                    resList.Add(fItem);
                }
            }
            return resList.Distinct();
        }

        public static async Task<IEnumerable<PersonInfo>> GetNewPersonsNotExistsAsync(SortedList<string, Person> dataBase, List<PersonInfo> procPersonsList)
        {
            var task = new Task<IEnumerable<PersonInfo>>(() => GetNewPhonesList(dataBase, procPersonsList));
            task.Start();
            return await task;
        }

        public static async Task<IEnumerable<PersonInfo>> GetPhonesAlreadyExistsAsync(SortedList<string, Person> dataBase, List<PersonInfo> fileOpenedList)
        {
            var task = new Task<IEnumerable<PersonInfo>>(() => PhonesAlreadyExists(dataBase, fileOpenedList));
            task.Start();
            return await task;
        }

        public static async Task<IEnumerable<PersonInfo>> GetUnicPersonsAsync(SortedList<string, Person> dataBase, List<PersonInfo> fileOpenedList)
        {
            var task = new Task<IEnumerable<PersonInfo>>(() => GetUnicPersons(dataBase, fileOpenedList));
            task.Start();
            return await task;
        }
        #endregion

        #region Создание клиентов

        public static bool TryAddToDataBase(SortedList<string, Person> dBase, PersonInfo person)
        {
            var personToAdd = new Person(person.Name, person.Phone, person.Notes);
            var result = DataBaseLevel.PersonAdd(dBase, personToAdd);
            if (result == ResponseCode.Success) return true;
            // DataBaseM.ExplainResponse(result);
            return false;
        }

        #endregion

    }
}
