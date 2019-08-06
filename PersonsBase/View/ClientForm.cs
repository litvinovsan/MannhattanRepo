﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.View;

namespace PBase
{
   public partial class ClientForm : Form
   {
      ///////////////// ОСНОВНЫЕ ОБЬЕКТЫ ////////////////////////////////
      [NonSerialized]
      private readonly Person _person;
      private readonly DataBaseClass _dataBase = DataBaseClass.GetInstance();
      private readonly Options _options;
      private bool _isAnythingChanged;

      ///////////////// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ////////////////////////////////
      public ClientForm(string keyName, Options opt)
      {
         InitializeComponent();
         _person = _dataBase.GetCollectionRw()[keyName];
         _isAnythingChanged = false;
         _options = opt;
      }

      private void ClientForm_Load(object sender, EventArgs e)
      {
         LoadUserData();
         LoadShortInfo();
         LoadEditableData();

         UpdateControlState(this, EventArgs.Empty);
         LoadListboxQueue();

         // Подписка на События
         _saveDelegateChain += SaveUserData; // Цепочка Делегатов для сохранения измененных данных.
         _person.StatusChanged += UpdateControlState;
         _options.PasswordChangedEvent += PasswordChangedEvent;

         // Очередь абонементов
         if (_person.AbonementsQueue == null) _person.AbonementsQueue = new ObservableCollection<AbonementBasic>();
         _person.AbonementsQueue.CollectionChanged += AbonementsQueue_CollectionChanged; // Список Абонементов. Если изменился

      }

      private void LoadListboxQueue()
      {
         if (_person.AbonementsQueue == null) return;
         var list = new List<string>();
         foreach (var x in _person.AbonementsQueue) list.Add(x.AbonementName);

         listBox_abonements.Items.AddRange(list.ToArray<object>());
      }

      private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (_isAnythingChanged)
         {
            DialogResult dialogResult = MessageBox.Show(@"Сохранить изменения перед выходом?", @"Данные Поменялись!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
               SaveData();
            }
         }
         SaveSpecialNotes(); //Всегда сохраняем Особые отметки
         _isAnythingChanged = false;
      }

      //////////// ЛОГИКА ФОРМЫ ////////////////////////////////////////////////////////
      private void AbonementsQueue_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
      {
         switch (e.Action)
         {
            case NotifyCollectionChangedAction.Add: // если добавление
               AbonementBasic item = e.NewItems[0] as AbonementBasic;
               if (item != null) listBox_abonements.Items.Add(item.AbonementName);
               break;
            case NotifyCollectionChangedAction.Remove: // если удаление
               listBox_abonements.Items.RemoveAt(0);
               break;
         }

         // Скрытие Списка абонементов
         //HideQueueAbonements();
      }
      private void UpdateControlState(object sender, EventArgs arg)
      {
         // Различные изменения, которые зависят от СТАТУСА клиента.
         Action myDelegate = delegate
         {// FIXME     Попробовать логику наоборот.Включать всё, а в свитче выключать если надо.Может уменьшит мерцание
            // По умолчанию для всех карт
            button_add_dop_tren.Visible = false;
            button_CheckInWorkout.Visible = false;
            button_Add_Abon.Enabled = false;
            button_Freeze.Visible = false;

            groupBox_abonList.Visible = false;

            // Вкл/Выкл Кнопки ЗАМОРОЗКА и ПОСЕЩЕНИЕ если проблемы с абонементом
            switch (_person.UpdateActualStatus())
            {
               case StatusPerson.Активный:
                  {
                     button_Add_Abon.Enabled = true;
                     button_CheckInWorkout.Visible = true;
                     groupBox_abonList.Visible = true;

                     // Кнопка Заморозка Клубной Карты
                     if ((_person.AbonementCurent is ClubCardA) &&
                        (_person.AbonementCurent as ClubCardA).PeriodAbonem != PeriodClubCard.На_1_Месяц)
                     {
                        button_Freeze.Visible = true;
                        // Кнопка Добавить для Клубной Карты
                        button_add_dop_tren.Visible = true;
                     }
                     // HideQueueAbonements();
                     break;
                  }
               case StatusPerson.Нет_Карты:
                  {
                     button_Add_Abon.Enabled = true;
                     break;
                  }
               case StatusPerson.Заморожен:
                  {
                     button_Freeze.Visible = _person.IsAbonementExist();

                     groupBox_abonList.Visible = true;
                     break;
                  }
               case StatusPerson.Гостевой:
                  {
                     button_Add_Abon.Enabled = true;
                     break;
                  }
               case StatusPerson.Запрещён:
                  {
                     break;
                  }
               case StatusPerson.Вероятный_Клиент:
                  {
                     button_Add_Abon.Enabled = true;
                     break;
                  }
            }
            UpdateNameText();
         };

         if (InvokeRequired)
         {
            Invoke(myDelegate);
         }
         else
         {
            myDelegate();
         }
      }

