using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using PersonsBase.control;
using PersonsBase.data.Abonements;

namespace PersonsBase.data
{
    [Serializable]
    public class Person : IEquatable<Person>
    {
        #region/// СОБЫТИЯ ////

        [field: NonSerialized] public event EventHandler StatusChanged;
        [field: NonSerialized] public event EventHandler PathToPhotoChanged;
        [field: NonSerialized] public event EventHandler AbonementCurentChanged;
        [field: NonSerialized] public event EventHandler ActivationChanged;
        [field: NonSerialized] public event EventHandler<string> PhoneChanged;
        [field: NonSerialized] public event EventHandler<string> NameChanged;
        [field: NonSerialized] public event EventHandler<string> PassportChanged;
        [field: NonSerialized] public event EventHandler<string> DriverIdChanged;
        [field: NonSerialized] public event EventHandler<string> SpecialNotesChanged;
        [field: NonSerialized] public event EventHandler<long> PersonalNumberChanged;
        [field: NonSerialized] public event EventHandler<DateTime> BirthDateChanged;
        [field: NonSerialized] public event EventHandler<Gender> GenderTypeChanged;

        private void OnStatusChanged()
        {
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }
        private void OnActivationChanged()
        {
            ActivationChanged?.Invoke(this, EventArgs.Empty);
        }
        private void OnPathPhotoChanged()
        {
            PathToPhotoChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnAbonementCurentChanged()
        {
            AbonementCurentChanged?.Invoke(this, EventArgs.Empty);
        }
        private void OnPhoneChanged(string text)
        {
            PhoneChanged?.Invoke(this, text);
        }
        private void OnNameChanged(string text)
        {
            NameChanged?.Invoke(this, text);
        }
        private void OnPassportChanged(string text)
        {
            PassportChanged?.Invoke(this, text);
        }
        private void OnDriverIdChanged(string text)
        {
            DriverIdChanged?.Invoke(this, text);
        }
        private void OnSpecialNotesChanged(string text)
        {
            SpecialNotesChanged?.Invoke(this, text);
        }
        private void OnPersonalNumberChanged(long number)
        {
            PersonalNumberChanged?.Invoke(this, number);
        }
        private void OnBirthDateChanged(DateTime date)
        {
            BirthDateChanged?.Invoke(this, date);
        }
        private void OnGenderTypeChanged(Gender gender)
        {
            GenderTypeChanged?.Invoke(this, gender);
        }

        #endregion

        #region/// ПРИВАТНЫЕ ПОЛЯ ////
        private string _phone;
        private string _name;
        private string _pathToPhoto;
        private string _passport;
        private string _driverIdNum;
        private string _specialNotes;
        private long _personalNumber;
        private DateTime _birthDate;
        private Gender _genderType;
        private StatusPerson _status;
        private AbonementBasic _abonementCurent;
        #endregion

        #region/// ПУБЛИЧНЫЕ ПОЛЯ, ДОСТУПНЫЕ ДАННЫЕ О КЛИЕНТЕ ////////////

        public string Name
        {
            get { return _name; }
            set
            {
                var newName = Logic.PrepareName(value);
                if (newName.Equals(_name)) return;

                _name = newName;
                OnNameChanged(_name);
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                var newPhone = string.IsNullOrEmpty(value) ? "" : value;
                if (_phone.Equals(newPhone)) return;
                _phone = newPhone;
                OnPhoneChanged(_phone);
            }
        }
        public string Passport
        {
            get { return _passport; }
            set
            {
                _passport = value;
                OnPassportChanged(_passport);
            }
        }
        public string DriverIdNum
        {
            get { return _driverIdNum; }
            set
            {
                _driverIdNum = value;
                OnDriverIdChanged(_driverIdNum);
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
        public string SpecialNotes
        {
            get { return _specialNotes; }
            set
            {
                _specialNotes = value;
                OnSpecialNotesChanged(_specialNotes);
            }
        }
        public long PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                _personalNumber = value;
                OnPersonalNumberChanged(_personalNumber);
            }
        }
        public StatusPerson Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (_status == value) return;
                _status = value;
                OnStatusChanged();
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnBirthDateChanged(_birthDate);
            }
        }
        public readonly ObservableCollection<AbonementBasic> AbonementsQueue;
        public AbonementBasic AbonementCurent
        {
            get
            {
                return _abonementCurent;
            }
            set
            {
                if (_abonementCurent == value) return;

                _abonementCurent = value;
                StatusDirector();
                OnAbonementCurentChanged();
            }
        }
        public Gender GenderType
        {
            get { return _genderType; }
            set
            {
                _genderType = value;
                OnGenderTypeChanged(_genderType);
            }
        }

