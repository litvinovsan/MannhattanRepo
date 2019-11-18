using PBase;
using System;

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
        public readonly Trener PeronalTrener;
        public readonly Administrator CurrentAdministrator;

        // Свойства абонемента на момент посещения
        public SpaService SpaStatus { get; }
        public Pay PayStatus { get; }
        public TimeForTr TimeForTrenStatus { get; }
        public DateTime AbonBuyDate { get; } // FIXME Переделать даты в абонементе
        public DateTime AbonEndDate { get; } // FIXME Переделать даты в абонементе
        public int NumAerobicTr { get; }
        public int NumPersonalTr { get; }

        // Конструкторы
        public Visit(AbonementBasic abon, WorkoutOptions workoutOptions, Administrator admin)
        {
            TypeWorkout = workoutOptions.TypeWorkout;
            DateTimeVisit = DateTime.Now;

            GroupInfo = workoutOptions.GroupInfo;
            PeronalTrener = workoutOptions.PersonalTrener ?? new Trener();
            CurrentAdministrator = admin ?? new Administrator("Не известно", "");

            SpaStatus = abon.spa;
            PayStatus = abon.payStatus;
            TimeForTrenStatus = abon.timeTraining;
            AbonBuyDate = abon.buyDate;
            AbonEndDate = abon.EndDate;
            NumAerobicTr = abon.NumAerobicTr;
            NumPersonalTr = abon.NumPersonalTr;
        }
    }
}