      private void HideQueueAbonements()
      {
         // Список абонементов скрывается если:
         groupBox_abonList.Visible = _person.AbonementsQueue.Count > 0;
      }

      private void PasswordChangedEvent(object sender, EventArgs e)
      {
         if (_options.IsPasswordValid)
         {
            button__remove_abon.Enabled = true;
            button1.Enabled = true;
            groupBox_Detailed.Enabled = true;
         }
         else
         {
            button__remove_abon.Enabled = false;
            button1.Enabled = false;
            groupBox_Detailed.Enabled = false;
         }
      }

      // Сохранение данных 
      private void SaveData()
      {
         _saveDelegateChain?.Invoke(); //Цепочка делегатов на сохранение всех полей
         SaveSpecialNotes();
         _isAnythingChanged = false;
         typeClubCardChanged = false;
      }

      /////////// ДАННЫЕ АБОНЕМЕНТА И КЛИЕНТА /////////////////////////////

      // Загрузка Данных
      private void LoadUserData()
      {
         // Загружаем данные на Вкладку Редактирование, в Группу Персональных данных

         _person.UpdateActualStatus(); // Обновляем текущий статус
         // Имя Клиента на форме.
         UpdateNameText();

         // Телефон
         maskedTextBox_PhoneNumber.Text = _person.Phone;
         Methods.SetControlBackColor(maskedTextBox_PhoneNumber, maskedTextBox_PhoneNumber.Text, _person.Phone);

         // Паспорт
         maskedTextBox_Passport.Text = _person.Passport;
         Methods.SetControlBackColor(maskedTextBox_Passport, _editedPassport, _person.Passport);

         // Права
         maskedTextBox_DriverID.Text = _person.DriverIdNum;
         Methods.SetControlBackColor(maskedTextBox_DriverID, _editedDriveId, _person.DriverIdNum);

         // Персональный Номер
         textBox_Number.Text = _person.PersonalNumber.ToString();

         // День Рождения
         dateTimePicker_birthDate.Value = _person.BirthDate;

         // Пол
         comboBox_Gender.Items.Clear();
         comboBox_Gender.Items.AddRange(Enum.GetNames(typeof(Gender)).ToArray<object>()); // Обновляем комбобокс
         comboBox_Gender.SelectedItem = _person.GenderType.ToString();

         // Особые Отметки
         textBox_Notes.Text = _person.SpecialNotes;
         _editedSpecialNote = _person.SpecialNotes;

         // Загрузка Фото
         if (_person.PathToPhoto != "")
         {
            pictureBox_ClientPhoto.Image = Image.FromFile(_person.PathToPhoto);
         }

         _isAnythingChanged = false;
      }
      private void LoadShortInfo()
      { //FIXME Мерцание
         Action myDelegate = delegate
         {
            var labelTextBoxList = new List<Tuple<Label, Control>>();
            if (!_person.IsAbonementExist())
            {
               labelTextBoxList.AddRange(Methods.TupleConverter(Methods.GetEmptyInfoList(_person)));
            }
            else
            {
               labelTextBoxList.AddRange(Methods.TupleConverter(_person.AbonementCurent.GetShortInfoList()));
               // Добавляем Поле Статуса. Делаем тут потому что Person.abonem не знает об этом.
               labelTextBoxList.Insert(1, (Methods.CreateRowInfo("Текущий статус Клиента", _person.Status.ToString())));
            }

            // Отрисовка Short Info
            var table = Methods.CreateTable(labelTextBoxList); // Создаем таблицу c элементами из списка. Таблица: Лэйбл - Текстбокс
            if (groupBox_Info.Controls.Count != 0)
            {
               groupBox_Info.Controls.Clear();
            }

            groupBox_Info.Controls.Add(table); // Выводим на групбокс нашу новую ShortInfo Table

            _isAnythingChanged = false;
         };

         if (InvokeRequired)
         {
            Invoke(myDelegate);
         }
         else
         {
            myDelegate();
         }
      }
      private void LoadEditableData()
      {// Данные подробные,разрешено редактирование через события.
         TableLayoutPanel table = Methods.CreateTable(SelectList(_person.AbonementCurent));
         if (groupBox_Detailed.Controls.Count != 0) groupBox_Detailed.Controls.Clear();

         table.Font = new Font("Arial", 10);

         groupBox_Detailed.Controls.Add(table);
         _isAnythingChanged = false;
      }
      private void UpdateEditableData()
      {
         var listUpdated = SelectList(_person.AbonementCurent);
         List<Control> lst = new List<Control>();
         Methods.ForAllControls(groupBox_Detailed, x =>
         {
            if (x is TextBox || x is ComboBox) lst.Add(x); //Получили только нужные Контролы в массив lst
         });

         for (int i = 0; i < lst.Count; i++)
         {
            lst[i].Text = listUpdated[i].Item2.Text;
         }
         _isAnythingChanged = false;
      }

