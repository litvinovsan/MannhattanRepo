using System;
using System.Data;
using PersonsBase.data.Abonements;

namespace PersonsBase.data
{
    /// <summary>
    /// История посещений клиента 
    /// </summary>
    [Serializable]
    public class Visit
    {
        public TypeWorkout TypeWorkoutToday { get; }
        public DateTime DateTimeVisit { get; }

        public readonly Group GroupInfo;
        public readonly string PeronalTrenerName;
        public readonly string CurrAdmName;

        // Свойства абонемента на момент посещения
        public SpaService SpaStatus { get; }
        public Pay PayStatus { get; }
        public TimeForTr AvailableTimeTren { get; }
        public DateTime AbonStartDate { get; } // FIXME Переделать даты в абонементе
        public DateTime AbonEndDate { get; } // FIXME Переделать даты в абонементе
        public int NumAerobicTr { get; }
        public int NumPersonalTr { get; }

        // Конструкторы
        public Visit(AbonementBasic abon, WorkoutOptions workoutOptions, string administratorName)
        {
            DateTimeVisit = DateTime.Now;
            TypeWorkoutToday = workoutOptions.TypeWorkout;
            NumAerobicTr = abon.NumAerobicTr;
            NumPersonalTr = abon.NumPersonalTr;
            SpaStatus = abon.Spa;
            PayStatus = abon.PayStatus;
            AvailableTimeTren = abon.TimeTraining;
            AbonStartDate = abon.BuyDate;
            AbonEndDate = abon.EndDate;
            CurrAdmName = administratorName ?? "Имя неизвестно";
            PeronalTrenerName = (workoutOptions.PersonalTrener == null || workoutOptions.PersonalTrener.Name == "")
                ? "Имя неизвестно"
                : workoutOptions.PersonalTrener.Name;
            GroupInfo = workoutOptions.GroupInfo;
        }

        #region // Не изменять. Кусок нужен для создания таблицы для вывода на форму в датагридвью 

        /// <summary>
        /// Создает массив со значениями полей в текущем посещении
        /// </summary>
        /// <returns></returns>
        public object[] GetValues()
        {
            // Зависят от типа тренировки. Т.к. могут не быть групповые трени
            string trenerName = GetTrenerName();
            string groupTimeNameInfo = GetGroupTimeNameInfo();
            string notes = GroupInfo.Notes;

            // Основной массив с данными
            object[] temp = {
                $"{DateTimeVisit:f}",     // Время и дата посещения
                TypeWorkoutToday.ToString().Replace("_"," "),   // Тип тренировки. Аэроб, персона или тренажерка
                AvailableTimeTren.ToString().Replace("_"," "), // Доступное время посещений
                PayStatus.ToString().Replace("_"," "),     // статус оплаты
                NumAerobicTr.ToString(),  //
                NumPersonalTr.ToString(), //
                SpaStatus.ToString().Replace("_"," "),     // Спа доступность
                trenerName,
                groupTimeNameInfo,         // Название и Время групповой тренировки
                CurrAdmName,          // Имя Администратора на тот момент
                $"{AbonStartDate:d}",   // Дата покупки абонемента
                $"{AbonEndDate:d}",   // Дата окончания абонемента
                notes
            };
            return temp;
        }

        /// <summary>
        /// Возвращает массив с названиями Полей в такой же очередности что и в функции GetValues. Не менять порядок!!!
        /// </summary>
        /// <returns></returns>
        public DataColumn[] GetHeadersForValues()
        {
            var headerNames = new[]
            {
                "Дата",
                "Тип Тренировки",
                "Утро/Весь день",
                "Оплата",
                "Ост. Групповых",
                "Ост. Персонал",
                "Спа",
                "Тренер",
                "Групповая трен.",
                "Администратор",
                "Покупка абонем.",
                "Конец абонем.",
                "Заметки"
            };
            var dcol = new DataColumn[headerNames.Length];
            for (var i = 0; i < headerNames.Length; i++)
            {
                dcol[i] = new DataColumn(headerNames[i]);
            }

            return dcol;
        }

        private string GetGroupTimeNameInfo()
        {
            return (TypeWorkoutToday == TypeWorkout.Аэробный_Зал) ? GroupInfo.ScheduleNote.GetTimeAndNameStr() : "";
        }

        /// <summary>
        /// Возвращает имя тренера в зависимости от типа тренировки. Для персоналок один, для Аэробных - другой
        /// </summary>
        /// <returns></returns>
        private string GetTrenerName()
        {
            var result = "";
            switch (TypeWorkoutToday)
            {
                case TypeWorkout.Тренажерный_Зал:
                    break;
                case TypeWorkout.Аэробный_Зал:
                    {
                        result = GroupInfo.TrenerName;
                        break;
                    }
                case TypeWorkout.Персональная:
                    {
                        result = PeronalTrenerName;
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        #endregion

    }
}
