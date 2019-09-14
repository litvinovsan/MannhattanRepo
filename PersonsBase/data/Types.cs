using System;

namespace PBase
{
    /// <summary>
    /// Вспомогательные Общедоступные Структуры и Классы
    /// </summary>

    #region /// СТРУКТУРЫ ///

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
        Запрещён,
        Вероятный_Клиент
    }

    [Serializable]
    public enum TimeForTr
    {
        Утро,
        День
    }

    [Serializable]
    public enum TypeWorkout  //Доступные Тренировки
    {
        Тренажерный_Зал,
        Аэробный_Зал,
        Персональная
    }

    [Serializable]
    public enum ResponseCode
    {
        Success,
        Fail,
        //ответы по совпадениям
        NoDuplicate,
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
        Нет_Спа,
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
        На_8_посещений = 8,
        На_10_посещений = 10,
        На_12_посещений = 12
    }

    [Serializable]
    public enum FreezeLenghtMont
    {
        На_1_Месяц = 1,
        На_2_Месяца = 2,
    }

    #endregion

    #region /// КЛАССЫ ///


    [Serializable]
    public class MyTime
    {
        public readonly static string[] Hours = { "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
        public readonly static string[] Minutes = { "00", "10", "20", "30", "40", "50" };

        public readonly int Hour;
        public readonly int Minute;
        public string HourMinuteTime;
        public MyTime(int h, int m)
        {
            Hour = h;
            Minute = m;
            HourMinuteTime = Methods.ClockFormating(Hour, Minute);
        }
        public MyTime(string HM) // 08:30
        {
            if (string.IsNullOrEmpty(HM) || !HM.Contains(":"))
            {
                Hour = 0;
                Minute = 0;
            }
            else
            {
                var time = HM.Split(':');
                Hour = int.Parse(time[0].Trim());
                Minute = int.Parse(time[1].Trim());
            }

            HourMinuteTime = Methods.ClockFormating(Hour, Minute);
        }
    }


    #endregion
}