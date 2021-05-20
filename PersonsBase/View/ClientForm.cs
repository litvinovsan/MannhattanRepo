using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;
using PersonsBase.ViewPresenters;

namespace PersonsBase.View
{
   public partial class ClientForm : Form, IClientsForm
   {
      #region /// ОСНОВНЫЕ ОБЬЕКТЫ ///

      private readonly Logic _logic;
      private readonly Person _person;
      private IPresenterProperty _presenter;

      private int _listViewSelectedIndex { get; set; }

      public event Action<string> NameChanged;
      public event Action<StatusPerson> StatusChanged;
      public event Action<Activation> ActivationChanged;
      public event Action<TimeForTr> TimeForTrenningChanged;
      public event Action<AbonementBasic> AbonementOnFormChanged;
      public event Action<string, AbonementBasic> RemoveAbonement;
      public event Action ClosingForm;
      public event Action<Pay> PayChanged;
      public event Action<object> TypeCardPeriodChanged; // Длительность карты или абонемента
      public event Action<TypeWorkout> TypeWorkoutChanged;
      public event Action<SpaService> SpaServiceChanged;
      public event Action<int> OstDaysChanged;
      public event Action<int> OstPersonsChanged;
      public event Action<int> OstAerobChanged;
      public event Action<int> OstMiniGroupChanged;
      public event Action<DateTime> ActivationDateChanged;
      public event Action<DateTime> EndDateChanged;
      public event Action SaveButtonPressed;
      public event Action<string, string> PersonalNumberChanged;
      public event Action<bool> ToggleValidNotValidAbonsChanged;

      #endregion

      #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///
      public ClientForm(string keyName, IPresenterProperty presenter)
      {
         InitializeComponent();
         _person = PersonObject.GetLink(keyName) ?? new Person();
         _logic = Logic.GetInstance();
         _presenter = presenter;
      }

      private void SubscribeEvents()
      {
         // Подписка на События
         _person.NameChanged += _person_NameChanged;
         _person.PathToPhotoChanged += PathToPhotoChangedMethod;
         _person.PhoneChanged += _person_PhoneChanged;
         _person.PassportChanged += _person_PassportChanged;
         _person.DriverIdChanged += _person_DriverIdChanged;
         _person.PersonalNumberChanged += _person_PersonalNumberChanged;
         _person.SpecialNotesChanged += _person_SpecialNotesChanged;
      }
      private void UnsubscribeEvents()
      {
         _person.NameChanged -= _person_NameChanged;
         _person.PathToPhotoChanged -= PathToPhotoChangedMethod;
         _person.PhoneChanged -= _person_PhoneChanged;
         _person.PassportChanged -= _person_PassportChanged;
         _person.DriverIdChanged -= _person_DriverIdChanged;
         _person.PersonalNumberChanged -= _person_PersonalNumberChanged;
         _person.SpecialNotesChanged -= _person_SpecialNotesChanged;

         _person.StatusChanged -= UpdateInfoTextBoxField;
         _person.StatusChanged -= UpdateControls;
         _person.StatusChanged -= GuestVisitHappend;
      }

      private void ClientForm_Load(object sender, EventArgs e)
      {
         // Заполнение стартовое всех полей
         SubscribeEvents();

         // Вкладки Посещений и Архив абонементов
         SetupVisitsDataGridView();
         SetupHistoryAbonement(); //Настройка дата грид вью на вкладке истории абонементов

         Logic.TryLoadPhoto(pictureBox_ClientPhoto, _person.PathToPhoto, _person.GenderType);
         LoadUserData();

         // Когда изменился какой-либо параметр Абонемента
         //_person.AbonementCurentChanged += FreezeStateChanged;
         ////  _person.AbonementCurentChanged += OnPersonOnAbonementCurentChanged;
         //_person.AbonementCurentChanged += HideControls;

         //// Когда изменилась заморозка абонемента - Обновим Инфо поле
      

         // Когда изменился Статус Абонемента
         //_person.StatusChanged += UpdateInfoTextBoxField;
         //_person.StatusChanged += UpdateControls;
         //_person.StatusChanged += GuestVisitHappend;
      }

      private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         SaveSpecialNotes(); //Всегда сохраняем Особые отметки

         // Освобождаем память от изображения
         if (pictureBox_ClientPhoto.Image != null)
         {
            pictureBox_ClientPhoto.Image.Dispose();
            pictureBox_ClientPhoto.Image = null;
         }

         PwdForm.LockPassword();

         UnsubscribeEvents();
         ClosingForm?.Invoke();
      }
      #endregion

