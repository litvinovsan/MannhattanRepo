using PBase;
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
   public partial class MainForm : Form
   {
      ///////////////// ОСНОВНЫЕ ОБЬЕКТЫ ////////////////////////////////
      readonly DataBaseClass _db = DataBaseClass.getInstance();
      private SortedList<string, Person> UserList => _db.GetCollectionRW();
      private Options _options; // Хранятся локальные настройки и параметры программы.
      private Logic _logic;       // Логика и управляющие методы программы.

      ///////////////// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ////////////////////////////////
      public MainForm()
      {
         InitializeComponent();
         _options = new Options();
         _logic = new Logic(_options, _db);
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         HelperMethods.DeSerialize<Options>(ref _options, "Option.bin");

         // Подписка на события в пользовательской Базе Данных
         _db.listChangedEvent += UpdateFindComboBox;       // Обновляем список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
         _db.listChangedEvent += UpdateUsersCountTextBox; // Обновляем Счетчик пользователей на гл странице.
         _db.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         // Сохраняем настройки. 
         HelperMethods.Serialize<Options>(_options, "Option.bin");
      }

      public void RunClientForm(string keyName)
      {
         if (_db.ContainsKey(keyName))
         {
            ClientForm clientFrm = new ClientForm(keyName);
            clientFrm.ShowDialog();
         }
         else
         {
            MessageBox.Show("Ошибка. Неправильное имя клиента");
         }
      }

      ///////////////// РАБОТА С MAIN FORM ////////////////////////////////
      private void UpdateFindComboBox(object sender, EventArgs arg)
      {
         Action myDelegate = delegate ()
          {
             comboBox_Find.Items.Clear();

             comboBox_Find.Items.AddRange(UserList.Values.Select(c => c.Name).ToArray<string>());
             this.Invalidate();
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

      public void ClearFindCombo()
      {
         Action myDelegate = delegate () { this.comboBox_Find.SelectedText = ""; };
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
         this.Invalidate();
      }

      private void выходToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void button1_Click_1(object sender, EventArgs e)
      {
         _db.AddPerson(new Person("Трактирщик Мо"));
      }

      private void comboBox_Find_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            RunClientForm(comboBox_Find.SelectedItem.ToString());
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void button2_Click(object sender, EventArgs e)
      {

      }
   }
}
