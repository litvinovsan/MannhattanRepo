using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.ViewPresenters
{
   public class ClientFormPresenter : IPresenter //, IDisposable
   {
      #region Поля и Свойства
      private readonly IClientForm _viewForm;
      private readonly Person _person;
      public AbonementBasic AbonementCurrent { get; private set; }
      #endregion

      #region Конструктор
      public ClientFormPresenter(IClientForm view, Person person, AbonementBasic current)
      {
         _viewForm = view;
         _person = person;
         AbonementCurrent = current;
         // СОБЫТИЯ изменения вкладки Детальной информации
         _viewForm.NameChanged += _view_NameChanged;

      }
      #endregion

      private void _view_NameChanged(string obj)
      {
         throw new NotImplementedException();
      }

      public void Run()
      {
         _viewForm.Show();
         Load();
      }

      public void SetCurrentAbonement(ref AbonementBasic abonement)
      {
         AbonementCurrent = abonement;
         // FIXME Обновить всёж
      }
      public void Load()
      {
         _viewForm.SetDetailsName(_person.Name);
         _viewForm.SetDetailsActivation(AbonementCurrent.IsActivated);
         _viewForm.SetDetailsStatus(_person.Status);
         _viewForm.SetDetailsTimeForTrenning(AbonementCurrent.TimeTraining);
      }
   }
}