      #region /// ОБРАБОТЧИКИ ПОДПИСОК ПЕРСОНАЛЬНЫЕ ДАННЫЕ ///

      /// <summary>
      /// Обновляет таблицу с посещениями на вкладке посещений.
      /// Сейчас только для Гостевого посещения. Костыль
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void GuestVisitHappend(object sender, EventArgs e)
      {
         if (_person.Status == StatusPerson.Гостевой)
         {
            MyDataGridView.SetSourceDataGridView(dataGridView_Visits, Visit.GetVisitsTable(_person));
         }
      }

      private void _person_PersonalNumberChanged(object sender, string e)
      {
         if (!textBox_Number.Text.Equals(_person.IdString))
            textBox_Number.Text = _person.IdString;
         Logic.SetControlBackColor(textBox_Number, _person.IdString.ToString(), textBox_Number.Text);
      }
      private void textBox_Number_Leave(object sender, EventArgs e)
      {

      }
      private void _person_SpecialNotesChanged(object sender, string e)
      {
         MyRichTextBox.Load(richTextBox_notes, _person.SpecialNotes);
      }
      private void _person_DriverIdChanged(object sender, string e)
      {
         if (!maskedTextBox_DriverID.Text.Equals(_person.DriverIdNum))
            maskedTextBox_DriverID.Text = _person.DriverIdNum;
         Logic.SetControlBackColor(maskedTextBox_DriverID, _editedDriveId, _person.DriverIdNum);
      }
      private void _person_PassportChanged(object sender, string e)
      {
         if (!maskedTextBox_Passport.Text.Equals(_person.Passport))
            maskedTextBox_Passport.Text = _person.Passport;
         Logic.SetControlBackColor(maskedTextBox_Passport, _editedPassport, _person.Passport);
      }
      private void _person_NameChanged(object sender, string e)
      {
         Text = @"Карточка Клиента:    " + _person.Name; // Имя формы
         label_PersonName.Text = _person.Name;
      }
      private void _person_PhoneChanged(object sender, string e)
      {
         if (!maskedTextBox_PhoneNumber.Text.Equals(_person.Phone))
            maskedTextBox_PhoneNumber.Text = _person.Phone;
         Logic.SetControlBackColor(maskedTextBox_PhoneNumber, maskedTextBox_PhoneNumber.Text, _person.Phone);
      }
      private void PathToPhotoChangedMethod(object sender, EventArgs e)
      {
         Logic.TryLoadPhoto(pictureBox_ClientPhoto, _person.PathToPhoto, _person.GenderType);
      }
      #endregion

