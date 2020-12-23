using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;
using PersonsBase.View;

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

        #region/// ОБЬЕКТЫ /////

        [NonSerialized] private static Logic _logicInstance;

        // Маркеры для выделения красным цветом в таблице ShortInfo. Если текст равен...
        private const string StrMorning = "Утро";
        private const string StrNoPay = "Не_Оплачено";

        private readonly DailyVisits _dailyVisits = DailyVisits.GetInstance();

        #endregion

        #region /// РАЗНЫЕ МЕТОДЫ ///

        /// <summary>
        /// Загрузка фотографии в PictureBox на форме.
        /// На вход подать либо полный путь, либо только имя файла.
        /// Поиск в стандартных директориях
        /// Выполняется проверка на существование фотки на диске
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="pathOrNamePhoto"></param>
        /// <param name="inputGender">Пол клиента</param>
        public static bool TryLoadPhoto(PictureBox pictureBox, string pathOrNamePhoto, Gender inputGender)
        {
            var gender = inputGender;
            var result = true;
            var fileName = pathOrNamePhoto;
            if (string.IsNullOrEmpty(fileName))
            {
                // Если разрешены фейковые фото и не присвоена реальная фотка
                if (Options.SimpsonsPhoto)
                {
                    fileName = Photo.GetRndPhoto(gender);
                }
                else
                {
                    pictureBox.Image = null;
                    return false;
                }
            }

            try
            {
                if (string.IsNullOrEmpty(fileName)) return false;

                var path = Photo.GetFullPathToPhoto(fileName);

                if (MyFile.IsFileExist(path))
                {
                    pictureBox.Image = Photo.OpenPhoto(path);
                    pictureBox.Invalidate();
                }
                else
                {
                    pictureBox.Image = null;
                    result = false;
                }
            }
            catch
            {
                pictureBox.Image = null;
            }

            pictureBox.Refresh();
            return result;
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
            if (!char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
            // KeyEventArgs e
            // if (e.KeyCode == Keys.Enter) // Если нажат Enter
        }

        public static void SaveEverithing()
        {
            var saveTask = new Task(() =>
              {
                  try
                  {
                      Options.SaveProperties(); // Сохранение пользовательских настроек
                      DataBaseLevel.SerializeObjects();
                      AbonementController.GetInstance().Save();
                  }
                  catch (Exception e)
                  {
                      MessageBox.Show(e.Message);
                      using (var sw = new StreamWriter("errors.log", true))
                      {
                          sw.WriteLine(DateTime.Now + " " + e.Message);
                      }
                  }
              });

            saveTask.Start();
        }

        #endregion

        #region /// ФОРМА Босса /// 

        public static bool SchedulesAdd2DataBase(MyTime time, ScheduleNote sch)
        {
            var manhattanInfo = DataBaseLevel.GetManhattanInfo();

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
            var manhattanInfo = DataBaseLevel.GetManhattanInfo();

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
            var manhattanInfo = DataBaseLevel.GetManhattanInfo();

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
            var manhattanInfo = DataBaseLevel.GetManhattanInfo();

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

        #region /// КЛИЕНТ. СОЗДАНИЕ. УДАЛЕНИЕ. РЕДАКТИРОВАНИЕ. ПРОВЕРКИ ///

        /// <summary>
        /// Запуск Формы создания клиента
        /// </summary>
        /// <returns></returns>
        public static bool CreatePerson()
        {
            var isSuccess = FormsRunner.RunCreatePersonForm(out var createdPersoName);

            if (!isSuccess) return false;
            var res = MessageBox.Show(@"Желаете Добавить Абонемент?", @"Клиент Добавлен!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            //  Создаем Абонемент если выбрали Да
            if (res == DialogResult.Yes) AddAbonement(createdPersoName);
            OpenPersonCard(createdPersoName);
            SaveEverithing(); //Сохраним в базу клиентов
            return true;
        }

        public static bool RemovePerson()
        {
            if (!FormsRunner.RunSelectPersonForm(out var selectedName, "УДАЛЕНИЕ КЛИЕНТА")) return false;

            if (string.IsNullOrEmpty(selectedName)) return false;

            var res = MessageBox.Show($@"{selectedName}", @"Удалить клиента из базы???", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.No) return false;

            var response = DataBaseLevel.PersonRemove(selectedName);
            if (response == ResponseCode.Success)
            {
                // Удаляем из журнала посещений данные о selectedName клиенте
                if (DataBaseLevel.GetPersonsVisitDict().ContainsKey(selectedName))
                {
                    DataBaseLevel.GetPersonsVisitDict().Remove(selectedName);
                }

                // Удаляем из журнала посещений данные о selectedName клиенте
                if (DataBaseLevel.GetPersonsAbonHistDict().ContainsKey(selectedName))
                {
                    DataBaseLevel.GetPersonsAbonHistDict().Remove(selectedName);
                }
            }

            SaveEverithing();
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
                PathToPhoto = dataStruct.photoName,
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

            // Удаляет все пустые подстроки
            // text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
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

        /// <summary>
        ///  Возвращает длинну  числовой строки содержащей маскировочные символы, например для телефона в maskedTextbox
        /// То есть из строки "8(912) -  -" вернет только  длинну 8(912.
        /// </summary>
        /// <param name="maskedText"></param>
        /// <returns></returns>
        public static int GetLenght(string maskedText)
        {
            var resultString = maskedText;

            while (resultString.Length > 0)
            {
                var lastIndex = resultString.Length - 1;
                var lastCharInString = resultString[lastIndex];
                if (char.IsDigit(lastCharInString))
                {
                    return lastIndex + 1;
                }

                resultString = resultString.Remove(lastIndex).Trim();
            }

            return resultString.Length;
        }

        /// <summary>
        /// Возвращает строку содержащей маскировочные символы, например для телефона в maskedTextbox
        /// То есть из строки "8(912) -  -" вернет только   8(912.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string RemoveEmptySymbols(string inputString)
        {
            int length = Logic.GetLenght(inputString);
            string resultString = inputString.Substring(0, length);

            return resultString;
        }

        /// <summary>
        /// Метод пытается изменить Имя Клиента. Если Успешно, переименовывает файл с фотографией и перезаписывает Путь до фотки
        /// </summary>
        /// <param name="curentName"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public static bool ChangePersonName(string curentName, string newName)
        {
            if (string.IsNullOrEmpty(curentName) || string.IsNullOrEmpty(newName)) return false;

            var oldName = string.Copy(curentName);
            // Получаем обьекты для работы
            var person = PersonObject.GetLink(oldName);
            // Если текущее имя совпадает с новым
            if (person.Name == newName) return false;
            // Пытаемся переименовать старое имя в новое
            var isSuccess = DataBaseLevel.PersonEditName(person.Name, newName);

            // Переименование коллекции с Посещениями
            if (isSuccess)
            {
                DataBaseLevel.GetPersonsVisitDict().RenameKey(oldName, PrepareName(newName));
                DataBaseLevel.GetPersonsAbonHistDict().RenameKey(oldName, PrepareName(newName));
            }

            // Переименование файлов и Пути к фотке
            if (isSuccess)
            {
                var isRenamedOk = MyFile.TryRenameFile(person.PathToPhoto, newName);
                if (isRenamedOk)
                {
                    DataBaseM.EditPathToPhoto(newName, newName);
                }
            }

            // Переименование в контроллере абонементов
            if (isSuccess)
            {
                AbonementController.GetInstance().GetPersonsDictn().RenameKey(oldName, PrepareName(newName));
            }
            //

            return isSuccess;
        }

        public static string GetPersonShortName(string nameLong)
        {
            if (string.IsNullOrWhiteSpace(nameLong) || string.IsNullOrEmpty(nameLong)) return string.Empty;

            var longNameArray = PrepareName(nameLong).Split(' ');

            var totalString = new StringBuilder();
            totalString.Append(longNameArray[0] + " ");

            for (var i = 1; i < longNameArray.Length; i++)
            {
                var firstLetter = longNameArray[i][0];
                totalString.Append(firstLetter + ". ");
            }

            return totalString.ToString().Trim();
        }


        #endregion

        #region /// КАРТОЧКА КЛИЕНТА. СКАНЕР  ///

        /// <summary>
        /// Открывает карточку клиента namePerson
        /// </summary>
        /// <param name="namePerson"></param>
        public static void OpenPersonCard(string namePerson)
        {
            if (string.IsNullOrEmpty(namePerson)) return;

            try
            {
                FormsRunner.RunClientForm(namePerson);
            }
            catch (Exception e)
            {
                using (var sw = new StreamWriter("errors.log", true))
                {
                    sw.WriteLine(DateTime.Now + " " + e.Message);
                }
            }
        }

        /// <summary>
        /// Выбор из списка клиентов, открытие карточки клиента. Открывает из меню Список клиентов с главной формы
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

        #region /// АДМИНИСТРАТОРЫ ///

        /// <summary>
        /// Создание,запуск формы выбора Администратора
        /// </summary>
        public static void SelectCurentAdmin()
        {
            FormsRunner.RunAdminForm();
        }

        #endregion

        #region /// АБОНЕМЕНТ и ТРЕНИРОВКИ.

        public static bool SellAbonement()
        {
            if (!FormsRunner.RunSelectPersonForm(out var selectedName, "Выберите клиента для добавления Абонемента"))
                return false;

            if (string.IsNullOrEmpty(selectedName)) return false;

            var res = MessageBox.Show($@"{selectedName}", @"Добавить абонемент?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.No) return false;

            var isSuccess = AddAbonement(selectedName);
            SaveEverithing();
            return (isSuccess);
        }

        public static bool AddAbonement(string personName)
        {
            // Для справки. В архив абонементов новый добавляемый абонемент добавляется в форме абонементов AbonementForm
            // именно там он создается. Поэтому сразу и добавляем там

            var person = PersonObject.GetLink(personName);
            if (person == null) return false;

            var dialogResult = FormsRunner.CreateAbonementForm(person.Name);

            if (dialogResult == DialogResult.OK)
            {
                AbonementController.GetInstance().Save();
                return true;
            }
            return false;
        }

        private static bool IsAbonementValid(ref Person person)
        {
            if (person.AbonementCurent == null)
            {
                return false;
            }
            if (person.AbonementCurent.IsValid()) return true;
            else
            {
                person.AbonementCurent = null;
                return false;
            }
        }

        /// <summary>
        /// Отметить посещение. Запускается логика из текущего абонемента, а так же запускается событие для добавления
        /// в списки на главной форме
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public bool CheckInWorkout(string personName)
        {
            var person = PersonObject.GetLink(personName);
            if (person.AbonementCurent == null) return false;

            if (!IsAbonementValid(ref person)) return false;

            // Проверка на дубляж посещений. Если сегодня уже клиент ходил - задать вопрос
            var isAlreadyVisited = PersonObject.IsVisitToday(personName, out var infoMessage);
            if (isAlreadyVisited)
            {
                var dialogResult = MessageBox.Show($@"Повторно отметить посещение?

{infoMessage}", @"Сегодня клиент уже отмечался!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No) return false;
            }


            var selectedOptions = new WorkoutOptions();

            bool isSuccess;
            switch (person.AbonementCurent)
            {
                case AbonementByDays byDays:
                    {
                        var dlgResult = FormsRunner.RunWorkoutOptionsForm(ref selectedOptions, person.Name);
                        if (dlgResult == DialogResult.Cancel) return false;

                        person.AbonementCurent.TryActivate(); // Если не Активирован

                        isSuccess = byDays.CheckInWorkout(selectedOptions.TypeWorkout);
                        if (!isSuccess) return false;
                        PersonObject.SaveCurentVisit(person, selectedOptions); // Сохраняет текущий визит 
                        break;
                    }
                case ClubCardA clubCardA:
                    {
                        var dlgResult = FormsRunner.RunWorkoutOptionsForm(ref selectedOptions, person.Name);
                        if (dlgResult == DialogResult.Cancel) return false;

                        person.AbonementCurent.TryActivate(); // Если не Активирован

                        isSuccess = clubCardA.CheckInWorkout(selectedOptions.TypeWorkout);
                        if (!isSuccess) return false;
                        PersonObject.SaveCurentVisit(person, selectedOptions); // Сохраняет текущий визит 
                        break;
                    }
                case SingleVisit singleVisit:
                    {
                        var dlgResult = FormsRunner.RunWorkoutOptionsForm(ref selectedOptions, person.Name);
                        if (dlgResult == DialogResult.Cancel) return false;

                        person.AbonementCurent.TryActivate(); // Если не Активирован

                        isSuccess = singleVisit.CheckInWorkout(person.AbonementCurent.TypeWorkout);

                        if (!isSuccess) return false;
                        PersonObject.SaveCurentVisit(person, selectedOptions); // Сохраняет текущий визит 
                        break;
                    }
            }

            _dailyVisits.AddToLog(personName, selectedOptions); // Cобытие для добавления текущего посещения на главную форму

            IsAbonementValid(ref person);
            MessageBox.Show(@"Тренировка Учтена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SaveEverithing();
            return true;
        }
        #endregion

        #region /// ДЛЯ Создания ТАБЛИЦ на ClientForms /// Подготовка для отображения на Клиентской форме

        public static void LoadShortInfo(GroupBox gbBoxToShow, Person person)
        {
            var labelTextBoxList = CreateLabelTextBoxList(person);

            try
            {
                HighlightControls(ref labelTextBoxList);
            }
            catch (Exception)
            {
                SaveEverithing();
                MessageBox.Show(@"Ошибка подсветки строк по определенным признакам в карточке клиента");
            }

            // Отрисовка Short Info
            var table = CreateTable(labelTextBoxList); // Создаем таблицу c элементами из списка. Таблица: Лэйбл - Текстбокс

            AddTableToGroupBox(table, gbBoxToShow);
        }

        public static void LoadShortInfo(GroupBox gbBoxToShow, AbonementBasic abonement)
        {
            var labelTextBoxList = CreateLabelTextBoxList(abonement);

            try
            {
                HighlightControls(ref labelTextBoxList);
            }
            catch (Exception)
            {
                SaveEverithing();
                MessageBox.Show(@"Ошибка подсветки строк по определенным признакам в карточке клиента");
            }

            // Отрисовка Short Info
            var table = CreateTable(labelTextBoxList); // Создаем таблицу c элементами из списка. Таблица: Лэйбл - Текстбокс

            AddTableToGroupBox(table, gbBoxToShow);
        }

        private static void HighlightControls(ref List<Tuple<Label, Control>> inputListOfCntrls)
        {
            // Условие подсветки. Если Тренировки только Утром
            var indexTimeDay = inputListOfCntrls.FindIndex(x =>
                     x.Item1.Text.Contains("Время Тренировок") && x.Item2.Text.Contains(StrMorning));
            if (indexTimeDay != -1) inputListOfCntrls[indexTimeDay].Item2.BackColor = Color.LightPink;

            // Условие подсветки. Если Не Оплачено
            var indexPay = inputListOfCntrls.FindIndex(x =>
                x.Item1.Text.Contains("Статус Оплаты") && (x.Item2.Text.Contains(StrNoPay.Replace("_", " "))));
            if (indexPay != -1) inputListOfCntrls[indexPay].Item2.BackColor = Color.LightPink;

            // Условие подсветки. Карта или Абонемент заканчиваются через 3 дня
            var indexEndsSoon = inputListOfCntrls.FindIndex(x =>
                x.Item1.Text.Contains("Дата Окончания") && ((DateTime.Parse(x.Item2.Text) - DateTime.Now).Days <= 3));
            if (indexEndsSoon != -1) inputListOfCntrls[indexEndsSoon].Item2.BackColor = Color.Orange;

            // Условие подсветки. Мало занятий
            var indexNum = inputListOfCntrls.FindIndex(x =>
                x.Item1.Text.Contains("Осталось Занятий") && (int.Parse(x.Item2.Text) <= 3));
            if (indexNum != -1) inputListOfCntrls[indexNum].Item2.BackColor = Color.Orange;

        }
        private static void AddTableToGroupBox(TableLayoutPanel table, GroupBox grpBx)
        {
            if (grpBx.Controls.Count != 0)
            {
                grpBx.Controls.Clear();
            }
            grpBx.Controls.Add(table); // Выводим на групбокс нашу новую ShortInfo Table
        }

        /// <summary>
        /// Создает List с парами Лэйбл - Контрол. Заголовок строки - Контрол со значением.
        /// Эта реализация метода подходит для персон с действующими абонементами.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Создает List с парами Лэйбл - Контрол. Заголовок строки - Контрол со значением.
        /// Перегруженная версия. На вход подаётся абонемент(Не действительный и кончившийся).
        /// Нужен для отображения на форме клиентов в списке закончившихся абонементов
        /// </summary>
        /// <param name="abonement"></param>
        /// <returns></returns>
        private static List<Tuple<Label, Control>> CreateLabelTextBoxList(AbonementBasic abonement)
        {
            var labelTextBoxList = new List<Tuple<Label, Control>>();
            if (abonement == null)
            {
                labelTextBoxList.AddRange(TupleConverter(GetEmptyInfoList(new Person(""))));
            }
            else
            {
                labelTextBoxList.AddRange(TupleConverter(abonement?.GetShortInfoList()));
                // Добавляем Поле Статуса. Делаем тут потому что Person.abonem не знает об этом.
                var status = "Абонемент Сгорел";
                labelTextBoxList.Insert(1, CreateRowInfo("Текущий статус Клиента", status));
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
            string statusAbonemens = @"Нет карты";
            if (person.AbonementCurent != null && person.AbonementCurent.IsValid() == false)
            {
                statusAbonemens = @"Абонемент сгорел";
            }

            var result = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Текущий статус Клиента", statusAbonemens),
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
                Font = new Font("Microsoft Sans Serif", 10F)
            };

            return Tuple.Create<Label, Control>(lb, tb);
        }

        private static IEnumerable<Tuple<Label, Control>> TupleConverter(IEnumerable<Tuple<string, string>> data)
        {// Преобразует Список вида List<Tuple<string, string>> в универсальный Список: List<Tuple<Label, Control>>
            var result = data.Select(item => CreateRowInfo(item.Item1, item.Item2)).ToList();

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