using PBase;
using System;
using System.Collections.Generic;

namespace PersonsBase.data
{
    /// <summary>
    /// История посещений клиента 
    /// </summary>
    [Serializable]
    public class Visit
    {
        public TypeWorkout TypeWorkout { get; }

        public DateTime DateTimeVisit { get; }
        public readonly Group GroupInfo;
        public readonly Trener TrenerIfPersonal;
        public readonly List<Tuple<string, string>> SummaryAbonInfo;// Название - Значение
        public readonly Administrator CurrentAdministrator;

        // Конструкторы
        public Visit(AbonementBasic abon, WorkoutOptions workoutOptions, Administrator admin)
        {
            TypeWorkout = workoutOptions.TypeWorkout;
            DateTimeVisit = DateTime.Now;

            SummaryAbonInfo = abon.GetShortInfoList();
            GroupInfo = workoutOptions.GroupInfo;
            TrenerIfPersonal = workoutOptions.PersonalTrener;
            CurrentAdministrator = admin;
        }
    }
}
