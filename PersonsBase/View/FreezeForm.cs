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
using PersonsBase.data.Abonements;

namespace PersonsBase.View
{
    public partial class FreezeForm : Form
    {
        private readonly ClubCardA _clubCard;


        public FreezeForm(ClubCardA clubCard)
        {
            InitializeComponent();
            _clubCard = clubCard;
        }


        private void FreezeForm_Load(object sender, EventArgs e)
        {
            // Экземпляр класса заморозки. Создаем если не существует 
            InitializeFreezeObject();

            // Заголовок Формы
            this.Text = "Карта " + _clubCard.GetTypeClubCard().ToString().Replace("_", " ");

            // Доступно Дней      
            textBox_available.Text = _clubCard.Freeze.GetAvailableDays().ToString();

            // Заполнение комбобокса Количества дней для заморозки
            var maxDaysAvailable = _clubCard.Freeze.GetAvailableDays();
            InitComboBox(maxDaysAvailable);

            // Текущая дата
            dateTimePicker_startFreeze.Value = DateTime.Now.Date;

            // Кнопка удаления заморозки
            buttonClearFreeze.Visible = PwdForm.IsPassUnLocked() ? true : false;
        }

        private void InitComboBox(int maxDaysAvailable)
        {
            if (maxDaysAvailable != 0)
            {   // FIXME Проверить этот кусок. Удалить закоментированное
                comboBox_toFreeze.Items.Clear();
                var nums = Enumerable.Range(1, maxDaysAvailable).Select(x => (object)x).ToArray();
                comboBox_toFreeze.Items.AddRange(nums);
                //for (int i = 1; i <= maxDaysAvailable; i++)
                //{
                //    comboBox_toFreeze.Items.Add(i.ToString());
                //}
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
            _clubCard.Freeze?.RemoveLast(); // Если != null
        }

        private void button_Freeze_Click(object sender, EventArgs e)
        {
            int numDays;
            DateTime startDate;
            if (GetFreezeParams(out numDays, out startDate))
            {
                bool isConfigured = _clubCard.Freeze.TrySetFreeze(numDays, startDate);
                if (isConfigured)
                {
                    _clubCard.EndDate = _clubCard.EndDate.AddDays(numDays);
                    MessageBox.Show($"Заморозка начинается c {startDate.ToString("d")}.\n\rОсталось дней: {_clubCard.Freeze.GetAvailableDays()} ", "Установка Заморозки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show($"Ошибка! Возможно, не хватает дней или не корректная дата.\n\rОсталось дней: {_clubCard.Freeze.GetAvailableDays()}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// Возвращает false если заморозка не возможна
        /// </summary>
        /// <param name="numDays"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private bool GetFreezeParams(out int numDays, out DateTime startDate)
        {
            startDate = dateTimePicker_startFreeze.Value.Date;
            var numResult = int.TryParse(comboBox_toFreeze.Text, out numDays); // Если не осталось дней
            if (!numResult) return false;

            if (DateTime.Now.Date.CompareTo(startDate) > 0)
            {
                MessageBox.Show("Дата должна быть позднее сегодняшнего дня!", "Выберите Дату!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker_startFreeze.Value = DateTime.Now.Date;
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
