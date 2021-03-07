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

    public class PersonInfo : IEquatable<PersonInfo>
    {
        public PersonInfo(string name, string phone, string notes)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Phone =  phone ?? throw new ArgumentNullException(nameof(phone));
            Notes = notes;
        }

        public string Name { get; }
        public string Phone { get; }
        public string Notes { get; }

        public bool Equals(PersonInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) || string.Equals(Phone, other.Phone);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PersonInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397);
                return hashCode;
            }
        }

        public static bool operator ==(PersonInfo left, PersonInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PersonInfo left, PersonInfo right)
        {
            return !Equals(left, right);
        }
    }


    public static class Import
    {
        #region Фильтрация входных списков. Асинхронно
        private static IEnumerable<PersonInfo> GetNamesDuplicateList(List<PersonInfo> dataBaseConverted, List<PersonInfo> fileOpenedList)
        {
            if (dataBaseConverted == null) throw new ArgumentNullException(nameof(dataBaseConverted));
            if (fileOpenedList == null) throw new ArgumentNullException(nameof(fileOpenedList));

            IEnumerable<PersonInfo> resultList = from actual in dataBaseConverted
                                                 from processed in fileOpenedList
                                                 where actual.Name.Equals(processed.Name)
                                                 where !actual.Phone.Equals(processed.Phone)
                                                 select processed;
            return resultList;
        }

        private static IEnumerable<PersonInfo> GetPhonesDuplicateList(List<PersonInfo> dataBaseConverted, List<PersonInfo> fileOpenedList)
        {
            if (dataBaseConverted == null) throw new ArgumentNullException(nameof(dataBaseConverted));
            if (fileOpenedList == null) throw new ArgumentNullException(nameof(fileOpenedList));

            IEnumerable<PersonInfo> resultList = from actual in dataBaseConverted
                                                 from processed in fileOpenedList
                                                 where actual.Phone.Equals(processed.Phone)
                                                 where !actual.Name.Equals(processed.Name)
                                                 select processed;

            return resultList;
        }
        private static IEnumerable<PersonInfo> GetUnicDuplicateList(List<PersonInfo> dataBaseConverted, List<PersonInfo> fileOpenedList)
        {
            if (dataBaseConverted == null) throw new ArgumentNullException(nameof(dataBaseConverted));
            if (fileOpenedList == null) throw new ArgumentNullException(nameof(fileOpenedList));

            List<PersonInfo> resList = new List<PersonInfo>();
            foreach (var fItem in fileOpenedList)
            {
                if (dataBaseConverted.Contains(fItem)) continue;
                resList.Add(fItem);
                break;
            }

            return resList;
        }

        public static async Task<IEnumerable<PersonInfo>> GetNamesDuplicateListAsync(List<PersonInfo> actualPersonslList, List<PersonInfo> procPersonsList)
        {
            var task = new Task<IEnumerable<PersonInfo>>(() => GetNamesDuplicateList(actualPersonslList, procPersonsList));
            task.Start();
            return await task;
        }

        public static async Task<IEnumerable<PersonInfo>> GetPhonesDuplicateListAsync(List<PersonInfo> dataBaseConverted, List<PersonInfo> fileOpenedList)
        {
            var task = new Task<IEnumerable<PersonInfo>>(() => GetPhonesDuplicateList(dataBaseConverted, fileOpenedList));
            task.Start();
            return await task;
        }

        public static async Task<IEnumerable<PersonInfo>> GetUnicDuplicateListAsync(List<PersonInfo> dataBaseConverted, List<PersonInfo> fileOpenedList)
        {
            var task = new Task<IEnumerable<PersonInfo>>(() => GetUnicDuplicateList(dataBaseConverted, fileOpenedList));
            task.Start();
            return await task;
        }
        #endregion

        #region Создание клиентов

        public static bool TryAddToDataBase(SortedList<string, Person> dBase, PersonInfo person)
        {
            var personToAdd = new Person(person.Name, person.Phone, person.Notes);
            var result = DataBaseLevel.PersonAdd(dBase,personToAdd);
            if (result == ResponseCode.Success) return true;
          //  DataBaseM.ExplainResponse(result);
            return false;
        }

        #endregion

    }
}
