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
      DataBaseClass db = DataBaseClass.getInstance();
      private SortedList<string, Person> UserList
      {
         get
         {
            return db.GetCollectionRW();
         }
      }
      public Options options; // Хранятся локальные настройки и параметры программы.
      public Logic logic;       // Логика и управляющие методы программы.

      ///////////////// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ////////////////////////////////
      public MainForm()
      {
         InitializeComponent();
         options = new Options();
         logic = new Logic(options, db);
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         HelperMethods.DeSerialize<Options>(ref options, "Option.bin");

         // Подписка на события в пользовательской Базе Данных
         db.listChangedEvent += UpdateFindComboBox;       // Обновляем список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
         db.listChangedEvent += UpdateUsersCountTextBox; // Обновляем Счетчик пользователей на гл странице.
         db.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         // Сохраняем настройки. 
         HelperMethods.Serialize<Options>(options, "Option.bin");
      }

      public void RunClientForm(string keyName)
      {
         if (db.ContainsKey(keyName))
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
      public void UpdateFindComboBox(object sender, EventArgs arg)
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
         textBox1.Text = db.GetNumberOfPersons().ToString();
         this.Invalidate();
      }

      private void выходToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void button1_Click_1(object sender, EventArgs e)
      {
         db.AddPerson(new Person("Трактирщик Мо"));
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
