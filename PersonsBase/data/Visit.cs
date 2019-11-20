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
        public readonly string PeronalTrenerName;
        public readonly string CurrentAdministratorName;

        // Свойства абонемента на момент посещения
        public SpaService SpaStatus { get; }
        public Pay PayStatus { get; }
        public TimeForTr TimeForTrenStatus { get; }
        public DateTime AbonBuyDate { get; } // FIXME Переделать даты в абонементе
        public DateTime AbonEndDate { get; } // FIXME Переделать даты в абонементе
        public int NumAerobicTr { get; }
        public int NumPersonalTr { get; }

        // Конструкторы
        public Visit(AbonementBasic abon, WorkoutOptions workoutOptions, string administratorName)
        {
            TypeWorkout = workoutOptions.TypeWorkout;
            DateTimeVisit = DateTime.Now;

            GroupInfo = workoutOptions.GroupInfo;
            PeronalTrenerName = (workoutOptions.PersonalTrener == null || workoutOptions.PersonalTrener.Name == "")
                ? "Имя неизвестно"
                : workoutOptions.PersonalTrener.Name;
            CurrentAdministratorName = administratorName ?? "Имя неизвестно";

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
