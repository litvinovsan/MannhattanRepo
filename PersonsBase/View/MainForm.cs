﻿using System;
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
         _db.ListChangedEvent += UpdateFindComboBoxMenu;  // Обновляем список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
         _db.ListChangedEvent += UpdateUsersCountTextBox; // Обновляем Счетчик пользователей на гл странице.
         _db.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.

         // Инициализация Таймера для Часов
         _time.Interval = 1000;
         _time.Tick += _time_ClockTick;
         _time.Start();

      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         // Сохраняем настройки. 
         //  Methods.Serialize(_options, "Option.bin");
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

      private void UpdateFindComboBoxMenu(object sender, EventArgs arg)
      {
         Action myDelegate = delegate
         {
            toolStripComboBox1.Items.Clear();

            toolStripComboBox1.Items.AddRange(UserList.Values.Select(c => c.Name).ToArray<object>());
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
         _db.AddPerson(new Person("Трактирщик Мо"));
         _db.AddPerson(new Person("Гомер Симпсон"));
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

      private void _time_ClockTick(object sender, EventArgs e)
      {
         int h = DateTime.Now.Hour;
         int m = DateTime.Now.Minute;
         int s = DateTime.Now.Second;

         string _time = "";
         if (h < 10)
         {
            _time += "0" + h;
         }
         else
         {
            _time += h;
         }

         _time += ":";

         if (m < 10)
         {
            _time += "0" + m;
         }
         else
         {
            _time += m;
         }

         _time += ":";

         if (s < 10)
         {
            _time += "0" + s;
         }
         else
         {
            _time += s;
         }

         label_Time.Text = _time;
      }
   }
}
