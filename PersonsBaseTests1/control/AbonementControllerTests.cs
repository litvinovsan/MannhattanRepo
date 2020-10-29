using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsBase.control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.control.Tests
{
    [TestClass()]
    public class AbonementControllerTests
    {
        [TestMethod()]
        public void GetInstanceTest()
        {
            Assert.IsFalse(false);

            AbonementController inst = null;
            Assert.IsNull(inst);
            inst = AbonementController.GetInstance();
            Assert.IsNotNull(inst);
        }

        [TestMethod()]
        public void GetPersonAbonementsTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetDictionary().Clear();

            // Коллекция пустая
            Assert.AreEqual(inst.GetDictionary().Count, 0);

            var firstPerson = Guid.NewGuid().ToString();
            var secondPerson = Guid.NewGuid().ToString();

            // Добавляем в коллекцию клиентов
            inst.GetDictionary().Add(firstPerson, new List<AbonementBasic>() { new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений) });
            Assert.AreEqual(1, inst.GetDictionary().Count);

            // Проверяем основной метод
            var result = inst.GetList(firstPerson);
            Assert.AreSame(inst.GetDictionary()[firstPerson], result);

            // Изменения в основной коллекции
            var testChanges1 = result.First().IsActivated;
            result.First().IsActivated = true;
            Assert.AreEqual(result.First().IsActivated, true);

            Assert.AreEqual(inst.GetDictionary()[firstPerson].First().IsActivated, true);

            var expect = result.ToList().Count;
            Assert.AreEqual(1, expect);

            // Проверка доступа по индексу
            inst.GetDictionary().Add(secondPerson, new List<AbonementBasic>() { new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Весь_День, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений) });

        }

        [TestMethod()]
        public void CheckAccessByIndexTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetDictionary().Clear();
            // Коллекция пустая
            Assert.AreEqual(inst.GetDictionary().Count, 0);
            var firstPerson = Guid.NewGuid().ToString();
            // Добавляем в коллекцию клиентов
            inst.GetDictionary().Add(firstPerson, new List<AbonementBasic>());
            // Проверяем что клиент есть, но у него нет абонементов
            Assert.AreEqual(inst.GetListValid(firstPerson).Count(), 0);
            Assert.AreEqual(inst.GetListNotValid(firstPerson).Count(), 0);

            var abon_valid_1 = new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);

            var abon_valid_2 = new SingleVisit(TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, Pay.Не_Оплачено,
                TimeForTr.Весь_День)
            { BuyActivationDate = DateTime.Today.AddDays(-20), NumAerobicTr = 0, NumMiniGroup = 0, NumPersonalTr = 0, IsActivated = true, TypeWorkout = TypeWorkout.Аэробный_Зал };

            var abon_valid_3 = new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);

            var abon_not_Valid = new ClubCardA(Pay.Не_Оплачено, TimeForTr.Весь_День, TypeWorkout.Аэробный_Зал,
                    SpaService.Без_Спа, PeriodClubCard.На_1_Месяц)
            { BuyActivationDate = DateTime.Today.AddDays(-200), IsActivated = true };


            string name = "myPerson";
            inst.AddAbonement(name, abon_not_Valid);
            inst.AddAbonement(name, abon_valid_1);
            inst.AddAbonement(name, abon_valid_2);
            inst.AddAbonement(name, abon_valid_3);

            Assert.AreEqual(inst.GetDictionary().Count, 2);
            Assert.AreEqual(inst.GetDictionary()[name].Count, 4);

            // Поиск по значению работает
            var t = inst.GetListValid("myPerson");
            Assert.AreEqual(t.Count(), 3);

            var i = t.ToList().IndexOf(abon_valid_1);
            Assert.AreEqual(i, 0); // 0 потому что первый элемент ориг массива отбрасывается.Он не валиден

            //1 Проверка как в рабочей программе
            var validAbons = inst.GetListValid(name);
            //2 Отобразили в листбоксе
            //3 Выбрали нужную строчку в листбоксе,получили индекс
            //4 Нашли по индексу нужный элемент в оригинальной коллекции
            int index = 2;
            var selectedAbon = validAbons.ToArray()[index]; // abon_valid_3
            selectedAbon.NumAerobicTr = 123;
            var originalIndex = inst.GetDictionary()["myPerson"].IndexOf(selectedAbon);
            var curentAbon = inst.GetDictionary()["myPerson"][originalIndex];
            curentAbon.NumAerobicTr = 9;
        }

        [TestMethod()]
        public void GetValidAbonementsTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetDictionary().Clear();
            var firstPerson = Guid.NewGuid().ToString();
            inst.GetDictionary().Add(firstPerson, new List<AbonementBasic>() { new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений) });

            var r = inst.GetDictionary().First().Value.Count;
            Assert.AreEqual(r, 1);

            // Основная проверка
            var res = inst.GetListValid(firstPerson).Count();
            Assert.AreEqual(res, 1);

        }

        [TestMethod()]
        public void GetOldAbonementsTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetDictionary().Clear();
            var firstPerson = Guid.NewGuid().ToString();
            inst.GetDictionary().Add(firstPerson, new List<AbonementBasic>() { new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений) });

            var r = inst.GetDictionary().First().Value.Count;
            Assert.AreEqual(r, 1);

            // Основная проверка
            var res = inst.GetListNotValid(firstPerson).Count();
            Assert.AreEqual(res, 0);
        }

        [TestMethod()]
        public void AddAbonementTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetDictionary().Clear();
            var actual = inst.GetDictionary().Count;
            Assert.AreEqual(0,actual);

            var expected = Guid.NewGuid().ToString();
            inst.AddAbonement(expected, new AbonementByDays(Pay.Не_Оплачено,TimeForTr.Весь_День,TypeWorkout.Аэробный_Зал,SpaService.Без_Спа,DaysInAbon.На_10_посещений));
            Assert.IsTrue(inst.GetDictionary().ContainsKey(expected));

            Assert.AreEqual(1, inst.GetList(expected).Count);
        }
    }
}