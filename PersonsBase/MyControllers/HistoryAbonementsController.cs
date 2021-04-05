using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.MyControllers
{
    // FIXME Удалить этот класс. Выдавать историю абонементов из Контроллера абонементов.
    public class HistoryAbonementsController
    {
        const string FName = "HistoryAbonements";

        #region Синглтон
        [NonSerialized]
        private static HistoryAbonementsController _instance;  //Singleton.
        public static HistoryAbonementsController GetInstance()
        {
            return _instance ?? (_instance = new HistoryAbonementsController());
        }
        #endregion

        #region Поля
        public Dictionary<string, List<AbonHistory>> HistoryAbonements;


        #endregion
        // DataBaseLevel.GetPersonsAbonHistDict()
    }
}
