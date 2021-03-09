using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;

namespace PersonsBase.data
{
    [Serializable]
    public static class DataBaseM
    {
        #region /// ПОИСК ДУБЛИКАТОВ ///////////////
        /// <summary>
        /// Полная и сама долгая проверка.
        /// Проверяются все значимые поля для создания персоны по базе.Возвращает статус Success/Duplicate или указывает на повторяющееся поле.
        /// </summary>
        public static bool IsContainsCopyOfValues(SortedList<string, Person> inputDict, Person person, out ResponseCode response)
        {
            var containsCopy = false;
            response = ResponseCode.Success;
            //Если пустая коллекция
            if (inputDict.Count == 0)
            {
                response = ResponseCode.Success;
                return false;
            }

            //быстрая Проверка на Ключ/Имя клиента    
            if (inputDict.ContainsKey(person.Name))
            {
                containsCopy = true;
                response = ResponseCode.KeyExist;
            }
            else
            {
                //Ищем по Значению: Tel, Passp, Drive, ID,
                foreach (var item in inputDict)
                {
                    ResponseCode tempResponse;
                    if (item.Value.Equals(person, out tempResponse))
                    {
                        containsCopy = true;
                        response = tempResponse;
                        break;
                    }
                }
            }
            return containsCopy;
        }

