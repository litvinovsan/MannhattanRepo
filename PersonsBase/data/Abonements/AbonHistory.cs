using System;
using System.ComponentModel;

namespace PersonsBase.data.Abonements
{
    /// <summary>
    ///  История абонементов.
    /// Данный клас используется хранит один экземпляр
    /// информации об абонементн
    /// </summary>

    [Serializable]
    public class AbonHistory
    {
        // [MyFieldName("Название")]  // Или первый или второй вариант можно использовать для названий
        [Description("Название")]
        public string AbonementName { get; set; }

        [Description("Тип")]
        public string TypeWorkout { get; set; }

        [Description("Активация")]
        public string ActivationDate { get; set; }

        [Description("Окончание")]
        public string EndDate { get; set; }

        [Description("Админ")]
        public string AdminName { get; set; }

        [Description("Спа")]
        public string SpaStatus { get; set; }

        [Description("Время")]
        public string Time { get; set; }

        [Description("Кл.Карт")]
        public string ClubCardPeriod { get; set; }

        [Description("Персон")]
        public string NumPerson { get; set; }

        [Description("Аэробн")]
        public string NumAerobn { get; set; }

        [Description("Мини")]
        public string NumMini { get; set; }
    }
}
