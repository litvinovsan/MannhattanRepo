using System;
using System.Collections.Generic;

namespace PersonsBase.data.Abonements
{
   [Serializable]
   public class ClubCardA : AbonementBasic //Безлимитный Абонемент
   {
      // Свойства
      private int _numAerobicTr;
      private int _numberMonths;
      private PeriodClubCard _periodAbonem;
      public const string NameAbonement = "Клубная Карта";

      // Конструктор
      public ClubCardA(Pay payStatus, TimeForTr time, TypeWorkout typeTr, SpaService spa,
          PeriodClubCard periodInMonths)
          : base(payStatus, time, typeTr, spa)
      {
         _numberMonths = (int)periodInMonths;
         _numAerobicTr = _numberMonths * 10;
         NumPersonalTr = 0;
         NumMiniGroup = 0;
         _periodAbonem = periodInMonths;

         Freeze = new FreezeClass(periodInMonths);

         EndDateChanged += CalculateDaysLeft;
         EndDate = DateTime.Now.AddMonths(_numberMonths).Date;
      }

      public sealed override int NumPersonalTr { get; set; }

      public PeriodClubCard PeriodAbonem
      {
         get { return _periodAbonem; }
         set
         {
            _periodAbonem = value;
            _numberMonths = (int)_periodAbonem;
            _numAerobicTr = _numberMonths * 10;
            EndDate = BuyActivationDate.AddMonths(_numberMonths).Date;
         }
      }

      public override string AbonementName
      {
         get { return NameAbonement; }
      }

      public override string InfoMessageEnd
      {
         get { return "Клубная Карта Закончилась!"; }
      }

      public override int NumAerobicTr
      {
         get { return _numAerobicTr; }
         set
         {
            if (value >= 0 && value <= _numberMonths * 10) _numAerobicTr = value;
            OnValuesChanged();
         }
      }

      // Методы
      public override bool IsValid()
      {
         // Если +, то DateTime.Now позднее _endDate
         // Если 0, то даты совпали
         // Если -, то DateTime.Now раньше Конца абонемента

         if (_numberMonths == 0)
         { throw new Exception("Ошибка в методе IsValid Клубной карты. _numberMonths =0" + this.GetType()); }

         // FIXME Проверить как работает Валидация клубной карты
         //   if (!IsActivated && DateTime.Now.Date.CompareTo(BuyActivationDate.AddMonths(12).Date) <= 0) return true;

         var addFreezedDays = Freeze?.GetSpentDays();
         DateTime finishDate = new DateTime();
         finishDate = EndDate.Date.AddDays((addFreezedDays ?? 0));
         var checkDate = DateTime.Now.Date.CompareTo(finishDate.Date) <= 0;
         return checkDate;
      }

      /// <summary>
      /// Для абонементов которые на половину исхожены. Позволяет установить дату активации в прошлом или в будущем
      /// дату окончания.
      /// </summary>
      public override void TryActivate(DateTime newDate)
      {
         if (IsActivated) return; // Уже Активирован.
         IsActivated = true;
         SetActivationDate(newDate);
      }

      public override bool CheckInWorkout(TypeWorkout type)
      {
         var result = false;

         if (!IsValid()) return false;
         switch (type)
         {
            case TypeWorkout.Аэробный_Зал:
               {
                  if (NumAerobicTr > 0)
                  {
                     --NumAerobicTr;
                     result = true;
                  }

                  break;
               }
            case TypeWorkout.Персональная:
               {
                  if (NumPersonalTr > 0)
                  {
                     --NumPersonalTr;
                     result = true;
                  }

                  break;
               }
            case TypeWorkout.Тренажерный_Зал:
               {
                  result = true;
                  break;
               }
            case TypeWorkout.МиниГруппа:
               {
                  if (NumMiniGroup > 0)
                  {
                     --NumMiniGroup;
                     result = true;
                  }
                  break;
               }
            default:
               throw new ArgumentOutOfRangeException(nameof(type), type, null);
         }
         // OnValuesChanged();
         return result;
      }

