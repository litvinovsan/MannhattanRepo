using PersonsBase.data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace PBase
{
    [Serializable]
    public class Person : IEquatable<Person>
    {
        #region/// СОБЫТИЯ //////////////////////////////////////

        // Статус
        [field: NonSerialized]
        public event EventHandler StatusChanged;
        public void OnStatusChanged()
        {
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }

        // Фото Клиента
        [field: NonSerialized]
        public event EventHandler PathToPhotoChanged;
        public void OnPathPhotoChanged()
        {
            PathToPhotoChanged?.Invoke(this, EventArgs.Empty);
        }

        // Абонемент
        [field: NonSerialized]
        public event EventHandler AbonementCurentChanged;
        public void OnAbonementCurentChanged()
        {
            AbonementCurentChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region/// ПРИВАТНЫЕ ПОЛЯ /////////////////////////
        private string _phone;
        private string _driverIdNum;
        private string _name;
        private string _pathToPhoto;
        private StatusPerson _status;
        private AbonementBasic _abonementCurent;
        #endregion

        #region/// ПУБЛИЧНЫЕ ПОЛЯ, ДОСТУПНЫЕ ДАННЫЕ О КЛИЕНТЕ ////////////
        public string Name
        {
            get { return _name; }
            set
            {
                _name = Methods.PrepareName(value);
                Key = _name;
            }
        }
        public string Key { get; private set; }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = string.IsNullOrEmpty(value) ? "" : value;
            }
        }
        public string Passport { get; set; }
        public string DriverIdNum
        {
            get { return _driverIdNum; }
            set
            {
                _driverIdNum = value;
            }
        }
        public string PathToPhoto
        {
            get
            {
                return _pathToPhoto;
            }

            set
            {
                _pathToPhoto = value;
                OnPathPhotoChanged();
            }
        }
        public string SpecialNotes { get; set; }
        public int PersonalNumber { get; set; }
        public StatusPerson Status
        {
            get
            {
                return _status;
            }
            set
            {// if(_status != value)
                _status = value;
                OnStatusChanged();
            }
        }
        public DateTime BirthDate { get; set; }
        public Gender GenderType;
        public ObservableCollection<AbonementBasic> AbonementsQueue;
        public AbonementBasic AbonementCurent
        {
            get
            {
                return _abonementCurent;
            }
            set
            {
                if (UpdateQueue(value))
                    OnAbonementCurentChanged();
            }
        }
        public List<Visit> JournalVisits;
        #endregion

        #region/// КОНСТРУКТОРЫ.  ///////////////////////////
        public Person(string nameFio)
        {
            Name = nameFio;
            PersonalNumber = 0;
            Status = StatusPerson.Нет_Карты;
            _phone = "";
            GenderType = Gender.Неизвестен;
            BirthDate = DateTime.Parse("02.02.2000");
            Passport = "";
            _driverIdNum = "";
            _pathToPhoto = "";
            SpecialNotes = "";
            _abonementCurent = null;
            AbonementsQueue = new ObservableCollection<AbonementBasic>();
            JournalVisits = new List<Visit>();
        }
        #endregion

        #region/// МЕТОДЫ  ///////////////////////////

        // Публичные
        public StatusPerson UpdateActualStatus()
        { ///Обновляем статус клиента.
            if (Status == StatusPerson.Запрещён) return Status;

            if (AbonementCurent == null)
            {
                if (Status == StatusPerson.Активный || Status == StatusPerson.Заморожен) _status = StatusPerson.Нет_Карты;
            }
            else
            {
                if (AbonementCurent.IsValid())
                {
                    ClubCardA clubCard = _abonementCurent as ClubCardA;
                    if (clubCard?.Freeze != null)
                    {
                        if (clubCard.Freeze.IsFreezedNow()) // Если Заморожен или обьект заморозки не создан
                        {
                            _status = StatusPerson.Заморожен;
                        }
                        else _status = StatusPerson.Активный;
                    }

                    if (_status != StatusPerson.Заморожен)
                    {
                        _status = StatusPerson.Активный;
                    }
                }
                else // Кончился Абонемент
                {
                    _status = StatusPerson.Нет_Карты;
                    // FIXME Надо придумать способ когда нужно удалять абонемент
                    // AbonementCurent = null;
                }
            }
            return Status;
        }
        public bool IsAbonementExist()
        {// FIXME сделать тут проверку валидности абонемента по всем полям. Дата,занятия,дни
            return AbonementCurent != null;
        }
        public void AddToJournal(WorkoutOptions selectedOptions)
        {
            if (JournalVisits == null) JournalVisits = new List<Visit>(); // Проверка на случай сериализации
            JournalVisits.Add(new Visit(_abonementCurent, selectedOptions));
        }

        // Приватные
        private bool UpdateQueue(AbonementBasic newAbonementValue)
        {
            bool result = true;
            if (_abonementCurent == null)
            {
                _abonementCurent = newAbonementValue;
            }
            else // Изменяем уже существующий абонемент
            {
                if (newAbonementValue != null)
                {
                    AbonementsQueue.Add(newAbonementValue);
                    result = false;
                }
                else if (AbonementsQueue.Count == 0)
                {// Заменяем существующий абонемент на null со смещением по списку
                    _abonementCurent = null;
                }
                else
                {
                    _abonementCurent = AbonementsQueue[0];
                    AbonementsQueue.RemoveAt(0);
                }
            }

            return result;
        }
        #endregion

        #region //Перегрузка операторов для сравнения клиентов
        /// <summary>
        /// Перегружаем операторы ==  !=, а так же метод Equal для сравнения по значению классов
        /// </summary>
        public bool Equals(Person other)
        {
            if (other == null) return false;
            /*this.Id == other.Id &&*/
            bool passpResult = false;
            bool phoneResult = false;
            bool fullNameResult = false;
            bool driverIdResult = false;
            bool personalNumber = false;

            if (other.PersonalNumber == 0 && PersonalNumber == 0)
            {
                personalNumber = true;
            }
            else
            {
                personalNumber = other.PersonalNumber == PersonalNumber;
            }

            if (other.Passport == null && Passport == null)
            {
                passpResult = true;
            }
            else
            {
                passpResult = (other.Passport == Passport);
            }

            if (other.Phone == null && Phone == null)
            {
                phoneResult = true;
            }
            else
            {
                phoneResult = (other.Phone == Phone);
            }

            if (other.Name == null && Name == null)
            {
                fullNameResult = true;
            }
            else
            {
                fullNameResult = (Name == other.Name);
            }

            if (other.DriverIdNum == null && DriverIdNum == null)
            {
                driverIdResult = true;
            }
            else
            {
                driverIdResult = (DriverIdNum == other.DriverIdNum);
            }

            return driverIdResult && fullNameResult && phoneResult && passpResult;
        }
        /// <summary>
        /// Возвращает true если обнаружено совпадение по какому-либо полю. Так же возвращает код совпадающего поля.
        /// </summary>
        public bool Equals(Person other, out ResponseCode response)
        {
            response = ResponseCode.Fail;
            if (other == null) return false;

            if (Equals(other))
            {
                response = ResponseCode.Duplicate;
                return true;
            }

            if (PersonalNumber != 0 && other.PersonalNumber != 0 && PersonalNumber == other.PersonalNumber)
            {
                response = ResponseCode.IdNumberExist;
                return true;
            }

            if (Name == other.Name)
            {
                response = ResponseCode.KeyExist;
                return true;
            }

            if (Phone != "" && other.Phone != "" && Phone == other.Phone)
            {
                response = ResponseCode.PhoneExist;
                return true;
            }

            if (Passport != "" && other.Passport != "" && Passport == other.Passport)
            {
                response = ResponseCode.PassportExist;
                return true;
            }

            if (DriverIdNum != "" && other.DriverIdNum != "" && DriverIdNum == other.DriverIdNum)
            {
                response = ResponseCode.DriverIdExist;
                return true;
            }
            response = ResponseCode.NoDuplicate;
            return false;
        }
        public static bool operator ==(Person person1, Person person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return Equals(person1, person2);

            return person1.Equals(person2);
        }
        public static bool operator !=(Person person1, Person person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return !Equals(person1, person2);

            return !(person1.Equals(person2));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Person)obj);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_phone != null ? _phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_driverIdNum != null ? _driverIdNum.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)_status;
                hashCode = (hashCode * 397) ^ (int)GenderType;
                hashCode = (hashCode * 397) ^ (AbonementCurent != null ? AbonementCurent.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PersonalNumber;
                hashCode = (hashCode * 397) ^ (Key != null ? Key.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ BirthDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Passport != null ? Passport.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PathToPhoto != null ? PathToPhoto.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SpecialNotes != null ? SpecialNotes.GetHashCode() : 0);
                return hashCode;
            }
        }
        #endregion
    }
}
