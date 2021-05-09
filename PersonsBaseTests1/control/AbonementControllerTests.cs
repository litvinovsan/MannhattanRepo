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
            inst.GetPersonsDictn().Clear();

            // Коллекция пустая
            Assert.AreEqual(inst.GetPersonsDictn().Count, 0);

            var firstPerson = Guid.NewGuid().ToString();
            var secondPerson = Guid.NewGuid().ToString();

            // Добавляем в коллекцию клиентов
            inst.GetPersonsDictn().Add(firstPerson, new List<AbonementBasic>() { new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений) });
            Assert.AreEqual(1, inst.GetPersonsDictn().Count);

            // Проверяем основной метод
            var result = inst.GetList(firstPerson);
            Assert.AreSame(inst.GetPersonsDictn()[firstPerson], result);

            // Изменения в основной коллекции
            var testChanges1 = result.First().IsActivated;
            result.First().IsActivated = true;
            Assert.AreEqual(result.First().IsActivated, true);

            Assert.AreEqual(inst.GetPersonsDictn()[firstPerson].First().IsActivated, true);

            var expect = result.ToList().Count;
            Assert.AreEqual(1, expect);

            // Проверка доступа по индексу
            inst.GetPersonsDictn().Add(secondPerson, new List<AbonementBasic>() { new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Весь_День, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений) });

        }

        [TestMethod()]
        public void CheckAccessByIndexTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetPersonsDictn().Clear();
            // Коллекция пустая
            Assert.AreEqual(inst.GetPersonsDictn().Count, 0);
            var firstPerson = Guid.NewGuid().ToString();
            // Добавляем в коллекцию клиентов
            inst.GetPersonsDictn().Add(firstPerson, new List<AbonementBasic>());
            // Проверяем что клиент есть, но у него нет абонементов
            Assert.AreEqual(inst.GetListValid(firstPerson).Count(), 0);
            Assert.AreEqual(inst.GetListNotValid(firstPerson).Count(), 0);

            var abonValid1 = new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);

            var abonValid2 = new SingleVisit(TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, Pay.Не_Оплачено,
                TimeForTr.Весь_День)
            { BuyActivationDate = DateTime.Today.AddDays(-20), NumAerobicTr = 0, NumMiniGroup = 0, NumPersonalTr = 0, IsActivated = true, TypeWorkout = TypeWorkout.Аэробный_Зал };

            var abonValid3 = new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);

            var abonNotValid = new ClubCardA(Pay.Не_Оплачено, TimeForTr.Весь_День, TypeWorkout.Аэробный_Зал,
                    SpaService.Без_Спа, PeriodClubCard.На_1_Месяц)
            { IsActivated = true };
            abonNotValid.SetActivationDate(DateTime.Today.AddDays(-200));

            string name = "myPerson";
            inst.AddAbonement(name, abonNotValid);
            inst.AddAbonement(name, abonValid1);
            inst.AddAbonement(name, abonValid2);
            inst.AddAbonement(name, abonValid3);

            Assert.AreEqual(inst.GetPersonsDictn().Count, 2);
            Assert.AreEqual(inst.GetPersonsDictn()[name].Count, 4);

            // Поиск по значению работает
            var t = inst.GetListValid("myPerson");
            Assert.AreEqual(t.Count(), 3);

            var i = t.ToList().IndexOf(abonValid1);
            Assert.AreEqual(i, 0); // 0 потому что первый элемент ориг массива отбрасывается.Он не валиден

            //1 Проверка как в рабочей программе
            var validAbons = inst.GetListValid(name);
            //2 Отобразили в листбоксе
            //3 Выбрали нужную строчку в листбоксе,получили индекс
            //4 Нашли по индексу нужный элемент в оригинальной коллекции
            int index = 2;
            var selectedAbon = validAbons.ToArray()[index]; // abon_valid_3
            selectedAbon.NumAerobicTr = 123;
            var originalIndex = inst.GetPersonsDictn()["myPerson"].IndexOf(selectedAbon);
            var curentAbon = inst.GetPersonsDictn()["myPerson"][originalIndex];
            curentAbon.NumAerobicTr = 9;
        }

        [TestMethod()]
        public void GetListValidTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetPersonsDictn().Clear();
            var firstPerson = Guid.NewGuid().ToString();
            var l1 = inst.GetListValid(firstPerson);
            Assert.AreEqual(l1.Count, 0);


            inst.AddAbonement(firstPerson, new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений));
            var r = inst.GetPersonsDictn().First().Value.Count;
            Assert.AreEqual(r, 1);

            // Основная проверка
            var res = inst.GetListValid(firstPerson).Count();
            Assert.AreEqual(res, 1);

            // Если имя персоны null
            var res2 = inst.GetListValid(null);
            Assert.IsNull(res2);
        }

        [TestMethod()]
        public void GetOldAbonementsTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetPersonsDictn().Clear();
            var firstPerson = Guid.NewGuid().ToString();
            inst.GetPersonsDictn().Add(firstPerson, new List<AbonementBasic>() { new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений) });

            var r = inst.GetPersonsDictn().First().Value.Count;
            Assert.AreEqual(r, 1);

            // Основная проверка
            var res = inst.GetListNotValid(firstPerson).Count();
            Assert.AreEqual(res, 0);
        }

        [TestMethod()]
        public void AddAbonementTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetPersonsDictn().Clear();
            var actual = inst.GetPersonsDictn().Count;
            Assert.AreEqual(0, actual);

            var name = Guid.NewGuid().ToString();
            inst.AddAbonement(name, new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Весь_День, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, DaysInAbon.На_10_посещений));
            Assert.IsTrue(inst.GetPersonsDictn().ContainsKey(name));

            Assert.AreEqual(1, inst.GetList(name).Count);
        }

        [TestMethod()]
        public void RemoveAbonementTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetPersonsDictn().Clear();
            var actual = inst.GetPersonsDictn().Count;
            Assert.AreEqual(0, actual);

            var personName = Guid.NewGuid().ToString();

            //Добавляем пользователя и абонементы
            var abonValid1 = new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);
            var abonValid2 = new SingleVisit(TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, Pay.Не_Оплачено, TimeForTr.Весь_День) { IsActivated = true };
            var abonValid3 = new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);
            var abonNotValid = new ClubCardA(Pay.Не_Оплачено, TimeForTr.Весь_День, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, PeriodClubCard.На_1_Месяц)
            { BuyActivationDate = DateTime.Today.AddDays(-200) };

            inst.GetPersonsDictn().Add(personName, new List<AbonementBasic>());
            inst.GetPersonsDictn()[personName].Add(abonNotValid);
            inst.GetPersonsDictn()[personName].Add(abonValid1);
            inst.GetPersonsDictn()[personName].Add(abonValid2);
            inst.GetPersonsDictn()[personName].Add(abonValid3);
            Assert.AreEqual(4, inst.GetPersonsDictn()[personName].Count);

            // Проверяем удаление
            inst.RemoveAbonement(personName, abonValid3);
            Assert.AreEqual(3, inst.GetPersonsDictn()[personName].Count);

            try
            {
                inst.RemoveAbonement("2as", abonValid3);
            }
            catch (Exception e)
            {
                throw new NullReferenceException();
            }

        }

        [TestMethod()]
        public void GetIndexGlobalTest()
        {
            var inst = AbonementController.GetInstance();
            inst.GetPersonsDictn().Clear();
            var actual = inst.GetPersonsDictn().Count;
            Assert.AreEqual(0, actual);

            var abonValid1 = new AbonementByDays(Pay.Не_Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);
            var abonValid2 = new SingleVisit(TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, Pay.Не_Оплачено, TimeForTr.Весь_День) { IsActivated = true };
            var abonValid3 = new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);
            var abonNotValid = new ClubCardA(Pay.Не_Оплачено, TimeForTr.Весь_День, TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, PeriodClubCard.На_1_Месяц)
            ;
            abonNotValid.SetActivationDate(DateTime.Today.AddDays(-200));
            // Если нет пользователя
            var result = inst.GetGlobalIndex("nameDummy", abonValid1);
            Assert.AreEqual(-1, result);

            // Если абонемент есть
            string personName = "MyName";
            inst.AddAbonement(personName, abonValid1);
            inst.AddAbonement(personName, abonValid2);
            inst.AddAbonement(personName, abonValid3);
            Assert.AreEqual(3, inst.GetList(personName).Count);

            var index = inst.GetGlobalIndex(personName, abonValid2);
            Assert.AreEqual(1, index);

            // Если абонемента нет
            index = inst.GetGlobalIndex(personName, abonNotValid);
            Assert.AreEqual(-1, index);

            // Получить невалидный и найти его индекс в основной коллекции
            inst.AddAbonement(personName, abonNotValid);
            var notValidList = inst.GetListNotValid(personName);
            //.. Получить абонемент по индексу
            var curentAbon = inst.GetByIndex(notValidList, 0);
            Assert.AreSame(curentAbon, abonNotValid);

            var globalIndex = inst.GetGlobalIndex(personName, curentAbon);
            Assert.AreEqual(3, globalIndex);

            var globalIndex2 = inst.GetGlobalIndex(null, curentAbon);
            Assert.AreEqual(-1, globalIndex2);
        }
    }
}