      #region /// МЕТОДЫ. ОБНОВЛЕНИЯ ДАННЫХ НА ФОРМЕ
      public void UpdateDataOnForm()
      {
         UpdateInfoTextBoxField(this, EventArgs.Empty);
         UpdateControls(this, EventArgs.Empty);
         FreezeStateChanged(this, EventArgs.Empty);
         HideControls();
         Logic.LoadShortInfo(groupBox_Info, _person.Status, _presenter.AbonementCurent);
      }
      private void LoadUserData()
      {
         // Имя Клиента
         if (label_PersonName.Text != _person.Name) label_PersonName.Text = _person.Name;
         // Телефон
         if (maskedTextBox_PhoneNumber.Text != _person.Phone) maskedTextBox_PhoneNumber.Text = _person.Phone;
         // Паспорт
         if (maskedTextBox_Passport.Text != _person.Passport) maskedTextBox_Passport.Text = _person.Passport;
         // Права
         if (maskedTextBox_DriverID.Text != _person.DriverIdNum) maskedTextBox_DriverID.Text = _person.DriverIdNum;
         // Персональный Номер
         if (textBox_Number.Text != _person.IdString) textBox_Number.Text = _person.IdString;

         // День Рождения
         try
         {
            if (dateTimePicker_birthDate.Value != _person.BirthDate) dateTimePicker_birthDate.Value = _person.BirthDate;
         }
         catch (Exception)
         {
            dateTimePicker_birthDate.Value = DateTime.Now;
         }

         // Пол
         var gendRange = Enum.GetNames(typeof(Gender)).ToArray<object>();
         var gendSelected = _person.GenderType.ToString();
         MyComboBox.Initialize(comboBox_Gender, gendRange, gendSelected);

         // Особые Отметки
         if (_editedSpecialNote != _person.SpecialNotes) _editedSpecialNote = _person.SpecialNotes;

         MyRichTextBox.Load(richTextBox_notes, _person.SpecialNotes);
      }
      // Информационное текстовое поле
      private void UpdateInfoTextBoxField(object sender, EventArgs e)
      {
         switch (_person?.Status)
         {
            case StatusPerson.Активный:
               {
                  label_infoText.Text = @"";
                  label_infoText.ForeColor = Color.SeaGreen;
                  // Заморозка запланирована в будущем
                  if (_presenter?.AbonementCurent?.Freeze != null && _person?.Status != StatusPerson.Заморожен && _person.Status != StatusPerson.Гостевой)
                  {
                     if (_presenter.AbonementCurent.Freeze.IsConfiguredForFuture())
                     {
                        label_infoText.Text =
                            $@"Заморозка c {_presenter.AbonementCurent.Freeze.GetFutureFreeze().StartDate.Date:d}, дней: {_presenter.AbonementCurent.Freeze.GetDaysToFreeze()}";
                     }
                  }
                  // Не Активирован
                  if (_person.IsAbonementExist() && _presenter.AbonementCurent != null && !_presenter.AbonementCurent.IsActivated)
                  {
                     label_infoText.Text = @" Не активирован";
                  }

                  break;
               }
            case StatusPerson.Нет_Карты:
               {
                  label_infoText.Text = @"Нет Карты";
                  label_infoText.ForeColor = Color.DarkRed;
                  break;
               }
            case StatusPerson.Заморожен:
               {
                  label_infoText.ForeColor = Color.SeaGreen;
                  if (_person.IsAbonementExist() && _presenter.AbonementCurent?.Freeze != null &&
                      _person.Status != StatusPerson.Гостевой)
                  {
                     if (_presenter.AbonementCurent.Freeze?.AllFreezes.Count == 0) break;
                     var dateEnd = _presenter.AbonementCurent.Freeze?.AllFreezes.Last().GetEndDate().Date.ToString("d");
                     label_infoText.Text = @"Заморожен до " + dateEnd;
                  }
                  break;
               }
            case StatusPerson.Гостевой:
               label_infoText.Text = @"Был Гостевой визит";
               label_infoText.ForeColor = Color.SeaGreen;
               break;
            case StatusPerson.Запрещён:
               label_infoText.Text = StatusPerson.Запрещён.ToString();
               label_infoText.ForeColor = Color.DarkRed;
               break;
            case null:
               break;
         }
      }
      // Кнопки
      private void UpdateControls(object sender, EventArgs e)
      {
         // Все контролы
         switch (_person.Status)
         {
            case StatusPerson.Активный:
               {
                  button_Add_Abon.Enabled = true;
                  button_CheckInWorkout.Visible = true;

                  if (_presenter.AbonementCurent is ClubCardA a && a.PeriodAbonem != PeriodClubCard.На_1_Месяц)
                  {
                     button_Freeze.Visible = true;
                     button_Freeze.Enabled = _presenter.AbonementCurent.IsActivated;
                     button_Freeze.Text = @"Заморозка";
                  }
                  else
                  {
                     button_Freeze.Visible = false;
                  }

                  // Кнопка Добавить 
                  button_add_dop_tren.Visible = (_presenter.AbonementCurent is ClubCardA);

                  break;
               }
            case StatusPerson.Нет_Карты:
               {
                  button_Add_Abon.Enabled = true;
                  button_CheckInWorkout.Visible = false;
                  button_Freeze.Visible = false;
                  button_add_dop_tren.Visible = false;
                  break;
               }
            case StatusPerson.Заморожен:
               {
                  button_CheckInWorkout.Visible = false;
                  button_Add_Abon.Enabled = true;
                  button_Freeze.Visible = true;
                  button_add_dop_tren.Visible = false;
                  button_Freeze.Text = @"Разморозить";
                  break;
               }
            case StatusPerson.Гостевой:
               {
                  button_CheckInWorkout.Visible = false;
                  button_Add_Abon.Enabled = true;
                  button_Freeze.Visible = false;
                  button_add_dop_tren.Visible = false;
                  break;
               }
            case StatusPerson.Запрещён:
               {
                  button_CheckInWorkout.Visible = false;
                  button_Add_Abon.Enabled = false;
                  button_add_dop_tren.Visible = false;
                  button_Freeze.Visible = false;
                  break;
               }
            default:
               throw new ArgumentOutOfRangeException();
         }
      }
      // Абонементы
      private void FreezeStateChanged(object sender, EventArgs e)
      {
         // Подписываемся на заморозку если появился абонемент
         if (_presenter.AbonementCurent?.Freeze != null)
         {
            _presenter.AbonementCurent.Freeze.FreezeChanged -= UpdateInfoTextBoxField;
            _presenter.AbonementCurent.Freeze.FreezeChanged += UpdateInfoTextBoxField;
         }
      }

