using System;
using System.Collections.Generic;
using System.Linq;
using PersonsBase.data.Abonements;

namespace PersonsBase.data
{
    public static class PersonObject
    {
        private static Person _person;
        // private static readonly DataBaseLevel DataBase = DataBaseLevel.GetInstance();

        public static Person GetLink(string name)
        {
            if (!DataBaseLevel.ContainsNameKey(name)) return null;
            _person = DataBaseLevel.GetPersonsList()[name];
            return _person;
        }

        #region /// Журнал посещений пользователя
        public static List<Visit> GetVisitsList(string name)
        {
            var dictVisits = DataBaseLevel.GetPersonsVisitDict();

            return !dictVisits.ContainsKey(name) ? null : dictVisits[name];
        }

        /// <summary>
        /// Проверка на наличие в базе посещений за сегодняшний день.
        /// Возвращает Тру если посещения сегодня были и строку с информацией о посещении.
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="infoMessage"></param>
        /// <returns></returns>
        public static bool IsVisitToday(string personName, out string infoMessage)
        {
            infoMessage = string.Empty;

            if (string.IsNullOrEmpty(personName)) return false;

            var visitsToday = GetVisitsList(personName)?.Where(x => x.DateTimeVisit.Date.Equals(DateTime.Today)).ToList();

            if (visitsToday.Count == 0) return false;
            else
            {
                var lastVisit = visitsToday.Last();
                infoMessage = $"Админ: {lastVisit.CurrAdmName}, \r\n Визит: {lastVisit.DateTimeVisit}, \r\n Тип: {lastVisit.AbonementName}, \r\n Тренировка: {lastVisit.TypeWorkoutToday} ";
                return true;
            }
        }

        /// <summary>
        /// Сохраняет текущий визит.
        /// Добавляет в Журнал посещений параметры выбранной Тренировки, Текущего администратора, время тренировки.
        /// Статический метод, на вход нужно подать Персону.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="selectedOptions"></param>
        public static void SaveCurentVisit(Person person, WorkoutOptions selectedOptions)
        {
            var currentAdmin = (DataBaseLevel.GetManhattanInfo()?.CurrentAdmin) ?? new Administrator();
            var visit = new Visit(person.AbonementCurent, selectedOptions, currentAdmin.Name);
            var personsVisitDict = DataBaseLevel.GetPersonsVisitDict();

            if (personsVisitDict.ContainsKey(person.Name))
            {
                personsVisitDict[person.Name].Add(visit);
            }
            else
            {
                personsVisitDict.Add(person.Name, new List<Visit> { visit });
            }
        }

        /// <summary>
        /// Сохраняет текущий визит. Перегрузка для работы с Диспетчером абонементов
        /// Добавляет в Журнал посещений параметры выбранной Тренировки, Текущего администратора, время тренировки.
        /// Статический метод, на вход нужно подать Персону.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="abonement">Абонемент для сохранения</param>
        /// <param name="selectedOptions"></param>
        public static void SaveCurentVisit(Person person, AbonementBasic abonement, WorkoutOptions selectedOptions)
        {
            var currentAdmin = (DataBaseLevel.GetManhattanInfo()?.CurrentAdmin) ?? new Administrator();
            var visit = new Visit(abonement, selectedOptions, currentAdmin.Name);
            var personsVisitDict = DataBaseLevel.GetPersonsVisitDict();

            if (personsVisitDict.ContainsKey(person.Name))
            {
                personsVisitDict[person.Name].Add(visit);
            }
            else
            {
                personsVisitDict.Add(person.Name, new List<Visit> { visit });
            }
        }

        #endregion

        #region /// Архив абонементов пользователя
        /// <summary>
        /// Возвращает коллекцию с старыми абонементами клиента. Если их нет - вернет нулл.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<AbonHistory> GetAbonHistoryList(string name)
        {
            var dictHistory = DataBaseLevel.GetPersonsAbonHistDict();

            return !dictHistory.ContainsKey(name) ? null : dictHistory[name];
        }

        public static void SaveAbonementToHistory(Person person, AbonementBasic abon)
        {
            if (abon == null) return;

            var currentAdmin = (DataBaseLevel.GetManhattanInfo()?.CurrentAdmin) ?? new Administrator();

            var lengAbonOrClCa = string.Empty;

            if (abon is AbonementByDays byDays)
                lengAbonOrClCa = byDays.GetTypeAbonementByDays().ToString().Replace("На_", "").Replace("_", " ");
            else if (abon is ClubCardA clubCardA)
                lengAbonOrClCa = clubCardA.PeriodAbonem.ToString().Replace("На_", "");
            else if (abon is SingleVisit singleVisit) lengAbonOrClCa = "";


            var abonHistory = new AbonHistory()
            {
                AbonementName = abon.AbonementName,
                AdminName = currentAdmin.Name,
                TypeWorkout = abon.TypeWorkout.ToString(),
                Time = abon.TimeTraining.ToString(),
                SpaStatus = abon.Spa.ToString(),
                EndDate = abon.EndDate.ToShortDateString(),
                ActivationDate = abon.BuyActivationDate.ToShortDateString(),
                LengthAbonOrClubCard = lengAbonOrClCa,
                NumAerobn = (abon is AbonementByDays days && days.TypeWorkout == TypeWorkout.Аэробный_Зал) ? days.GetRemainderDays().ToString() : abon.NumAerobicTr.ToString(),
                NumMini = (abon is AbonementByDays daysM && daysM.TypeWorkout == TypeWorkout.МиниГруппа) ? daysM.GetRemainderDays().ToString() : abon.NumMiniGroup.ToString(),
                NumPerson = (abon is AbonementByDays daysP && daysP.TypeWorkout == TypeWorkout.Персональная) ? daysP.GetRemainderDays().ToString() : abon.NumPersonalTr.ToString()
            };

            // Список всех абонементов для всех клиентов
            var personsAbonHistDict = DataBaseLevel.GetPersonsAbonHistDict();

            if (personsAbonHistDict.ContainsKey(person.Name))
            {
                personsAbonHistDict[person.Name].Add(abonHistory);
            }
            else
            {
                personsAbonHistDict.Add(person.Name, new List<AbonHistory> { abonHistory });
            }
        }
        #endregion
    }
}
