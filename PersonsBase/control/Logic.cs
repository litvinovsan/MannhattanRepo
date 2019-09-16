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

        private void OnVisitedChanged(string personName, WorkoutOptions workout)
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
            Person person = DataObjects.GetPersonLink(personName);
            person.AbonementCurent.TryActivate(); // Если не Активирован

            if (!IsAbonementValid(ref person)) return false;

            var selectedOptions = new WorkoutOptions();

            // Условия для отображения\не отображения окна с выбором
            var isSingleVisit = person.AbonementCurent is SingleVisit;
            var isByDays = person.AbonementCurent is AbonementByDays;
            var isClubCard = person.AbonementCurent is ClubCardA;

            var isTrenZallOnly = person.AbonementCurent.trainingsType == TypeWorkout.Тренажерный_Зал;
            var isNoAeroAndPerson = (person.AbonementCurent.NumAerobicTr + person.AbonementCurent.NumPersonalTr) == 0;

            if (((isSingleVisit || isByDays) && isTrenZallOnly) || (isClubCard && isNoAeroAndPerson))
            {
                selectedOptions.TypeWorkout = person.AbonementCurent.trainingsType;
                selectedOptions.GroupInfo = new Group();  // dummy
                selectedOptions.PersonalTrener = new Trener();// dummy
            }
            else
            {
                var dlgResult = FormsRunner.RunWorkoutOptionsForm(ref selectedOptions, person.Name);
                if (dlgResult == DialogResult.Cancel) return false;
            }

            bool isSuccess = person.AbonementCurent.CheckInWorkout(selectedOptions.TypeWorkout);
            if (isSuccess)
            {
                // Дополнительная информация для вывода если успешный учет.
                var infoAerobic = (person.AbonementCurent.NumAerobicTr > 0) ? $"\r\nОсталось Аэробных: {person.AbonementCurent.NumAerobicTr}" : "";
                var infoPersonal = (person.AbonementCurent.NumPersonalTr > 0) ? $"\r\nОсталось Персональных: {person.AbonementCurent.NumPersonalTr}" : "";

                MessageBox.Show($@"Осталось посещений: {person.AbonementCurent.GetRemainderDays()}{infoAerobic}{infoPersonal}", @"Тренировка Учтена!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                person.AddToJournal(selectedOptions);

                OnVisitedChanged(personName, selectedOptions);

                IsAbonementValid(ref person);
                return true;
            }
            else return false;
        }

        private static bool IsAbonementValid(ref Person person)
        {
            // Если Кончился абонемент и не сработали проверки в других местах
            if (person.AbonementCurent.IsValid()) return true;
            person.AbonementCurent = null;
            if (person.AbonementCurent != null) return true;
            person.Status = StatusPerson.Нет_Карты;
            return false;
        }

        /// <summary>
        /// Запрос Пароля Суперпользователя если необходимо. Запускает событие LockChangedEvent. 
        /// </summary>
        public void AccessRoot()
        {
            FormsRunner.RunPasswordForm();
        }

        #region /// ФОРМА Босса /// 
        public static bool SchedulesAdd2DataBase(MyTime time, ScheduleNote sch)
        {
            var manhattanInfo = DataObjects.GetManhattanInfo();

            //  Проверка. Содержит ли список запись с добавляемым временем
            bool isExist = manhattanInfo.Schedule.Exists(x => (x.Time.HourMinuteTime.Equals(time.HourMinuteTime) && (x.WorkoutsName.Equals(sch.WorkoutsName))));
            if (isExist)
            {
                MessageBox.Show("Такая тренировка уже существует. Измените время или название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            manhattanInfo.Schedule.Add(sch);
            return true;
        }

        public static int SchedulesRemoveDataBase(string time, string nameWorkout)
        {
            int result = 0;
            var manhattanInfo = DataObjects.GetManhattanInfo();

            //  Проверка. Содержит ли список запись с временем
            var isExist = manhattanInfo.Schedule.Exists(x => (x.Time.HourMinuteTime.Equals(time) && (x.WorkoutsName.Equals(nameWorkout))));
            var schl = new ScheduleNote(new MyTime(time), nameWorkout);

            if (isExist)
            {
                result = manhattanInfo.Schedule.RemoveAll(x => x.GetTimeAndNameStr().Equals(schl.GetTimeAndNameStr()));
            }

            return result;
        }

        // Работники Тренеры Админ
        public static bool EmployeeAdd2DataBase(Employee emploerToAdd)
        {
            var manhattanInfo = DataObjects.GetManhattanInfo();

            bool isTrener = emploerToAdd.IsTrener;
            bool isExist = false;

            //  Проверка. Содержится ли в списках такое имя. Если да - выходим.
            isExist = isTrener ? manhattanInfo.Treners.Exists(x => (x.Name.Equals(emploerToAdd.Name))) : manhattanInfo.Admins.Exists(x => (x.Name.Equals(emploerToAdd.Name)));

            if (isExist)
            {
                MessageBox.Show("Такое имя уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (isTrener)
                manhattanInfo.Treners.Add(new Trener(emploerToAdd.Name) { Phone = emploerToAdd.Phone });
            else
                manhattanInfo.Admins.Add(new Administrator(emploerToAdd.Name) { Phone = emploerToAdd.Phone });

            return true;
        }

        public static void EmployeeRemoveDataBase(string name, bool isTrener)
        {
            var manhattanInfo = DataObjects.GetManhattanInfo();

            bool isExist = false;

            //  Проверка. Содержит ли список
            isExist = isTrener ? manhattanInfo.Treners.Exists(x => (x.Name.Equals(name))) : manhattanInfo.Admins.Exists(x => (x.Name.Equals(name)));

            if (!isExist) return; // нет такого имени в списке базы данных

            if (isTrener)
            {
                manhattanInfo.Treners.RemoveAll(x => x.Name.Equals(name));
            }
            else
            {
                manhattanInfo.Admins.RemoveAll(x => x.Name.Equals(name));
            }
        }
        #endregion


        #endregion
    }
}
