using PersonsBase.data.Abonements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.ViewPresenters
{
   public interface IPresenterProperty
   {
      /// <summary>
      /// Текущий Отображаемый абонемент на форме
      /// </summary>
      AbonementBasic AbonementCurent { get; }
      /// <summary>
      /// Срабатывает когда изменяется Отображаемый абонемент на форме
      /// </summary>
      event Action<AbonementBasic> AbonementCurentChanged;
      /// <summary>
      /// Содержит коллекцию Абонементов, отображаемую в ListView валидных-невалидных абонементов.
      /// Эта коллекция обновляется ТОЛЬКО из метода SetAbonementsListview. 
      /// Нужна только для идентификации текущего выбранного абонемента
      /// </summary>
      List<AbonementBasic> CurrentListViewCollection { get; set; }

   }
}
