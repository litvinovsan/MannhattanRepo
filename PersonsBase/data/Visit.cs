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
        private TypeWorkout _typeWorkout;
        private DateTime _dateTimeVisit;

        public TypeWorkout TypeWorkout
        {
            get
            {
                return _typeWorkout;
            }
        }
        public DateTime DateTimeVisit
        {
            get
            {
                return _dateTimeVisit;
            }
        }
        public readonly Group GroupInfo;
        public readonly Trener TrenerIfPersonal;
        public readonly List<Tuple<string, string>> SummaryAbonInfo;// Название - Значение

        // Конструкторы
        public Visit(AbonementBasic abon, WorkoutOptions workoutOptions)
        {
            _typeWorkout = workoutOptions.TypeWorkout;
            _dateTimeVisit = DateTime.Now;

            SummaryAbonInfo = abon.GetShortInfoList();
            GroupInfo = workoutOptions.GroupInfo;
            TrenerIfPersonal = workoutOptions.PersonalTrener;
        }
    }
}
