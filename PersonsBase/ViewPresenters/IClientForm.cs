using PersonsBase.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.ViewPresenters
{
   // контракт, по которому представитель будет взаимодействовать с формой
   public interface IClientForm : IView
   {
      #region Детальные Данные о Абонементе и Клиенте

      //string Name { get; set; }
      //StatusPerson Status { get; set; }
      //Activation Activation { get; set; }
      //TimeForTr TimeForTrenning { get; set; }

      // FIXME Добавить остальные свойства

      #endregion

      #region События
      event Action<string> NameChanged;
      event Action<StatusPerson> StatusChanged;
      event Action<bool> ActivationChanged;
      event Action<TimeForTr> TimeForTrenningChanged;

      // FIXME Добавить остальные свойства
      #endregion

      #region Методы  для установки значений в форме в группе детальных данных по персоне и абонементу

      void SetDetailsName(string name);
      void SetDetailsStatus(StatusPerson status);
      void SetDetailsActivation(bool activation);
      void SetDetailsTimeForTrenning(TimeForTr time);


      #endregion


   }
}
