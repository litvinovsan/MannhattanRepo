using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.View;

namespace PersonsBase.control
{
    [Serializable]
    public class Logic
    {
        #region /// КОНСТРУКТОР ////

        private Logic()
        {
            _options = Options.GetInstance();
            _dataBase = DataBaseLevel.GetInstance();
            _persons = DataBaseLevel.GetListPersons();
        }

        #endregion

        #region/// Синглтон ////

        public static Logic GetInstance()
        {
            return _logicInstance ?? (_logicInstance = new Logic());
        }

        #endregion

        #region/// ОБЬЕКТЫ Приватные //////////////////////////////

        [NonSerialized] private static Logic _logicInstance; //Singleton.

        private Options _options;
        private DataBaseLevel _dataBase;
        private SortedList<string, Person> _persons;

        #endregion

        #region///  События ////

        // Клиент Отметился на тренировке

        [field: NonSerialized] public event Action<string, WorkoutOptions> VisitEvent;

        private void OnVisitChanged(string personName, WorkoutOptions workout)
        {
            VisitEvent?.Invoke(personName, workout);
        }

        #endregion

        #region /// РАЗНЫЕ МЕТОДЫ ///

        public bool CheckInWorkout(string personName)
        {
            var person = DataBaseO.GetPersonLink(personName);
            person.AbonementCurent.TryActivate(); // Если не Активирован

            if (!IsAbonementValid(ref person)) return false;

            // Условия для отображения\не отображения окна с выбором
            var isSingleVisit = person.AbonementCurent is SingleVisit;
            var isByDays = person.AbonementCurent is AbonementByDays;
            var isClubCard = person.AbonementCurent is ClubCardA;

            var isTrenZallOnly = person.AbonementCurent.TrainingsType == TypeWorkout.Тренажерный_Зал;
            var isNoAeroAndPerson = person.AbonementCurent.NumAerobicTr + person.AbonementCurent.NumPersonalTr == 0;

            var selectedOptions = new WorkoutOptions();

            if ((isSingleVisit || isByDays) && isTrenZallOnly || isClubCard && isNoAeroAndPerson)
            {
                selectedOptions.TypeWorkout = person.AbonementCurent.TrainingsType;
                selectedOptions.GroupInfo = new Group(); // dummy
                selectedOptions.PersonalTrener = new Trener(); // dummy
            }
            else
            {
                var dlgResult = FormsRunner.RunWorkoutOptionsForm(ref selectedOptions, person.Name);
                if (dlgResult == DialogResult.Cancel) return false;
            }

            var isSuccess = person.AbonementCurent.CheckInWorkout(selectedOptions.TypeWorkout);

            if (!isSuccess) return false;

            // Дополнительная информация для вывода если успешный учет.
            var infoAerobic = person.AbonementCurent.NumAerobicTr > 0
                ? $"\r\nОсталось Аэробных: {person.AbonementCurent.NumAerobicTr}"
                : "";
            var infoPersonal = person.AbonementCurent.NumPersonalTr > 0
                ? $"\r\nОсталось Персональных: {person.AbonementCurent.NumPersonalTr}"
                : "";

            MessageBox.Show(
                $@"Осталось посещений: {person.AbonementCurent.GetRemainderDays()}{infoAerobic}{infoPersonal}",
                @"Тренировка Учтена!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            person.AddToJournal(selectedOptions);

            OnVisitChanged(personName, selectedOptions);

            IsAbonementValid(ref person);
            return true;
        }

        public static void TryLoadPhoto(PictureBox pictureBox, string pathToPhoto)
        {
            if (string.IsNullOrEmpty(pathToPhoto))
            {
                pictureBox.Image = null;
                return;
            }

            try
            {
                if (Photo.IsPhotoExist(pathToPhoto))
                {
                    pictureBox.Image = Photo.OpenPhoto(pathToPhoto);
                    pictureBox.Invalidate();
                }
                else
                {
                    pictureBox.Image = null;
                }
            }
            catch
            {
                pictureBox.Image = null;
            }
            pictureBox.Refresh();
        }

        /// <summary>
        ///     Запрос Пароля Суперпользователя если необходимо. Запускает событие LockChangedEvent.
        /// </summary>
        public static void AccessRootUser()
        {
            FormsRunner.RunPasswordForm();
        }
        #endregion

        #region /// ФОРМА Босса /// 

        public static bool SchedulesAdd2DataBase(MyTime time, ScheduleNote sch)
        {
            var manhattanInfo = DataBaseO.GetManhattanInfo();

            //  Проверка. Содержит ли список запись с добавляемым временем
            var isExist = IsSchedExists(time.HourMinuteTime, sch.WorkoutsName, manhattanInfo);
            if (isExist)
            {
                MessageBox.Show(@"Такая тренировка уже существует. Измените время или название!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            manhattanInfo.Schedule.Add(sch);
            return true;
        }

        public static void SchedulesRemoveDataBase(string time, string nameWorkout)
        {
            var manhattanInfo = DataBaseO.GetManhattanInfo();

            //  Проверка. Содержит ли список запись с временем
            var isExist = IsSchedExists(time, nameWorkout, manhattanInfo);
            var schl = new ScheduleNote(new MyTime(time), nameWorkout);

            if (isExist) manhattanInfo.Schedule.RemoveAll(x => x.GetTimeAndNameStr().Equals(schl.GetTimeAndNameStr()));
        }

        private static bool IsSchedExists(string time, string nameWorkout, ManhattanInfo manhattanInfo)
        {
            return manhattanInfo.Schedule.Exists(x =>
                x.Time.HourMinuteTime.Equals(time) && x.WorkoutsName.Equals(nameWorkout));
        }

        // Работники Тренеры Админ
        public static bool EmployeeAdd2DataBase(Employee emploerToAdd)
        {
            var manhattanInfo = DataBaseO.GetManhattanInfo();

            var isTrener = emploerToAdd.IsTrener;

            //  Проверка. Содержится ли в списках такое имя. Если да - выходим.
            if (IsEmploeeExists(emploerToAdd, manhattanInfo))
            {
                var oldPhone = GetPhoneFromBase(emploerToAdd, manhattanInfo);
                var phoneNotChanged = emploerToAdd.Phone.Equals(oldPhone);

                if (phoneNotChanged)
                {
                    MessageBox.Show(@"Такое имя уже существует!", "Внимание", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return false;
                }

                // Обновляем номер телефона
                if (isTrener)
                    FindTrenerInBase(emploerToAdd, manhattanInfo).Phone = emploerToAdd.Phone;
                else
                    FindAdminInBase(emploerToAdd, manhattanInfo).Phone = emploerToAdd.Phone;
                return false; // Чтобы не добавлялся ещё один элемент в список. т.к. он уже есть
            }

            AddEmploee(emploerToAdd, manhattanInfo);
            return true;
        }

        private static void AddEmploee(Employee emploerToAdd, ManhattanInfo manhattanInfo)
        {
            if (emploerToAdd.IsTrener)
                manhattanInfo.Treners.Add(new Trener(emploerToAdd.Name, emploerToAdd.Phone));
            else
                manhattanInfo.Admins.Add(new Administrator(emploerToAdd.Name, emploerToAdd.Phone));
        }

        private static Trener FindTrenerInBase(Employee emploerToAdd, ManhattanInfo manhattanInfo)
        {
            Trener result;
            try
            {
                result = manhattanInfo.Treners.Find(x => x.Name.Equals(emploerToAdd.Name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        private static Administrator FindAdminInBase(Employee emploerToAdd, ManhattanInfo manhattanInfo)
        {
            Administrator result;
            try
            {
                result = manhattanInfo.Admins.Find(x => x.Name.Equals(emploerToAdd.Name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        /// <summary>
        ///     Возвращает номер телефона работника из Базы Manhattan. Автоматически смотрит кто это, тренер или админ
        /// </summary>
        private static string GetPhoneFromBase(Employee emploerToAdd, ManhattanInfo manhattanInfo)
        {
            var result = emploerToAdd.IsTrener
                ? manhattanInfo.Treners.Find(x => x.Name.Equals(emploerToAdd.Name)).Phone
                : manhattanInfo.Admins.Find(x => x.Name.Equals(emploerToAdd.Name)).Phone;
            return result;
        }

        private static bool IsEmploeeExists(Employee emploerToAdd, ManhattanInfo manhattanInfo)
        {
            var result = emploerToAdd.IsTrener
                ? manhattanInfo.Treners.Exists(x => x.Name.Equals(emploerToAdd.Name))
                : manhattanInfo.Admins.Exists(x => x.Name.Equals(emploerToAdd.Name));
            return result;
        }

        public static void EmployeeRemoveDataBase(string name, bool isTrener)
        {
            var manhattanInfo = DataBaseO.GetManhattanInfo();

            //  Проверка. Содержит ли список
            var isExist = isTrener
                ? manhattanInfo.Treners.Exists(x => x.Name.Equals(name))
                : manhattanInfo.Admins.Exists(x => x.Name.Equals(name));

            if (!isExist) return; // нет такого имени в списке базы данных

            if (isTrener)
                manhattanInfo.Treners.RemoveAll(x => x.Name.Equals(name));
            else
                manhattanInfo.Admins.RemoveAll(x => x.Name.Equals(name));
        }

        #endregion

        #region /// КЛИЕНТ. СОЗДАНИЕ  ///

        public static bool CreatePerson()
        {
            string createdPersoName;

            var isSuccess = FormsRunner.RunCreatePersonForm(out createdPersoName);

            if (isSuccess)
            {
                var res = MessageBox.Show(@"Желаете Добавить Абонемент?", "Клиент Добавлен!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //  Создаем Абонемент если выбрали Да
                if (res == DialogResult.Yes) AddAbonement(createdPersoName);
            }

            return isSuccess;
        }

        #endregion

        #region /// КЛИЕНТ. УДАЛЕНИЕ ///
        public static bool RemovePerson()
        {
            if (!FormsRunner.RunSelectPersonForm(out var selectedName, "УДАЛЕНИЕ КЛИЕНТА")) return false;

            if (string.IsNullOrEmpty(selectedName)) return false;

            var res = MessageBox.Show($@"{selectedName}", @"Удалить клиента из базы???", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.No) return false;

            var response = DataBaseLevel.GetInstance().PersonRemove(selectedName);
            return (response == ResponseCode.Success);
        }

        #endregion

        #region /// КЛИЕНТ. ПЕРСОНАЛЬНАЯ КАРТОЧКА  ///
        /// <summary>
        /// Открывает карточку клиента namePerson
        /// </summary>
        /// <param name="namePerson"></param>
        public static void OpenPersonCard(string namePerson)
        {
            if (string.IsNullOrEmpty(namePerson)) return;

            FormsRunner.RunClientForm(namePerson);
        }

        /// <summary>
        /// Выбор из списка клиентов, открытие карточки клиента
        /// </summary>
        public static void SelectPerson()
        {
            // Выбор имени Клиента
            if (!FormsRunner.RunSelectPersonForm(out var selectedName, "Cписок Клиентов")) return;

            if (string.IsNullOrEmpty(selectedName) || string.IsNullOrWhiteSpace(selectedName)) return;

            OpenPersonCard(selectedName);
        }

        #endregion

        #region /// АБОНЕМЕНТ.

        public static bool SellAbonement()
        {
            if (!FormsRunner.RunSelectPersonForm(out var selectedName, "Продажа Абонемента")) return false;

            if (string.IsNullOrEmpty(selectedName)) return false;

            var res = MessageBox.Show($@"{selectedName}", @"Добавить Абонемент клиенту:?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.No) return false;

            var isSuccess = AddAbonement(selectedName);
            return (isSuccess);
        }

        public static bool AddAbonement(string personName)
        {
            var person = DataBaseO.GetPersonLink(personName);
            if (person == null) return false;

            var dialogResult = DialogResult.Cancel;
            if (person.AbonementCurent == null)
            {
                dialogResult = FormsRunner.CreateAbonementForm(person.Name);
            }
            else
            {
                var result = MessageBox.Show($@"Действует:  {person.AbonementCurent.AbonementName}.
Добавить новый абонемент к существующему?", "Добавление Абонемента", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dialogResult = FormsRunner.CreateAbonementForm(person.Name);
                }
            }

            return dialogResult == DialogResult.OK;
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



        #endregion
    }
}