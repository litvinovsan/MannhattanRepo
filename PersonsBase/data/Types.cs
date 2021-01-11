using System;
using PersonsBase.control;

namespace PersonsBase.data
{
    /// <summary>
    /// Вспомогательные Общедоступные Структуры и Классы
    /// </summary>

    #region /// СТРУКТУРЫ и ОБЬЕДИНЕНИЯ ///

    [Serializable]
    public enum Gender
    {
        Мужской,
        Женский,
        Неизвестен
    }

    [Serializable]
    public enum StatusPerson
    {
        Активный,
        Нет_Карты,
        Заморожен,
        Гостевой,
        Запрещён
    }

    [Serializable]
    public enum TimeForTr
    {
        Утро,
        Весь_День
    }

    [Serializable]
    public enum TypeWorkout  //Доступные Тренировки
    {
        Тренажерный_Зал,
        Аэробный_Зал,
        Персональная,
        МиниГруппа
    }

    [Serializable]
    public enum ResponseCode
    {
        Success,
        Fail,
        //ответы по совпадениям
        Duplicate,
        NameExist,
        KeyExist,
        IdNumberExist,
        PhoneExist,
        PassportExist,
        DriverIdExist
    }

    [Serializable]
    public enum SpaService
    {
        Без_Спа,
        Спа
    }

    [Serializable]
    public enum Pay
    {
        Не_Оплачено,
        Оплачено
    }

    [Serializable]
    public enum PeriodClubCard
    {
        На_1_Месяц = 1,
        На_3_Месяца = 3,
        На_6_Месяцев = 6,
        На_12_Месяцев = 12
    }

    [Serializable]
    public enum DaysInAbon
    {
        На_5_посещений = 5,
        На_8_посещений = 8,
        На_10_посещений = 10,
        На_12_посещений = 12
    }

    [Serializable]
    public struct Employee
    {
        public string Name;
        public string Phone;
        public bool IsTrener;
    }

    [Serializable]
    public struct PersonalDataStruct
    {
        public string Name;
        public string Phone;
        public string Passport;
        public string DriveId;
        public string photoName;
        public string SpecialNotes;
        public int PersonalNumber;
        public Gender Gender;
        public DateTime BDate;
    }

    [Serializable]
    public struct PersonField
    {
        public string HeaderName;
        public string Value;
    }

    [Serializable]
    public struct GymItem
    {
        public readonly string Time;
        public readonly string Name;
        public readonly DateTime VisitDateTime;
        public GymItem(string t, string n)
        {
            Time = t;
            Name = n;
            VisitDateTime = DateTime.Now;
        }
    }

    [Serializable]
    public struct AerobItem
    {
        public readonly string GroupTimeName;
        public readonly string NamePerson;
        public readonly DateTime VisitDateTime;
        public AerobItem(string groupTime, string namePerson)
        {
            GroupTimeName = groupTime;
            NamePerson = namePerson;
            VisitDateTime = DateTime.Now;
        }
    }
    [Serializable]
    public struct StandartItem
    {
        public readonly string TrenerName;
        public readonly string NamePerson;
        public readonly DateTime VisitDateTime;
        public StandartItem(string namePerson, string trenerName)
        {
            TrenerName = trenerName;
            NamePerson = namePerson;
            VisitDateTime = DateTime.Now;
        }
    }

    [Serializable]
    public enum Activation
    {
        Активирован,
        Не_Активирован
    }
   

    #endregion

    #region /// КЛАССЫ ///


    [Serializable]
    public class MyTime
    {
        public static readonly string[] Hours = { "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
        public static readonly string[] Minutes = { "00", "10", "20", "30", "40", "50" };

        public readonly string HourMinuteTime;
        public MyTime(int h, int m)
        {
            HourMinuteTime = Logic.ClockFormating(h, m);
        }
        public MyTime(string hm) // 08:30
        {
            int hour;
            int minute;
            if (string.IsNullOrEmpty(hm) || !hm.Contains(":"))
            {
                hour = 0;
                minute = 0;
            }
            else
            {
                var time = hm.Split(':');
                hour = int.Parse(time[0].Trim());
                minute = int.Parse(time[1].Trim());
            }

            HourMinuteTime = Logic.ClockFormating(hour, minute);
        }
    }


    #endregion
}