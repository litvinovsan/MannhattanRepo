using PersonsBase.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{
   public partial class ClientForm : Form
   {
      ///////////////// ОСНОВНЫЕ ОБЬЕКТЫ ////////////////////////////////
      [NonSerialized]
      Person _person;
      readonly DataBaseClass _dataBase = DataBaseClass.getInstance();
      private bool isAnythingChanged;

      ///////////////// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ////////////////////////////////
      public ClientForm(Person person)
      {
         InitializeComponent();
         _person = person;
         groupBox_Info.Font = new Font("Arial", 10);
         isAnythingChanged = false;
      }
      public ClientForm(string keyName)
      {
         InitializeComponent();
         _person = _dataBase.GetCollectionRW()[keyName];
         isAnythingChanged = false;
      }

      private void ClientForm_Load(object sender, EventArgs e)
      {
         LoadUserData();
         LoadShortInfo();
         LoadEditableData();

         UpdateControlState(this, EventArgs.Empty);

         SaveDelegateChain += SaveUserData; // Цепочка Делегатов для сохранения измененных данных.
         _person.statusChanged += UpdateControlState;
      }


      private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (isAnythingChanged)
         {
            DialogResult dialogResult = MessageBox.Show("Сохранить изменения перед выходом?", "Данные Поменялись!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
               SaveData();
            }
         }
         SaveSpecialNotes(); //Всегда сохраняем Особые отметки
         isAnythingChanged = false;
      }

      //////////// ЛОГИКА ФОРМЫ ////////////////////////////////////////////////////////

      private void UpdateControlState(object sender, EventArgs arg)
      {
         // Различные изменения, которые зависят от СТАТУСА клиента.
         Action myDelegate = delegate ()
         {
            // Вкл/Выкл Кнопки ЗАМОРОЗКА и ПОСЕЩЕНИЕ если проблемы с абонементом
            switch (_person.GetActualStatus())
            {
               case StatusPerson.Активный:
                  {
                     button_Add_Abon.Enabled = true;
                     button_CheckInWorkout.Enabled = true;

                     button_Freeze.Enabled = true;
                     button_Freeze.Text = "Заморозить";

                     // Кнопка Заморозка для РАЗОВОГО ЗАНЯТИЯ
                     if (_person.abonementCurent is SingleVisit)
                     {
                        button_Freeze.Enabled = false;
                     }
                     // Кнопка Добавить для Клубной Карты
                     if (_person.abonementCurent is ClubCardAbonement)
                     {
                        button_add_dop_tren.Visible = true;
                     }
                     else
                     {
                        button_add_dop_tren.Visible = false;
                     }


                     break;
                  }
               case StatusPerson.Нет_Карты:
                  {
                     button_Add_Abon.Enabled = true;
                     button_CheckInWorkout.Enabled = false;

                     button_Freeze.Enabled = false;
                     button_Freeze.Text = "Заморозить";
                     break;
                  }
               case StatusPerson.Заморожен:
                  {
                     button_Add_Abon.Enabled = false;
                     button_CheckInWorkout.Enabled = false;
                     button_Freeze.Enabled = _person.abonementCurent != null;
                     button_Freeze.Text = "Разморозить";
                     break;
                  }
               case StatusPerson.Гостевой:
                  {
                     button_Add_Abon.Enabled = true;
                     button_CheckInWorkout.Enabled = false;
                     button_Freeze.Enabled = false;
                     break;
                  }
               case StatusPerson.Запрещён:
                  {
                     button_Add_Abon.Enabled = false;
                     button_CheckInWorkout.Enabled = false;
                     button_Freeze.Enabled = false;
                     break;
                  }
               case StatusPerson.Вероятный_Клиент:
                  {
                     button_Add_Abon.Enabled = true;
                     button_CheckInWorkout.Enabled = false;
                     button_Freeze.Enabled = false;
                     break;
                  }
               default:
                  {
                     break;
                  }
            }
            PersonCardioButton();
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

      // Перенастраивает контейнер для отображения Кнопки Добавить Аэробную или Персональную тренировку
      private void PersonCardioButton()
      {
         if (button_add_dop_tren.Visible == true)
         {
            tableLayoutPanel2.RowStyles[0] = new RowStyle(SizeType.Percent, 25);
            tableLayoutPanel2.RowStyles[1] = new RowStyle(SizeType.Percent, 25);
            tableLayoutPanel2.RowStyles[2] = new RowStyle(SizeType.Percent, 25);
            tableLayoutPanel2.RowStyles[3] = new RowStyle(SizeType.Percent, 25);
         }
         else
         {
            tableLayoutPanel2.RowStyles[0] = new RowStyle(SizeType.Percent, 100);
            tableLayoutPanel2.RowStyles[1] = new RowStyle(SizeType.Percent, 0);
            tableLayoutPanel2.RowStyles[2] = new RowStyle(SizeType.Percent, 100);
            tableLayoutPanel2.RowStyles[3] = new RowStyle(SizeType.Percent, 100);
         }
      }

      // Сохранение данных 
      private void SaveData()
      {
         SaveDelegateChain?.Invoke(); //Цепочка делегатов на сохранение всех полей
         SaveSpecialNotes();
         isAnythingChanged = false;
      }

      /////////// ДАННЫЕ АБОНЕМЕНТА И КЛИЕНТА /////////////////////////////

      // Загрузка Данных
      private void LoadUserData()
      {
         // Загружаем данные на Вкладку Редактирование, в Группу Персональных данных

         _person.GetActualStatus(); // Обновляем текущий статус
         // Имя Клиента на форме.
         UpdateName();

         // Телефон
         maskedTextBox_PhoneNumber.Text = _person.Phone;
         SetControlBackColor(maskedTextBox_PhoneNumber, maskedTextBox_PhoneNumber.Text, _person.Phone);

         // Паспорт
         maskedTextBox_Passport.Text = _person.Passport;
         SetControlBackColor(maskedTextBox_Passport, editedPassport, _person.Passport);

         // Права
         maskedTextBox_DriverID.Text = _person.DriverIdNum;
         SetControlBackColor(maskedTextBox_DriverID, editedDriveID, _person.DriverIdNum);

         // Персональный Номер
         textBox_Number.Text = _person.PersonalNumber.ToString();

         // День Рождения
         dateTimePicker_birthDate.Value = _person.BirthDate;

         // Пол
         comboBox_Gender.Items.Clear();
         comboBox_Gender.Items.AddRange(Enum.GetNames(typeof(Gender))); // Обновляем комбобокс
         comboBox_Gender.SelectedItem = _person.GenderType.ToString();

         // Особые Отметки
         textBox_Notes.Text = _person.SpecialNotes;
         editedSpecialNote = _person.SpecialNotes;

         // Загрузка Фото
         if (_person.PathToPhoto != "")
         {
            pictureBox_ClientPhoto.Image = Image.FromFile(_person.PathToPhoto);
         }

         isAnythingChanged = false;
      }
      private void LoadShortInfo()
      {
         // Загрузка абонемента,если существует
         List<Tuple<Label, Control>> labelTextBoxList = new List<Tuple<Label, Control>>();
         if (_person.abonementCurent == null)
         {
            labelTextBoxList.AddRange(TupleConverter(GetEmptyInfoList()));
         }
         else
         {
            labelTextBoxList.AddRange(TupleConverter(_person.abonementCurent.GetShortInfoList()));
            // Добавляем Поле Статуса. Делаем тут потому что Person.abonem не знает об этом.
            labelTextBoxList.Insert(1, (CreateRowInfo("Текущий статус Клиента", _person.Status.ToString())));
         }

         // Отрисовка Short Info
         var table = CreateTable(labelTextBoxList); // Создаем таблицу c элементами из списка. Таблица: Лэйбл - Текстбокс
         if (groupBox_Info.Controls.Count != 0) groupBox_Info.Controls.Clear();
         groupBox_Info.Controls.Add(table); // Выводим на групбокс нашу новую ShortInfo Table

         isAnythingChanged = false;
      }
      private void LoadEditableData()
      {// Данные подробные,разрешено редактирование через события.
         TableLayoutPanel table = CreateTable(SelectList(_person.abonementCurent));
         if (groupBox_Detailed.Controls.Count != 0) groupBox_Detailed.Controls.Clear();

         table.Font = new Font("Arial", 10);

         groupBox_Detailed.Controls.Add(table);
         isAnythingChanged = false;
      }
      private void UpdateEditableData()
      {
         var listUpdated = SelectList(_person.abonementCurent);
         List<Control> lst = new List<Control>();
         ForAllControls(groupBox_Detailed, (x) =>
         {
            if (x is TextBox || x is ComboBox) lst.Add(x); //Получили только нужные Контролы в массив lst
         });

         // if (lst.Count != listUpdated.Count) return; // Для безопасности

         for (int i = 0; i < lst.Count; i++)
         {
            lst[i].Text = listUpdated[i].Item2.Text;
         }
         isAnythingChanged = false;
      }

      #region // Хелп Методы для Загрузки и обновления пользовательских данных
      private List<Tuple<string, string>> GetEmptyInfoList()
      {  /// Лист по-умолчанию. Отображается на стартовой странице карточки Кл, если не прикреплен абонемент.
         List<Tuple<string, string>> result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Текущий статус Клиента", _person.Status.ToString()),
              new Tuple<string, string>("Абонемент ", "Нет"),
              new Tuple<string, string>("Клубная Карта ", "Нет ")
          };

         return result;
      }
      private TableLayoutPanel CreateTable(List<Tuple<Label, Control>> list)
      {/// Создает таблицу с элементами из List. Таблица вида: Лэйбл - Значение.
         TableLayoutPanel tableInfo = new TableLayoutPanel() { Dock = DockStyle.Fill };
         // Базовая таблица. 1 стр, 2 стлб
         tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
         tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

         for (int i = 0; i < list.Count; i++)
         {
            tableInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tableInfo.Controls.Add(list[i].Item1, 0, i);
            tableInfo.Controls.Add(list[i].Item2, 1, i);
         }

         // Пустые элементы. Без них сьезжает вся разметка.
         tableInfo.Controls.Add(new Panel(), 0, list.Count);
         tableInfo.Controls.Add(new Panel(), 1, list.Count);

         return tableInfo;
      }
      private Tuple<Label, Control> CreateRowInfo(string label, string info)
      {// Создаем экземпляры Label и TextBox. Настройка отображения и свойст тут
         Label lb = new Label()
         {
            Text = label,
            Anchor = AnchorStyles.Left,
            AutoSize = true,
            TextAlign = ContentAlignment.TopLeft
         };

         TextBox tb = new TextBox()
         {
            BackColor = Color.AliceBlue,
            BorderStyle = BorderStyle.FixedSingle,
            Text = " " + info.Replace("_", " "),
            Dock = DockStyle.Fill,
            Font = new Font("Microsoft Sans Serif", 10F)
         };

         // Выполняем проверки на какие-либо ограничения. 
         if (info == "Не_Оплачено") tb.BackColor = Color.LightPink;

         return Tuple.Create<Label, Control>(lb, tb);
      }
      private void UpdateName()
      {
         this.Text = "Карточка Клиента:    " + _person.Name;// Имя формы
         textBox_Name.Text = _person.Name;
         SetFontColor(textBox_Name, _person.Status.ToString(), StatusPerson.Активный.ToString());
         //Если Заморожен
         if (_person.Status == StatusPerson.Заморожен && _person.abonementCurent != null)
         {
            textBox_Name.ForeColor = Color.Green;
            // FIXME: Заморозка абонемента
            textBox_Name.Text = _person.Name + "  (Заморожен до " + "FIXME" + ")";
         }

         if (_person.abonementCurent != null && !_person.abonementCurent.isActivated)
         {
            textBox_Name.ForeColor = Color.Green;
            textBox_Name.Text = _person.Name + "      (Не Активирован)";
         }
      }

      private List<Tuple<Label, Control>> TupleConverter(List<Tuple<string, string>> data)
      {// Преобразует Список вида List<Tuple<string, string>> в универсальный Список: List<Tuple<Label, Control>>
         List<Tuple<Label, Control>> result = new List<Tuple<Label, Control>>();

         foreach (var item in data)
         {
            result.Add(CreateRowInfo(item.Item1, item.Item2));
         }
         // Выделяем жирным первую строку
         result[0].Item1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         result[0].Item2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         result[0].Item1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         result[0].Item2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

         return result;
      }
      private List<Tuple<Label, Control>> SelectList(AbonementBasic currentAbon)
      {
         List<Tuple<Label, Control>> listResult;
         if (currentAbon is AbonementByDays)
         {
            listResult = CreateListAbonement();
         }
         else if (currentAbon is ClubCardAbonement)
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
         List<Tuple<Label, Control>> list = new List<Tuple<Label, Control>>
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
         List<Tuple<Label, Control>> list = new List<Tuple<Label, Control>>()
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
      #endregion

      #region // Разные мелкие методы По оформлению и тд
      /// <summary>
      /// Задает Цвет Текстбоксам и другим элементам. Зеленый если == , Красный если != аргументы. 
      /// </summary>
      private void SetFontColor(Control ctrl, string actual, string expected)
      {
         ctrl.ForeColor = actual == expected ? Color.Green : Color.Red;
      }
      /// <summary>
      /// // Задает Цвет clrSuccess если == , И clrFail если != аргументы.
      /// </summary>
      private void SetControlBackColor(Control ctrl, string current, string expected, Color clrSuccess, Color clrFail)
      {
         ctrl.BackColor = current == expected ? clrSuccess : clrFail;
      }
      /// <summary>
      /// // Задает Цвет SystemColors.Window если == , И Yellow если != аргументы.
      /// </summary>
      private void SetControlBackColor(Control ctrl, string current, string expected)
      {
         Color clrSuccess = SystemColors.Window;
         Color clrFail = Color.Yellow;
         ctrl.BackColor = current == expected ? clrSuccess : clrFail;
      }
      /// <summary>  
      /// Задает Цвет clr если == , Красный если != аргументы.
      /// </summary>
      private void SetControlBackColor(Control ctrl, string current, string expected, Color clrFail)
      { // Задает Цвет clrFail если != аргументы.
         if (current != expected)
         {
            ctrl.BackColor = clrFail;
         } // SystemColors.Window
      }
      /// <summary>
      /// Перебираем все контролы рекурсивно. Выполняем для каждого действие action
      /// </summary>
      public void ForAllControls(Control parent, Action<Control> action)
      {
         foreach (Control c in parent.Controls)
         {
            action(c);
            ForAllControls(c, action);
         }
      }

      public void DisableSelectionComboBoxes()
      {
         ForAllControls(groupBox_Detailed, (x) =>
         {
            if (x is ComboBox)
            {
               (x as ComboBox).SelectionLength = 0;
               (x as ComboBox).Select(0, 0);
               (x as ComboBox).BackColor = SystemColors.Window;
            }
            if (x is TextBox)
            {
               (x as TextBox).BackColor = SystemColors.Window;
            }
         });
      }
      public void SetControlsColorDefault()
      {
         ForAllControls(groupBox_Detailed, (x) =>
         {
            if (x is ComboBox)
            {
               (x as ComboBox).BackColor = SystemColors.Window;
            }
            if (x is TextBox)
            {
               (x as TextBox).BackColor = SystemColors.Window;
            }
         });
      }
      private void NoValidActions()
      {
         MessageBox.Show(_person.abonementCurent.InfoWhenEnd, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         _person.abonementCurent = null;
         _person.Status = StatusPerson.Нет_Карты;
      }
      #endregion

      //////////// СТАНДАРТНЫЕ ОБРАБОТЧИКИ ///////////////////////////////////////////////

      private void button_CheckInWorkout_Click(object sender, EventArgs e)
      {// FIXME переписать попроще
         _person.abonementCurent.TryActivate(); // Если не Активирован

         TypeWorkout typeWorkout = _person.abonementCurent.trainingsType;
         string infoAerobic = "";
         string infoPersonal = "";
         var aerobic = _person.abonementCurent.NumAerobicTr;
         var personal = _person.abonementCurent.NumPersonalTr;

         // Если Кончился абонемент и не сработали проверки в других местах
         if (!_person.abonementCurent.isValid())
         {
            NoValidActions();
            return;
         }

         if (aerobic == 0 && personal == 0)
         {
            typeWorkout = _person.abonementCurent.trainingsType;
         }
         else
         {
            using (WorkoutForm workoutForm = new WorkoutForm(_person.abonementCurent))
            {
               if (workoutForm.ShowDialog() == DialogResult.OK)
               {
                  typeWorkout = workoutForm.selectedTypeWorkout;
               }
               else return;
            }
         }

         // Учет посещения, обновление циферок
         var isSuccess = _person.abonementCurent.CheckInWorkout(typeWorkout);

         if (isSuccess)
         {
            // Дополнительная информация для вывода если успешный учет.
            infoAerobic = (_person.abonementCurent.NumAerobicTr > 0) ? $"\r\nОсталось Аэробных: {_person.abonementCurent.NumAerobicTr}" : "";
            infoPersonal = (_person.abonementCurent.NumPersonalTr > 0) ? $"\r\nОсталось Персональных: {_person.abonementCurent.NumPersonalTr}" : "";

            MessageBox.Show($"Осталось посещений: {_person.abonementCurent.DaysLeft}{infoAerobic}{infoPersonal}", $"Тренировка Учтена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!_person.abonementCurent.isValid())
            {
               _person.Status = StatusPerson.Нет_Карты;
               _person.abonementCurent = null;
            }
            UpdateName();
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
         this.Close();
      }

      private void button_SavePersonalData_Click(object sender, EventArgs e)
      {
         SaveData();
         LoadUserData();
         LoadShortInfo();
         UpdateEditableData();
         DisableSelectionComboBoxes();
         //  SetControlsColorDefault();
      }

      private void ClientForm_Resize(object sender, EventArgs e)
      {
         DisableSelectionComboBoxes(); // Это костыль 
                                       // SetControlsColorDefault();
      }

      private void button_Add_Abon_Click(object sender, EventArgs e)
      {
         using (AbonementForm form = new AbonementForm(_person.Name))
         {
            if (form.ShowDialog() == DialogResult.OK)
            {
               form.ApplyChanges();

               // Обновляем Если выбрано что-то.
               LoadUserData();
               LoadShortInfo();
               LoadEditableData();
               UpdateControlState(this, EventArgs.Empty);
            }
            else return;
         }
         button_CheckInWorkout.Focus();
      }

      private void button_add_dop_tren_VisibleChanged(object sender, EventArgs e)
      {
         PersonCardioButton();
      }

      private void button_add_dop_tren_Click(object sender, EventArgs e)
      {
         using (NumWorkoutForm form = new NumWorkoutForm(_person.abonementCurent))
         {
            if (form.ShowDialog() == DialogResult.OK)
            {
               form.ApplyChanges();

               // Обновляем Если выбрано что-то.
               LoadUserData();
               LoadShortInfo();
               LoadEditableData();
               UpdateControlState(this, EventArgs.Empty);
            }
            else return;
         }
         button_CheckInWorkout.Focus();

      }

      private void textBox_Name_TextChanged(object sender, EventArgs e)
      {

      }

      private void button_Change_Photo_Click(object sender, EventArgs e)
      {

      }
   }
}
