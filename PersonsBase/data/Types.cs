﻿using System;

namespace PBase
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
        Запрещён,
        Вероятный_Клиент
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

    [Serializable]
    public struct Employee
    {
        public string Name;
        public string Phone;
        public bool IsTrener;
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
            HourMinuteTime = Methods.ClockFormating(h, m);
        }
        public MyTime(string HM) // 08:30
        {
            int hour;
            int minute;
            if (string.IsNullOrEmpty(HM) || !HM.Contains(":"))
            {
                hour = 0;
                minute = 0;
            }
            else
            {
                var time = HM.Split(':');
                hour = int.Parse(time[0].Trim());
                minute = int.Parse(time[1].Trim());
            }

            HourMinuteTime = Methods.ClockFormating(hour, minute);
        }
    }


    #endregion
}