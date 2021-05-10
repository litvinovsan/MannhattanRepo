using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.View;
using System;

namespace PersonsBase.ViewPresenters
{
   public class ClientFormPresenter : IPresenter, IPresenterProperty
   {
      #region Поля и Свойства
      private readonly IClientsForm _viewForm;
      private readonly Person _person;
      private readonly AbonementController _abonementController = AbonementController.GetInstance();

      public AbonementBasic AbonementCurent { get; set; }

      #endregion

      #region Конструктор и Загрузка стартовая

      public ClientFormPresenter(Person person, AbonementBasic current)
      {
         AbonementCurent = current;

         _person = person;

         _viewForm = new ClientForm(_person.Name, this);
         _viewForm.InitializeControls();

         SetCurrentAbonement(ref current);
         _viewForm.UpdateDataOnForm();
      }

      /// <summary>
      /// Подписываемся на события с Клиентской формы
      /// </summary>
      private void Subscribe()
      {
         PwdForm.LockChangedEvent += _viewForm.LockControlsPwd;

         _viewForm.NameChanged += _view_NameChanged;
         _viewForm.StatusChanged += _viewForm_StatusChanged;
         _viewForm.ActivationChanged += _viewForm_ActivationChanged;
         _viewForm.TimeForTrenningChanged += _viewForm_TimeForTrenningChanged;
         _viewForm.PayChanged += _viewForm_PayChanged;
         _viewForm.TypeCardPeriodChanged += _viewForm_TypeCardPeriodChanged;
         _viewForm.TypeWorkoutChanged += _viewForm_TypeWorkoutChanged;
         _viewForm.SpaServiceChanged += _viewForm_SpaServiceChanged;
         _viewForm.OstDaysChanged += _viewForm_OstDaysChanged;
         _viewForm.OstPersonsChanged += _viewForm_OstPersonsChanged;
         _viewForm.OstAerobChanged += _viewForm_OstAerobChanged;
         _viewForm.OstMiniGroupChanged += _viewForm_OstMiniGroupChanged;
         _viewForm.ActivationDateChanged += _viewForm_ActivationDateChanged;
         _viewForm.EndDateChanged += _viewForm_EndDateChanged;

         _viewForm.ActiveAbonementChanged += _viewForm_ListValidSelectionChanged;
         _viewForm.RemoveAbonement += _viewForm_RemoveAbonement;
         _viewForm.ClosingForm += _viewForm_ClosingForm;
         _viewForm.SaveButtonPressed += _viewForm_SaveButtonPressed;

         // Если изменился
         _abonementController.CollectionChanged += _abonementController_CollectionChanged;
      }

      private void Unsubscribe()
      {
         PwdForm.LockChangedEvent -= _viewForm.LockControlsPwd;
         _viewForm.NameChanged -= _view_NameChanged;
         _viewForm.ActiveAbonementChanged -= _viewForm_ListValidSelectionChanged;
         _viewForm.RemoveAbonement -= _viewForm_RemoveAbonement;
         _viewForm.StatusChanged -= _viewForm_StatusChanged;
         _viewForm.ActivationChanged -= _viewForm_ActivationChanged;
         _viewForm.ClosingForm -= _viewForm_ClosingForm;
         _viewForm.PayChanged -= _viewForm_PayChanged;
         _viewForm.TypeCardPeriodChanged -= _viewForm_TypeCardPeriodChanged;
         _viewForm.TypeWorkoutChanged -= _viewForm_TypeWorkoutChanged;
         _viewForm.SpaServiceChanged -= _viewForm_SpaServiceChanged;
         _viewForm.OstDaysChanged -= _viewForm_OstDaysChanged;
         _viewForm.OstPersonsChanged -= _viewForm_OstPersonsChanged;
         _viewForm.OstAerobChanged -= _viewForm_OstAerobChanged;
         _viewForm.OstMiniGroupChanged -= _viewForm_OstMiniGroupChanged;
         _viewForm.ActivationDateChanged -= _viewForm_ActivationDateChanged;
         _viewForm.EndDateChanged -= _viewForm_EndDateChanged;
         _viewForm.SaveButtonPressed -= _viewForm_SaveButtonPressed;

         _abonementController.CollectionChanged -= _abonementController_CollectionChanged;
      }

