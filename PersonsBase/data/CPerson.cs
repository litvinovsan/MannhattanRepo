using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{
   [Serializable]
   public class Person : IEquatable<Person>
   {
      //////// СОБЫТИЯ без флага НЕ СОЗДАВАТЬ !!!!!!   Проблемы с сериализацией //
      [field: NonSerialized()]
      public event EventHandler StatusChanged;
      public void OnStatusChanged()
      {
         StatusChanged?.Invoke(this, EventArgs.Empty);
      }

      //[field: NonSerialized()]
      //public event EventHandler nameChanged;
      //public void OnNameChanged()
      //{
      //   if (nameChanged != null) nameChanged(this, EventArgs.Empty);
      //}

      /// Приватные поля
      private string _phone;
      private string _driverIdNum;
      private string _name;
      private StatusPerson _status;
      private AbonementBasic _abonementCurent;

      /// Публичные поля, доступные данные о Клиенте
      public string Name
      {
         get { return _name; }
         set
         {
            _name = HelperMethods.prepareName(value);
            Key = _name;
            //  OnNameChanged();
         }
      }
      public int PersonalNumber { get; set; }
      public string Key { get; private set; }

      public StatusPerson Status
      {
         get
         {
            return _status;
         }
         set
         {
            _status = value;
            OnStatusChanged();
         }
      }
      public DateTime BirthDate { get; set; }
      public Gender GenderType;
      public string Phone
      {
         get { return _phone; }
         set
         {
            //TODO: Написать обработку номера телефона. Проверка на +7,8, пробелы, дефисы, так же на городской номер.
            this._phone = String.IsNullOrEmpty(value) ? "" : value;
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
      public string PathToPhoto { get; set; } //FIXME: Добавить поддержку фотографий
      public string SpecialNotes { get; set; }
      public ObservableCollection<AbonementBasic> AbonementsQueue;
      public AbonementBasic AbonementCurent
      {
         get
         {
            return _abonementCurent;
         }
         set
         {
            ValidateAbonementAdd(value);
         }
      }

      /////////////////////////// КОНСТРУКТОРЫ.  ///////////////////////////
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
         PathToPhoto = "";
         SpecialNotes = "";
         _abonementCurent = null;
         AbonementsQueue = new ObservableCollection<AbonementBasic>();
      }

      /////////////////////////// МЕТОДЫ  ///////////////////////////
      /// 
      ///Обновляем статус клиента.
      public StatusPerson GetActualStatus()
      {
         if (AbonementCurent == null && (this._status == StatusPerson.Активный))
         {
            this._status = StatusPerson.Нет_Карты;
            return _status;
         }
         if (AbonementCurent == null) return _status;
         if (AbonementCurent.isValid() && this._status != StatusPerson.Заморожен && this._status != StatusPerson.Запрещён)
         {
            this._status = StatusPerson.Активный;
         }
         return _status;
      }
      private void ValidateAbonementAdd(AbonementBasic value)
      {
         //   if (AbonementsQueue == null) AbonementsQueue = new ObservableCollection<AbonementBasic>();

         if (_abonementCurent == null)
         {
            _abonementCurent = value;
            AbonementsQueue.Clear();
         }
         else // Изменяем уже существующий абонемент
         {
            if (value != null)
            {
               // Добавляем новый абонемент в очередь
               AbonementsQueue.Add(value);
            }
            else if (value == null && AbonementsQueue.Count == 0)
            {// Заменяем существующий абонемент на null со смещением по списку
               _abonementCurent = null;
            }
            else
            {
               _abonementCurent = AbonementsQueue[0];
               AbonementsQueue.RemoveAt(0);
            }
         }
      }

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

         if (other.PersonalNumber == 0 && this.PersonalNumber == 0)
         {
            personalNumber = true;
         }
         else
         {
            personalNumber = other.PersonalNumber == this.PersonalNumber;
         }

         if (other.Passport == null && this.Passport == null)
         {
            passpResult = true;
         }
         else
         {
            passpResult = (other.Passport == this.Passport);
         }

         if (other.Phone == null && this.Phone == null)
         {
            phoneResult = true;
         }
         else
         {
            phoneResult = (other.Phone == this.Phone);
         }

         if (other.Name == null && this.Name == null)
         {
            fullNameResult = true;
         }
         else
         {
            fullNameResult = (this.Name == other.Name);
         }


         if (other.DriverIdNum == null && this.DriverIdNum == null)
         {
            driverIdResult = true;
         }
         else
         {
            driverIdResult = (this.DriverIdNum == other.DriverIdNum);
         }

         if (driverIdResult && fullNameResult && phoneResult && passpResult)
            return true;
         else
            return false;
      }
      /// <summary>
      /// Возвращает true если обнаружено совпадение по какому-либо полю. Так же возвращает код совпадающего поля.
      /// </summary>
      public bool Equals(Person other, out ResponseCode response)
      {
         //TODO /*this.Id == other.Id &&*/
         response = ResponseCode.Fail;
         if (other == null) return false;

         if (Equals(other))
         {
            response = ResponseCode.Duplicate;
            return true;
         }
         else
         {
            if (this.PersonalNumber != 0 && other.PersonalNumber != 0 && this.PersonalNumber == other.PersonalNumber)
            {
               response = ResponseCode.IdNumberExist;
               return true;
            }
            else if (this.Name == other.Name)
            {
               response = ResponseCode.KeyExist;
               return true;
            }
            else
            {
               if (this.Phone != "" && other.Phone != "" && this.Phone == other.Phone)
               {
                  response = ResponseCode.PhoneExist;
                  return true;
               }
               else
               {
                  if (this.Passport != "" && other.Passport != "" && this.Passport == other.Passport)
                  {
                     response = ResponseCode.PassportExist;
                     return true;
                  }
                  else
                  {
                     if (this.DriverIdNum != "" && other.DriverIdNum != "" && this.DriverIdNum == other.DriverIdNum)
                     {
                        response = ResponseCode.DriverIdExist;
                        return true;
                     }
                  }
               }
            }
            response = ResponseCode.NoDuplicate;
            return false;
         }
      }
      public static bool operator ==(Person person1, Person person2)
      {
         if (((object)person1) == null || ((object)person2) == null)
            return Object.Equals(person1, person2);

         return person1.Equals(person2);
      }
      public static bool operator !=(Person person1, Person person2)
      {
         if (((object)person1) == null || ((object)person2) == null)
            return !Object.Equals(person1, person2);

         return !(person1.Equals(person2));
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != this.GetType()) return false;
         return Equals((Person)obj);
      }

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
