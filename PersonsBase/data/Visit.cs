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

        public readonly List<Tuple<string, string>> SummaryAbonInfo;// Название - Значение
        public readonly Group GroupWorkout;
        public readonly Trener Trener;

        // Конструкторы
        public Visit(AbonementBasic abon, WorkoutOptions workoutOptions)
        {
            _typeWorkout = workoutOptions.TypeWorkout;
            _dateTimeVisit = DateTime.Now;

            SummaryAbonInfo = abon.GetShortInfoList();

            GroupWorkout = workoutOptions.GroupTraining;

            Trener = workoutOptions.PersonalTrener;
        }
    }
}