      /// <summary>
      ///  Загрузка на форму значений по умолчанию при старте
      /// </summary>
      public void SetDataOnForm()
      {
         // Всегда отображаемые параметры
         _viewForm.SetNameTextBox(_person.Name);
         _viewForm.SetStatusComboBox(_person.Status);

         // Отображаются если есть абонемент
         if (_person.AbonementCurent != null)
         {
            _viewForm.SetActivationComboBox(_person.AbonementCurent.IsActivated ? Activation.Активирован : Activation.Не_Активирован);
            _viewForm.SetTimeForTrenning(_person.AbonementCurent.TimeTraining);
            _viewForm.SetPayComboBox(_person.AbonementCurent.PayStatus);
            _viewForm.SetTypeWorkout(_person.AbonementCurent.TypeWorkout);
            _viewForm.SetSpaComboBoxa(_person.AbonementCurent.Spa);
            _viewForm.SetOstDaysComboBox(_person.AbonementCurent.GetRemainderDays());
            _viewForm.SetOstPersonalsComboBox(_person.AbonementCurent.NumPersonalTr);
            _viewForm.SetOstAerobComboBox(_person.AbonementCurent.NumAerobicTr);
            _viewForm.SetBuyDate(_person.AbonementCurent.BuyDate);
            _viewForm.SetActivationDate(_person.AbonementCurent.BuyActivationDate);
            _viewForm.SetEndDate(_person.AbonementCurent.EndDate);


            // Настройки зависящие от типа абонемента
            switch (_person.AbonementCurent)
            {
               case AbonementByDays byDays:
                  {
                     _viewForm.SetTypeCardComboBox(byDays.TypeAbonement);
                     break;
                  }
               case ClubCardA clubCardA:
                  { 
                     _viewForm.SetTypeCardComboBox(clubCardA.PeriodAbonem);
                     break;
                  }
               case SingleVisit singleVisit:
                  {
                     _viewForm.InitComboBoxTypeCard<PeriodSingleVisit>();
                     break;
                  }
            }
         }
      }

      #endregion

      #region Методы общие

      /// <summary>
      /// Устанавливает конкретной персоне новый текущий Абонемент. 
      /// Вызываются методы загрузки обновленных данных на форме. А также присваивается персоне новый
      /// текущий абонемент
      /// </summary>
      /// <param name="abonement"></param>
      public void SetCurrentAbonement(ref AbonementBasic abonement)
      {
         Unsubscribe();
         AbonementCurent = abonement;
         _person.AbonementCurent = abonement;
         SetDataOnForm();
         Subscribe();
      }

      public void Run()
      {
         _viewForm.Show();
      }

      public void Dispose()
      {
         Unsubscribe();
         _abonementController.Save();
      }


      #endregion

      #region Обработчики всех событий с формы КЛиента
      private void _abonementController_CollectionChanged(object sender, EventArgs e)
      {
         _viewForm.ActiveAbonementChanged -= _viewForm_ListValidSelectionChanged;

         _viewForm.UpdateAbonementsCollection(_abonementController.GetListValid(_person.Name));

         _viewForm.ActiveAbonementChanged += _viewForm_ListValidSelectionChanged;

         // Обновляем контролы на форме
         _viewForm.UpdateButtonsState();
      }

      private void _viewForm_ActivationChanged(Activation obj)
      {
         _person.AbonementCurent.IsActivated = obj == Activation.Активирован;
         _viewForm.UpdateButtonsState();
         _viewForm.UpdateDataOnForm();
      }

      private void _viewForm_TimeForTrenningChanged(TimeForTr obj)
      {
         _person.AbonementCurent.TimeTraining = obj;
      }

      private void _viewForm_StatusChanged(StatusPerson obj)
      {
         _person.Status = obj;
      }
      private void _viewForm_PayChanged(Pay obj)
      {
         _person.AbonementCurent.PayStatus = obj;
      }

      private void _viewForm_TypeCardPeriodChanged(object obj)
      {
         // Настройки зависящие от типа абонемента
         switch (_person.AbonementCurent)
         {
            case AbonementByDays byDays:
               {
                  (_person.AbonementCurent as AbonementByDays).TypeAbonement = (DaysInAbon)obj;
                  break;
               }
            case ClubCardA clubCardA:
               {
                  (_person.AbonementCurent as ClubCardA).PeriodAbonem = (PeriodClubCard)obj;
                  break;
               }
            case SingleVisit singleVisit:
               {
                  break;
               }
         }
      }