      /// <summary>
      /// Скрывает контролы на форме если абонемента не существует.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void HideControls()
      {
         if (_presenter.AbonementCurent == null)
         {
            #region Вкладка Детальная Информация
            // Активация
            comboBox_activation.Visible = false;
            label9.Visible = false;
            // Время посещения
            comboBox_timeVisit.Visible = false;
            label12.Visible = false;
            // Оплата
            label15.Visible = false;
            comboBox_Payment.Visible = false;
            // Тип Карты Абонемента
            label10.Visible = false;
            comboBox_Type.Visible = false;
            // Доступные тренировки
            label11.Visible = false;
            comboBox_TrenTypes.Visible = false;
            //  Услуги Спа
            label13.Visible = false;
            comboBox_Spa.Visible = false;
            //  Осталось дней
            label21.Visible = false;
            textBox_Ostalos_Dney.Visible = false;
            //  Осталось персональных
            label14.Visible = false;
            textBox_Ostalos_Person.Visible = false;
            //  Осталось Аэробных
            label23.Visible = false;
            textBox_Ostalos_Aerob.Visible = false;
            //  Дата покупки
            label16.Visible = false;
            dateTimePicker_Buy.Visible = false;
            //  Дата Активации
            dateTimePicker_Activation.Visible = false;
            label17.Visible = false;
            //  Дата Окончания
            dateTimePicker_End.Visible = false;
            label18.Visible = false;
            #endregion
         }
         else
         {
            #region Вкладка Детальная Информация
            // Активация
            comboBox_activation.Visible = true;
            label9.Visible = true;

            // Время посещения
            comboBox_timeVisit.Visible = true;
            label12.Visible = true;

            // Оплата
            label15.Visible = true;
            comboBox_Payment.Visible = true;

            // Тип Карты Абонемента
            label10.Visible = true;
            comboBox_Type.Visible = true;

            // Доступные тренировки
            label11.Visible = true;
            comboBox_TrenTypes.Visible = true;
            //  Услуги Спа
            label13.Visible = true;
            comboBox_Spa.Visible = true;
            //  Осталось дней
            label21.Visible = true;
            textBox_Ostalos_Dney.Visible = true;
            //  Осталось персональных
            label14.Visible = true;
            textBox_Ostalos_Person.Visible = true;
            //  Осталось Аэробных
            label23.Visible = true;
            textBox_Ostalos_Aerob.Visible = true;
            //  Дата покупки
            label16.Visible = true;
            dateTimePicker_Buy.Visible = true;
            //  Дата Активации
            dateTimePicker_Activation.Visible = true;
            label17.Visible = true;
            //  Дата Окончания
            dateTimePicker_End.Visible = true;
            label18.Visible = true;
            #endregion
         }
      }

      #endregion

      #region  /// МЕТОДЫ

      private void RunStatusDirector(object sender, EventArgs e)
      {
         _person.StatusDirector();
      }

      /// <summary>
      /// Настройка Источника, Внешнего вида и Помощи для Списка Посещений на вкладке в Карточке клиента
      /// </summary>
      private void SetupVisitsDataGridView()
      {
         var dtable = Visit.GetVisitsTable(_person);
         MyDataGridView.SetSourceDataGridView(dataGridView_Visits, dtable);
         MyDataGridView.ImplementStyle(dataGridView_Visits);
      }

      #region Вкладка Архив Абонементов
      /// <summary>
      /// Настраивает вывод информации о предыдущих абонементах на вкладке Архив Абонементов.
      /// Для обновления таблицы с архивом абон. вызывать этот метод.
      /// </summary>
      private void SetupHistoryAbonement()
      {
         // Получение имен всех полей через атрибуты этих полей. В классе АбонХистори есть атрибуты у полей с описанием имени.
         // var headerStrings = MyReflection.GetPropertiesName(typeof(AbonHistory));
         var headerStrings = MyReflection.GetPropertyDescriptions(typeof(AbonHistory));

         var abonHistories = PersonObject.GetAbonHistoryList(_person.Name);
         if (abonHistories == null) return;

         // Перевернем список
         var abonReverced = abonHistories.Reverse<AbonHistory>().ToList();

         MyDataGridView.SetSourceDataGridView(dataGridView_history_abonements, abonReverced);
         MyDataGridView.ImplementStyle(dataGridView_history_abonements);
         MyDataGridView.AddHeaders(dataGridView_history_abonements, headerStrings);
      }
      #endregion

      #endregion

      #region /// СТАНДАРТНЫЕ ОБРАБОТЧИКИ ////