      #region // Хелп Методы для Загрузки и обновления пользовательских данных

      private void UpdateNameText()
      {
         Text = @"Карточка Клиента:    " + _person.Name;// Имя формы
         if (textBox_Name.Text != _person.Name)
         {
            textBox_Name.Text = _person.Name;
            Methods.SetFontColor(textBox_Name, _person.Status.ToString(), StatusPerson.Активный.ToString());
         }

         // Если Заморожен
         if (_person.Status == StatusPerson.Заморожен && _person.IsAbonementExist() && _person.AbonementCurent is ClubCardA)
         {
            textBox_Name.ForeColor = Color.SeaGreen;
            string dateEnd = ((ClubCardA)_person.AbonementCurent).Freeze?.FreezeEndDate.Date.ToString("d");
            textBox_Name.Text = _person.Name + @"   (Заморожен До " + dateEnd + @" )";
         }

         // Заморозка запланирована в будущем
         var card = _person.AbonementCurent as ClubCardA;
         if (card?.Freeze != null && (_person.Status != StatusPerson.Заморожен))
         {
            if (card.Freeze.IsConfigured())
            {
               textBox_Name.ForeColor = Color.SeaGreen;
               textBox_Name.Text = _person.Name + $"   (Заморозка c {card.Freeze.FreezeStartDate.Date.ToString("d")}, на {card.Freeze.GetDaysToFreeze()} дней)";
            }
         }

         // Не Активирован
         if (_person.IsAbonementExist() && !_person.AbonementCurent.isActivated)
         {
            textBox_Name.ForeColor = Color.Green;
            textBox_Name.Text = _person.Name + @"   (Не Активирован)";
            button_Freeze.Enabled = false;
         }
         else button_Freeze.Enabled = true;

      }

