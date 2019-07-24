﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{
   public partial class ClientForm
   {
      // Создаем Контролы для Детальной информации
      // Создаются все контролы, а дальше раскидываются по Тэйбл Панелям

      private Action _saveDelegateChain; // Цепочка Делегатов для сохранения измененных данных.

      #region // Метод. Фамилия Имя Отчество

      private string _editedName; // Сохраняем новое редактированное имя.

      private Tuple<Label, Control> CreateNameField()
      {
         const string nameLabel = "Имя Клиента";

         Label lableType = CreateLabel(nameLabel);
         TextBox textbox = CreateTextBox(false);
         _editedName = _person.Name;
         // Инициализируем наши Контролы
         textbox.Text = _person.Name;
         // Подписываемся на событие по изменению
         textbox.TextChanged += Textbox_NameChanged;

         _saveDelegateChain += () =>
         {
            if (_editedName != null && _editedName != "" && _person.Name != _editedName)
            {
               _dataBase.EditName(_person.Name, _editedName);
               SetControlBackColor(textbox, _editedName, _person.Name);
            }
         };

         return new Tuple<Label, Control>(lableType, textbox);
      }
      private void Textbox_NameChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;
         _editedName = tb.Text;
         SetControlBackColor(tb, _editedName, _person.Name);
         IsChangedUpdateStatus(_editedName, _person.Name);
      }

      #endregion

      #region // Метод. Статус Клиента.

      StatusPerson _editedStatusPerson;
      Tuple<Label, Control> CreateStatusField()
      {
         const string curentStatusLabel = "Текущий статус Клиента: ";
         Label lableType = CreateLabel(curentStatusLabel);
         _editedStatusPerson = _person.Status;
         ComboBox comboStatus = CreateComboBox();
         // Инициализируем наши Контролы
         var array = Enum.GetNames(typeof(StatusPerson));
         // Удалим из Массива Активный и Заморожен если у клиента нет абонемента.
         if (_person.AbonementCurent == null)
         {
            var updatedarray = array.Where((x) => (x != StatusPerson.Активный.ToString()) && ((x != StatusPerson.Заморожен.ToString()))).Select(x => x);
            array = updatedarray.ToArray<string>();
         }

         // Записываем Поля в Комбобокс
         comboStatus.Items.AddRange(array);
         comboStatus.SelectedItem = _person.Status.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboStatus.SelectedIndexChanged += ComboStatus_SelectedIndexChanged;
         _saveDelegateChain += () =>
         {
            if (_editedStatusPerson != _person.Status)
            {
               _person.StatusChanged -= UpdateControlState;
               _person.Status = _editedStatusPerson;
               _person.StatusChanged += UpdateControlState;
               ComboBoxColor(comboStatus, _person.Status.ToString(), _editedStatusPerson.ToString());
               _person.OnStatusChanged();
            }
         };

         return new Tuple<Label, Control>(lableType, comboStatus);
      }
      private void ComboStatus_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var editedStatus = (StatusPerson)Enum.Parse(typeof(StatusPerson), tb.SelectedItem.ToString());
         _editedStatusPerson = editedStatus;
         IsChangedUpdateStatus(_editedStatusPerson.ToString(), _person.Status.ToString());
         ComboBoxColor(tb, _person.Status.ToString(), _editedStatusPerson.ToString());
      }
      #endregion

      #region // Метод. Доступные Тренировки.
      TypeWorkout _editedTypeWorkout;
      Tuple<Label, Control> CreateTypeWorkoutField()
      {
         const string labelText = "Доступные Тренировки: ";
         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();
         _editedTypeWorkout = _person.AbonementCurent.trainingsType;
         // Инициализируем наши Контролы
         var array = Enum.GetNames(typeof(TypeWorkout));
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
         comboBox.SelectedItem = _person.AbonementCurent.trainingsType.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_TypeWorkout_SelectedIndexChanged;

         _saveDelegateChain += () =>
         {
            if (_person.AbonementCurent != null && _editedTypeWorkout != _person.AbonementCurent.trainingsType)
            {
               _person.AbonementCurent.trainingsType = _editedTypeWorkout;
               ComboBoxColor(comboBox, _editedTypeWorkout.ToString(), _person.AbonementCurent.trainingsType.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_TypeWorkout_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (TypeWorkout)Enum.Parse(typeof(TypeWorkout), tb.SelectedItem.ToString());
         _editedTypeWorkout = edited;
         ComboBoxColor(tb, _editedTypeWorkout.ToString(), _person.AbonementCurent.trainingsType.ToString());
         IsChangedUpdateStatus(_editedTypeWorkout.ToString(), _person.AbonementCurent.trainingsType.ToString());
      }

      #endregion

      #region // Метод. Услуги СПА.

      SpaService _editedSpaService;

      private Tuple<Label, Control> CreateSpaServiceField()
      {
         const string labelText = "Услуги: ";
         Label lableType = CreateLabel(labelText);
         var array = Enum.GetNames(typeof(SpaService));
         ComboBox comboBox = CreateComboBox();
         _editedSpaService = _person.AbonementCurent.spa;
         // Инициализируем наши Контролы
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
         comboBox.SelectedItem = _person.AbonementCurent.spa.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_SpaService_SelectedIndexChanged;

         _saveDelegateChain += () =>
         {
            if (_person.AbonementCurent != null && _editedSpaService != _person.AbonementCurent.spa)
            {
               _person.AbonementCurent.spa = _editedSpaService;
               ComboBoxColor(comboBox, _person.AbonementCurent.spa.ToString(), comboBox.SelectedItem.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_SpaService_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (SpaService)Enum.Parse(typeof(SpaService), tb.SelectedItem.ToString());
         _editedSpaService = edited;
         ComboBoxColor(tb, _person.AbonementCurent.spa.ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(_person.AbonementCurent.spa.ToString(), tb.SelectedItem.ToString());
      }

      #endregion

      #region // Метод. Статус Оплаты.
      Pay _editedPay;

      private Tuple<Label, Control> CreatePayServiceField()
      {
         const string labelText = "Статус Оплаты: ";
         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();
         _editedPay = _person.AbonementCurent.payStatus;
         // Инициализируем наши Контролы
         var array = Enum.GetNames(typeof(Pay));
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
         comboBox.SelectedItem = _person.AbonementCurent.payStatus.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_Pay_SelectedIndexChanged;

         _saveDelegateChain += () =>
         {
            if (_person.AbonementCurent != null && _editedPay != _person.AbonementCurent.payStatus)
            {
               _person.AbonementCurent.payStatus = _editedPay;
               ComboBoxColor(comboBox, _person.AbonementCurent.payStatus.ToString(), comboBox.SelectedItem.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_Pay_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (Pay)Enum.Parse(typeof(Pay), tb.SelectedItem.ToString());
         _editedPay = edited;
         ComboBoxColor(tb, _person.AbonementCurent.payStatus.ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(_person.AbonementCurent.payStatus.ToString(), tb.SelectedItem.ToString());
      }

      #endregion

      #region // Метод. Время Тренировок
      private TimeForTr _editedTimeForTr;
      Tuple<Label, Control> CreateTimeForTrField()
      {
         const string labelText = "Время Тренировок: ";
         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();
         _editedTimeForTr = _person.AbonementCurent.timeTraining;
         // Инициализируем наши Контролы
         var array = Enum.GetNames(typeof(TimeForTr));
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
         comboBox.SelectedItem = _person.AbonementCurent.timeTraining.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_TimeForTr_SelectedIndexChanged;

         _saveDelegateChain += () =>
         {
             if (_person.AbonementCurent == null || _editedTimeForTr == _person.AbonementCurent.timeTraining) return;
             _person.AbonementCurent.timeTraining = _editedTimeForTr;
            ComboBoxColor(comboBox, _person.AbonementCurent.timeTraining.ToString(), comboBox.SelectedItem.ToString());
         };

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_TimeForTr_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (TimeForTr)Enum.Parse(typeof(TimeForTr), tb.SelectedItem.ToString());
         _editedTimeForTr = edited;
         ComboBoxColor(tb, _person.AbonementCurent.timeTraining.ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(_person.AbonementCurent.timeTraining.ToString(), tb.SelectedItem.ToString());
      }
      #endregion

      #region // Метод. Тип Срок Клубной Карты
      PeriodClubCard _editedTypeClubCard;
      Tuple<Label, Control> CreatePeriodClubCardField()
      {
         // Этот метод отличается от других из-за Полей,присущих только данному классу. Например, Тип Абонемента на месяцы.
         const string labelText = "Тип Клубной Карты";

         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();

         var array = Enum.GetNames(typeof(PeriodClubCard));
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс

         var clubCard = _person.AbonementCurent as ClubCardAbonement;
         if (clubCard != null)
         {
             comboBox.SelectedItem = clubCard.GetTypeClubCard().ToString(); // Выбор по умолчанию
            _editedTypeClubCard = clubCard.GetTypeClubCard();

            _saveDelegateChain += () =>
            {
                if (_person.AbonementCurent == null || _editedTypeClubCard == clubCard.GetTypeClubCard()) return;
                clubCard.SetTypeClubCard(_editedTypeClubCard);
               ComboBoxColor(comboBox, clubCard.GetTypeClubCard().ToString(), _editedTypeClubCard.ToString());

               (_person.AbonementCurent as ClubCardAbonement)?.UpdateEndDate();
            };
         }
         // Подписываемся на событие по изменению комбобокса
         comboBox.SelectedIndexChanged += comboBox_TypeClubCard_SelectedIndexChanged;

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_TypeClubCard_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         _editedTypeClubCard = (PeriodClubCard)Enum.Parse(typeof(PeriodClubCard), tb.SelectedItem.ToString());

         var сard = _person.AbonementCurent as ClubCardAbonement;
         if (сard == null) return;
         ComboBoxColor(tb, сard.GetTypeClubCard().ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(сard.GetTypeClubCard().ToString(), tb.SelectedItem.ToString());
      }
      #endregion

      #region // Метод. Дата Окончания Карты

      DateTime _editedEndDate;
      Tuple<Label, Control> CreateEndDateField()
      {
         const string labelText = "Дата Окончания Карты ";
         Label lableType = CreateLabel(labelText);
         DateTimePicker dateTime = CreateDateTimePicker();
         dateTime.Value = _person.AbonementCurent.endDate.Date;
         _editedEndDate = _person.AbonementCurent.endDate.Date;
         //dateTime.ValueChanged += DateTime_EndDate_ValueChanged;

         //SaveDelegateChain += () =>
         //{
         //   if (_person.abonementCurent != null && editedEndDate.CompareTo(_person.abonementCurent.endDate.Date) != 0) 
         //   {
         //      _person.abonementCurent.endDate = editedEndDate;
         //   };
         //};
         return new Tuple<Label, Control>(lableType, dateTime);
      }

      //private void DateTime_EndDate_ValueChanged(object sender, EventArgs e)
      //{
      //   var tb = (DateTimePicker)sender;
      //   editedEndDate = tb.Value.Date;
      //}

      #endregion

      #region // Метод. Осталось Дней

      private Tuple<Label, Control> CreateRemainderDaysField()
      {
         const string nameLabel = "Осталось Дней";
         string tbInitialText = _person.AbonementCurent.GetRemainderDays().ToString();

         Label lableType = CreateLabel(nameLabel);
         TextBox textbox = CreateTextBox(true);
         // Инициализируем наши Контролы
         textbox.Text = tbInitialText;
         return new Tuple<Label, Control>(lableType, textbox);
      }
      #endregion

      #region // Метод. Осталось Персональных тренировок

      private int _editedNumPersonalTr;

      private Tuple<Label, Control> CreateNumPersonalTrField()
      {
         const string nameLabel = "Осталось Персональных";
         string tbInitialText = _person.AbonementCurent.NumPersonalTr.ToString();

         Label lableType = CreateLabel(nameLabel);
         TextBox textbox = CreateTextBox(false);
         _editedNumPersonalTr = _person.AbonementCurent.NumPersonalTr;
         // Инициализируем наши Контролы
         textbox.Text = tbInitialText;
         textbox.MaxLength = 3;
         // Подписываемся на событие по изменению
         textbox.KeyPress += Textbox_NumPersonalTr_KeyPress;
         textbox.TextChanged += Textbox_NumPersonalTrChanged;

         _saveDelegateChain += () =>
         {
            if (_person.AbonementCurent.NumPersonalTr != _editedNumPersonalTr && (_editedNumPersonalTr >= 0))
            {
               _person.AbonementCurent.NumPersonalTr = _editedNumPersonalTr;
               SetControlBackColor(textbox, _editedNumPersonalTr.ToString(), _person.AbonementCurent.NumPersonalTr.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, textbox);
      }
      private void Textbox_NumPersonalTr_KeyPress(object sender, KeyPressEventArgs e)
      {
         char number = e.KeyChar;
         if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
         {
            e.Handled = true;
         }
      }
      private void Textbox_NumPersonalTrChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;
         Int32.TryParse(tb.Text, out _editedNumPersonalTr);
         SetControlBackColor(tb, _editedNumPersonalTr.ToString(), _person.AbonementCurent.NumPersonalTr.ToString());
         _isAnythingChanged = true;

      }
      #endregion

      #region // Метод. Осталось Аэробных тренировок
      private int _editedNumAerobicTr;
      private bool _numAerobicTrChanged;
      Tuple<Label, Control> CreateNumAerobicTrField()
      {
         const string nameLabel = "Осталось Аэробных";
         _numAerobicTrChanged = false;
         string tbInitialText = _person.AbonementCurent.NumAerobicTr.ToString();

         Label lableType = CreateLabel(nameLabel);
         TextBox textbox = CreateTextBox(false);
         _editedNumAerobicTr = _person.AbonementCurent.NumAerobicTr;
         // Инициализируем наши Контролы
         textbox.Text = tbInitialText;
         textbox.MaxLength = 3;
         // Подписываемся на событие по изменению
         textbox.KeyPress += Textbox_NumAerobicTr_KeyPress;
         textbox.TextChanged += Textbox_NumAerobicTrChanged;

         _saveDelegateChain += () =>
         {
            if (_person.AbonementCurent.NumAerobicTr != _editedNumAerobicTr && (_editedNumAerobicTr >= 0) && _numAerobicTrChanged)
            {
               _person.AbonementCurent.NumAerobicTr = _editedNumAerobicTr;
               SetControlBackColor(textbox, _editedNumAerobicTr.ToString(), _person.AbonementCurent.NumAerobicTr.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, textbox);
      }
      private void Textbox_NumAerobicTr_KeyPress(object sender, KeyPressEventArgs e)
      {
         char number = e.KeyChar;
         if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
         {
            e.Handled = true;
         }
      }
      private void Textbox_NumAerobicTrChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;
         _isAnythingChanged = true;
         _numAerobicTrChanged = true;
         Int32.TryParse(tb.Text, out _editedNumAerobicTr);
         SetControlBackColor(tb, _editedNumAerobicTr.ToString(), _person.AbonementCurent.NumAerobicTr.ToString());
      }
      #endregion

      #region // Метод. Дата Покупки Карты

      //DateTime editedBuyDate;
      private Tuple<Label, Control> CreateBuyDateField()
      {
         const string labelText = "Дата Покупки Карты ";
         Label lableType = CreateLabel(labelText);
         DateTimePicker dateTime = CreateDateTimePicker();
         dateTime.Value = _person.AbonementCurent.buyDate.Date;
         _editedEndDate = _person.AbonementCurent.buyDate.Date;
         //dateTime.ValueChanged += DateTime_BuyDate_ValueChanged;

         //SaveDelegateChain += () =>
         //{
         //   if (_person.abonementCurent != null && editedBuyDate.CompareTo(_person.abonementCurent.buyDate.Date) != 0) 
         //   {
         //      _person.abonementCurent.buyDate = editedBuyDate;
         //   };
         //};
         return new Tuple<Label, Control>(lableType, dateTime);
      }

      //private void DateTime_BuyDate_ValueChanged(object sender, EventArgs e)
      //{
      //   var tb = (DateTimePicker)sender;
      //   editedBuyDate = tb.Value.Date;
      //}

      #endregion

      #region // Метод. Количество дней в Абонементе
      DaysInAbon _editedDaysInAbon;
      Tuple<Label, Control> CreateNumberDaysInAbonField()
      {
         // Этот метод отличается от других из-за Полей,присущих только данному классу. Например, Количество дней в Абонементе
         const string labelText = "Тип Абонемента: ";
         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();
         var array = Enum.GetNames(typeof(DaysInAbon));
         comboBox.Items.AddRange(array.ToArray<object>());

         if (_person.AbonementCurent is AbonementByDays)
         {
            var abonement = (AbonementByDays)_person.AbonementCurent;
            comboBox.SelectedItem = abonement.GetTypeAbonementByDays().ToString(); // Выбор по умолчанию
            _editedDaysInAbon = abonement.GetTypeAbonementByDays();
            _saveDelegateChain += () =>
            {
               if (_person.AbonementCurent != null && _editedDaysInAbon != abonement.GetTypeAbonementByDays())
               {
                  abonement.SetTypeAbonementByDays(_editedDaysInAbon);
                  ComboBoxColor(comboBox, abonement.GetTypeAbonementByDays().ToString(), _editedDaysInAbon.ToString());
               }
            };
         }
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_DaysInAbon_SelectedIndexChanged;
         return new Tuple<Label, Control>(lableType, comboBox);
      }

      private void comboBox_DaysInAbon_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         _editedDaysInAbon = (DaysInAbon)Enum.Parse(typeof(DaysInAbon), tb.SelectedItem.ToString());

         var сard = _person.AbonementCurent as AbonementByDays;
         if (сard == null) return;
         ComboBoxColor(tb, сard.GetTypeAbonementByDays().ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(сard.GetTypeAbonementByDays().ToString(), tb.SelectedItem.ToString());
      }

      #endregion

      // Поля персональных данных
      #region // Поле. Телефон

      private string _editedPhone;
      private void maskedTextBox_PhoneNumber_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         _editedPhone = tb.Text;
         SetControlBackColor(tb, _editedPhone, _person.Phone);
         IsChangedUpdateStatus(_editedPhone, _person.Phone);
      }


      #endregion

      #region // Поле. Паспорт

      private string _editedPassport;
      private void maskedTex_Passport_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         _editedPassport = tb.Text;
         SetControlBackColor(tb, _editedPassport, _person.Passport);
         IsChangedUpdateStatus(_editedPassport, _person.Passport);
      }
      #endregion

      #region // Поле. Права

      private string _editedDriveId;
      private void maskedTextBox_DriverID_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         _editedDriveId = tb.Text;
         SetControlBackColor(tb, _editedDriveId, _person.DriverIdNum);
         IsChangedUpdateStatus(_editedDriveId, _person.DriverIdNum);
      }
      #endregion

      #region // Поле. День Рождения
      DateTime _editedDr;
      private void dateTimePicker_birthDate_ValueChanged(object sender, EventArgs e)
      {
         var tb = (DateTimePicker)sender;
         _editedDr = tb.Value.Date;
         _isAnythingChanged = true;
      }

      #endregion

      #region // Поле. Пол
      Gender _editedGender;
      private void comboBox_Gender_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (Gender)Enum.Parse(typeof(Gender), tb.SelectedItem.ToString());
         _editedGender = edited;
         IsChangedUpdateStatus(_editedGender.ToString(), _person.GenderType.ToString());
         ComboBoxColor(tb, _person.GenderType.ToString(), _editedGender.ToString());
      }
      #endregion

      #region // Поле. Особые отметки
      private string _editedSpecialNote;
      private void textBox_Notes_TextChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;
         _editedSpecialNote = tb.Text;
      }

      #endregion

      /// <summary>
      /// Запускается автоматически в цепочке делегатов SaveDelegateChain. SaveData()
      /// </summary>
      private void SaveUserData()
      {
         if (_editedPhone != _person.Phone) _person.Phone = _editedPhone;
         if (_editedPassport != _person.Passport) _person.Passport = _editedPassport;
         if (_editedDriveId != _person.DriverIdNum) _person.DriverIdNum = _editedDriveId;
         if (_editedDr.CompareTo(_person.BirthDate) != 0) _person.BirthDate = _editedDr;
         if (_editedGender != _person.GenderType) _person.GenderType = _editedGender;
         SaveSpecialNotes();
      }
      private void SaveSpecialNotes()
      {
         if (_editedSpecialNote != _person.SpecialNotes) _person.SpecialNotes = _editedSpecialNote;
      }
      private void IsChangedUpdateStatus(string oldArg, string newArg)
      {
         //if (newArg == oldArg) isAnythingChanged = false;
         //else isAnythingChanged = true;
         if (newArg != oldArg) _isAnythingChanged = true;

      }
      private void ComboBoxColor(ComboBox comboBox, string oldVal, string curVal)
      {
         SetControlBackColor(comboBox, curVal, oldVal);
         comboBox.SelectionLength = 0;
         comboBox.Select(0, 0);
         button_SavePersonalData.Focus(); // Cнимаем выделение сменой фокуса.
      }

      // /////////////////////////////// ФУНКЦИИ СОЗДАНИЯ КОНТРОЛОВ ///////////////////////////////////

      // TextBox
      private static TextBox CreateTextBox(bool isReadOnly)
      {
         return new TextBox()
         {
            BorderStyle = BorderStyle.Fixed3D,
            ReadOnly = isReadOnly,
            Dock = DockStyle.Fill,
            TextAlign=HorizontalAlignment.Center,
            Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)))
         };
      }
      // Label
      private static Label CreateLabel(string labelText)
      {
         return new Label()
         {
            Text = labelText,
            Anchor = AnchorStyles.Left,
            AutoSize = true,
            TextAlign = ContentAlignment.TopLeft,
            Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)))
         };
      }
      // ComboBox
      private static ComboBox CreateComboBox()
      {
         var cmbx = new ComboBox()
         {
            Dock = DockStyle.Fill,
            DropDownStyle = ComboBoxStyle.DropDown
         };
         return cmbx;
      }

      // DateTimePicker
      private static DateTimePicker CreateDateTimePicker()
      {
         return new DateTimePicker()
         {
            Dock = DockStyle.Fill,
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "dd MMM yyyy"
         };
      }
   }
}
