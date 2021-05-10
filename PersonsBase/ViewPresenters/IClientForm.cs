using PersonsBase.data;
using PersonsBase.data.Abonements;
using System;
using System.Collections.Generic;

namespace PersonsBase.ViewPresenters
{
   // контракт, по которому представитель будет взаимодействовать с формой
   public interface IClientsForm : IView
   {
      #region События Изменения внутри формы. Вкладка детальных данных
      event Action<string> NameChanged;
      event Action<StatusPerson> StatusChanged;
      event Action<Activation> ActivationChanged;
      event Action<TimeForTr> TimeForTrenningChanged;
      event Action<Pay> PayChanged;
      event Action<object> TypeCardPeriodChanged;
      event Action<TypeWorkout> TypeWorkoutChanged;
      event Action<SpaService> SpaServiceChanged;
      event Action<int> OstDaysChanged;
      event Action<int> OstPersonsChanged;
      event Action<int> OstAerobChanged;
      event Action<int> OstMiniGroupChanged;
      event Action<DateTime> ActivationDateChanged;
      event Action<DateTime> EndDateChanged;
      #endregion

      #region События. Персональные данные клиента
      /// <summary>
      /// Old, New Values
      /// </summary>
      event Action<string, string> PersonalNumberChanged;

      #endregion

      #region События Кнопок и Формы
      event Action<string, AbonementBasic> RemoveAbonement;
      /// <summary>
      /// Событие вызываемое в случае изменения текущего активного абонемента, отображаемого на форме клиента. 
      /// Когда выбирается новый действующий или не валидный абонемент - вызывается это событие
      /// </summary>
      event Action<AbonementBasic> ActiveAbonementChanged;
      event Action ClosingForm;
      event Action SaveButtonPressed;

      #endregion

      #region Методы  для установки значений в форме в группе детальных данных по персоне и абонементу

      void SetNameTextBox(string name);
      void SetStatusComboBox(StatusPerson status);
      void SetActivationComboBox(Activation activation);
      void SetTimeForTrenning(TimeForTr time);
      void SetPayComboBox(Pay pay);
      void SetTypeWorkout(TypeWorkout workout);
      void SetSpaComboBoxa(SpaService spa);
      void SetOstDaysComboBox(int num);
      void SetOstPersonalsComboBox(int num);
      void SetOstAerobComboBox(int num);
      void SetBuyDate(DateTime buyDate);
      void SetActivationDate(DateTime activationDate);
      void SetEndDate(DateTime endDate);

      // КомбоБокс Длительность Абонемента(дней) или Период КлКарты(мес)
      void SetTypeCardComboBox(DaysInAbon value);
      void SetTypeCardComboBox(PeriodClubCard value);
      void InitComboBoxTypeCard<T>();

      void InitializeControls();
      void LockControlsPwd(bool isLocked);
      void UpdateButtonsState();
      void UpdateDataOnForm();

      // Персональные данные
      void SetPersonalNumber(string number);
      #endregion


      // Списки Абонементов Пользователя. Валидный и Невалидный
      void UpdateAbonementsCollection(List<AbonementBasic> abonements);

   }
}