      /// <inheritdoc />
      /// <summary>
      ///     Добавить Блок Персональных или Аэробных тренировок к Клубной Карте
      /// </summary>
      public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
      {
         bool result;

         switch (type)
         {
            case TypeWorkout.Аэробный_Зал:
               {
                  NumAerobicTr += numberToAdd;
                  result = true;
                  break;
               }
            case TypeWorkout.Персональная:
               {
                  NumPersonalTr += numberToAdd;
                  result = true;
                  break;
               }
            case TypeWorkout.Тренажерный_Зал:
               {
                  result = false;
                  break;
               }
            case TypeWorkout.МиниГруппа:
               {
                  NumMiniGroup += numberToAdd;
                  result = true;

                  break;
               }
            default:
               {
                  result = false;
                  break;
               }
         }
         OnValuesChanged();
         return result;
      }

      public override IEnumerable<Tuple<string, string>> GetShortInfoList()
      {
         var numFreezDays = Freeze?.GetSpentDays() ?? 0; //Продлим на замороженные дни

         // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
         var result = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Тип: ", AbonementName),
                new Tuple<string, string>("Доступные Тренировки ", TypeWorkout.ToString()),
                new Tuple<string, string>("Время Тренировок ", TimeTraining.ToString()),
                new Tuple<string, string>("Услуги", Spa.ToString()),
                new Tuple<string, string>("Срок Клубной Карты", _numberMonths + "  мес."),
                new Tuple<string, string>("Дата Покупки", BuyDate.ToString("d")),
                new Tuple<string, string>("Дата Активации", BuyActivationDate.ToString("d")),
                new Tuple<string, string>("Дата Окончания", EndDate.Date.AddDays(numFreezDays).ToString("d")),
                new Tuple<string, string>("Осталось Дней", GetRemainderDays().ToString())
            };
         if (NumPersonalTr > 0)
            result.Add(new Tuple<string, string>("Осталось Персональных", NumPersonalTr.ToString()));

         if (NumAerobicTr > 0)
            result.Add(new Tuple<string, string>("Осталось Аэробных", NumAerobicTr.ToString()));

         if (NumMiniGroup > 0)
            result.Add(new Tuple<string, string>("Осталось МиниГрупп", NumMiniGroup.ToString()));

         if (PayStatus == Pay.Не_Оплачено)
            result.Add(new Tuple<string, string>("Статус Оплаты ", PayStatus.ToString()));

         if (Freeze != null)
            result.Add(new Tuple<string, string>("Осталось дней Заморозки", Freeze.GetAvailableDays().ToString()));

         return result;
      }
      /// <summary>
      /// Получить оставшиеся дни в клубной карте
      /// </summary>
      /// <returns></returns>
      public override int GetRemainderDays()
      {
         var numFreezDays = Freeze?.GetSpentDays() ?? 0; //Продлим на замороженные дни
         DaysLeft = (EndDate.Date - DateTime.Now.Date).Days + numFreezDays;
         return (DaysLeft >= 0) ? DaysLeft : 0;
      }

      private void CalculateDaysLeft(object sender, EventArgs e)
      {
         GetRemainderDays();
         OnValuesChanged();
      }

      /// <summary>
      /// Позволяет установить дату активации в прошлом и в будущем без проверок! 
      /// </summary>
      /// <param name="startDate"></param>
      public void SetActivationDate(DateTime startDate)
      {
         // Если +, то DateTime.Now позднее startDate
         // Если 0, то даты совпали
         // Если -, то DateTime.Now раньше startdate

         var date = startDate.AddMonths(_numberMonths).Date;
         if (EndDate.Date.CompareTo(date) != 0)
         {
            EndDate = date;
            BuyActivationDate = startDate;
            OnValuesChanged();
         }
      }

      /// <summary>
      /// Метод очень узкий только для Клубной Карты. Хотя можно  было сделать универсальным по названию для всех типов
      /// </summary>
      /// <returns></returns>
      public PeriodClubCard GetTypeClubCard()
      {
         return PeriodAbonem;
      }

      /// <summary>
      /// Метод такой же как и GetTypeClubCard() только универсально называется, для всех разновидностей абонементов, возвращает строку с типом.
      /// 
      /// </summary>
      /// <returns></returns>
      public override string GetAbonementType()
      {
         return PeriodAbonem.ToString().Replace("На_", "");
      }
   }
}