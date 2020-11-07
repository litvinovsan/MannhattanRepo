using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsBase.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.Converter.Tests
{
    [TestClass()]
    public class DbConverterTests
    {
        [TestMethod()]
        public void GetPersonAbonementsTest()
        {
            // Init
            string name = Guid.NewGuid().ToString();
            Person p = new Person(name);

            var abonValid1 = new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа,
                SpaService.Спа, DaysInAbon.На_5_посещений);
            var abonValid2 = new SingleVisit(TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, Pay.Не_Оплачено,
                TimeForTr.Весь_День)
            {
                BuyActivationDate = DateTime.Today.AddDays(-20),
                NumAerobicTr = 0,
                NumMiniGroup = 0,
                NumPersonalTr = 0,
                IsActivated = true,
                TypeWorkout = TypeWorkout.Аэробный_Зал
            };
            var abonValid3 = new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа,
                DaysInAbon.На_5_посещений);

            // If no abons
            var result = DbConverter.GetPersonAbonements(p);
            Assert.AreEqual(0, result.Count);

            // Only CurentAbon
            p.AbonementCurent = abonValid1;
            result = DbConverter.GetPersonAbonements(p);
            Assert.AreEqual(1, result.Count);
            Assert.AreSame(abonValid1, result[0]);

            // Queue
            p.AbonementsQueue.Add(abonValid2);
            p.AbonementsQueue.Add(abonValid3);

            result = DbConverter.GetPersonAbonements(p);
            Assert.AreEqual(3, result.Count);
            Assert.AreSame(abonValid2, result[1]);
        }

        [TestMethod()]
        public void ConvertTest()
        {
            List<Person> persons = new List<Person>();

            // Empty
            var resultDict = DbConverter.Convert(persons);
            Assert.AreEqual(0, resultDict.Count);

            // One person No abonements
            {
                string name = Logic.PrepareName(Guid.NewGuid().ToString());

                Person p = new Person(name);
                persons.Add(p);

                resultDict = DbConverter.Convert(persons);
                Assert.AreEqual(1, resultDict.Count);
                Assert.IsTrue(resultDict.ContainsKey(p.Name));
                Assert.AreEqual(0, resultDict[name].Count);

            }

            // 2 person 1 abonement
            {
                string name = Logic.PrepareName(Guid.NewGuid().ToString());
                Person p = new Person(name);
                var abonValid1 = new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа,
                    SpaService.Спа, DaysInAbon.На_5_посещений);
                p.AbonementCurent = abonValid1;

                persons.Add(p);

                resultDict = DbConverter.Convert(persons);
                Assert.AreEqual(2, resultDict.Count);
                Assert.IsTrue(resultDict.ContainsKey(name));
                Assert.AreEqual(1, resultDict[name].Count);
            }
            // 2 person 3 abons
            {
                persons = new List<Person>();
                AbonementController.GetInstance().GetPersonsDictn().Clear();

                string name = Logic.PrepareName(Guid.NewGuid().ToString());
                string name2 = Logic.PrepareName(Guid.NewGuid().ToString());

                Person p = new Person(name);
                Person p2 = new Person(name2);


                var abonValid1 = new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа,
                    SpaService.Спа, DaysInAbon.На_5_посещений);
                var abonValid2 = new SingleVisit(TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, Pay.Не_Оплачено,
                    TimeForTr.Весь_День);
                var abonValid3 = new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа,
                    SpaService.Спа, DaysInAbon.На_5_посещений);

                p.AbonementCurent = abonValid1;
                p.AbonementsQueue.Add(abonValid2);
                p.AbonementsQueue.Add(abonValid3);

                p2.AbonementCurent = abonValid1;
                p2.AbonementsQueue.Add(abonValid2);

                persons.Add(p);
                persons.Add(p2);

                resultDict = DbConverter.Convert(persons);

                // Сколько персон в коллекции
                Assert.AreEqual(2, resultDict.Count);
                // Проверка наличия имен в коллекции
                Assert.IsTrue(resultDict.ContainsKey(name));
                Assert.IsTrue(resultDict.ContainsKey(name2));
                Assert.IsFalse(resultDict.ContainsKey("asasas"));
                // Проверка количества абонементов
                Assert.AreEqual(3, resultDict[name].Count);
                Assert.AreEqual(2, resultDict[name2].Count);


            }

        }

    }
}