      private List<Tuple<Label, Control>> SelectList(AbonementBasic currentAbon)
      {
         List<Tuple<Label, Control>> listResult;
         if (currentAbon is AbonementByDays)
         {
            listResult = CreateListAbonement();
         }
         else if (currentAbon is ClubCardA)
         {
            listResult = CreateListClubCard();
         }
         else if (currentAbon is SingleVisit)
         {
            listResult = CreateListSingleVisit();
         }
         else
         {
            listResult = CreateListNoAbonement();
         }
         return listResult;
      }
      private List<Tuple<Label, Control>> CreateListNoAbonement()
      {
         List<Tuple<Label, Control>> list = new List<Tuple<Label, Control>>
          {
             CreateNameField(),
             CreateStatusField()
          };
         return list;
      }
      private List<Tuple<Label, Control>> CreateListSingleVisit()
      {
         List<Tuple<Label, Control>> list = new List<Tuple<Label, Control>>
          {
              CreateNameField(),
              CreateStatusField(),
              CreateTypeWorkoutField(),
              CreateSpaServiceField(),
              CreatePayServiceField()
          };

         return list;
      }
      private List<Tuple<Label, Control>> CreateListClubCard()
      {
         var list = new List<Tuple<Label, Control>>
          {
              CreateNameField(),
              CreateStatusField(),
              CreatePeriodClubCardField(),
              CreateTypeWorkoutField(),
              CreateTimeForTrField(),
              CreateSpaServiceField(),
              CreateNumPersonalTrField(),
              CreateNumAerobicTrField(),
              CreateRemainderDaysField(),
              CreatePayServiceField(),
              CreateBuyDateField(),
              CreateEndDateField()
          };
         return list;
      }
      private List<Tuple<Label, Control>> CreateListAbonement()
      {
         List<Tuple<Label, Control>> list = new List<Tuple<Label, Control>>
         {
            CreateNameField(),
            CreateStatusField(),
            CreateNumberDaysInAbonField(),
            CreateTypeWorkoutField(),
            CreateTimeForTrField(),
            CreateSpaServiceField(),
            CreateRemainderDaysField(),
            CreatePayServiceField(),
            CreateBuyDateField(),
            CreateEndDateField()
         };

         return list;
      }
      private void CreateAbonementForm()
      {
         using (var form = new AbonementForm(_person.Name))
         {
            if (form.ShowDialog() == DialogResult.OK)
            {
               form.ApplyChanges();
               // Обновляем Если выбрано что-то.
               _person.UpdateActualStatus(); // Обновляем текущий статус
               UpdateNameText();

               LoadShortInfo();
               LoadEditableData();
               UpdateControlState(this, EventArgs.Empty);
            }
         }
      }

