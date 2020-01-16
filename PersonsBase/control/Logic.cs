using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.View;
using Group = PersonsBase.data.Group;

namespace PersonsBase.control
{
    [Serializable]
    public class Logic
    {
        #region/// Синглтон ////

        public static Logic GetInstance()
        {
            return _logicInstance ?? (_logicInstance = new Logic());
        }

        #endregion

        #region/// ОБЬЕКТЫ Приватные /////

        [NonSerialized] private static Logic _logicInstance; //Singleton.
        // Маркеры для выделения красным цветом в таблице ShortInfo. Если текст равен...
        private const string StrMorning = "Утро";
        private const string StrNoPay = "Не_Оплачено";

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

        /// <summary>
        /// Загрузка фотографии в PictureBox на форме. Выполняется проверка на существование фотки на диске
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="pathToPhoto"></param>
        public static void TryLoadPhoto(PictureBox pictureBox, string pathToPhoto)
        {
            if (String.IsNullOrEmpty(pathToPhoto))
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
        public static void CheckForDigits(KeyPressEventArgs e)
        {
            var number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
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
                MessageBox.Show(@"Такая тренировка уже существует. Измените время или название!", @"Внимание",
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
                    MessageBox.Show(@"Такое имя уже существует!", @"Внимание", MessageBoxButtons.OK,
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

        #region /// КЛИЕНТ. СОЗДАНИЕ. УДАЛЕНИЕ. РЕДАКТИРОВАНИЕ ///

        /// <summary>
        /// Запуск Формы создания клиента
        /// </summary>
        /// <returns></returns>
        public static bool CreatePerson()
        {
            string createdPersoName;

            var isSuccess = FormsRunner.RunCreatePersonForm(out createdPersoName);

            if (isSuccess)
            {
                var res = MessageBox.Show(@"Желаете Добавить Абонемент?", @"Клиент Добавлен!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //  Создаем Абонемент если выбрали Да
                if (res == DialogResult.Yes) AddAbonement(createdPersoName);
            }

            return isSuccess;
        }

        public static bool RemovePerson()
        {
            if (!FormsRunner.RunSelectPersonForm(out var selectedName, "УДАЛЕНИЕ КЛИЕНТА")) return false;

            if (String.IsNullOrEmpty(selectedName)) return false;

            var res = MessageBox.Show($@"{selectedName}", @"Удалить клиента из базы???", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.No) return false;

            var response = DataBaseLevel.GetInstance().PersonRemove(selectedName);
            return (response == ResponseCode.Success);
        }

        /// <summary>
        /// Создает и возвращает новый обьект Person из значений в dataStruct. Используется для
        /// сбора всех параметров с формы создания клиента.
        /// </summary>
        /// <param name="dataStruct"></param>
        /// <returns></returns>
        public static Person CreateNewPerson(PersonalDataStruct dataStruct)
        {
            var p = new Person(dataStruct.Name)
            {
                BirthDate = dataStruct.BDate,
                GenderType = dataStruct.Gender,
                DriverIdNum = dataStruct.DriveId,
                Passport = dataStruct.Passport,
                PathToPhoto = dataStruct.PathToPhoto,
                PersonalNumber = dataStruct.PersonalNumber,
                Phone = dataStruct.Phone,
                SpecialNotes = dataStruct.SpecialNotes,
            };
            return p;
        }

        /// <summary>
        /// Подготавливает строку с именем, приводит в  заглавный формат Фамилия Имя Отчество вместо  фамилия имя отчество
        /// </summary>
        /// <param name="fio"></param>
        /// <returns></returns>
        public static string PrepareName(string fio)
        {
            if (String.IsNullOrWhiteSpace(fio) || String.IsNullOrEmpty(fio))
            {
                return "";
            }

            string resultName = String.Empty;
            var minimumSpaces = Regex.Replace(fio.ToLower().Trim(), @"[^\S\r\n]+", " "); // Уплотняем пробелы
            var lowercase = minimumSpaces.ToLower();

            var fioArray = lowercase.Split(' ');

            foreach (var item in fioArray)
            {
                var tempWord = item;
                if (!Char.IsLetterOrDigit(item[0]))
                {
                    tempWord = tempWord.Remove(0, 1);
                    if (tempWord.Length == 0) break;
                }
                var c = Char.ToUpper(tempWord[0]);
                resultName += c + tempWord.Remove(0, 1) + " ";
            }

            return resultName.Trim();
        }

        #endregion

        #region /// КАРТОЧКА КЛИЕНТА. СКАНЕР  ///
        /// <summary>
        /// Открывает карточку клиента namePerson
        /// </summary>
        /// <param name="namePerson"></param>
        public static void OpenPersonCard(string namePerson)
        {
            if (String.IsNullOrEmpty(namePerson)) return;

            FormsRunner.RunClientForm(namePerson);
        }

        /// <summary>
        /// Выбор из списка клиентов, открытие карточки клиента
        /// </summary>
        public static void SelectPerson()
        {
            // Выбор имени Клиента
            if (!FormsRunner.RunSelectPersonForm(out var selectedName, "Cписок Клиентов")) return;

            if (String.IsNullOrEmpty(selectedName) || String.IsNullOrWhiteSpace(selectedName)) return;

            OpenPersonCard(selectedName);
        }

        /// <summary>
        /// Вызывает метод Запуска формы сканирования по штрих коду. Если успешно найден код - Открывает карточку клиента
        /// </summary>
        public static void BarCodeOpen()
        {
            var name = GetBarCodeName();
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) return;

            OpenPersonCard(name);
        }

        /// <summary>
        /// Запуск окна для Считывания Штрих кода. Возвращает Имя Клиента если Ок. Либо null если нету
        /// </summary>
        /// <returns></returns>
        private static string GetBarCodeName()
        {
            return FormsRunner.RunBarCodeForm(out var namePerson) ? namePerson : "";
        }
        #endregion

        #region /// СОЗДАНИЕ ОТЧЕТА по КЛИЕНТАМ ///

        /// <summary>
        /// Создание,запуск и работа с отчетами о клиенте. 
        /// </summary>
        public static void CreateReport()
        {
            FormsRunner.RunReportForm();
        }

        #endregion

        #region /// АБОНЕМЕНТ и ТРЕНИРОВКИ.

        public static bool SellAbonement()
        {
            if (!FormsRunner.RunSelectPersonForm(out var selectedName, "Выберите клиента для добавления Абонемента")) return false;

            if (String.IsNullOrEmpty(selectedName)) return false;

            var res = MessageBox.Show($@"{selectedName}", @"Добавить абонемент?", MessageBoxButtons.YesNo,
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
                var result = MessageBox.Show($@"Действует:  {person.AbonementCurent.AbonementName}.Добавить новый абонемент к существующему?", @"Добавление Абонемента", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

            Visit.AddVisit2Journal(person, selectedOptions);

            OnVisitChanged(personName, selectedOptions);

            IsAbonementValid(ref person);
            return true;
        }
        #endregion

        #region /// ДЛЯ Создания ТАБЛИЦ на ClientForms /// Подготовка для отображения на Клиентской форме

        public static void LoadShortInfo(GroupBox gbBoxToShow, Person person)
        {
            CreateShortInfo(gbBoxToShow, person);
        }

        private static void CreateShortInfo(GroupBox gbBoxToShow, Person person)
        {
            var labelTextBoxList = CreateLabelTextBoxList(person);

            // Отрисовка Short Info
            var table = CreateTable(labelTextBoxList); // Создаем таблицу c элементами из списка. Таблица: Лэйбл - Текстбокс

            AddTableToGroupBox(table, gbBoxToShow);
        }

        private static void AddTableToGroupBox(TableLayoutPanel table, GroupBox grpBx)
        {
            if (grpBx.Controls.Count != 0)
            {
                grpBx.Controls.Clear();
            }
            grpBx.Controls.Add(table); // Выводим на групбокс нашу новую ShortInfo Table
        }

        private static List<Tuple<Label, Control>> CreateLabelTextBoxList(Person person)
        {
            var labelTextBoxList = new List<Tuple<Label, Control>>();
            if (person.IsAbonementExist())
            {
                labelTextBoxList.AddRange(TupleConverter(person.AbonementCurent.GetShortInfoList()));
                // Добавляем Поле Статуса. Делаем тут потому что Person.abonem не знает об этом.
                var status = person.Status.ToString();
                labelTextBoxList.Insert(1, CreateRowInfo("Текущий статус Клиента", status));
            }
            else
            {
                labelTextBoxList.AddRange(TupleConverter(GetEmptyInfoList(person)));
            }

            return labelTextBoxList;
        }

        public static TableLayoutPanel CreateTable(List<Tuple<Label, Control>> list)
        {// Создает таблицу с элементами из List. Таблица вида: Лэйбл - Значение.
            var tableInfo = new TableLayoutPanel { Dock = DockStyle.Fill };
            // Базовая таблица. 1 стр, 2 стлб
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));

            for (int i = 0; i < list.Count; i++)
            {
                tableInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                tableInfo.Controls.Add(list[i].Item1, 0, i);
                tableInfo.Controls.Add(list[i].Item2, 1, i);
            }

            // Пустые элементы. Без них сьезжает вся разметка.
            tableInfo.Controls.Add(new Panel(), 0, list.Count);
            tableInfo.Controls.Add(new Panel(), 1, list.Count);

            return tableInfo;
        }

        private static IEnumerable<Tuple<string, string>> GetEmptyInfoList(Person person)
        {
            var result = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Текущий статус Клиента", person.Status.ToString()),
                new Tuple<string, string>("Абонемент ", "Нет"),
                new Tuple<string, string>("Клубная Карта ", "Нет ")
            };

            return result;
        }

        /// <summary>
        /// Тюпл Сборка ИмяПоля-Поле, содержащие конкретные значения, например, Статус оплаты
        /// </summary>
        /// <param name="label"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        private static Tuple<Label, Control> CreateRowInfo(string label, string info)
        {// Создаем экземпляры Label и TextBox. Настройка отображения и свойст тут
            var lb = new Label
            {
                Text = label,
                Anchor = AnchorStyles.Left,
                AutoSize = true,
                TextAlign = ContentAlignment.TopLeft
            };

            var tb = new TextBox
            {
                BackColor = Color.AliceBlue,
                BorderStyle = BorderStyle.FixedSingle,
                Text = @" " + info.Replace("_", " "),
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 9F)
            };

            // Выделение цветом по какому-либо признакму
            if (info == StrNoPay || info == StrMorning) tb.BackColor = Color.LightPink;

            return Tuple.Create<Label, Control>(lb, tb);
        }

        private static IEnumerable<Tuple<Label, Control>> TupleConverter(IEnumerable<Tuple<string, string>> data)
        {// Преобразует Список вида List<Tuple<string, string>> в универсальный Список: List<Tuple<Label, Control>>
            List<Tuple<Label, Control>> result = data.Select(item => CreateRowInfo(item.Item1, item.Item2)).ToList();

            // Выделяем жирным первую строку
            result[0].Item1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            result[0].Item2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            result[0].Item1.ForeColor = Color.FromArgb(0, 64, 64);
            result[0].Item2.ForeColor = Color.FromArgb(0, 64, 64);

            return result;
        }

        #endregion

        #region /// РАБОТА с CONTROLS формы ///
        /// <summary>
        /// Задает Цвет Текстбоксам и другим элементам. Зеленый если == , Красный если != аргументы. 
        /// </summary>
        public static void SetFontColor(Control ctrl, string actual, string expected)
        {
            ctrl.ForeColor = actual == expected ? Color.Green : Color.Red;
        }
        /// <summary>
        /// // Задает Цвет SystemColors.Window если == , И Yellow если != аргументы.
        /// </summary>
        public static void SetControlBackColor(Control ctrl, string current, string expected)
        {
            Color clrSuccess = SystemColors.Window;
            Color clrFail = Color.Yellow;
            ctrl.BackColor = current == expected ? clrSuccess : clrFail;
        }

        /// <summary>
        /// Перебираем все контролы рекурсивно. Выполняем для каждого действие action
        /// </summary>
        public static void ForAllControls(Control parent, Action<Control> action)
        {
            foreach (Control c in parent.Controls)
            {
                action(c);
                ForAllControls(c, action);
            }
        }

        /// <summary>
        /// Снимает выделение по всем контролам в групбоксе
        /// </summary>
        public static void ClearSelection(Control control)
        {
            ForAllControls(control, x =>
            {
                if (!(x is ComboBox box)) return;
                box.SelectionLength = 0;
                box.Select(0, 0);
                box.BackColor = SystemColors.Window;
            });
        }

        public static void SetControlsColorDefault(Control control)
        {
            ForAllControls(control, x =>
            {
                switch (x)
                {
                    case ComboBox box:
                        box.BackColor = SystemColors.Window;
                        break;
                    case TextBox textBox:
                        textBox.BackColor = SystemColors.Window;
                        break;
                }
            });
        }
        #endregion

        #region ///  ВРЕМЯ ///
        /// <summary>
        /// Форматирование Текущего времени
        /// </summary>
        /// <returns></returns>
        public static string ClockFormating()
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            string time = "";
            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }
            time += ":";
            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }
            time += ":";
            if (s < 10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }
            return time;
        }
        public static string ClockFormating(int hour, int minute)
        {
            int h = hour;
            int m = minute;

            string time = "";
            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }

            time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }
            return time;
        }
        #endregion


    }
}