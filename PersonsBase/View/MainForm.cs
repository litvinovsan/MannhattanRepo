using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PBase
{
   public partial class MainForm : Form
   {
      ///////////////// ОСНОВНЫЕ ОБЬЕКТЫ ////////////////////////////////
      readonly DataBaseClass _db = DataBaseClass.GetInstance();
      private SortedList<string, Person> UserList => _db.GetCollectionRw();
      private readonly Options _options; // Хранятся локальные настройки и параметры программы.
      private Logic _logic;       // Логика и управляющие методы программы.
      private Photo _photo;
      private Timer _time = new Timer();

      

      ///////////////// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ////////////////////////////////
      public MainForm()
      {
         InitializeComponent();
         _options = new Options();
         _logic = new Logic(_options, _db);
         _photo = new Photo();
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         // Использовать выборочное сохранение обьектов в Options. Весь класс сериализовать не рекомендуется т.к. перетирается пароль
         //  Methods.DeSerialize(ref _options, "Option.bin");
         // FIXME проверка если опшин пароль равен нулю - прописать ручками умолчальный

         // Подписка на события в пользовательской Базе Данных
         _db.ListChangedEvent += UpdateFindComboBoxMenu;  // Список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
         _db.ListChangedEvent += UpdateUsersCountTextBox; // Счетчик пользователей
         _db.ListChangedEvent += UpdateBirthDateComboBox; // Поле Сегодняшних Дней рождений
         _db.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.

         comboBox_BDay.SelectedIndexChanged += new EventHandler(comboBox_BDay_SelectedIndexChanged);

         // Инициализация Таймера для Часов
         StartTimer();

      }
      private void UpdateBirthDateComboBox(object sender, EventArgs e)
      {
         Action myDelegate = delegate
         {
            comboBox_BDay.Items.Clear();
            label4.Text = "Дней Рождения: 0";
            var array = UserList.Values.Where(c => c.BirthDate.ToString("M") == DateTime.Today.ToString("M")).Select(c => c.Name).ToArray<object>();
            if (array.Length != 0)
            {
               comboBox_BDay.Items.AddRange(array);
               comboBox_BDay.SelectedIndex = 0;
               label4.Text = "Дней Рождения: " + array.Length.ToString();
            }
            Invalidate();
         };

         if (InvokeRequired) Invoke(myDelegate);
         else myDelegate();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         // Сохраняем настройки. 
         //  Methods.Serialize(_options, "Option.bin");
      }

      private void RunClientForm(string keyName)
      {
         try
         {
            if (_db.ContainsKey(keyName))
            {
               ClientForm clientFrm = new ClientForm(keyName, _options, _logic);
               clientFrm.ShowDialog();
            }
            else
            {
               MessageBox.Show(@"Ошибка. Неправильное имя клиента");
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      ///////////////// РАБОТА С MAIN FORM ////////////////////////////////
     
      private void UpdateFindComboBoxMenu(object sender, EventArgs arg)
      {
         Action myDelegate = delegate
         {
            toolStripComboBox1.Items.Clear();

            toolStripComboBox1.Items.AddRange(UserList.Values.Select(c => c.Name).ToArray<object>());
            Invalidate();
         };

         if (InvokeRequired) Invoke(myDelegate);
         else myDelegate();
      }

      public void ClearFindCombo()
      {
         Action myDelegate = () => toolStripComboBox1.SelectedText = "";
         if (InvokeRequired)
         {
            Invoke(myDelegate);
         }
         else
         {
            myDelegate();
         }
      }

      private void UpdateUsersCountTextBox(object sender, EventArgs arg)
      {
         textBox1.Text = _db.GetNumberOfPersons().ToString();
         Invalidate();
      }

      private void выходToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void button1_Click_1(object sender, EventArgs e)
      {

      }

      private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
      {

         RunClientForm(toolStripComboBox1.SelectedItem.ToString());

      }
      private void comboBox_BDay_SelectedIndexChanged(object sender, EventArgs e)
      {

         RunClientForm(comboBox_BDay.SelectedItem.ToString());

      }
      private void StartTimer()
      {
         _time.Interval = 1000;
         _time.Tick += _time_ClockTick;
         _time.Start();
      }
      private void _time_ClockTick(object sender, EventArgs e)
      {
         label_Time.Text = Methods.ClockProcessing();
      }

      private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
      {

      }

      private void конфигураторОтчетовToolStripMenuItem_Click(object sender, EventArgs e)
      {

      }


      private void добавитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _db.AddPerson(new Person("Трактирщик Мо"));
         _db.AddPerson(new Person("Гомер Симпсон"));
      }

      private void руководительToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         _logic.AccessRoot();
      }


   }
}
// FIXME добавить пиктограммы и иконки везде в менюхах и на формах