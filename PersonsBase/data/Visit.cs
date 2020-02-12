using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;

namespace PersonsBase.data
{
    /// <summary>
    /// История посещений клиента 
    /// </summary>
    [Serializable]
    public class Visit
    {
        // Текстовые константы
        private const string NameUnknown = "Имя неизвестно";

        public TypeWorkout TypeWorkoutToday { get; }
        public DateTime DateTimeVisit { get; }

        public readonly Group GroupInfo;
        public readonly string PeronalTrenerName;
        public readonly string CurrAdmName;
        public readonly string AbonementName;

        // Свойства абонемента на момент посещения
        private SpaService SpaStatus { get; }
        private Pay PayStatus { get; }
        private TimeForTr AvailableTimeTren { get; }
        private DateTime AbonStartDate { get; } // FIXME Переделать даты в абонементе
        private DateTime AbonEndDate { get; } // FIXME Переделать даты в абонементе
        private int NumAllDaysAbon { get; }
        private int NumAerobicTr { get; }
        private int NumPersonalTr { get; }
        private  int NumMiniGroup { get; }

        // Конструкторы
        public Visit(AbonementBasic abon, WorkoutOptions workoutOptions, string administratorName)
        {
            DateTimeVisit = DateTime.Now;
            TypeWorkoutToday = workoutOptions.TypeWorkout;
            NumAllDaysAbon = abon.GetRemainderDays();
            NumAerobicTr = abon.NumAerobicTr;
            NumPersonalTr = abon.NumPersonalTr;
            NumMiniGroup = abon.NumMiniGroup;
            SpaStatus = abon.Spa;
            PayStatus = abon.PayStatus;
            AvailableTimeTren = abon.TimeTraining;
            AbonStartDate = abon.BuyActivationDate;
            AbonEndDate = abon.EndDate;
            AbonementName = abon.AbonementName; // "Клубная Карта"  "Абонемент"   "Разовое Занятие"
            CurrAdmName = administratorName ?? NameUnknown;
            PeronalTrenerName = (workoutOptions.PersonalTrener == null || workoutOptions.PersonalTrener.Name == "")
                ? NameUnknown
                : workoutOptions.PersonalTrener.Name;
            GroupInfo = workoutOptions.GroupInfo;
        }
        public Visit()
        {
            DateTimeVisit = DateTime.Now;
            TypeWorkoutToday = TypeWorkout.Тренажерный_Зал;
            NumAllDaysAbon = 0;
            NumAerobicTr = 0;
            NumPersonalTr = 0;
            NumMiniGroup = 0;
            SpaStatus = SpaService.Без_Спа;
            PayStatus = Pay.Не_Оплачено;
            AvailableTimeTren = TimeForTr.Утро;
            AbonStartDate = DateTime.Now;
            AbonEndDate = DateTime.Now;
            AbonementName = ""; // "Клубная Карта"  "Абонемент"   "Разовое Занятие"
            CurrAdmName = "";
            PeronalTrenerName = "";
            GroupInfo = new Group();
        }

        #region // Cоздание таблицы для вывода на форму в DataGridView 

