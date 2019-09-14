using PersonsBase.data;
using PersonsBase.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PBase
{
    [Serializable]
    public class Logic
    {
        #region/// ОБЬЕКТЫ Приватные //////////////////////////////

        [NonSerialized]
        private static Logic _logicInstance;  //Singleton.

        private Options _options;
        private DataBaseClass _dataBase;
        private SortedList<string, Person> _persons;

        #endregion

        #region/// Синглтон ////
        public static Logic GetInstance()
        {
            return _logicInstance ?? (_logicInstance = new Logic());
        }
        #endregion

        #region///  События ////

        // Клиент Отметился на тренировке
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        [field: NonSerialized]
        public event Action<string, WorkoutOptions> VisitEvent;
        public void OnVisitedChanged(string personName, WorkoutOptions workout)
        {
            VisitEvent?.Invoke(personName, workout);
        }

        #endregion

        #region /// КОНСТРУКТОР ////
        private Logic()
        {
            _options = Options.GetInstance();
            _dataBase = DataBaseClass.GetInstance();
            _persons = _dataBase.GetListPersons();
        }

        #endregion

        #region /// МЕТОДЫ ///

        public bool CheckInWorkout(string personName)
        {
            Person _person = DataObjects.GetPersonLink(personName);
            _person.AbonementCurent.TryActivate(); // Если не Активирован

            if (!IsAbonementValid(ref _person)) return false;

            var selectedOptions = new WorkoutOptions();

            // Условия для отображения\не отображения окна с выбором
            var isSingleVisit = _person.AbonementCurent is SingleVisit;
            var isByDays = _person.AbonementCurent is AbonementByDays;
            var isClubCard = _person.AbonementCurent is ClubCardA;

            var isTrenZallOnly = _person.AbonementCurent.trainingsType == TypeWorkout.Тренажерный_Зал;
            var isNoAeroAndPerson = (_person.AbonementCurent.NumAerobicTr + _person.AbonementCurent.NumPersonalTr) == 0;

            if (((isSingleVisit || isByDays) && isTrenZallOnly) || (isClubCard && isNoAeroAndPerson))
            {
                selectedOptions.TypeWorkout = _person.AbonementCurent.trainingsType;
                selectedOptions.GroupInfo = new Group();  // dummy
                selectedOptions.PersonalTrener = new Trener();// dummy
            }
            else
            {
                var dlgResult = FormsRunner.RunWorkoutOptionsForm(ref selectedOptions, _person.Name);
                if (dlgResult == DialogResult.Cancel) return false;
            }

            bool isSuccess = _person.AbonementCurent.CheckInWorkout(selectedOptions.TypeWorkout);
            if (isSuccess)
            {
                // Дополнительная информация для вывода если успешный учет.
                var infoAerobic = (_person.AbonementCurent.NumAerobicTr > 0) ? $"\r\nОсталось Аэробных: {_person.AbonementCurent.NumAerobicTr}" : "";
                var infoPersonal = (_person.AbonementCurent.NumPersonalTr > 0) ? $"\r\nОсталось Персональных: {_person.AbonementCurent.NumPersonalTr}" : "";

                MessageBox.Show($@"Осталось посещений: {_person.AbonementCurent.GetRemainderDays()}{infoAerobic}{infoPersonal}", @"Тренировка Учтена!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _person.AddToJournal(selectedOptions);

                OnVisitedChanged(personName, selectedOptions);

                IsAbonementValid(ref _person);
                return true;
            }
            else return false;
        }

        private static bool IsAbonementValid(ref Person _person)
        {
            bool result = true;
            // Если Кончился абонемент и не сработали проверки в других местах
            if (!_person.AbonementCurent.IsValid())
            {
                _person.AbonementCurent = null;
                if (_person.AbonementCurent == null)
                {
                    _person.Status = StatusPerson.Нет_Карты;
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Запрос Пароля Суперпользователя если необходимо. Запускает событие LockChangedEvent. 
        /// </summary>
        public void AccessRoot()
        {
            FormsRunner.RunPasswordForm();
        }

        public static bool SchedulesAddNote(MyTime time, ScheduleNote sch)
        {
            var _manhattanInfo = DataObjects.GetManhattanInfo();

            //  Проверка. Содержит ли список запись с добавляемым временем
            var isExist = _manhattanInfo.Schedule.Exists(x => (x.Time.HourMinuteTime.Equals(time.HourMinuteTime) && (x.WorkoutsName.Equals(sch.WorkoutsName))));
            if (isExist)
            {
                MessageBox.Show("Такая тренировка уже существует. Измените время или название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            _manhattanInfo.Schedule.Add(sch);
            return true;
        }

        public static bool SchedulesRemoveNote(MyTime time, ScheduleNote sch)
        {
            var _manhattanInfo = DataObjects.GetManhattanInfo();

            //  Проверка. Содержит ли список запись с добавляемым временем
            var isExist = _manhattanInfo.Schedule.Exists(x => (x.Time.HourMinuteTime.Equals(time.HourMinuteTime) && (x.WorkoutsName.Equals(sch.WorkoutsName))));
            if (isExist)
            {
                MessageBox.Show("Такая тренировка уже существует. Измените время или название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            _manhattanInfo.Schedule.Add(sch);
            return true;
        }
        #endregion
    }
}
