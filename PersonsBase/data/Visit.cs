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

        // Главная переменная! Хранение полей Имя Заголовка - Значение - Хелп таблицы
        private List<DataGridItem> _myDataRowsList;

        public TypeWorkout TypeWorkoutToday { get; }
        public DateTime DateTimeVisit { get; }

        public readonly Group GroupInfo;
        public readonly string PeronalTrenerName;
        public readonly string CurrAdmName;
        public readonly string AbonementName;

        // Свойства абонемента на момент посещения
        public SpaService SpaStatus { get; }
        public Pay PayStatus { get; }
        public TimeForTr AvailableTimeTren { get; }
        public DateTime AbonStartDate { get; } // FIXME Переделать даты в абонементе
        public DateTime AbonEndDate { get; } // FIXME Переделать даты в абонементе
        public int NumAllDaysAbon { get; }
        public int NumAerobicTr { get; }
        public int NumPersonalTr { get; }

        // Конструкторы
        public Visit(AbonementBasic abon, WorkoutOptions workoutOptions, string administratorName)
        {
            DateTimeVisit = DateTime.Now;
            TypeWorkoutToday = workoutOptions.TypeWorkout;
            NumAllDaysAbon = abon.GetRemainderDays();
            NumAerobicTr = abon.NumAerobicTr;
            NumPersonalTr = abon.NumPersonalTr;
            SpaStatus = abon.Spa;
            PayStatus = abon.PayStatus;
            AvailableTimeTren = abon.TimeTraining;
            AbonStartDate = abon.BuyDate;
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
            SpaStatus = SpaService.Без_Спа;
            PayStatus = Pay.Не_Оплачено;
            AvailableTimeTren = TimeForTr.Утро;
            AbonStartDate = System.DateTime.Now;
            AbonEndDate = System.DateTime.Now;
            AbonementName = ""; // "Клубная Карта"  "Абонемент"   "Разовое Занятие"
            CurrAdmName = "";
            PeronalTrenerName = "";
            GroupInfo = new Group();
        }

        #region // Не изменять очередность. Кусок нужен для создания таблицы для вывода на форму в датагридвью 

        /// <summary>
        /// Задаются значения, которые будут отображены в таблице посещений( Название заголовка, значение текущее, строка справки)
        /// </summary>
        private void CreateReportList()
        {
            _myDataRowsList.Clear();

            string numTrenZal = NumAllDaysAbon.ToString();
            string numAerob = NumAerobicTr.ToString();
            string numPersonal = NumPersonalTr.ToString();
            string trenerName = GetTrenerName();
            string groupTimeNameInfo = GetGroupTimeNameInfo();

            _myDataRowsList.Add(new DataGridItem("Дата", $"{DateTimeVisit:g}", "Дата и время посещения"));
            _myDataRowsList.Add(new DataGridItem("Вид Карты", AbonementName, "Тип карты/абонемента клиента. (Клубная Карта / Абонемент / Разовое Занятие"));
            _myDataRowsList.Add(new DataGridItem("Тренировка", TypeWorkoutToday.ToString().Replace("_", " "), "Тип тренировки в указанную дату (Аэробная, Персональная или Тренажерный залл)"));
            _myDataRowsList.Add(new DataGridItem("Разрешенное Время", AvailableTimeTren.ToString().Replace("_", " "), "Время занятий (Утро или Весь день)"));
            _myDataRowsList.Add(new DataGridItem("Оплата", PayStatus.ToString().Replace("_", " "), "Статус Оплата в указанную дату"));
            _myDataRowsList.Add(new DataGridItem("Занятий", numTrenZal, "Осталось занятий в тренажерном зале или всего занятий если у клиента Абонемент"));
            _myDataRowsList.Add(new DataGridItem("Групповые", numAerob, "Остаток Групповых тренировок"));
            _myDataRowsList.Add(new DataGridItem("Персоны", numPersonal, "Остаток Персональных тренировок"));
            _myDataRowsList.Add(new DataGridItem("Спа", SpaStatus.ToString().Replace("_", " "), "Разрешена ли Спа зона"));
            _myDataRowsList.Add(new DataGridItem("Тренер", trenerName, "Имя Тренера, проводившего тренировку. Если известно"));
            _myDataRowsList.Add(new DataGridItem("Расписание Группы", groupTimeNameInfo, "Название и время Групповой тренировки. Если известно."));
            _myDataRowsList.Add(new DataGridItem("Администратор", CurrAdmName, "Администратор в клубе на момент посещения"));
            _myDataRowsList.Add(new DataGridItem("Покупка абонем.", $"{AbonStartDate:d}", "Дата Покупки абонемента"));
            _myDataRowsList.Add(new DataGridItem("Конец абонем.", $"{AbonEndDate:d}", "Дата Конеца абонемента"));
        }

        /// <summary>
        /// Создает массив со значениями полей в текущем посещении
        /// </summary>
        /// <returns></returns>
        public object[] GetValues()
        {
            // Создаем массив с полями и заголовками будущей таблицы по текущему посещению
            if (_myDataRowsList == null)
            {
                _myDataRowsList = new List<DataGridItem>();
                CreateReportList();
            }
            // Основной массив с данными
            var temp = _myDataRowsList.Select(x => x.Value).ToArray<object>();
            return temp;
        }

        /// <summary>
        /// Возвращает массив с названиями Полей в такой же очередности что и в функции GetValues. Не менять порядок!!!
        /// </summary>
        /// <returns></returns>
        public DataColumn[] GetHeadersForValues()
        {
            // Создаем массив с полями и заголовками будущей таблицы по текущему посещению
            if (_myDataRowsList == null)
            {
                _myDataRowsList = new List<DataGridItem>();
                CreateReportList();
            }

            var headerNames = _myDataRowsList.Select(x => x.HeaderName).ToArray();

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
            if (_myDataRowsList == null)
            {
                _myDataRowsList = new List<DataGridItem>();
                CreateReportList();
            }

            // Основной массив с данными
            var helpStrings = _myDataRowsList.Select(x => x.HeaderToolTipHelp).ToArray();

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
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        #endregion

    }
}