      private void button_CheckInWorkout_Click(object sender, EventArgs e)
      {
         var isOk = _logic.CheckInWorkout(_person.Name);

         if (isOk)
            Close();

         // Перенос Фокуса на кнопку 
         button_CheckInWorkout.Focus();
      }

      private void button_Cancel_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void button_SavePersonalData_Click(object sender, EventArgs e)
      {
         SaveUserData();
         Logic.SetControlsColorDefault(tableLayoutPanel1);
         Logic.SetControlsColorDefault(tableLayoutPanel3);
         Logic.SaveEverithing();
         SaveButtonPressed?.Invoke();
         MessageBox.Show("Данные Сохранены!");
      }

      private void button_Add_New_Abon_Click(object sender, EventArgs e)
      {
         Logic.AddAbonement(_person.Name);

         button_CheckInWorkout.Focus();
      }

      private void button_add_dop_tren_Click(object sender, EventArgs e)
      {
         using (var form = new NumWorkoutForm(_presenter.AbonementCurent))
         {
            if (form.ShowDialog() == DialogResult.OK)
            {
               form.ApplyChanges();
               PersonObject.SaveAbonementToHistory(_person, _presenter.AbonementCurent);
               // FIXME Убрать эти функции отсюда, возвращать диалог резалт
               // Обновляем Если выбрано что-то.
               Logic.LoadShortInfo(groupBox_Info, _person.Status, _presenter.AbonementCurent);
            }
            else
            {
               return;
            }
         }

         button_CheckInWorkout.Focus();
      }

      private void button_remove_current_abon_Click(object sender, EventArgs e)
      {
         if (_presenter.AbonementCurent == null) return;

         var result = MessageBox.Show($@"Будет удаленo: {_presenter.AbonementCurent.AbonementName}.Продолжить?",
             @"Удаление Абонемента!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

         if (result != DialogResult.Yes) return;
         if (_presenter.CurrentListViewCollection != null && _presenter.CurrentListViewCollection.Count != 0)
         {
            var abonToRemove = _presenter.CurrentListViewCollection[_listViewSelectedIndex];
            RemoveAbonement?.Invoke(_person.Name, abonToRemove);
         }
      }

      private void button_Password_Click(object sender, EventArgs e)
      {
         Logic.AccessRootUser();
      }

      private void button_Freeze_Click(object sender, EventArgs e)
      {
         var status = _person.Status;
         // Чередуется заморозка и разморозка. Если абонемент заморожен - доступна только разморозка
         // Для Разморозки
         if (status == StatusPerson.Заморожен)
         {
            var result = MessageBox.Show(@"Разморозить абонемент?", @"Разморозка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            var abon = _presenter.AbonementCurent as ClubCardA;
            abon?.Freeze.UnFreezeCurrent();
            RunStatusDirector(this, EventArgs.Empty);
         }
         else //  Для заморозки
         {
            var dlgResult = FormsRunner.RunFreezeForm(_person.Name);
            if (dlgResult == DialogResult.Cancel)
            {
               return;
            }
            RunStatusDirector(this, EventArgs.Empty);
         }

         // Для обновления
         UpdateDataOnForm();
      }

      private void button_photo_Click(object sender, EventArgs e)
      {
         var success = Photo.OpenPhoto(out var img);
         var path = Photo.SaveToPhotoDir(img, _person.Name);
         if (success) _person.PathToPhoto = Path.GetFileName(path);
      }

      private void button_photo_cam_Click(object sender, EventArgs e)
      {
         // Открывает форму для получения снимка. 
         var isPictOk = Logic.GetWebCamBmp(out Bitmap picture);

         if (!isPictOk || picture == null) return;

         // Прописывает в персону имя файла фотки. Сохраняет копию изображения
         var path = Photo.SaveToPhotoDir(picture, _person.Name);
         _person.PathToPhoto = Path.GetFileName(path);
      }

      // Кнопки управвления цветом в Заметках
      private void button_Clear_Selection_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ClearFormat(richTextBox_notes);
      }

      private void button_Bold_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ToggleBold(richTextBox_notes);
      }

