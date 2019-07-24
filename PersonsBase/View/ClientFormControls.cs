using System;
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

      Action SaveDelegateChain; // Цепочка Делегатов для сохранения измененных данных.

      #region // Метод. Фамилия Имя Отчество

      private string editedName; // Сохраняем новое редактированное имя.
      Tuple<Label, Control> CreateNameField()
      {
         const string nameLabel = "Имя Клиента";

         Label lableType = CreateLabel(nameLabel);
         TextBox textbox = CreateTextBox(false);
         editedName = _person.Name;
         // Инициализируем наши Контролы
         textbox.Text = _person.Name;
         // Подписываемся на событие по изменению
         textbox.TextChanged += Textbox_NameChanged;

         SaveDelegateChain += () =>
         {
            if (editedName != null && editedName != "" && _person.Name != editedName)
            {
               _dataBase.EditName(_person.Name, editedName);
               SetControlBackColor(textbox, editedName, _person.Name);
            }
         };

         return new Tuple<Label, Control>(lableType, textbox);
      }
      private void Textbox_NameChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;
         editedName = tb.Text;
         SetControlBackColor(tb, editedName, _person.Name);
         IsChangedUpdateStatus(editedName, _person.Name);
      }

      #endregion

      #region // Метод. Статус Клиента.

      StatusPerson editedStatusPerson;
      Tuple<Label, Control> CreateStatusField()
      {
         const string curentStatusLabel = "Текущий статус Клиента: ";
         Label lableType = CreateLabel(curentStatusLabel);
         editedStatusPerson = _person.Status;
         ComboBox comboStatus = CreateComboBox();
         // Инициализируем наши Контролы
         var array = Enum.GetNames(typeof(StatusPerson));
         // Удалим из Массива Активный и Заморожен если у клиента нет абонемента.
         if (_person.abonementCurent == null)
         {
            var updatedarray = array.Where((x) => (x != StatusPerson.Активный.ToString()) && ((x != StatusPerson.Заморожен.ToString()))).Select(x => x);
            array = updatedarray.ToArray<string>();
         }

         // Записываем Поля в Комбобокс
         comboStatus.Items.AddRange(array);
         comboStatus.SelectedItem = _person.Status.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboStatus.SelectedIndexChanged += ComboStatus_SelectedIndexChanged;
         SaveDelegateChain += () =>
         {
            if (editedStatusPerson != _person.Status)
            {
               _person.statusChanged -= UpdateControlState;
               _person.Status = editedStatusPerson;
               _person.statusChanged += UpdateControlState;
               ComboBoxColor(comboStatus, _person.Status.ToString(), editedStatusPerson.ToString());
               _person.OnStatusChanged();
            }
         };

         return new Tuple<Label, Control>(lableType, comboStatus);
      }
      private void ComboStatus_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var editedStatus = (StatusPerson)Enum.Parse(typeof(StatusPerson), tb.SelectedItem.ToString());
         editedStatusPerson = editedStatus;
         IsChangedUpdateStatus(editedStatusPerson.ToString(), _person.Status.ToString());
         ComboBoxColor(tb, _person.Status.ToString(), editedStatusPerson.ToString());
      }
      #endregion

      #region // Метод. Доступные Тренировки.
      TypeWorkout editedTypeWorkout;
      Tuple<Label, Control> CreateTypeWorkoutField()
      {
         const string labelText = "Доступные Тренировки: ";
         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();
         editedTypeWorkout = _person.abonementCurent.trainingsType;
         // Инициализируем наши Контролы
         var array = Enum.GetNames(typeof(TypeWorkout));
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
         comboBox.SelectedItem = _person.abonementCurent.trainingsType.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_TypeWorkout_SelectedIndexChanged;

         SaveDelegateChain += () =>
         {
            if (_person.abonementCurent != null && editedTypeWorkout != _person.abonementCurent.trainingsType)
            {
               _person.abonementCurent.trainingsType = editedTypeWorkout;
               ComboBoxColor(comboBox, editedTypeWorkout.ToString(), _person.abonementCurent.trainingsType.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_TypeWorkout_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (TypeWorkout)Enum.Parse(typeof(TypeWorkout), tb.SelectedItem.ToString());
         editedTypeWorkout = edited;
         ComboBoxColor(tb, editedTypeWorkout.ToString(), _person.abonementCurent.trainingsType.ToString());
         IsChangedUpdateStatus(editedTypeWorkout.ToString(), _person.abonementCurent.trainingsType.ToString());
      }

      #endregion

      #region // Метод. Услуги СПА.

      SpaService editedSpaService;
      Tuple<Label, Control> CreateSpaServiceField()
      {
         const string labelText = "Услуги: ";
         Label lableType = CreateLabel(labelText);
         var array = Enum.GetNames(typeof(SpaService));
         ComboBox comboBox = CreateComboBox();
         editedSpaService = _person.abonementCurent.spa;
         // Инициализируем наши Контролы
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
         comboBox.SelectedItem = _person.abonementCurent.spa.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_SpaService_SelectedIndexChanged;

         SaveDelegateChain += () =>
         {
            if (_person.abonementCurent != null && editedSpaService != _person.abonementCurent.spa)
            {
               _person.abonementCurent.spa = editedSpaService;
               ComboBoxColor(comboBox, _person.abonementCurent.spa.ToString(), comboBox.SelectedItem.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_SpaService_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (SpaService)Enum.Parse(typeof(SpaService), tb.SelectedItem.ToString());
         editedSpaService = edited;
         ComboBoxColor(tb, _person.abonementCurent.spa.ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(_person.abonementCurent.spa.ToString(), tb.SelectedItem.ToString());
      }

      #endregion

      #region // Метод. Статус Оплаты.
      Pay editedPay;
      Tuple<Label, Control> CreatePayServiceField()
      {
         const string labelText = "Статус Оплаты: ";
         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();
         editedPay = _person.abonementCurent.payStatus;
         // Инициализируем наши Контролы
         var array = Enum.GetNames(typeof(Pay));
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
         comboBox.SelectedItem = _person.abonementCurent.payStatus.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_Pay_SelectedIndexChanged;

         SaveDelegateChain += () =>
         {
            if (_person.abonementCurent != null && editedPay != _person.abonementCurent.payStatus)
            {
               _person.abonementCurent.payStatus = editedPay;
               ComboBoxColor(comboBox, _person.abonementCurent.payStatus.ToString(), comboBox.SelectedItem.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_Pay_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (Pay)Enum.Parse(typeof(Pay), tb.SelectedItem.ToString());
         editedPay = edited;
         ComboBoxColor(tb, _person.abonementCurent.payStatus.ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(_person.abonementCurent.payStatus.ToString(), tb.SelectedItem.ToString());
      }

      #endregion

      #region // Метод. Время Тренировок
      TimeForTr editedTimeForTr;
      Tuple<Label, Control> CreateTimeForTrField()
      {
         const string labelText = "Время Тренировок: ";
         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();
         editedTimeForTr = _person.abonementCurent.timeTraining;
         // Инициализируем наши Контролы
         var array = Enum.GetNames(typeof(TimeForTr));
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
         comboBox.SelectedItem = _person.abonementCurent.timeTraining.ToString(); // Выбор по умолчанию
         // Подписываемся на событие по изменению
         comboBox.SelectedIndexChanged += comboBox_TimeForTr_SelectedIndexChanged;

         SaveDelegateChain += () =>
         {
            if (_person.abonementCurent != null && editedTimeForTr != _person.abonementCurent.timeTraining)
            {
               _person.abonementCurent.timeTraining = editedTimeForTr;
               ComboBoxColor(comboBox, _person.abonementCurent.timeTraining.ToString(), comboBox.SelectedItem.ToString());
            }
         };

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_TimeForTr_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (TimeForTr)Enum.Parse(typeof(TimeForTr), tb.SelectedItem.ToString());
         editedTimeForTr = edited;
         ComboBoxColor(tb, _person.abonementCurent.timeTraining.ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(_person.abonementCurent.timeTraining.ToString(), tb.SelectedItem.ToString());
      }
      #endregion

      #region // Метод. Тип Срок Клубной Карты
      PeriodClubCard editedTypeClubCard;
      Tuple<Label, Control> CreatePeriodClubCardField()
      {
         // Этот метод отличается от других из-за Полей,присущих только данному классу. Например, Тип Абонемента на месяцы.
         const string labelText = "Тип Клубной Карты";

         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();

         var array = Enum.GetNames(typeof(PeriodClubCard));
         comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс

         if (_person.abonementCurent is ClubCardAbonement)
         {
            var clubCard = (ClubCardAbonement)_person.abonementCurent;
            comboBox.SelectedItem = clubCard.GetTypeClubCard().ToString(); // Выбор по умолчанию
            editedTypeClubCard = clubCard.GetTypeClubCard();

            SaveDelegateChain += () =>
            {
               if (_person.abonementCurent != null && editedTypeClubCard != clubCard.GetTypeClubCard())
               {
                  clubCard.SetTypeClubCard(editedTypeClubCard);
                  ComboBoxColor(comboBox, clubCard.GetTypeClubCard().ToString(), editedTypeClubCard.ToString());

                  (_person.abonementCurent as ClubCardAbonement).UpdateEndDate();
               }
            };
         }
         // Подписываемся на событие по изменению комбобокса
         comboBox.SelectedIndexChanged += comboBox_TypeClubCard_SelectedIndexChanged;

         return new Tuple<Label, Control>(lableType, comboBox);
      }
      private void comboBox_TypeClubCard_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         editedTypeClubCard = (PeriodClubCard)Enum.Parse(typeof(PeriodClubCard), tb.SelectedItem.ToString());

         var сard = _person.abonementCurent as ClubCardAbonement;
         ComboBoxColor(tb, сard.GetTypeClubCard().ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(сard.GetTypeClubCard().ToString(), tb.SelectedItem.ToString());
      }
      #endregion

      #region // Метод. Дата Окончания Карты

      DateTime editedEndDate;
      Tuple<Label, Control> CreateEndDateField()
      {
         const string labelText = "Дата Окончания Карты ";
         Label lableType = CreateLabel(labelText);
         DateTimePicker dateTime = CreateDateTimePicker();
         dateTime.Value = _person.abonementCurent.endDate.Date;
         editedEndDate = _person.abonementCurent.endDate.Date;
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
      Tuple<Label, Control> CreateRemainderDaysField()
      {
         const string nameLabel = "Осталось Дней";
         string tbInitialText = _person.abonementCurent.GetRemainderDays().ToString();

         Label lableType = CreateLabel(nameLabel);
         TextBox textbox = CreateTextBox(true);
         // Инициализируем наши Контролы
         textbox.Text = tbInitialText;
         return new Tuple<Label, Control>(lableType, textbox);
      }
      #endregion

      #region // Метод. Осталось Персональных тренировок

      private int editedNumPersonalTr;
      Tuple<Label, Control> CreateNumPersonalTrField()
      {
         const string nameLabel = "Осталось Персональных";
         string tbInitialText = _person.abonementCurent.NumPersonalTr.ToString();

         Label lableType = CreateLabel(nameLabel);
         TextBox textbox = CreateTextBox(false);
         editedNumPersonalTr = _person.abonementCurent.NumPersonalTr;
         // Инициализируем наши Контролы
         textbox.Text = tbInitialText;
         textbox.MaxLength = 3;
         // Подписываемся на событие по изменению
         textbox.KeyPress += Textbox_NumPersonalTr_KeyPress;
         textbox.TextChanged += Textbox_NumPersonalTrChanged;

         SaveDelegateChain += () =>
         {
            if (_person.abonementCurent.NumPersonalTr != editedNumPersonalTr && (editedNumPersonalTr >= 0))
            {
               _person.abonementCurent.NumPersonalTr = editedNumPersonalTr;
               SetControlBackColor(textbox, editedNumPersonalTr.ToString(), _person.abonementCurent.NumPersonalTr.ToString());
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
         Int32.TryParse(tb.Text, out editedNumPersonalTr);
         SetControlBackColor(tb, editedNumPersonalTr.ToString(), _person.abonementCurent.NumPersonalTr.ToString());
         isAnythingChanged = true;

      }
      #endregion

      #region // Метод. Осталось Аэробных тренировок
      private int editedNumAerobicTr;
      private bool NumAerobicTrChanged;
      Tuple<Label, Control> CreateNumAerobicTrField()
      {
         const string nameLabel = "Осталось Аэробных";
         NumAerobicTrChanged = false;
         string tbInitialText = _person.abonementCurent.NumAerobicTr.ToString();

         Label lableType = CreateLabel(nameLabel);
         TextBox textbox = CreateTextBox(false);
         editedNumAerobicTr = _person.abonementCurent.NumAerobicTr;
         // Инициализируем наши Контролы
         textbox.Text = tbInitialText;
         textbox.MaxLength = 3;
         // Подписываемся на событие по изменению
         textbox.KeyPress += Textbox_NumAerobicTr_KeyPress;
         textbox.TextChanged += Textbox_NumAerobicTrChanged;

         SaveDelegateChain += () =>
         {
            if (_person.abonementCurent.NumAerobicTr != editedNumAerobicTr && (editedNumAerobicTr >= 0) && NumAerobicTrChanged)
            {
               _person.abonementCurent.NumAerobicTr = editedNumAerobicTr;
               SetControlBackColor(textbox, editedNumAerobicTr.ToString(), _person.abonementCurent.NumAerobicTr.ToString());
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
         isAnythingChanged = true;
         NumAerobicTrChanged = true;
         Int32.TryParse(tb.Text, out editedNumAerobicTr);
         SetControlBackColor(tb, editedNumAerobicTr.ToString(), _person.abonementCurent.NumAerobicTr.ToString());
      }
      #endregion

      #region // Метод. Дата Покупки Карты

      //DateTime editedBuyDate;
      private Tuple<Label, Control> CreateBuyDateField()
      {
         const string labelText = "Дата Покупки Карты ";
         Label lableType = CreateLabel(labelText);
         DateTimePicker dateTime = CreateDateTimePicker();
         dateTime.Value = _person.abonementCurent.buyDate.Date;
         editedEndDate = _person.abonementCurent.buyDate.Date;
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
      DaysInAbon editedDaysInAbon;
      Tuple<Label, Control> CreateNumberDaysInAbonField()
      {
         // Этот метод отличается от других из-за Полей,присущих только данному классу. Например, Количество дней в Абонементе
         const string labelText = "Тип Абонемента: ";
         Label lableType = CreateLabel(labelText);
         ComboBox comboBox = CreateComboBox();
         var array = Enum.GetNames(typeof(DaysInAbon));
         comboBox.Items.AddRange(array.ToArray<object>());

         if (_person.abonementCurent is AbonementByDays)
         {
            var abonement = (AbonementByDays)_person.abonementCurent;
            comboBox.SelectedItem = abonement.GetTypeAbonementByDays().ToString(); // Выбор по умолчанию
            editedDaysInAbon = abonement.GetTypeAbonementByDays();
            SaveDelegateChain += () =>
            {
               if (_person.abonementCurent != null && editedDaysInAbon != abonement.GetTypeAbonementByDays())
               {
                  abonement.SetTypeAbonementByDays(editedDaysInAbon);
                  ComboBoxColor(comboBox, abonement.GetTypeAbonementByDays().ToString(), editedDaysInAbon.ToString());
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
         editedDaysInAbon = (DaysInAbon)Enum.Parse(typeof(DaysInAbon), tb.SelectedItem.ToString());

         var сard = _person.abonementCurent as AbonementByDays;
         ComboBoxColor(tb, сard.GetTypeAbonementByDays().ToString(), tb.SelectedItem.ToString());
         IsChangedUpdateStatus(сard.GetTypeAbonementByDays().ToString(), tb.SelectedItem.ToString());
      }

      #endregion

      // Поля персональных данных
      #region // Поле. Телефон

      private string editedPhone;
      private void maskedTextBox_PhoneNumber_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         editedPhone = tb.Text;
         SetControlBackColor(tb, editedPhone, _person.Phone);
         IsChangedUpdateStatus(editedPhone, _person.Phone);
      }


      #endregion

      #region // Поле. Паспорт

      private string editedPassport;
      private void maskedTex_Passport_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         editedPassport = tb.Text;
         SetControlBackColor(tb, editedPassport, _person.Passport);
         IsChangedUpdateStatus(editedPassport, _person.Passport);
      }
      #endregion

      #region // Поле. Права

      private string editedDriveID;
      private void maskedTextBox_DriverID_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         editedDriveID = tb.Text;
         SetControlBackColor(tb, editedDriveID, _person.DriverIdNum);
         IsChangedUpdateStatus(editedDriveID, _person.DriverIdNum);
      }
      #endregion

      #region // Поле. День Рождения
      DateTime editedDR;
      private void dateTimePicker_birthDate_ValueChanged(object sender, EventArgs e)
      {
         var tb = (DateTimePicker)sender;
         editedDR = tb.Value.Date;
         isAnythingChanged = true;
      }

      #endregion

      #region // Поле. Пол
      Gender editedGender;
      private void comboBox_Gender_SelectedIndexChanged(object sender, EventArgs e)
      {
         var tb = (ComboBox)sender;
         var edited = (Gender)Enum.Parse(typeof(Gender), tb.SelectedItem.ToString());
         editedGender = edited;
         IsChangedUpdateStatus(editedGender.ToString(), _person.GenderType.ToString());
         ComboBoxColor(tb, _person.GenderType.ToString(), editedGender.ToString());
      }
      #endregion

      #region // Поле. Особые отметки
      private string editedSpecialNote;
      private void textBox_Notes_TextChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;
         editedSpecialNote = tb.Text;
      }

      #endregion

      /// <summary>
      /// Запускается автоматически в цепочке делегатов SaveDelegateChain. SaveData()
      /// </summary>
      private void SaveUserData()
      {
         if (editedPhone != _person.Phone) _person.Phone = editedPhone;
         if (editedPassport != _person.Passport) _person.Passport = editedPassport;
         if (editedDriveID != _person.DriverIdNum) _person.DriverIdNum = editedDriveID;
         if (editedDR.CompareTo(_person.BirthDate) != 0) _person.BirthDate = editedDR;
         if (editedGender != _person.GenderType) _person.GenderType = editedGender;
         SaveSpecialNotes();
      }
      private void SaveSpecialNotes()
      {
         if (editedSpecialNote != _person.SpecialNotes) _person.SpecialNotes = editedSpecialNote;
      }
      private void IsChangedUpdateStatus(string oldArg, string newArg)
      {
         //if (newArg == oldArg) isAnythingChanged = false;
         //else isAnythingChanged = true;
         if (newArg != oldArg) isAnythingChanged = true;

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
         ComboBox cmbx = new ComboBox()
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
