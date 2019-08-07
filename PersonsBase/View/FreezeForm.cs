using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBase;

namespace PersonsBase.View
{
   public partial class FreezeForm : Form
   {
      private ClubCardA _clubCard;
      private bool _passCorrect;


      public FreezeForm(ClubCardA clubCard, bool passwordCorrect)
      {
         InitializeComponent();
         _clubCard = clubCard;
         _passCorrect = passwordCorrect;
      }


      private void FreezeForm_Load(object sender, EventArgs e)
      {
         // Экземпляр класса заморозки. Создаем если не существует 
         InitializeFreezeObject();

         // Заголовок Формы
         this.Text = "Карта " + _clubCard.GetTypeClubCard().ToString().Replace("_", " ");

         // Доступно Дней      
         textBox_available.Text = _clubCard.Freeze.GetRemainDays().ToString();

         // Заполнение комбобокса Количества дней для заморозки
         var maxDaysAvailable = _clubCard.Freeze.GetRemainDays();
         InitComboBox(maxDaysAvailable);
       
         // Текущая дата
         dateTimePicker_startFreeze.Value = DateTime.Now.Date;

         // Кнопка удаления заморозки
         buttonClearFreeze.Visible = _passCorrect ? true : false;
      }

      private void InitComboBox(int maxDaysAvailable)
      {
         if (maxDaysAvailable != 0)
         {
            comboBox_toFreeze.Items.Clear();
            for (int i = 1; i <= maxDaysAvailable; i++)
            {
               comboBox_toFreeze.Items.Add(i.ToString());
            }
         }
         else
         {
            comboBox_toFreeze.Items.Clear();
            comboBox_toFreeze.Items.Add("Нет Дней");
         }
         comboBox_toFreeze.SelectedIndex = 0;
      }

      private void InitializeFreezeObject()
      {
         if (_clubCard.Freeze == null)
         {
            _clubCard.Freeze = new FreezeClass(_clubCard.GetTypeClubCard());
         }
      }

      private void buttonClearFreeze_Click(object sender, EventArgs e)
      {
         if (_clubCard.Freeze != null)
         {
            _clubCard.Freeze.Remove();
         }
      }

      private void button_Freeze_Click(object sender, EventArgs e)
      {
         int numDays;
         DateTime startDate;
         if (GetFreezeParams(out numDays, out startDate))
         {
            bool isConfigured = _clubCard.Freeze.TryConfigure(numDays, startDate);
            if (isConfigured)
            {
               _clubCard.EndDate = _clubCard.EndDate.AddDays(numDays);
               MessageBox.Show($"Заморозка начинается c {startDate.ToString("d")}.\n\rОсталось дней: {_clubCard.Freeze.GetRemainDays()} ", "Заморожено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               MessageBox.Show($"Ошибка! Возможно, не хватает дней или не корректная дата.\n\rОсталось дней: {_clubCard.Freeze.GetRemainDays()}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
         }
      }

      private bool GetFreezeParams(out int numDays, out DateTime startDate)
      {
         numDays = int.Parse(comboBox_toFreeze.Text);
         startDate = dateTimePicker_startFreeze.Value.Date;
         if (DateTime.Now.Date.CompareTo(startDate) > 0)
         {
            MessageBox.Show("Дата должна быть позднее сегодняшнего дня!", "Выберите Дату!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
         }
         if (DateTime.Now.Date.CompareTo(startDate) == 0)
         {
            var result = MessageBox.Show("Заморозить Карту с Сегодняшнего дня?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return false;
         }

         return true;
      }
   }
}