      private void button_Green_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ToggleColor(richTextBox_notes, Color.Green);
      }

      private void button_Blue_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ToggleColor(richTextBox_notes, Color.DarkBlue);
      }

      private void button_Red_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ToggleColor(richTextBox_notes, Color.Red);
      }
      private void toolStripMenuItem_Red_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ToggleColor(richTextBox_notes, Color.Red);
      }

      private void toolStripMenuItem_Green_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ToggleColor(richTextBox_notes, Color.Green);
      }

      private void toolStripMenuItem_Blue_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ToggleColor(richTextBox_notes, Color.DarkBlue);
      }

      private void toolStripMenuItem_Bold_Click(object sender, EventArgs e)
      {
         MyRichTextBox.ToggleBold(richTextBox_notes);
      }

      private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
      {
         flowLayoutPanel2.Visible = tabControl1.SelectedIndex == 0;
      }


      #endregion

      #region // Контролы общие. Блокировка, Обновление
      public void LockControlsPwd(bool isUnLocked)
      {
         // Детальная информация. Вкладка для редактирования
         textBox_name_Person.Enabled = isUnLocked;
         comboBox_activation.Enabled = isUnLocked;
         comboBox_timeVisit.Enabled = isUnLocked;
         comboBox_Type.Enabled = isUnLocked;
         comboBox_TrenTypes.Enabled = isUnLocked;
         comboBox_Spa.Enabled = isUnLocked;
         textBox_Ostalos_Dney.Enabled = isUnLocked;
         textBox_Ostalos_Person.Enabled = isUnLocked;
         textBox_Ostalos_Aerob.Enabled = isUnLocked;
         //  dateTimePicker_Buy.Enabled = isUnLocked;
         dateTimePicker_Activation.Enabled = isUnLocked;
         // dateTimePicker_End.Enabled = isUnLocked;

         // Кнопка удаления абонемента
         button_RemoveCurrentAbon.Visible = isUnLocked;
      }

      #endregion

      #region // Метод. Дата Окончания Карты
      public void SetEndDate(DateTime endDate)
      {
         dateTimePicker_End.Value = endDate;
      }

      private void dateTimePicker_End_ValueChanged(object sender, EventArgs e)
      {
         EndDateChanged?.Invoke(dateTimePicker_End.Value);
      }
      #endregion

      #region // Метод. Дата Активации Карты

      public void SetActivationDate(DateTime activationDate)
      {
         dateTimePicker_Activation.Value = activationDate;
      }

      private void dateTimePicker_Activation_ValueChanged(object sender, EventArgs e)
      {
         ActivationDateChanged?.Invoke(dateTimePicker_Activation.Value);
      }

      #endregion

      #region // Метод. Дата Покупки Карты
      public void SetBuyDate(DateTime buyDate)
      {
         dateTimePicker_Buy.Value = buyDate;
      }
      #endregion

      #region // Метод. Имя Клиента
      public void SetNameTextBox(string name)
      {
         if (name == null || string.IsNullOrEmpty(name))
         {
            throw new ArgumentNullException(nameof(name));
         }
         // FIXME Добавить проверку. Не делать ничего если данные те же
         textBox_name_Person.Text = name;
      }
      private void textBox_name_Person_TextChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;

         Logic.SetControlBackColor(tb, tb.Text, _person.Name);
      }
      private void textBox_name_Person_Leave(object sender, EventArgs e)
      {
         NameChanged?.Invoke(textBox_name_Person.Text);
      }
      #endregion

      #region // Метод. Статус

      public void SetStatusComboBox(StatusPerson status)
      {
         MyComboBox.SetComboBoxEnumValue<StatusPerson>(comboBox_status, status);
      }

      private void comboBox_status_SelectedIndexChanged(object sender, EventArgs e)
      {
         var control = (sender as ComboBox);
         var selectedIndex = control.SelectedIndex;
         if (selectedIndex == -1 || control.Items.Count == 0) return;
         var value = MyComboBox.GetComboBoxEnum<StatusPerson>(comboBox_status);
         if (_person.Status == value) return;

         StatusChanged?.Invoke(value);
      }

      #endregion

      #region // Метод. Осталось Аэробных тренировок
      public void SetOstAerobComboBox(int num)
      {
         textBox_Ostalos_Aerob.Text = num.ToString();
      }

      private void textBox_Ostalos_Aerob_TextChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;

         if (Int32.TryParse(tb.Text, out int result))
            OstAerobChanged?.Invoke(result);
      }

      private void textBox_Ostalos_Aerob_KeyPress(object sender, KeyPressEventArgs e)
      {
         Logic.CheckForDigits(e);
      }


      #endregion

      #region // Метод. Осталось Персональных тренировок

      private void textBox_Ostalos_Person_TextChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;

         if (int.TryParse(tb.Text, out int result))
            OstPersonsChanged?.Invoke(result);
      }

      public void SetOstPersonalsComboBox(int num)
      {
         textBox_Ostalos_Person.Text = num.ToString();
      }
      private void textBox_Ostalos_Person_KeyPress(object sender, KeyPressEventArgs e)
      {
         Logic.CheckForDigits(e);
      }

      #endregion

      #region // Метод. Осталось Дней

      public void SetOstDaysComboBox(int num)
      {
         textBox_Ostalos_Dney.Text = num.ToString();
      }
      private void textBox_Ostalos_Dney_KeyPress(object sender, KeyPressEventArgs e)
      {
         Logic.CheckForDigits(e);
      }

      private void textBox_Ostalos_Dney_TextChanged(object sender, EventArgs e)
      {
         var abon = _presenter.AbonementCurent as AbonementByDays;

         if (abon != null)
         {
            var tb = (TextBox)sender;
            if (Int32.TryParse(tb.Text, out int result))
            {
               var numCurrent = abon?.GetRemainderDays();
               if (numCurrent != result)
                  OstDaysChanged?.Invoke(result);
            }
         }
      }
      #endregion

      #region // Метод. Время Тренировок

      public void SetTimeForTrenning(TimeForTr time)
      {
         MyComboBox.SetComboBoxEnumValue<TimeForTr>(comboBox_timeVisit, time);
      }

      private void comboBox_timeVisit_SelectedIndexChanged(object sender, EventArgs e)
      {
         var control = (sender as ComboBox);
         var selectedIndex = control.SelectedIndex;
         if (selectedIndex == -1 || control.Items.Count == 0 || _presenter.AbonementCurent == null) return;
         var value = MyComboBox.GetComboBoxEnum<TimeForTr>(control);
         if (_presenter.AbonementCurent.TimeTraining == value) return;

         TimeForTrenningChanged?.Invoke(value);
      }

      #endregion

      #region // Метод. Статус Активации

      private void comboBox_activation_SelectedIndexChanged(object sender, EventArgs e)
      {
         var control = (sender as ComboBox);
         var selectedIndex = control.SelectedIndex;
         if (selectedIndex == -1 || control.Items.Count == 0 || _presenter.AbonementCurent == null) return;
         var value = MyComboBox.GetComboBoxEnum<Activation>(control);
         if (_presenter.AbonementCurent.IsActivated == (value == Activation.Активирован)) return;

         ActivationChanged?.Invoke(value);
      }

      public void SetActivationComboBox(Activation activation)
      {
         MyComboBox.SetComboBoxEnumValue<Activation>(comboBox_activation, activation);
      }

      #endregion

      #region // Метод. Статус Оплаты.

      public void SetPayComboBox(Pay pay)
      {
         MyComboBox.SetComboBoxEnumValue<Pay>(comboBox_Payment, pay);
      }

      private void comboBox_Payment_SelectedIndexChanged(object sender, EventArgs e)
      {
         var control = (sender as ComboBox);
         var selectedIndex = control.SelectedIndex;
         if (selectedIndex == -1 || control.Items.Count == 0 || _presenter.AbonementCurent == null) return;
         var value = MyComboBox.GetComboBoxEnum<Pay>(control);
         if (_presenter.AbonementCurent.PayStatus == value) return;

         PayChanged?.Invoke(value);
      }

      #endregion

      #region // Метод. Доступные Тренировки.

      private void comboBox_TrenTypes_SelectedIndexChanged(object sender, EventArgs e)
      {
         var control = (sender as ComboBox);
         var selectedIndex = control.SelectedIndex;
         if (selectedIndex == -1 || control.Items.Count == 0 || _presenter.AbonementCurent == null) return;
         var value = MyComboBox.GetComboBoxEnum<TypeWorkout>(control);
         if (_presenter.AbonementCurent.TypeWorkout == value) return;

         TypeWorkoutChanged?.Invoke(value);
      }

      public void SetTypeWorkout(TypeWorkout workout)
      {
         MyComboBox.SetComboBoxEnumValue<TypeWorkout>(comboBox_TrenTypes, workout);
      }

      #endregion

      #region // Метод. Услуги СПА.

      private void comboBox_Spa_SelectedIndexChanged(object sender, EventArgs e)
      {
         var control = (sender as ComboBox);
         var selectedIndex = control.SelectedIndex;
         if (selectedIndex == -1 || control.Items.Count == 0 || _presenter.AbonementCurent == null) return;
         var value = MyComboBox.GetComboBoxEnum<SpaService>(control);
         if (_presenter.AbonementCurent.Spa == value) return;

         SpaServiceChanged?.Invoke(value);
      }

      public void SetSpaComboBoxa(SpaService spa)
      {
         MyComboBox.SetComboBoxEnumValue<SpaService>(comboBox_Spa, spa);
      }

      #endregion

      #region // Метод. Тип и Срок Клубной Карты или Абонементра

      private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
      {
         var control = (sender as ComboBox);
         var selectedIndex = control.SelectedIndex;
         if (selectedIndex == -1 || control.Items.Count == 0 || _presenter.AbonementCurent == null) return;
         TypeCardPeriodChanged?.Invoke(control.SelectedItem);
      }

      /// <summary>
      /// Устанавливает Тип Абонемента в комбобоксе на вкладке детальных данных
      /// </summary>
      /// <param name="value"></param>
      public void SetTypeCardComboBox(DaysInAbon value)
      {
         MyComboBox.SetComboBoxEnumValue(comboBox_Type, value);
      }

      /// <summary>
      /// Устанавливает Тип Клубной карты в комбобоксе на вкладке детальных данных
      /// </summary>
      /// <param name="value"></param>
      public void SetTypeCardComboBox(PeriodClubCard value)
      {
         MyComboBox.SetComboBoxEnumValue(comboBox_Type, value);
      }
      /// <summary>
      /// Этот метод нужен для заполнения значениями т.к. есть два типа - Клубная карта и Абонемент
      /// </summary>
      /// <typeparam name="T"></typeparam>
      public void InitComboBoxTypeCard<T>()
      {
         MyComboBox.Initialize<T>(comboBox_Type);
      }

      public void SetPersonalNumber(string number)
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Устанавливает значения по умолчанию и заполняет комбобоксы значениями из енумов
      /// </summary>
      public void InitializeFormControls()
      {
         // FIXME Перенести эту инициализацию в презентер. Презентер должен знать о списках абонменетов и устанавливать их все во время стартапа
         // Инициализация контролов
         MyComboBox.Initialize<StatusPerson>(comboBox_status);
         MyComboBox.Initialize<Activation>(comboBox_activation);
         MyComboBox.Initialize<TimeForTr>(comboBox_timeVisit);
         MyComboBox.Initialize<Pay>(comboBox_Payment);
         MyComboBox.Initialize<TypeWorkout>(comboBox_TrenTypes);
         MyComboBox.Initialize<SpaService>(comboBox_Spa);
         // Поле Доступные тренировки загружаются каждый раз из Презентера. т.к 2 типа существует
      }


      #endregion

      #region // Списки Валидных и Невалидных абонементов и карт

      public void SetAbonementsListView(List<AbonementBasic> abonements)
      {// FIXME Проверить когда абонементов нет
         if (abonements == null) return;

         listView_Abonements.Items.Clear();

         foreach (var item in abonements)
         {
            MyListViewEx.AddNote(listView_Abonements, item.AbonementName, item.GetAbonementType());
         }

         if (listView_Abonements.Items.Count == 0) return;
         listView_Abonements.Focus();
         listView_Abonements.Items[0].Selected = true;
         listView_Abonements.Items[0].Checked = true;
      }

      private void radioButton_Valid_Selected_CheckedChanged(object sender, EventArgs e)
      {
         flowLayoutPanel_MainButtons.Enabled = radioButton_Valid_Selected.Checked;

         ToggleValidNotValidAbonsChanged?.Invoke(radioButton_Valid_Selected.Checked);
         // По идее если чекаем или анчекаем, то всегда должно генерироваться событие. И достаточно вызывать событие только тут.
      }
      private void radioButton_NotValid_selected_CheckedChanged(object sender, EventArgs e)
      {
         flowLayoutPanel_MainButtons.Enabled = !radioButton_NotValid_selected.Checked;
      }

      private void listView_Abonements_MouseClick(object sender, MouseEventArgs e)
      {
         var selectedIndex = listView_Abonements.SelectedIndices;
         if (selectedIndex.Count == 0 || listView_Abonements.Items.Count == 0) return;
         
         if (_presenter?.CurrentListViewCollection != null && _presenter?.CurrentListViewCollection.Count != 0)
         {
            var selectedAbon = _presenter?.CurrentListViewCollection[selectedIndex[0]];
            if (_presenter.AbonementCurent == selectedAbon) return;

            foreach (int index in listView_Abonements.CheckedIndices)
            {
               if (index >= 0 && listView_Abonements.Items.Count != 0)
                  listView_Abonements.Items[index].Checked = false;
               else break;
            }

            AbonementOnFormChanged?.Invoke(selectedAbon);
            listView_Abonements.Items[_listViewSelectedIndex].Checked = true;
         }
      }

      #endregion

      private void listView_Abonements_SelectedIndexChanged(object sender, EventArgs e)
      {
         var selectedIndex = listView_Abonements.SelectedIndices;
         if (selectedIndex.Count == 0 || listView_Abonements.Items.Count == 0) return;

         _listViewSelectedIndex = selectedIndex[0];
      }
   }
}