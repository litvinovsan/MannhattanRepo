using System.Collections.Generic;
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

        public static List<Visit> GetVisitsList(string name)
        {
            var dictVisits = DataBaseLevel.GetPersonsVisitDict();

            return !dictVisits.ContainsKey(name) ? null : dictVisits[name];
        }

        /// <summary>
        /// Добавляет в Журнал посещений параметры выбранной Тренировки, Текущего администратора, время тренировки.
        /// Статический метод, на вход нужно подать Персону.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="selectedOptions"></param>
        public static void SaveCurentVisit(Person person, WorkoutOptions selectedOptions)
        {
            var currentAdmin = DataBaseLevel.GetManhattanInfo().CurrentAdmin;
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
        /// Добавляет в Журнал посещений параметры выбранной Тренировки, Текущего администратора, время тренировки.
        /// Статический метод, на вход нужно подать Персону.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="selectedOptions"></param>
        public static void SaveSingleVisit(Person person, WorkoutOptions selectedOptions)
        {
            var currentAdmin = DataBaseLevel.GetManhattanInfo().CurrentAdmin;
            var abonCurr = person.AbonementCurent;
            var v = new SingleVisit(selectedOptions.TypeWorkout, abonCurr.Spa, Pay.Оплачено, abonCurr.TimeTraining);
            v.CheckInWorkout(selectedOptions.TypeWorkout);
            var visit = new Visit(v, selectedOptions, currentAdmin.Name);
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
    }
}