      private void NoValidActions()
      {
         MessageBox.Show(_person.AbonementCurent.InfoWhenEnd, @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         _person.AbonementCurent = null;
         _person.Status = StatusPerson.Нет_Карты;
      }

      #endregion

      //////////// СТАНДАРТНЫЕ ОБРАБОТЧИКИ ///////////////////////////////////////////////

      private void button_CheckInWorkout_Click(object sender, EventArgs e)
      {// FIXME переписать попроще
         _person.AbonementCurent.TryActivate(); // Если не Активирован

         TypeWorkout typeWorkout;
         int aerobic = _person.AbonementCurent.NumAerobicTr;
         int personal = _person.AbonementCurent.NumPersonalTr;

         // Если Кончился абонемент и не сработали проверки в других местах
         if (!_person.AbonementCurent.IsValid())
         {
            NoValidActions();
            return;
         }

         if (aerobic == 0 && personal == 0)
         {
            typeWorkout = _person.AbonementCurent.trainingsType;
         }
         else
         {
            using (var workoutForm = new WorkoutForm(_person.AbonementCurent))
            {
               if (workoutForm.ShowDialog() == DialogResult.OK)
               {
                  typeWorkout = workoutForm.SelectedTypeWorkout;
               }
               else return;
            }
         }

         // Учет посещения, обновление циферок
         var isSuccess = _person.AbonementCurent.CheckInWorkout(typeWorkout);

         if (isSuccess)
         {
            // Дополнительная информация для вывода если успешный учет.
            var infoAerobic = (_person.AbonementCurent.NumAerobicTr > 0) ? $"\r\nОсталось Аэробных: {_person.AbonementCurent.NumAerobicTr}" : "";
            var infoPersonal = (_person.AbonementCurent.NumPersonalTr > 0) ? $"\r\nОсталось Персональных: {_person.AbonementCurent.NumPersonalTr}" : "";

            MessageBox.Show($@"Осталось посещений: {_person.AbonementCurent.GetRemainderDays()}{infoAerobic}{infoPersonal}", @"Тренировка Учтена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!_person.AbonementCurent.IsValid())
            {
               _person.Status = StatusPerson.Нет_Карты;
               _person.AbonementCurent = null;
            }
            UpdateNameText();
            LoadShortInfo();
            LoadEditableData();
         }
         else
         {
            NoValidActions();
         }
      }
      private void button_Cancel_Click(object sender, EventArgs e)
      {
         Close();
      }
      private void button_SavePersonalData_Click(object sender, EventArgs e)
      {
         SaveData();
         LoadUserData();
         LoadShortInfo();
         UpdateEditableData();
         Methods.ClearSelection(groupBox_Detailed);

         // Methods.SetControlsColorDefault(groupBox_Detailed);
      }
      private void ClientForm_Resize(object sender, EventArgs e)
      {
         Methods.ClearSelection(groupBox_Detailed);
      }
      private void button_Add_Abon_Click(object sender, EventArgs e)
      {
         if (_person.AbonementCurent == null)
         {
            CreateAbonementForm();
         }
         else
         {
            var result = MessageBox.Show($"Действует:  {_person.AbonementCurent.AbonementName}.\n\rДобавить новый абонемент к существующему?", "Добавление Абонемента", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               CreateAbonementForm();
            }
         }

         button_CheckInWorkout.Focus();
      }

      private void button_add_dop_tren_Click(object sender, EventArgs e)
      {
         using (NumWorkoutForm form = new NumWorkoutForm(_person.AbonementCurent))
         {
            if (form.ShowDialog() == DialogResult.OK)
            {
               form.ApplyChanges();

               // Обновляем Если выбрано что-то.
               _person.UpdateActualStatus(); // Обновляем текущий статус
               LoadShortInfo();
               LoadEditableData();
               UpdateControlState(this, EventArgs.Empty);
            }
            else return;
         }
         button_CheckInWorkout.Focus();
      }

      private void button__remove_abon_Click(object sender, EventArgs e)
      {
         var selectedIndex = listBox_abonements.SelectedIndex;
         if (selectedIndex == -1) MessageBox.Show(@"Выберите Абонемент для удаления!");
         else
         {
            _person.AbonementsQueue.RemoveAt(selectedIndex);
            MessageBox.Show(@"Запись Удалена!");
         }
      }
      private void button_remove_current_abon_Click(object sender, EventArgs e)
      {
         if (_person.AbonementCurent == null) return;
         var result = MessageBox.Show($"Будет удаленo:  {_person.AbonementCurent.AbonementName}.\n\rПродолжить?", "Удаление Абонемента!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         if (result == DialogResult.Yes)
         {
            _person.AbonementCurent = null;
            _person.UpdateActualStatus(); // Обновляем текущий статус

            UpdateNameText();
            LoadShortInfo();
            LoadEditableData();
            UpdateControlState(this, EventArgs.Empty);
         }
      }

      private void button_Password_Click(object sender, EventArgs e)
      {
         if (_options.IsPasswordValid) // Заблокировать пароль в этом случае
         {
            _options.IsPasswordValid = false;
            button2.Text = @"Изменить данные";
         }
         else
         {
            PwdForm pwd = new PwdForm(_options);
            var dlgResult = pwd.ShowDialog();
            if (dlgResult == DialogResult.OK) button2.Text = @"Заблокировать данные";
            else button2.Text = @"Изменить данные";
         }
      }
      private void button_Freeze_Click(object sender, EventArgs e)
      {
         var status = _person.Status;

         if (status != StatusPerson.Заморожен)
         {
            var numDays = 14;
            var startDate = DateTime.Parse("13.08.2019").Date;

            if ((_person.AbonementCurent as ClubCardA).TryFreezeClubCard(numDays, startDate))
            {
               LoadUserData();
               LoadShortInfo();
               UpdateEditableData();
            }

         }
         else
         {
            MessageBox.Show(@"Сейчас абонемент заморожен!");
         }
      }


   }
}
