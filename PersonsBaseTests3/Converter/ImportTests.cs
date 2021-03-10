using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsBase.Converter;
using PersonsBase.data;

namespace PersonsBase.Converter.Tests
{
    [TestClass()]
    public class ImportTests
    {
        [TestMethod()]
        public void GetUnicDuplicateListAsyncTest()
        {
            // Arrange
            SortedList<string, Person> dataBase = DataBaseLevel.GetPersonsList();
            dataBase.Add("A1", new Person("A1", "111", "N1"));
            dataBase.Add("A2", new Person("A2", "222", "N2"));
            dataBase.Add("A3", new Person("A3", "333", "N3"));
            dataBase.Add("A4", new Person("A4", "444", "N4"));

            List<PersonInfo> procPersonsList = new List<PersonInfo>(4)
            {
                new PersonInfo("A1", "000", "Копия по имени"),
                new PersonInfo("B2", "222", "Копия по телефону"),
                new PersonInfo("A3", "333", "Копия полная"),
                new PersonInfo("Unic!", "123", "Уникальнй1"),
                new PersonInfo("Unic2!", "555", "Уникальнй2")  // 2
            };

            // Action 
            var actual = Import.GetUnicPersonsAsync(dataBase, procPersonsList).Result.ToList();

            // Assert 
            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod()]
        public void GetPhonesDuplicateListAsyncTest()
        {
            // Arrange
            SortedList<string, Person> dataBase = DataBaseLevel.GetPersonsList();
            dataBase.Add("A1", new Person("A1", "111", "N1"));
            dataBase.Add("A2", new Person("A2", "222", "N2"));
            dataBase.Add("A3", new Person("A3", "333", "N3"));
            dataBase.Add("A4", new Person("A4", "444", "N4"));


            List<PersonInfo> procPersonsList = new List<PersonInfo>(4)
            {
                new PersonInfo("A44", "444", "000"),
                new PersonInfo("A3", "333", "N3")
            };

            // Action 
            var actual = Import.GetPhonesAlreadyExistsAsync(dataBase, procPersonsList).Result.ToList();

            // Assert 
            Assert.AreEqual(procPersonsList.Count, actual.Count);
        }

        [TestMethod()]
        public void TryAddToDataBase_Ok_Test()
        {
            // Arrange
            SortedList<string, Person> dBase = new SortedList<string, Person>();

            var pInfo = new PersonInfo("A1", "111", "N1");

            // Action
            var actual = Import.TryAddToDataBase(dBase, pInfo);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void TryAddToDataBase_Fail_Test()
        {
            // Arrange
            SortedList<string, Person> dBase = new SortedList<string, Person>();

            var pInfo = new PersonInfo("A1", "111", "N1");
            Import.TryAddToDataBase(dBase, pInfo);

            // Action
            var actual = Import.TryAddToDataBase(dBase, pInfo);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void TryAddToDataBase_Fail_Pfone_Test()
        {
            // Arrange
            SortedList<string, Person> dBase = new SortedList<string, Person>();

            var pInfo = new PersonInfo("A1", "111", "N1");
            Import.TryAddToDataBase(dBase, pInfo);

            // Action
            var actual = Import.TryAddToDataBase(dBase, new PersonInfo("B1", "111", "N1"));

            //Assert
            Assert.IsFalse(actual);
        }
    }
}

namespace PersonsBaseTests3.Converter
{
    /// <summary>
    /// Проверка на совпадение Поля Имени.
    /// </summary>
    [TestClass()]
    public class ImportTests
    {
        [TestMethod()]
        public void GetNewPersonsTest()
        {
            // Arrange
            SortedList<string, Person> dataBase = DataBaseLevel.GetPersonsList();
            dataBase.Add("A1", new Person("A1", "111", "N1"));
            dataBase.Add("A2", new Person("A2", "222", "N2"));
            dataBase.Add("A3", new Person("A3", "333", "N3"));
            dataBase.Add("A4", new Person("A4", "444", "N4"));


            List<PersonInfo> procPersonsList = new List<PersonInfo>(4)
            {
                new PersonInfo("A4", "000", "000"),
                new PersonInfo("A3", "333", "N3")  // Полная копия, не должна учитываться в выборке
            };

            // Action 
            var actual = Import.GetNewPersonsNotExistsAsync(dataBase, procPersonsList).Result.ToList();

            // Assert 
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod()]
        public void GetNewPersons_Test1()
        {
            // Arrange
            SortedList<string, Person> dataBase = DataBaseLevel.GetPersonsList();
            dataBase.Add("A1", new Person("A1", "111", "N1"));
            dataBase.Add("A2", new Person("A2", "222", "N2"));
            dataBase.Add("A3", new Person("A3", "333", "N3"));
            dataBase.Add("A4", new Person("A4", "444", "N4"));



            List<PersonInfo> procPersonsList = new List<PersonInfo>(4)
            {
                new PersonInfo("A1", "111", "000"),
                new PersonInfo("A4", "000", "000"),
                new PersonInfo("A5", "555", "000")
            };

            // Action 
            var actual = Import.GetNewPersonsNotExistsAsync(dataBase, procPersonsList).Result.ToList();

            // Assert 
            Assert.AreEqual(procPersonsList.Count, actual.Count);
        }

        [TestMethod()]
        public void GetNamesDuplicateListAsync_NotFound_Test()
        {
            // Arrange
            SortedList<string, Person> dataBase = DataBaseLevel.GetPersonsList();
            dataBase.Add("A1", new Person("A1", "111", "N1"));
            dataBase.Add("A2", new Person("A2", "222", "N2"));
            dataBase.Add("A3", new Person("A3", "333", "N3"));
            dataBase.Add("A4", new Person("A4", "444", "N4"));

            List<PersonInfo> procPersonsList = new List<PersonInfo>(4);

            // Action 
            var actual = Import.GetNewPersonsNotExistsAsync(dataBase, procPersonsList).Result.ToList();

            // Assert 
            Assert.AreEqual(procPersonsList.Count, actual.Count); //0  0 

            procPersonsList.Add(new PersonInfo("A5", "000", "000"));
            Assert.AreEqual(0, actual.Count);
        }

    }




}