      private void _viewForm_TypeWorkoutChanged(TypeWorkout obj)
      {
         if (_person.AbonementCurent is AbonementByDays abonementByDays)
         {
            _person.AbonementCurent.TypeWorkout = obj;
            if (obj == TypeWorkout.Персональная)
            {
               var newEndDate = abonementByDays.BuyActivationDate.AddMonths(Options.ValidPeriod12Month).Date;
               abonementByDays.SetNewEndDate(Options.ValidPeriod12Month, newEndDate);
            }
            else
            {
               var newEndDate = abonementByDays.BuyActivationDate.AddMonths(Options.ValidPeriodInMonth).Date;
               abonementByDays.SetNewEndDate(Options.ValidPeriodInMonth, newEndDate);
            }
         }
      }

      private void _viewForm_SpaServiceChanged(SpaService obj)
      {
         _person.AbonementCurent.Spa = obj;
      }

      /// <summary>
      /// Изменить количество дней можно только для Абонементов
      /// </summary>
      /// <param name="obj"></param>
      private void _viewForm_OstDaysChanged(int obj)
      {
         if (_person.AbonementCurent is AbonementByDays)
         {
            var abon = _person.AbonementCurent as AbonementByDays;
            if (obj != abon?.GetRemainderDays())
               abon.SetDaysLeft(obj);
         }
      }

      private void _viewForm_OstPersonsChanged(int obj)
      {
         _person.AbonementCurent.NumPersonalTr = obj;
      }

      private void _viewForm_OstAerobChanged(int obj)
      {
         _person.AbonementCurent.NumAerobicTr = obj;
      }

      private void _viewForm_OstMiniGroupChanged(int obj)
      {
         _person.AbonementCurent.NumMiniGroup = obj;
      }

      private void _viewForm_EndDateChanged(DateTime obj)
      {
         _person.AbonementCurent.EndDate = obj;
      }

      private void _viewForm_ActivationDateChanged(DateTime obj)
      {
         // Дата активации совпадает с текущей. 
         if (obj.CompareTo(_person.AbonementCurent.BuyActivationDate) == 0) return;

         switch (_person.AbonementCurent)
         {
            case AbonementByDays byDays:
               {
                  int numMonths = (_person.AbonementCurent.TypeWorkout == TypeWorkout.Персональная ||
                     _person.AbonementCurent.TypeWorkout == TypeWorkout.МиниГруппа) ?
                         Options.ValidPeriod12Month : Options.ValidPeriodInMonth;

                  DateTime finishDate = (_person.AbonementCurent.TypeWorkout == TypeWorkout.Персональная ||
                     _person.AbonementCurent.TypeWorkout == TypeWorkout.МиниГруппа) ?
                         obj.AddMonths(Options.ValidPeriod12Month).Date :
                            obj.AddMonths(Options.ValidPeriodInMonth).Date;
                  byDays.SetNewEndDate(numMonths, finishDate);
                  _person.AbonementCurent.BuyActivationDate = obj;
                  break;
               }
            case ClubCardA clubCardA:
               {
                  clubCardA.SetActivationDate(obj);
                  break;
               }
            case SingleVisit singleVisit:
               {
                  break;
               }
         }

      }

      private void _viewForm_RemoveAbonement(string arg1, AbonementBasic arg2)
      {
         _abonementController.RemoveAbonement(arg1, arg2);
      }

   

      private void _viewForm_ListValidSelectionChanged(AbonementBasic obj)
      {
         SetCurrentAbonement(ref obj);
        // SetDataOnForm();
         _viewForm.UpdateDataOnForm();

      }

      private void _view_NameChanged(string nameNew)
      {
         Logic.ChangePersonName(_person.Name, nameNew);
      }

      private void _viewForm_ClosingForm()
      {
         Dispose();
      }

      private void _viewForm_SaveButtonPressed()
      {
         SetDataOnForm(); // Обновляем форму во время сохранения
       //  _abonementController.Save();
      }
      #endregion
   }
}