        /// <summary>
        /// Задаются значения и поля, которые будут отображены в таблице посещений( Название заголовка, значение текущее, строка справки)
        /// </summary>
        private List<DataGridItem> CreateReportList()
        {
            var reportRowsList = new List<DataGridItem>();

            var numTrenZal = NumAllDaysAbon.ToString();
            var numAerob = NumAerobicTr.ToString();
            var numPersonal = NumPersonalTr.ToString();
            var numMiniGr = NumMiniGroup.ToString();
            var trenerName = GetTrenerName();
            var groupTimeNameInfo = GetGroupTimeNameInfo();

            reportRowsList.Add(new DataGridItem("Дата", $"{DateTimeVisit:g}", "Дата и время посещения"));
            reportRowsList.Add(new DataGridItem("Вид Карты", AbonementName, "Тип карты/абонемента клиента. (Клубная Карта / Абонемент / Разовое Занятие"));
            reportRowsList.Add(new DataGridItem("Тренировка", TypeWorkoutToday.ToString().Replace("_", " "), "Тип тренировки в указанную дату (Аэробная, Персональная или Тренажерный залл)"));
            reportRowsList.Add(new DataGridItem("Разрешенное Время", AvailableTimeTren.ToString().Replace("_", " "), "Время занятий (Утро или Весь день)"));
            reportRowsList.Add(new DataGridItem("Оплата", PayStatus.ToString().Replace("_", " "), "Статус Оплата в указанную дату"));
            reportRowsList.Add(new DataGridItem("Занятий ост.", numTrenZal, "Осталось занятий в тренажерном зале или всего занятий если у клиента Абонемент"));
            reportRowsList.Add(new DataGridItem("Групповые", numAerob, "Остаток Групповых тренировок"));
            reportRowsList.Add(new DataGridItem("Персоны", numPersonal, "Остаток Персональных тренировок"));
            reportRowsList.Add(new DataGridItem("МиниГруп.", numMiniGr, "Остаток Мини Групп"));
            reportRowsList.Add(new DataGridItem("Спа", SpaStatus.ToString().Replace("_", " "), "Разрешена ли Спа зона"));
            reportRowsList.Add(new DataGridItem("Тренер", trenerName, "Имя Тренера, проводившего тренировку. Если известно"));
            reportRowsList.Add(new DataGridItem("Расписание Группы", groupTimeNameInfo, "Название и время Групповой тренировки. Если известно."));
            reportRowsList.Add(new DataGridItem("Администратор", CurrAdmName, "Администратор в клубе на момент посещения"));
            reportRowsList.Add(new DataGridItem("Покупка абонем.", $"{AbonStartDate:d}", "Дата Покупки абонемента"));
            reportRowsList.Add(new DataGridItem("Конец абонем.", $"{AbonEndDate:d}", "Дата Конеца абонемента"));

            return reportRowsList;
        }

        /// <summary>
        /// Создает массив со значениями полей о текущем посещении
        /// </summary>
        /// <returns></returns>
        private object[] GetValues()
        {
            // Создаем массив с полями и заголовками будущей таблицы по текущему посещению
            var reportRowsList = CreateReportList();

            // Основной массив с данными
            var temp = reportRowsList.Select(x => x.Value).ToArray<object>();
            return temp;
        }

        /// <summary>
        /// Возвращает массив с названиями Полей в такой же очередности что и в функции GetValues. Не менять порядок!!!
        /// </summary>
        /// <returns></returns>
        private DataColumn[] GetHeadersForValues()
        {
            // Создаем массив с полями и заголовками будущей таблицы по текущему посещению
            var reportRowsList = CreateReportList();

            var headerNames = reportRowsList.Select(x => x.HeaderName).ToArray();

            var dcol = new DataColumn[headerNames.Length];
            for (var i = 0; i < headerNames.Length; i++)
            {
                dcol[i] = new DataColumn(headerNames[i]);
            }
            return dcol;
        }
        /// <summary>
        /// Возвращает массив с хелпами в такой же очередности что и в функции GetValues.
        /// </summary>
        /// <returns></returns>
        protected internal string[] GetHeadersToolTipHelp()
        {
            // Создаем массив с полями и заголовками будущей таблицы по текущему посещению
            var reportRowsList = CreateReportList();

            // Основной массив с данными
            var helpStrings = reportRowsList.Select(x => x.HeaderToolTipHelp).ToArray();

            return helpStrings;
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
                case TypeWorkout.МиниГруппа:
                    result = PeronalTrenerName;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        #endregion


        #region /// ЖУРНАЛ ПОСЕЩЕНИЙ

        /// <summary>
        /// Создает DataTable обьект содержащий все посещения пользователя.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVisitsTable(Person person)
        {
            var table = new DataTable();
            var journal = PersonObject.GetVisitsList(person.Name);
            var journalVisits = journal ?? new List<Visit>();
            if (journalVisits.Count == 0)
            {
                table.Columns.Add(" ");
                table.Rows.Add(" ");
                return table;
            }

            // Создаем Заголовки таблицы, берем из первого элемента Visit
            var headers = journalVisits.First().GetHeadersForValues();
            table.Columns.AddRange(headers);

            // Заполняем строки значениями из журнала
            foreach (var item in journalVisits.Reverse<Visit>())
            {
                table.Rows.Add(item.GetValues());
            }
            return table;
        }
        #endregion
    }
}
