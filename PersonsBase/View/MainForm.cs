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

      ///////////////// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ////////////////////////////////
      public MainForm()
      {
         InitializeComponent();
         _options = new Options();
         _logic = new Logic(_options, _db);
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
        // Использовать выборочное сохранение обьектов в Options. Весь класс сериализовать не рекомендуется т.к. перетирается пароль
       //  HelperMethods.DeSerialize(ref _options, "Option.bin");
       // FIXME проверка если опшин пароль равен нулю - прописать ручками умолчальный
         
       // Подписка на события в пользовательской Базе Данных
         _db.ListChangedEvent += UpdateFindComboBox;       // Обновляем список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
         _db.ListChangedEvent += UpdateFindComboBoxMenu;
         _db.ListChangedEvent += UpdateUsersCountTextBox; // Обновляем Счетчик пользователей на гл странице.
         _db.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         // Сохраняем настройки. 
         //  HelperMethods.Serialize(_options, "Option.bin");
      }

      private void RunClientForm(string keyName)
      {
         if (_db.ContainsKey(keyName))
         {
            ClientForm clientFrm = new ClientForm(keyName, _options);
            clientFrm.ShowDialog();
         }
         else
         {
            MessageBox.Show(@"Ошибка. Неправильное имя клиента");
         }
      }

      ///////////////// РАБОТА С MAIN FORM ////////////////////////////////
      private void UpdateFindComboBox(object sender, EventArgs arg)
      {
         Action myDelegate = delegate
         {
             comboBox_Find.Items.Clear();

             comboBox_Find.Items.AddRange(UserList.Values.Select(c => c.Name).ToArray());
             Invalidate();
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
      private void UpdateFindComboBoxMenu(object sender, EventArgs arg)
      {
          Action myDelegate = delegate
          {
              toolStripComboBox1.Items.Clear();

              toolStripComboBox1.Items.AddRange(UserList.Values.Select(c => c.Name).ToArray());
              Invalidate();
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
         Action myDelegate = delegate { comboBox_Find.SelectedText = ""; };
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
         _db.AddPerson(new Person("Трактирщик Мо"));
         _db.AddPerson(new Person("Гомер Симпсон"));
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
         // FIXME: Сделать проверку на Enter
         /*
           if (Char.IsDigit(e.KeyChar) == true) return;
            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                _viewForm.OnSendCommand(textBox_WriteCMD.Text);
                return;
            }
                e.Handled = true;
          */
      }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RunClientForm(toolStripComboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // FIXME: Сделать проверку на Enter
            /*
              if (Char.IsDigit(e.KeyChar) == true) return;
               if (e.KeyChar == Convert.ToChar(Keys.Back)) return;
               if (e.KeyChar == Convert.ToChar(Keys.Enter))
               {
                   _viewForm.OnSendCommand(textBox_WriteCMD.Text);
                   return;
               }
                   e.Handled = true;
             */
        }
    }
}
