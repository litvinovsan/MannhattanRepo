using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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
            if (inputDict.ContainsKey(person.Key))
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
            if (inputCollection == null || String.IsNullOrEmpty(driveLic) || inputCollection.Count <= 0) return null;
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
        public static bool FindByPersonalNumber(SortedList<string, Person> inputCollection, int number, out Person findedPerson)
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
        public static bool EditPersonalNumber(string namePerson, int newNumber)
        {
            var isExist = FindByPersonalNumber(DataBaseLevel.GetListPersons(), newNumber, out var person);

            if (newNumber <= 0 || isExist)
            {
                MessageBox.Show($@"Такой ПЕРСОНАЛЬНЫЙ номер уже назначен клиенту: {person.Name}", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            DataBaseO.GetPersonLink(namePerson).PersonalNumber = newNumber;
            return true;
        }

        // Name 
        public static bool EditName(SortedList<string, Person> inputCollection, string key, string newFullName)
        {
            bool isSuccess = false;
            string newName = Methods.PrepareName(newFullName);

            if (inputCollection != null && inputCollection.Count > 0 && !String.IsNullOrEmpty(newName) && newName != "")
            {
                var localKey = Methods.PrepareName(key);
                // Копируем данные текущей персоны
                Person personForEdit; // Копия текущей персоны                                                                        
                isSuccess = inputCollection.TryGetValue(localKey, out personForEdit);
                if (isSuccess)
                {
                    personForEdit.Name = newName;
                    inputCollection.Remove(localKey);
                    inputCollection.Add(personForEdit.Key, personForEdit);
                }
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

        #endregion

        #region /// ВЫБОРКА клиентов ////////////////////
        public static IEnumerable<KeyValuePair<string, Person>> SelectByGender(IEnumerable<KeyValuePair<string, Person>> inputCollection, Gender gender)
        {
            var result = from n in inputCollection
                         where n.Value.GenderType == gender
                         select n;
            return result;
        }

        public static IEnumerable<Person> SelectByStatus(IEnumerable<Person> inputCollection, StatusPerson status)
        {
            var persons = inputCollection.Where(c => c.Status == status).Select(c => c);
            return persons;
        }

        public static IEnumerable<Person> SelectBDateToday(IEnumerable<Person> inputCollection)
        {
            var persons = inputCollection.Where(c => c.BirthDate.Equals(DateTime.Now.Date));
            return persons;
        }


        /*      // Добавляет в список тех людей, абонементы которых заканчиваются через  daysLeft  дней.
          public static IEnumerable<Person> SelectEndInXdays(IEnumerable<Person> inputCollection, int daysLeft)
          {
             var today = DateTime.Now;
             var lefts = today.AddDays(daysLeft);
             var persons = inputCollection.Where(c => c.FinishDate.Date.Equals(lefts.Date));
             return persons;
          }

          public static IEnumerable<Person> SelectTimeForVisit(IEnumerable<Person> inputCollection, TimeForTr td)
          {
             var persons = inputCollection.Where(c => c.TimeForVisit == td).Select(c => c);
             return persons;
          }

        public static IEnumerable<Person> SelectTypeOfTraining(IEnumerable<Person> inputCollection, TypeWorkout typetr)
          {
            var persons = inputCollection.Where(c => c.TypeTraining == typetr).Select(c => c);
             return persons;
          }

         
    */

        #endregion

        #region /// ИНФОРМАЦИЯ о ВСЕХ КЛИЕНТАХ


        /// <summary>
        /// Сохраняет список Всех клиентов в Excel файл.
        /// </summary>
        public static void ExportToExcel(DataTable table, bool showDlgBox)
        {
            if (showDlgBox)
            {
                MyExportFile.SaveToExcel(table);
            }
            else
            {
                var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.DataBaseFolderName + "\\";

                MyExportFile.SaveToExcel(table, $"{currentPath}CписокКлиентов");
            }
        }

        /// <summary>
        /// Возвращает DataTable со Всеми клиентами в Базе. Нужна для экспорта в Excel,а так же для создания отчетов
        /// </summary>
        /// <returns></returns>
        public static DataTable CreatePersonsTable()
        {
            var persons = DataBaseLevel.GetListPersons();
            var dt = CreatePersonsTable(persons, GetPersonFieldsFull);
            return dt;
        }

        /// <summary>
        /// Возвращает DataTable для произвольного количества клиентов из списка inputList. Для экспорта в Excel
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="getFieldsFunc"></param>
        /// <returns></returns>
        public static DataTable CreatePersonsTable(IEnumerable<KeyValuePair<string, Person>> inputList,
            Func<KeyValuePair<string, Person>, IEnumerable<PersonField>> getFieldsFunc)
        {
            var dt = new DataTable();
            if (inputList == null) return dt;

            // Если пустая коллекция человеков
            var keyValuePairs = inputList.ToList();
            if (!keyValuePairs.Any()) return dt;

            // Заголовки Таблицы
            DataColumn[] headers = GetHeaders(getFieldsFunc);
            dt.Columns.AddRange(headers);

            // Данные всех Клиентов
            foreach (var item in keyValuePairs)
            {
                var personFields = getFieldsFunc(item);
                var myDataRowsList = personFields.Select(x => x.Value).ToArray<object>();
                dt.Rows.Add(myDataRowsList);
            }
            return dt;
        }


        /// <summary>
        /// Получаем заголовки из Обьекта класса Пользователя. Нужно для экспорта в эксель
        /// На вход подается функция создающая поля поля и заголовки
        /// </summary>
        /// <returns></returns>
        private static DataColumn[] GetHeaders(Func<KeyValuePair<string, Person>, IEnumerable<PersonField>> getFieldsFunc)
        {
            // Создаем массив с полями и заголовками будущей таблицы по текущему посещению
            var persons = DataBaseLevel.GetListPersons();
            var p = persons.Select(x => x).FirstOrDefault(x => (x.Value.AbonementCurent != null));
            IEnumerable<PersonField> personFields;

            // Это условие нужно на тот случай если в списке нет клиентов с абонементами
            if (p.Key == null || p.Value == null)
            {
                var tempPerson = new KeyValuePair<string, Person>("temp", new Person("temp"));
                tempPerson.Value.AbonementCurent = new SingleVisit(TypeWorkout.Аэробный_Зал, SpaService.Без_Спа, Pay.Не_Оплачено, TimeForTr.Утро);
                personFields = getFieldsFunc(tempPerson);
            }
            else
            {
                personFields = getFieldsFunc(p);
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
        public static IEnumerable<PersonField> GetPersonFieldsFull(KeyValuePair<string, Person> first)
        {// FIXME  Попробовать тут Рефлексию
            var person = first.Value;
            var personFields = new List<PersonField>
            {
                new PersonField {HeaderName = "Имя", Value = person.Name},
                new PersonField {HeaderName = "Телефон", Value = person.Phone},
                new PersonField {HeaderName = "Дата Рождения", Value = $"{person.BirthDate.Date:MM/dd/yyyy}"},
                new PersonField {HeaderName = "Пол", Value = person.GenderType.ToString()},
                new PersonField {HeaderName = "Статус", Value = person.Status.ToString()},
                new PersonField {HeaderName = "ID номер", Value = person.PersonalNumber.ToString()},
                new PersonField {HeaderName = "Паспорт", Value = person.Passport},
                new PersonField {HeaderName = "Права", Value = person.DriverIdNum}
            };
            if (person.AbonementCurent != null)
            {
                personFields.Add(new PersonField { HeaderName = "Название Абон.", Value = person.AbonementCurent.AbonementName });
                personFields.Add(new PersonField { HeaderName = "Доступное время", Value = person.AbonementCurent.TimeTraining.ToString() });
                personFields.Add(new PersonField { HeaderName = "Осталось дней", Value = person.AbonementCurent.GetRemainderDays().ToString() });
                personFields.Add(new PersonField { HeaderName = "Аэробных", Value = person.AbonementCurent.NumAerobicTr.ToString() });
                personFields.Add(new PersonField { HeaderName = "Персональных", Value = person.AbonementCurent.NumPersonalTr.ToString() });
                personFields.Add(new PersonField { HeaderName = "Спа услуги", Value = person.AbonementCurent.Spa.ToString() });
                personFields.Add(new PersonField { HeaderName = "Доступный тип", Value = person.AbonementCurent.TrainingsType.ToString() });
                personFields.Add(new PersonField { HeaderName = "Оплата", Value = person.AbonementCurent.PayStatus.ToString() });
                personFields.Add(new PersonField { HeaderName = "Абон. Покупка", Value = $"{person.AbonementCurent.BuyDate:MM/dd/yyyy}" });
                personFields.Add(new PersonField { HeaderName = "Абон. Конец", Value = $"{person.AbonementCurent.EndDate:MM/dd/yyyy}" });
                personFields.Add(new PersonField { HeaderName = "Активация", Value = person.AbonementCurent.IsActivated.ToString() });
            }

            personFields.Add(new PersonField { HeaderName = "Заметки", Value = person.SpecialNotes });
            personFields.Add(new PersonField { HeaderName = "Фото", Value = Path.GetFileName(person.PathToPhoto) });
            // Вывод Списка Заморозок
            personFields.Add(new PersonField { HeaderName = "Заморозки", Value = GetFreezeString(person) });

            return personFields;
        }

        /// <summary>
        /// Только тут создаются заголовки Выборочных полей и записываются их данные в структуру PersonField
        /// </summary>
        /// <param name="first"></param>
        /// <returns></returns>
        public static IEnumerable<PersonField> GetPersonFieldsShort(KeyValuePair<string, Person> first)
        {
            var person = first.Value;
            // Главные поля, всегда отображаются
            var personFields = new List<PersonField>
            {
                new PersonField {HeaderName = "Имя", Value = person.Name},
                new PersonField {HeaderName = "Телефон", Value = person.Phone},
                new PersonField {HeaderName = "Статус", Value = person.Status.ToString()},
            };

            // Все что касается Абонемента
            if (person.AbonementCurent == null) return personFields;

            personFields.Add(new PersonField { HeaderName = "Название Абон.", Value = person.AbonementCurent.AbonementName });
            personFields.Add(new PersonField { HeaderName = "Абон. Покупка", Value = $"{person.AbonementCurent.BuyDate:MM/dd/yyyy}" });
            personFields.Add(new PersonField { HeaderName = "Абон. Конец", Value = $"{person.AbonementCurent.EndDate:MM/dd/yyyy}" });

            // Последнее посещение в журнале
            if (person.JournalVisits?.Count > 0)
            {
                var lastVisit = person.JournalVisits.Last().DateTimeVisit.Date; //.ToString("MM/dd/yyyy");
                var numDays = (DateTime.Now - lastVisit).Days;
                personFields.Add(new PersonField { HeaderName = "Был (дней назад)", Value = $"  {numDays}" });
            }
            else
            {
                personFields.Add(new PersonField { HeaderName = "Был (дней назад)", Value = $"" });
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
                catch (Exception)
                {
                    // ignored
                }
            }
            return result;
        }


        #endregion
    }
}