        /// <summary>
        /// Метод выводит МессаджБокс с описанием что за событие произошло по Респонс Коду
        /// </summary>
        /// <param name="result"></param>
        public static void ExplainResponse(ResponseCode result)
        {
            string message = "";
            switch (result)
            {
                case ResponseCode.Success:
                    break;
                case ResponseCode.Fail:
                    message = $"Неизвестная ошибка {result.ToString()}";
                    break;
                case ResponseCode.Duplicate:
                    message = "Дубликат!";
                    break;
                case ResponseCode.NameExist:
                    message = "Имя Уже существует!!!";
                    break;
                case ResponseCode.KeyExist:
                    message = "Ключ/Имя/Код уже существуют";
                    break;
                case ResponseCode.IdNumberExist:
                    message = "Персональный код Уже существует";
                    break;
                case ResponseCode.PhoneExist:
                    message = "Номер телефона уже существует";
                    break;
                case ResponseCode.PassportExist:
                    message = "Такой номер паспорта уже существует";
                    break;
                case ResponseCode.DriverIdExist:
                    message = "Такой номер прав уже существует";
                    break;
                default:
                    message = result.ToString();
                    break;
            }

            MessageBox.Show(message, @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region /// ПОИСК, РЕДАКТИРОВАНИЕ /////////////

        // Driver ID
        public static Person FindByDriveId(SortedList<string, Person> inputCollection, string driveLic)
        {
            Person findedPerson;
            if (inputCollection == null || string.IsNullOrEmpty(driveLic) || inputCollection.Count <= 0) return null;
            try
            {
                var matches = inputCollection.ToList().FindAll(p => (p.Value.DriverIdNum == driveLic));
                findedPerson = matches.Count >= 1 ? inputCollection.FirstOrDefault((p => (p.Value.DriverIdNum == driveLic))).Value : null;
            }
            catch
            {
                findedPerson = null;
            }
            return findedPerson;
        }
        // Personal Number
        public static bool FindByPersonalNumber(SortedList<string, Person> inputCollection, long number, out Person findedPerson)
        {
            findedPerson = null;

            if (inputCollection == null || number <= 0 || inputCollection.Count <= 0) return false;

            try
            {
                findedPerson = inputCollection.Values.First(x => x.PersonalNumber == number);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool EditPersonalNumber(string namePerson, long newNumber)
        {
            var isExist = FindByPersonalNumber(DataBaseLevel.GetPersonsList(), newNumber, out _);

            if (isExist)
            {
                MessageBox.Show(@"Такой номер уже назначен клиенту: \n\r {person.Name}", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (newNumber <= 0)
            {
                MessageBox.Show($@"Личный номер удалён", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonObject.GetLink(namePerson).PersonalNumber = 0;
                return false;
            }
            PersonObject.GetLink(namePerson).PersonalNumber = newNumber;
            return true;
        }

        // Name 
        public static bool EditName(SortedList<string, Person> inputCollection, string oldName, string newFullName)
        {
            var isSuccess = false;
            var newName = Logic.PrepareName(newFullName);

            if (inputCollection != null && inputCollection.Count > 0 && !string.IsNullOrEmpty(newName) && newName != "")
            {
                var localKey = Logic.PrepareName(oldName);
                // Копируем данные текущей персоны
                isSuccess = inputCollection.TryGetValue(localKey, out var personForEdit);

                if (!isSuccess) return false;

                personForEdit.Name = newName;
                inputCollection.Remove(localKey);
                inputCollection.Add(personForEdit.Name, personForEdit);
            }
            return isSuccess;
        }

        // Passport
        public static Person FindByPassport(SortedList<string, Person> inputCollection, string passp)
        {
            Person result;
            if (inputCollection == null || string.IsNullOrEmpty(passp) || inputCollection.Count <= 0) return null;
            try
            {
                var matches = inputCollection.ToList().FindAll(x => x.Value.Passport == (passp));
                result = matches.Count >= 1 ? inputCollection.FirstOrDefault(x => x.Value.Passport == passp).Value : null;
            }
            catch
            {
                result = new Person();
            }

            return result;
        }

        // Phone
        public static Person FindByPhone(SortedList<string, Person> inputCollection, string telnumber)
        {
            Person result;
            if (inputCollection == null || String.IsNullOrEmpty(telnumber) || inputCollection.Count <= 0) return null;
            try
            {
                result = inputCollection.Values.Single(x => x.Phone == telnumber);
            }
            catch
            {
                result = null;
            }
            return result;
        }

        // Path To Photo
        public static void EditPathToPhoto(string personName, string newFileNameNoExtens)
        {
            var oldPathToPhoto = PersonObject.GetLink(personName)?.PathToPhoto;
            if (oldPathToPhoto == null) return;
            var fileInfo = new FileInfo(oldPathToPhoto);
            var newFilePath = fileInfo.DirectoryName + "\\" + newFileNameNoExtens + fileInfo.Extension;
            if (personName != null && DataBaseLevel.ContainsNameKey(personName))
                PersonObject.GetLink(personName).PathToPhoto = newFilePath;
        }

        #endregion

        #region /// ВЫВОД ИНФОРМАЦИИ о ВСЕХ КЛИЕНТАХ

        /// <summary>
        /// Возвращает DataTable со Всеми клиентами в Базе. Нужна для экспорта в Excel,а так же для создания отчетов
        /// </summary>
        /// <returns></returns>
        public static DataTable CreatePersonsTable()
        {
            var persons = DataBaseLevel.GetPersonsList().Select(x => x.Value);
            var dt = CreatePersonsTable(persons, GetPersonFieldsFull);
            return dt;
        }


        /// <summary>
        /// Возвращает DataTable для произвольного количества клиентов из списка inputList. Для экспорта в Excel
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="getFieldsFunc"></param>
        /// <returns></returns>
        public static DataTable CreatePersonsTable(IEnumerable<Person> inputList,
            Func<Person, IEnumerable<PersonField>> getFieldsFunc)
        {
            var dt = new DataTable();
            if (inputList == null) return dt;

            // Если пустая коллекция человеков
            var list = inputList.ToList();
            if (!list.Any()) return dt;

            // Заголовки Таблицы
            var headers = GetHeaders(getFieldsFunc);
            dt.Columns.AddRange(headers);

            // Данные всех Клиентов
            foreach (var item in list)
            {
                var personFields = getFieldsFunc(item);
                var myDataRowsList = personFields.Select(x => x.Value).ToArray<object>();
                dt.Rows.Add(myDataRowsList);
            }
            return dt;
        }

        public static async Task<DataTable> CreatePersonsTableAsync(
            IEnumerable<Person> inputList,
            Func<Person, IEnumerable<PersonField>> getFieldsFunc)
        {
            return await Task.Run(() => CreatePersonsTable(inputList, getFieldsFunc)).ConfigureAwait(false);
        }

        /// <summary>
        /// Получаем заголовки из Обьекта класса Пользователя. Нужно для экспорта в эксель
        /// На вход подается функция создающая поля поля и заголовки
        /// </summary>
        /// <returns></returns>
        private static DataColumn[] GetHeaders(Func<Person, IEnumerable<PersonField>> getFieldsFunc)
        {
            // Создаем массив с полями и заголовками будущей таблицы по текущему посещению
            var persons = DataBaseLevel.GetPersonsList();
            var p = persons.Select(x => x).FirstOrDefault(x => (x.Value.AbonementCurent != null));
            IEnumerable<PersonField> personFields;

            // Это условие нужно на тот случай если в списке нет клиентов с абонементами
            if (p.Key == null || p.Value == null)
            {
                var tempPerson = new Person("temp")
                {
                    AbonementCurent = new SingleVisit(TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, Pay.Не_Оплачено,
                        TimeForTr.Утро)
                };
                personFields = getFieldsFunc(tempPerson);
            }
            else
            {
                personFields = getFieldsFunc(p.Value);
            }

            var headerNames = personFields.Select(x => x.HeaderName).ToArray();
            var dcol = new DataColumn[headerNames.Length];

            for (var i = 0; i < headerNames.Length; i++)
            {
                dcol[i] = new DataColumn(headerNames[i]);
            }

            return dcol;
        }

        /// <summary>
        /// Только тут создаются заголовки всех полей и записываются основные данные 
        /// </summary>
        /// <param name="first"></param>
        /// <returns></returns>
        public static IEnumerable<PersonField> GetPersonFieldsFull(Person first)
        {
            var person = first;

            var instAbonContr = AbonementController.GetInstance();
            var abonHistoriesOld = PersonObject.GetAbonHistoryList(person.Name);
            var abonListAll = instAbonContr.GetList(person.Name);
            var abonValid = instAbonContr.GetFirstValid(person.Name);

            // Создается текстовый список всех абонементов.
            var abonHistString = new StringBuilder();
            foreach (var item in abonListAll)
            {
                abonHistString.AppendLine(item?.AbonementName + $"({item?.BuyDate.Date}), ");
            }

            if (abonHistoriesOld != null)
                foreach (var item in abonHistoriesOld)
                {
                    abonHistString.Append(item?.AbonementName + $"({item?.BuyDate}), ");
                }
            // Для выдергивания не форматированного текста в заметки.
            RichTextBox tempSpecialNotesRtb = new RichTextBox();
            MyRichTextBox.Load(tempSpecialNotesRtb, person.SpecialNotes);

            var abon = abonValid ?? abonListAll?.LastOrDefault();

            var isAbonExist = abon != null;
            var personFields = new List<PersonField>
            {
                new PersonField {HeaderName = "Имя", Value = person.Name},
                new PersonField {HeaderName = "Телефон", Value = person.Phone},
                new PersonField {HeaderName = "Дата Рождения", Value = $"{person.BirthDate.Date:MM/dd/yyyy}"},
                new PersonField {HeaderName = "Пол", Value = person.GenderType.ToString()},
                new PersonField {HeaderName = "Статус", Value = person.Status.ToString()},
                new PersonField {HeaderName = "ID номер", Value = person.PersonalNumber.ToString()},
                new PersonField {HeaderName = "Паспорт", Value = person.Passport},
                new PersonField {HeaderName = "Права", Value = person.DriverIdNum},
                // Абонемент
                new PersonField { HeaderName = "Название", Value = (isAbonExist) ?abon.AbonementName: "" },
                new PersonField { HeaderName = "Доступное время", Value = (isAbonExist) ?abon.TimeTraining.ToString():"" },
                new PersonField { HeaderName = "Осталось дней", Value = (isAbonExist) ?abon.GetRemainderDays().ToString():"" },
                new PersonField { HeaderName = "Аэробных", Value = (isAbonExist) ?abon.NumAerobicTr.ToString():"" },
                new PersonField { HeaderName = "Персональных", Value = (isAbonExist) ?abon.NumPersonalTr.ToString():""},

                new PersonField { HeaderName = "Мини Групп", Value =(isAbonExist) ?abon.NumMiniGroup.ToString():"" },
                new PersonField { HeaderName = "Спа услуги", Value = (isAbonExist) ?abon.Spa.ToString():"" },
                new PersonField { HeaderName = "Доступный тип", Value =(isAbonExist) ?abon.TypeWorkout.ToString():"" },
                new PersonField { HeaderName = "Оплата", Value = (isAbonExist) ?abon.PayStatus.ToString():"" },
                new PersonField { HeaderName = "Абон. Покупка", Value =(isAbonExist) ? $"{abon.BuyDate:MM/dd/yyyy}" :""},
                new PersonField { HeaderName = "Абон. Активация", Value =(isAbonExist) ? $"{abon.BuyActivationDate:MM/dd/yyyy}" :""},
                new PersonField { HeaderName = "Абон. Конец", Value =(isAbonExist) ? $"{abon.EndDate:MM/dd/yyyy}":"" },
                new PersonField { HeaderName = "Активация", Value = (isAbonExist) ?abon.IsActivated.ToString():"" },
                new PersonField { HeaderName = "Заметки", Value = tempSpecialNotesRtb.Text },
                new PersonField { HeaderName = "Заморозки", Value = GetFreezeString(person) },
                new PersonField { HeaderName = "История Абон.", Value =abonHistString.ToString() }
            };

            return personFields;
        }

        /// <summary>
        /// Только тут создаются заголовки Выборочных полей и записываются их данные в структуру PersonField
        /// </summary>
        /// <param name="first"></param>
        /// <returns></returns>
        public static IEnumerable<PersonField> GetPersonFieldsShort(Person first)
        {
            var person = first;
            // Главные поля, всегда отображаются
            var personFields = new List<PersonField>
            {
                new PersonField {HeaderName = "Имя", Value = person.Name},
                new PersonField {HeaderName = "Телефон", Value = person.Phone},
              //  new PersonField {HeaderName = "Статус", Value = person.Status.ToString()},
            };

            // Все что касается Абонемента
            var instAbonContr = AbonementController.GetInstance();
            var lastAbonement = instAbonContr.GetFirstValid(person.Name) ?? instAbonContr.GetList(person.Name).LastOrDefault();
            if (lastAbonement == null) return personFields;

            personFields.Add(new PersonField { HeaderName = "Название", Value = lastAbonement.AbonementName });
            personFields.Add(new PersonField { HeaderName = "Покупка", Value = $"{lastAbonement.BuyActivationDate:dd/MM/yyyy}" });
            personFields.Add(new PersonField { HeaderName = "Конец", Value = $"{lastAbonement.EndDate:dd/MM/yyyy}" });

            // Последнее посещение в журнале
            var journal = PersonObject.GetVisitsList(person.Name);
            if (journal?.Count > 0)
            {
                var lastVisit = journal.Last().DateTimeVisit.Date; //.ToString("MM/dd/yyyy");
                var numDays = (DateTime.Now - lastVisit).Days;
                personFields.Add(new PersonField { HeaderName = "Посл.Визит", Value = lastVisit.ToString("MM/dd/yyyy") });

                personFields.Add(numDays == 0
                    ? new PersonField { HeaderName = "Был (дн. назад)", Value = $"Сегодня" }
                    : new PersonField { HeaderName = "Был (дн. назад)", Value = $"  {numDays}" });
            }
            else
            {
                personFields.Add(new PersonField { HeaderName = "Был(дн. назад)", Value = $"" });
            }

            return personFields;
        }

        /// <summary>
        /// Формирует строку из списка записей заморозки. Эта строка нужна для вывода в эксель
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private static string GetFreezeString(Person person)
        {
            var result = "";
            if (person.AbonementCurent != null && person.AbonementCurent is ClubCardA abon)
            {
                try
                {
                    abon.Freeze.Sort();
                    var startDateList = abon.Freeze.AllFreezes
                        .Select(x => $"Начало: {x.StartDate:d}(дней:{x.DaysToFreeze}) *** ").ToList();

                    foreach (var item in startDateList)
                    {
                        result += item;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    // ignored
                }
            }
            return result;
        }

        #endregion
    }
}