        #endregion

        #region/// КОНСТРУКТОРЫ.  ///////////////////////////
        public Person(string nameFio)
        {
            Name = nameFio;
            PersonalNumber = 0;
            _status = StatusPerson.Нет_Карты;
            GenderType = Gender.Неизвестен;
            BirthDate = DateTime.Parse("02.02.2000");
            Passport = string.Empty;
            SpecialNotes = string.Empty;

            _phone = string.Empty;
            DriverIdNum = string.Empty;
            _pathToPhoto = string.Empty;
            _abonementCurent = null;

            AbonementsQueue = new ObservableCollection<AbonementBasic>();
        }
        public Person()
        {
            Name = "Empty Name";
            PersonalNumber = 0;
            _status = StatusPerson.Нет_Карты;
            GenderType = Gender.Неизвестен;
            BirthDate = DateTime.Parse("02.02.2000");
            Passport = string.Empty;
            SpecialNotes = string.Empty;

            _phone = string.Empty;
            DriverIdNum = string.Empty;
            _pathToPhoto = string.Empty;
            _abonementCurent = null;

            AbonementsQueue = new ObservableCollection<AbonementBasic>();
        }

        #endregion

        #region /// МЕТОДЫ  ///////////////////////////

        //FIXME  Попробовать тут использовать не AbonementCurent, а _abonementCurent чтобы не вызывать лишний раз событие изменения абон

        public void StatusDirector()
        {
            if (Status == StatusPerson.Запрещён)
            {
                // AbonementCurent = null;
                return;
            }

            if (Status == StatusPerson.Гостевой)
            {
                _abonementCurent = AbonementController.GetInstance().GetFirstValid(Name);

                if (AbonementCurent == null) return;
            }

            // Нет Карты
            if (AbonementCurent == null)
            {
                Status = StatusPerson.Нет_Карты;
            }
            else // Активный
            {
                var isValid = AbonementCurent.IsValid();
                if (isValid)
                {
                    Status = AbonementCurent.Freeze != null && AbonementCurent.Freeze.IsFreezedNow() ? StatusPerson.Заморожен : StatusPerson.Активный;
                }
                else
                {
                    Status = StatusPerson.Нет_Карты;
                    AbonementCurent = null;
                }
            }
        }

        #endregion

        #region /// АБОНЕМЕНТ МЕТОДЫ ///

        public bool IsAbonementExist()
        {
            // FIXME Сделать тут проверку существования Валидного абонемента через Абонемент Контроллер
            return AbonementCurent != null && AbonementCurent.IsValid();
        }

        #endregion

        #region //Перегрузка операторов для сравнения клиентов
        /// <inheritdoc />
        /// <summary>
        /// Перегружаем операторы ==  !=, а так же метод Equal для сравнения по значению классов
        /// </summary>
        public bool Equals(Person other)
        {
            if (other == null) return false;
            /*this.Id == other.Id &&*/
            bool passpResult;
            bool phoneResult;
            bool fullNameResult;
            bool driverIdResult;

            var personalNumber = other.PersonalNumber == PersonalNumber || (PersonalNumber == 0 && other.PersonalNumber == 0);

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

            return driverIdResult && fullNameResult && phoneResult && passpResult && personalNumber;
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

            if (!string.IsNullOrEmpty(Phone) && !string.IsNullOrEmpty(other.Phone) && Phone == other.Phone)
            {
                response = ResponseCode.PhoneExist;
                return true;
            }

            if (!string.IsNullOrEmpty(Passport) && !string.IsNullOrEmpty(other.Passport) && Passport == other.Passport)
            {
                response = ResponseCode.PassportExist;
                return true;
            }

            if (!string.IsNullOrEmpty(DriverIdNum) && !string.IsNullOrEmpty(other.DriverIdNum) && DriverIdNum == other.DriverIdNum)
            {
                response = ResponseCode.DriverIdExist;
                return true;
            }
            response = ResponseCode.Success;
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
            return obj.GetType() == GetType() && Equals((Person)obj);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_phone != null ? _phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DriverIdNum != null ? DriverIdNum.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)_status;
                hashCode = (hashCode * 397) ^ (int)GenderType;
                hashCode = (hashCode * 397) ^ (AbonementCurent != null ? AbonementCurent.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)PersonalNumber;
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
