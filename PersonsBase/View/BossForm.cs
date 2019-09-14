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

namespace PersonsBase.View
{
    public partial class BossForm : Form
    {
        private Options _options;
        private DataBaseClass _dataBase;
        private ManhattanInfo _manhattanInfo;

        #region /// КОНСТРУКТОР. ЗАГРУЗКА. ЗАКРЫТИЕ /// 
        public BossForm()
        {
            InitializeComponent();
            _options = Options.GetInstance();
            _dataBase = DataBaseClass.GetInstance();
            _manhattanInfo = DataObjects.GetManhattanInfo();
        }

        private void BossForm_Load(object sender, EventArgs e)
        {
            // Заполнение Комбо бокс Время
            comboBox_time_H.Items.AddRange(MyTime.Hours.ToArray<object>());
            comboBox_time_M.Items.AddRange(MyTime.Minutes.ToArray<object>());
            comboBox_time_H.SelectedIndex = 0;
            comboBox_time_M.SelectedIndex = 0;

            //Заполнение Лист Вью Расписание
            MyListViewEx.SizeLastColumn(listView_schedule);
            MyListViewEx.AddScheduleNotes(listView_schedule, _manhattanInfo.Schedule);
        }
        private void BossForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PwdForm.LockPassword();
        }

        #endregion

        #region /// ОБРАБОТЧИКИ ///

        private void button_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_nameTren.Text))
            {
                MessageBox.Show("Введите Название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var time = new MyTime($"{comboBox_time_H.Text}:{comboBox_time_M.Text}");
            var sch = new ScheduleNote(time, textBox_nameTren.Text);
            bool isSuccess = Logic.SchedulesAddNote(time, sch);
            if (isSuccess) MyListViewEx.AddScheduleNote(listView_schedule, sch);
        }


        private void listView_schedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedListViewItem = new ListView.SelectedListViewItemCollection(listView_schedule);

            var isSuccess = MyListViewEx.GetSelectedItems(listView_schedule, ref selectedListViewItem);

            // ДеАктивация/Активация кнопки Удалить из расписания
            button_remove.Enabled = isSuccess;

            if (!isSuccess) return; //выход Если ничего не выбрано

            var itemRow = MyListViewEx.GetSelectedText(listView_schedule);
            if (itemRow == null) return;
            // Отображаем выбранный элемент в окне редактирования
            comboBox_time_H.Text = itemRow[0].Split(':')[0];
            comboBox_time_M.Text = itemRow[0].Split(':')[1];
            textBox_nameTren.Text = itemRow[1];
        }



        private void button_remove_Click(object sender, EventArgs e)
        {
            var itemRow = MyListViewEx.GetSelectedText(listView_schedule);
            if (itemRow == null) return;

            var selectedTime = itemRow[0];
            var name = itemRow[1];

            var time = new MyTime(selectedTime);
            var schl = new ScheduleNote(time, name);

            var b = _manhattanInfo.Schedule.RemoveAll(x => x.GetTimeAndNameStr().Equals(schl.GetTimeAndNameStr()));

            MyListViewEx.RemoveSelectedItem(listView_schedule);

        }

        #endregion
    }
}
