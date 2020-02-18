using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.View
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

            var lableType = CreateLabel(nameLabel);
            var textbox = CreateTextBox(false);
            _editedName = _person.Name;
            // Инициализируем наши Контролы
            textbox.Text = _person.Name;
            // Подписываемся на событие по изменению
            textbox.TextChanged += Textbox_NameChanged;

            _saveDelegateChain += () =>
            {
                Logic.ChangePersonName(_person.Name, _editedName);
                Logic.SetControlBackColor(textbox, _editedName, _person.Name);
            };

            return new Tuple<Label, Control>(lableType, textbox);
        }
        private void Textbox_NameChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            _editedName = tb.Text;
            Logic.SetControlBackColor(tb, _editedName, _person.Name);
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
            string[] array = Enum.GetNames(typeof(StatusPerson));
            // Удалим из Массива Активный и Заморожен если у клиента нет абонемента.
            if (_person.AbonementCurent == null)
            {
                var updatedarray = array.Where(x => (x != StatusPerson.Активный.ToString()) && ((x != StatusPerson.Заморожен.ToString()))).Select(x => x);
                array = updatedarray.ToArray();
            }
            // Удалим из Массива Заморожен если не Клубная Карта .
            if (!(_person.AbonementCurent is ClubCardA))
            {
                var updatedarray = array.Where(x => (x != StatusPerson.Заморожен.ToString())).Select(x => x);
                array = updatedarray.ToArray<string>();
            }

            // Записываем Поля в Комбобокс
            comboStatus.Items.AddRange(array.ToArray<object>());
            comboStatus.SelectedItem = _person.Status.ToString(); // Выбор по умолчанию
                                                                  // Подписываемся на событие по изменению
            comboStatus.SelectedIndexChanged += ComboStatus_SelectedIndexChanged;
            _saveDelegateChain += () =>
            {
                if (_editedStatusPerson != _person.Status)
                {
                    // Костыль для того чтобы изменение Ручками сбрасывало заморозку
                    if (_editedStatusPerson == StatusPerson.Активный && _person.Status == StatusPerson.Заморожен && (_person.AbonementCurent is ClubCardA a))
                    {
                        a.Freeze.RemoveLast();
                    }
                    _person.Status = _editedStatusPerson;
                    ComboBoxColor(comboStatus, _person.Status.ToString(), _editedStatusPerson.ToString());
                  //  _person.OnStatusChanged();
                }
            };

            return new Tuple<Label, Control>(lableType, comboStatus);
        }
        private void ComboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboChangedMethod<StatusPerson>(sender, out _editedStatusPerson, _person.Status);
        }
        #endregion

        #region // Метод. Доступные Тренировки.
        TypeWorkout _editedTypeWorkout;
        Tuple<Label, Control> CreateTypeWorkoutField()
        {
            const string labelText = "Доступные Тренировки: ";
            Label lableType = CreateLabel(labelText);
            ComboBox comboBox = CreateComboBox(PwdForm.IsPassUnLocked());
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _editedTypeWorkout = _person.AbonementCurent.TypeWorkout;
            // Инициализируем наши Контролы
            var array = Enum.GetNames(typeof(TypeWorkout));
            comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox.SelectedItem = _person.AbonementCurent.TypeWorkout.ToString(); // Выбор по умолчанию
                                                                                    // Подписываемся на событие по изменению
            comboBox.SelectedIndexChanged += comboBox_TypeWorkout_SelectedIndexChanged;

            _saveDelegateChain += () =>
            {
                if (_person.AbonementCurent != null && _editedTypeWorkout != _person.AbonementCurent.TypeWorkout)
                {
                    _person.AbonementCurent.TypeWorkout = _editedTypeWorkout;
                    ComboBoxColor(comboBox, _editedTypeWorkout.ToString(), _person.AbonementCurent.TypeWorkout.ToString());
                }
            };

            return new Tuple<Label, Control>(lableType, comboBox);
        }
        private void comboBox_TypeWorkout_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboChangedMethod<TypeWorkout>(sender, out _editedTypeWorkout, _person.AbonementCurent.TypeWorkout);
        }

        #endregion

        #region // Метод. Услуги СПА.

        SpaService _editedSpaService;

        private Tuple<Label, Control> CreateSpaServiceField()
        {
            const string labelText = "Услуги: ";
            Label lableType = CreateLabel(labelText);
            var array = Enum.GetNames(typeof(SpaService));
            ComboBox comboBox = CreateComboBox(PwdForm.IsPassUnLocked());
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _editedSpaService = _person.AbonementCurent.Spa;
            // Инициализируем наши Контролы
            comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox.SelectedItem = _person.AbonementCurent.Spa.ToString(); // Выбор по умолчанию
                                                                            // Подписываемся на событие по изменению
            comboBox.SelectedIndexChanged += comboBox_SpaService_SelectedIndexChanged;

            _saveDelegateChain += () =>
            {
                if (_person.AbonementCurent != null && _editedSpaService != _person.AbonementCurent.Spa)
                {
                    _person.AbonementCurent.Spa = _editedSpaService;
                    ComboBoxColor(comboBox, _person.AbonementCurent.Spa.ToString(), comboBox.SelectedItem.ToString());
                }
            };

            return new Tuple<Label, Control>(lableType, comboBox);
        }
        private void comboBox_SpaService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboChangedMethod<SpaService>(sender, out _editedSpaService, _person.AbonementCurent.Spa);
        }

        #endregion

        #region // Метод. Статус Оплаты.
        Pay _editedPay;

        private Tuple<Label, Control> CreatePayServiceField()
        {
            const string labelText = "Статус Оплаты: ";
            Label lableType = CreateLabel(labelText);
            ComboBox comboBox = CreateComboBox(PwdForm.IsPassUnLocked());
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _editedPay = _person.AbonementCurent.PayStatus;
            // Инициализируем наши Контролы
            var array = Enum.GetNames(typeof(Pay));
            comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox.SelectedItem = _person.AbonementCurent.PayStatus.ToString(); // Выбор по умолчанию
                                                                                  // Подписываемся на событие по изменению
            comboBox.SelectedIndexChanged += comboBox_Pay_SelectedIndexChanged;

            _saveDelegateChain += () =>
            {
                if (_person.AbonementCurent != null && _editedPay != _person.AbonementCurent.PayStatus)
                {
                    _person.AbonementCurent.PayStatus = _editedPay;
                    ComboBoxColor(comboBox, _person.AbonementCurent.PayStatus.ToString(), comboBox.SelectedItem.ToString());
                }
            };

            return new Tuple<Label, Control>(lableType, comboBox);
        }
        private void comboBox_Pay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboChangedMethod<Pay>(sender, out _editedPay, _person.AbonementCurent.PayStatus);
        }

        #endregion

        #region // Метод. Время Тренировок
        private TimeForTr _editedTimeForTr;
        Tuple<Label, Control> CreateTimeForTrField()
        {
            const string labelText = "Время Тренировок: ";
            Label lableType = CreateLabel(labelText);
            ComboBox comboBox = CreateComboBox(PwdForm.IsPassUnLocked());
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _editedTimeForTr = _person.AbonementCurent.TimeTraining;
            // Инициализируем наши Контролы
            var array = Enum.GetNames(typeof(TimeForTr));
            comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox.SelectedItem = _person.AbonementCurent.TimeTraining.ToString(); // Выбор по умолчанию
                                                                                     // Подписываемся на событие по изменению
            comboBox.SelectedIndexChanged += comboBox_TimeForTr_SelectedIndexChanged;

            _saveDelegateChain += () =>
            {
                if (_person.AbonementCurent == null || _editedTimeForTr == _person.AbonementCurent.TimeTraining) return;
                _person.AbonementCurent.TimeTraining = _editedTimeForTr;
                ComboBoxColor(comboBox, _person.AbonementCurent.TimeTraining.ToString(), comboBox.SelectedItem.ToString());
            };

            return new Tuple<Label, Control>(lableType, comboBox);
        }
        private void comboBox_TimeForTr_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboChangedMethod(sender, out _editedTimeForTr, _person.AbonementCurent.TimeTraining);
        }
        #endregion

        #region // Метод. Тип Срок Клубной Карты
        PeriodClubCard _editedTypeClubCard;

        private Tuple<Label, Control> CreatePeriodClubCardField()
        {
            // Этот метод отличается от других из-за Полей,присущих только данному классу. Например, Тип Абонемента на месяцы.
            const string labelText = "Тип Клубной Карты";

            Label lableType = CreateLabel(labelText);
            ComboBox comboBox = CreateComboBox(PwdForm.IsPassUnLocked());
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            var array = Enum.GetNames(typeof(PeriodClubCard));
            comboBox.Items.AddRange(array.ToArray<object>()); // Записываем Поля в Комбобокс

            if (_person.AbonementCurent is ClubCardA clubCard)
            {
                comboBox.SelectedItem = clubCard.GetTypeClubCard().ToString(); // Выбор по умолчанию
                _editedTypeClubCard = clubCard.GetTypeClubCard();

                _saveDelegateChain += () =>
                {
                    if (_person.AbonementCurent == null || _editedTypeClubCard == clubCard.GetTypeClubCard()) return;
                    clubCard.SetTypeClubCard(_editedTypeClubCard);
                    ComboBoxColor(comboBox, clubCard.GetTypeClubCard().ToString(), _editedTypeClubCard.ToString());

                    // (_person.AbonementCurent as ClubCardA)?.SetNewEndDate();
                };
            }
            // Подписываемся на событие по изменению комбобокса
            comboBox.SelectedIndexChanged += comboBox_TypeClubCard_SelectedIndexChanged;

            return new Tuple<Label, Control>(lableType, comboBox);
        }
        private bool _typeClubCardChanged = false; // Костыль для того чтобы при изменении Длительности карты - не слетало количество дней. Так как Дата перетирается в следующем поле Дата Окончания в цепочке делегатов.
        private void comboBox_TypeClubCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tb = (ComboBox)sender;
            _editedTypeClubCard = (PeriodClubCard)Enum.Parse(typeof(PeriodClubCard), tb.SelectedItem.ToString());

            if (!(_person.AbonementCurent is ClubCardA сard)) return;
            ComboBoxColor(tb, сard.GetTypeClubCard().ToString(), tb.SelectedItem.ToString());
            IsChangedUpdateStatus(сard.GetTypeClubCard().ToString(), tb.SelectedItem.ToString());
            _typeClubCardChanged = true;
        }
        #endregion

        #region // Метод. Дата Окончания Карты

        DateTime _editedEndDate;

        private Tuple<Label, Control> CreateEndDateField()
        {
            const string labelText = "Дата Окончания Карты ";
            Label lableType = CreateLabel(labelText);
            DateTimePicker dateTime = CreateDateTimePicker();

            var initDate = (_person.AbonementCurent.EndDate.Date.CompareTo(DateTime.Parse("01.01.0001")) > 0) ? _person.AbonementCurent.EndDate.Date : dateTime.Value;


            dateTime.Value = initDate;
            _editedEndDate = initDate;
            dateTime.Enabled = false;
            // dateTime.ValueChanged += DateTime_EndDate_ValueChanged;

            //_saveDelegateChain += () =>
            //{
            //    if (_person.IsAbonementExist() && (_editedEndDate.CompareTo(_person.AbonementCurent.EndDate.Date) != 0) && !_typeClubCardChanged)
            //    {
            //        _person.AbonementCurent.EndDate = _editedEndDate;
            //    }
            //};
            return new Tuple<Label, Control>(lableType, dateTime);
        }

        private void DateTime_EndDate_ValueChanged(object sender, EventArgs e)
        {
            var tb = (DateTimePicker)sender;
            _editedEndDate = tb.Value.Date;
        }

        #endregion

        #region // Метод. Осталось Дней

        private int _editedNumRemainder;
        private Tuple<Label, Control> CreateRemainderDaysField()
        {
            const string nameLabel = "Осталось Дней";
            string tbInitialText = _person.AbonementCurent.GetRemainderDays().ToString();
            _editedNumRemainder = _person.AbonementCurent.GetRemainderDays();
            Label lableType = CreateLabel(nameLabel);
            TextBox textbox = (_person.AbonementCurent is AbonementByDays) ? CreateTextBox(!PwdForm.IsPassUnLocked()) : CreateTextBox(true);

            // Инициализируем наши Контролы
            textbox.Text = tbInitialText;
            textbox.MaxLength = 3;
            // Подписываемся на событие по изменению
            textbox.KeyPress += Textbox_KeyPress;
            textbox.TextChanged += Textbox_Remainder_TextChanged;
            _saveDelegateChain += () =>
            {
                if (_person.AbonementCurent is AbonementByDays days)
                {
                    if (_editedNumRemainder != days.GetRemainderDays())
                        days.SetDaysLeft(_editedNumRemainder);
                }
            };
            return new Tuple<Label, Control>(lableType, textbox);
        }

        private void Textbox_Remainder_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            Int32.TryParse(tb.Text, out _editedNumRemainder);
            Logic.SetControlBackColor(tb, _editedNumRemainder.ToString(), _person.AbonementCurent.GetRemainderDays().ToString());
            _isAnythingChanged = true;
        }

        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logic.CheckForDigits(e);
        }
        #endregion

        #region // Метод. Осталось Персональных тренировок

        private int _editedNumPersonalTr;

        private Tuple<Label, Control> CreateNumPersonalTrField()
        {
            const string nameLabel = "Осталось Персональных";
            string tbInitialText = _person.AbonementCurent?.NumPersonalTr.ToString();

            Label lableType = CreateLabel(nameLabel);
            TextBox textbox = CreateTextBox(!PwdForm.IsPassUnLocked());
            _editedNumPersonalTr = _person.AbonementCurent?.NumPersonalTr ?? 0;
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
                    Logic.SetControlBackColor(textbox, _editedNumPersonalTr.ToString(), _person.AbonementCurent.NumPersonalTr.ToString());
                }
            };

            return new Tuple<Label, Control>(lableType, textbox);
        }
        private void Textbox_NumPersonalTr_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logic.CheckForDigits(e);
        }
        private void Textbox_NumPersonalTrChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            Int32.TryParse(tb.Text, out _editedNumPersonalTr);
            Logic.SetControlBackColor(tb, _editedNumPersonalTr.ToString(), _person.AbonementCurent.NumPersonalTr.ToString());
            _isAnythingChanged = true;

        }
        #endregion

        #region // Метод. Осталось Аэробных тренировок
        private int _editedNumAerobicTr;
        private bool _numAerobicTrChanged;

        private Tuple<Label, Control> CreateNumAerobicTrField()
        {
            const string nameLabel = "Осталось Аэробных";
            _numAerobicTrChanged = false;
            string tbInitialText = _person.AbonementCurent.NumAerobicTr.ToString();

            Label lableType = CreateLabel(nameLabel);
            TextBox textbox = CreateTextBox(!PwdForm.IsPassUnLocked());
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
                    Logic.SetControlBackColor(textbox, _editedNumAerobicTr.ToString(), _person.AbonementCurent.NumAerobicTr.ToString());
                }
            };

            return new Tuple<Label, Control>(lableType, textbox);
        }
        private void Textbox_NumAerobicTr_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logic.CheckForDigits(e);
        }
        private void Textbox_NumAerobicTrChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            _isAnythingChanged = true;
            _numAerobicTrChanged = true;
            Int32.TryParse(tb.Text, out _editedNumAerobicTr);
            Logic.SetControlBackColor(tb, _editedNumAerobicTr.ToString(), _person.AbonementCurent.NumAerobicTr.ToString());
        }
        #endregion

        #region // Метод. Дата Покупки Карты

        private DateTime _editedBuyDate;
        private Tuple<Label, Control> CreateBuyDateField()
        {
            const string labelText = "Дата Покупки/Активации Карты ";
            Label lableType = CreateLabel(labelText);
            DateTimePicker dateTime = CreateDateTimePicker();
            var init = (_person.AbonementCurent.BuyActivationDate.Date.CompareTo(DateTime.Parse("01.01.0001")) > 0) ? _person.AbonementCurent.BuyActivationDate.Date : dateTime.Value;

            dateTime.Value = init;
            _editedBuyDate = init;
            dateTime.Enabled = false;
            dateTime.ValueChanged += DateTime_BuyDate_ValueChanged;

            //_saveDelegateChain += () =>
            //{
            //    if (_person.IsAbonementExist() && _editedBuyDate.CompareTo(_person.AbonementCurent.BuyActivationDate.Date) != 0)
            //    {
            //        _person.AbonementCurent.BuyActivationDate = _editedBuyDate;
            //    }
            //};
            return new Tuple<Label, Control>(lableType, dateTime);
        }

        private void DateTime_BuyDate_ValueChanged(object sender, EventArgs e)
        {
            var tb = (DateTimePicker)sender;
            _editedBuyDate = tb.Value.Date;
        }

        #endregion

        #region // Метод. Количество дней в Абонементе
        DaysInAbon _editedDaysInAbon;
        Tuple<Label, Control> CreateNumberDaysInAbonField()
        {
            // Этот метод отличается от других из-за Полей,присущих только данному классу. Например, Количество дней в Абонементе
            const string labelText = "Тип Абонемента: ";
            Label lableType = CreateLabel(labelText);
            ComboBox comboBox = CreateComboBox(PwdForm.IsPassUnLocked());
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            var array = Enum.GetNames(typeof(DaysInAbon));
            comboBox.Items.AddRange(array.ToArray<object>());

            if (_person.AbonementCurent is AbonementByDays abonement)
            {
                comboBox.SelectedItem = abonement.GetTypeAbonementByDays().ToString(); // Выбор по умолчанию
                _editedDaysInAbon = abonement.GetTypeAbonementByDays();
                _saveDelegateChain += () =>
                {
                    try
                    {
                        if (_editedDaysInAbon != abonement.GetTypeAbonementByDays())
                        {
                            abonement.SetDaysLeft((int)_editedDaysInAbon);
                            ComboBoxColor(comboBox, abonement.GetTypeAbonementByDays().ToString(), _editedDaysInAbon.ToString());
                            ((AbonementByDays)_person.AbonementCurent).TypeAbonement = _editedDaysInAbon;
                        }
                    }
                    catch (Exception )
                    {
                        MessageBox.Show("Exception 1");
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

            if (!(_person.AbonementCurent is AbonementByDays сard)) return;
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
            Logic.SetControlBackColor(tb, _editedPhone, _person.Phone);
            IsChangedUpdateStatus(_editedPhone, _person.Phone);
        }


        #endregion

        #region // Поле. Паспорт

        private string _editedPassport;
        private void maskedTex_Passport_TextChanged(object sender, EventArgs e)
        {
            var tb = (MaskedTextBox)sender;
            _editedPassport = tb.Text;
            Logic.SetControlBackColor(tb, _editedPassport, _person.Passport);
            IsChangedUpdateStatus(_editedPassport, _person.Passport);
        }
        #endregion

        #region // Поле. Права

        private string _editedDriveId;
        private void maskedTextBox_DriverID_TextChanged(object sender, EventArgs e)
        {
            var tb = (MaskedTextBox)sender;
            _editedDriveId = tb.Text;
            Logic.SetControlBackColor(tb, _editedDriveId, _person.DriverIdNum);
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
            ComboChangedMethod(sender, out _editedGender, _person.GenderType);
        }
        #endregion

        #region // Поле. Персональный номер

        private string _editedPersonalNumber;
        private void textBox_Number_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            _editedPersonalNumber = tb.Text;
            Logic.SetControlBackColor(tb, _editedPersonalNumber, _person.PersonalNumber.ToString());
            IsChangedUpdateStatus(_editedPersonalNumber, _person.PersonalNumber.ToString());
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
            if (_editedPhone != null && _editedPhone != _person.Phone) _person.Phone = _editedPhone;
            if (_editedPassport != null && _editedPassport != _person.Passport) _person.Passport = _editedPassport;
            if (_editedDriveId != null && _editedDriveId != _person.DriverIdNum) _person.DriverIdNum = _editedDriveId;
            if (_editedDr.CompareTo(_person.BirthDate) != 0) _person.BirthDate = _editedDr;
            if (!Equals(_editedGender, _person.GenderType)) _person.GenderType = _editedGender;

            if (!_editedPersonalNumber.Equals(_person.PersonalNumber.ToString()))
            {
                int.TryParse(_editedPersonalNumber, out var num);
                DataBaseM.EditPersonalNumber(_person.Name, num);
            }
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
            Logic.SetControlBackColor(comboBox, curVal, oldVal);
            comboBox.SelectionLength = 0;
            comboBox.Select(0, 0);
            button_SavePersonalData.Focus(); // Cнимаем выделение сменой фокуса.
        }

        // /////////////////////////////// ФУНКЦИИ СОЗДАНИЯ КОНТРОЛОВ ///////////////////////////////////

        // TextBox
        private static TextBox CreateTextBox(bool isReadOnly)
        {
            return new TextBox
            {
                BorderStyle = BorderStyle.Fixed3D,
                ReadOnly = isReadOnly,
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204)
            };
        }
        // Label
        private static Label CreateLabel(string labelText)
        {
            return new Label
            {
                Text = labelText,
                Anchor = AnchorStyles.Left,
                AutoSize = true,
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204)
            };
        }
        // ComboBox
        private static ComboBox CreateComboBox()
        {
            var cmbx = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDown
            };
            return cmbx;
        }
        private static ComboBox CreateComboBox(bool isEnabled)
        {
            var cmbx = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDown,
                Enabled = isEnabled
            };
            return cmbx;
        }

        // DateTimePicker
        private static DateTimePicker CreateDateTimePicker()
        {
            return new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = @"dd MMM yyyy",
                Value = DateTime.Now
            };
        }


        // Разное
        private void ComboChangedMethod<T>(object sender, out T editedVar, T originVar)
        {
            var tb = (ComboBox)sender;
            var edited = (T)Enum.Parse(typeof(T), tb.SelectedItem.ToString());
            editedVar = edited;

            ComboBoxColor(tb, originVar.ToString(), tb.SelectedItem.ToString());
            IsChangedUpdateStatus(originVar.ToString(), tb.SelectedItem.ToString());
        }
    }
}
