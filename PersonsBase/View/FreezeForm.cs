using System;
using System.Linq;
using System.Windows.Forms;
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
            Text = @"Карта " + _clubCard.GetTypeClubCard().ToString().Replace("_", " ");

            // Доступно Дней      
            textBox_available.Text = _clubCard.Freeze.GetAvailableDays().ToString();

            // Заполнение комбобокса Количества дней для заморозки
            var maxDaysAvailable = _clubCard.Freeze.GetAvailableDays();
            InitComboBox(maxDaysAvailable);

            // Текущая дата
            dateTimePicker_startFreeze.Value = DateTime.Now.Date;

            // Заполнение Истории Заморозок
            InitCheckBoxHistory();

            // Кнопка удаления заморозки
            // buttonClearFreeze.Visible = PwdForm.IsPassUnLocked() ? true : false;
        }

        private void InitComboBox(int maxDaysAvailable)
        {
            if (maxDaysAvailable != 0)
            {
                comboBox_toFreeze.Items.Clear();
                var nums = Enumerable.Range(1, maxDaysAvailable).Select(x => (object)x).ToArray();
                comboBox_toFreeze.Items.AddRange(nums);
            }
            else
            {
                comboBox_toFreeze.Items.Clear();
                comboBox_toFreeze.Items.Add("Нет Дней");
            }
            comboBox_toFreeze.SelectedIndex = 0;
        }

        private void InitCheckBoxHistory()
        {
            _clubCard.Freeze.Sort();
            var freezes = _clubCard.Freeze.AllFreezes;
            foreach (var item in freezes)
            {
                var str = $"{item.StartDate:D}    {item.DaysToFreeze}";
                var status = item.IsFreezedNow() || !item.IsFreezeInFuture();
                checkedListBox_allFreeze.Items.Add(str, status);
            }
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
            if (GetFreezeParams(out var numDays, out var startDate))
            {
                var isConfigured = _clubCard.Freeze.TrySetFreeze(numDays, startDate);
                if (isConfigured)
                {
                   
                    MessageBox.Show($@"Заморозка начинается c {startDate:d}.
Осталось дней: {_clubCard.Freeze.GetAvailableDays()} ", @"Установка Заморозки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show($@"Ошибка! Возможно, не хватает дней или не корректная дата.Осталось дней: {_clubCard.Freeze.GetAvailableDays()}", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(@"Дата должна быть позднее сегодняшнего дня!", @"Выберите Дату!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker_startFreeze.Value = DateTime.Now.Date;
                return false;
            }
            if (DateTime.Now.Date.CompareTo(startDate) == 0)
            {
                var result = MessageBox.Show(@"Заморозить Карту с Сегодняшнего дня?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return false;
            }

            return true;
        }
    }
}
