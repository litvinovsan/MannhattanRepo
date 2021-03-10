using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.Converter;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class ImportForm : Form
    {
        #region Propetries

        private int NameColumn { get; set; } = 1;
        private int PhoneColumn { get; set; } = 2;
        private int NotesColumn { get; set; } = 3;


        private string EditedName { get; set; }
        private string EditedPhone { get; set; }
        private string EditedNotes { get; set; }
        private string _path;
        #endregion

        private readonly BindingSource _bindRightName = new BindingSource();
        private readonly BindingSource _bindRightPhone = new BindingSource();
        private readonly BindingSource _bindRightUnic = new BindingSource();

        private List<PersonInfo> _fileOpenedList = new List<PersonInfo>();
        private List<PersonInfo> _newPhonesList = new List<PersonInfo>();
        private List<PersonInfo> _duplicatePhoneList = new List<PersonInfo>();
        private List<PersonInfo> _unicList = new List<PersonInfo>();

        private readonly SortedList<string, Person> _dataBase = DataBaseLevel.GetPersonsList();
        private List<PersonInfo> _failList = new List<PersonInfo>();
        private DataTable _dt;

        public ImportForm()
        {
            InitializeComponent();

            dataGridViewRight_Name.DataSource = _bindRightName;
            dataGridViewRight_Name.AutoGenerateColumns = true;

            dataGridViewRight_Phone.DataSource = _bindRightPhone;
            dataGridViewRight_Phone.AutoGenerateColumns = true;

            dataGridViewRight_Unic.DataSource = _bindRightUnic;
            dataGridViewRight_Unic.AutoGenerateColumns = true;

            dataGridViewLeft.AutoGenerateColumns = true;

            MyDataGridView.ImplementStyle(dataGridViewRight_Name);
            MyDataGridView.ImplementStyle(dataGridViewRight_Phone);
            MyDataGridView.ImplementStyle(dataGridViewRight_Unic);

            MyDataGridView.ImplementStyle(dataGridViewLeft);

        }

        #region Text Boxes



        private void textBox_Phone_Column_TextChanged_1(object sender, EventArgs e)
        {
            var isOk = Int32.TryParse(textBox_Phone_Column.Text, out int result);
            if (isOk) PhoneColumn = result;
            else
            {
                MessageBox.Show(@"Введите целое число");
            }
        }
        private void textBox_Note_Column_TextChanged(object sender, EventArgs e)
        {
            var isOk = Int32.TryParse(textBox_Note_Column.Text, out int result);
            if (isOk) NotesColumn = result;
            else
            {
                MessageBox.Show(@"Введите целое число");
            }
        }
        private void textBox_Name_Column_TextChanged_1(object sender, EventArgs e)
        {
            var isOk = Int32.TryParse(textBox_Name_Column.Text, out int result);
            if (isOk) NameColumn = result;
            else
            {
                MessageBox.Show(@"Введите целое число");
            }
        }
        private void textBoxNameMod_TextChanged(object sender, EventArgs e)
        {
            EditedName = textBox_Edit_Name.Text;
        }

        private void textBoxPhoneMod_TextChanged(object sender, EventArgs e)
        {
            EditedPhone = textBox_Edit_Phone.Text;
        }

        private void textBoxNoteMod_TextChanged(object sender, EventArgs e)
        {
            EditedNotes = textBox_Edit_Notes.Text;
        }

        #endregion

        #region Buttons
        private void button_Add_Uniq_Click(object sender, EventArgs e)
        {
            _failList = new List<PersonInfo>();
            foreach (var item in _unicList)
            {
                var state = Import.TryAddToDataBase(_dataBase, item);
                if (!state)
                {
                    _failList.Add(item);
                }
            }
            // MessageBox.Show($@"Дубликатов по имени {_failList.Count.ToString()}");
            _bindRightUnic.DataSource = _failList.Distinct(new PersonInfoPhoneComparer());
            button_Add_Uniq.Text = @"Добавить в базу " + _failList.Count.ToString();
        }
        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            _path = MyFile.OpenFileDialogStr();
            _dt = null;
            _dt = MyFile.GetFromExcel(_path, 7);
            MyDataGridView.SetSourceDataGridView(dataGridViewLeft, _dt);

            button_start.Enabled = true;
        }
        private async void button_start_Click_1(object sender, EventArgs e)
        {
            try
            {
                _fileOpenedList = new List<PersonInfo>();
                foreach (var item in _dt.AsEnumerable())
                {
                    var name = Logic.PrepareName(item.ItemArray[NameColumn - 1].ToString());
                    var phone = Logic.PreparePhone(item.ItemArray[PhoneColumn - 1].ToString());
                    var note = item.ItemArray[NotesColumn - 1].ToString();
                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone))
                    {
                        var pInfo = new PersonInfo(name, phone, note);

                        _fileOpenedList.Add(pInfo);
                    }
                }

                _fileOpenedList = _fileOpenedList.Distinct().ToList();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }


            // Обновляем левую часть ещё раз
            MyDataGridView.SetSourceDataGridView(dataGridViewLeft, _fileOpenedList);

            await StartAnalysis();
        }

        #endregion


        #region Methods
        private async Task StartAnalysis()
        {
            var dNames = Import.GetNewPersonsNotExistsAsync(_dataBase, _fileOpenedList);
            var dPhone = Import.GetPhonesAlreadyExistsAsync(_dataBase, _fileOpenedList);
            var dUnic = Import.GetUnicPersonsAsync(_dataBase, _fileOpenedList);

            _newPhonesList = (await dNames).ToList();
            _duplicatePhoneList = (await dPhone).ToList();
            _unicList = (await dUnic).ToList();

            if (dNames.IsCompleted && dPhone.IsCompleted && dUnic.IsCompleted)
            {
                _newPhonesList = _newPhonesList.Except(_unicList, new PersonInfoPhoneComparer()).ToList();

                _bindRightName.DataSource = _newPhonesList;
                _bindRightPhone.DataSource = _duplicatePhoneList;
                _bindRightUnic.DataSource = _unicList;

                // Uniq
                button_Add_Uniq.Text += _unicList.Count.ToString();
                button_Add_Uniq.Enabled = true;
            }
        }



        #endregion


        /// <summary>
        /// При нажатии мышкой на любой из строчек- Заполняются текстбоксы для редактирования записей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRight_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateTextFields(sender);
        }

        private void UpdateTextFields(object sender)
        {
            var selectedRow = (sender as DataGridView)?.CurrentRow;
            if (selectedRow == null) return;

            var name = selectedRow.Cells[0];
            var phone = selectedRow.Cells[1];
            var note = selectedRow.Cells[2];

            textBox_Edit_Name.Text = name.Value.ToString();
            textBox_Edit_Phone.Text = phone.Value.ToString();
            textBox_Edit_Notes.Text = note.Value.ToString();

            try
            {
                Person p = DataBaseM.FindByPhone(_dataBase, Logic.PreparePhone(textBox_Edit_Phone.Text));
                if (p == null)
                {
                    p = PersonObject.GetLink(Logic.PrepareName(textBox_Edit_Name.Text));
                }

                if (p == null) return;

                textBox_Base_Name.Text = p.Name;
                textBox_Base_Phone.Text = p.Phone;
                textBox_Base_Note.Text = Logic.ConvertRichTextBoxToString(p.SpecialNotes);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error dataGridViewRight_MouseClick()");
            }
        }

        /// <summary>
        /// Сохранение в базу отредактированного Клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_Save_Edited(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Edit_Name.Text) || string.IsNullOrEmpty(textBox_Edit_Phone.Text)) return;

            var name = Logic.PrepareName(textBox_Edit_Name.Text);
            var phone = Logic.PreparePhone(textBox_Edit_Phone.Text);

            var pInfo = new PersonInfo(name, phone, textBox_Edit_Notes.Text);

            var isSuccess = Import.TryAddToDataBase(_dataBase, pInfo);
            if (!isSuccess)
            {
                MessageBox.Show($@"Ошибка добавления. Телефон или Имя существуют. ");
                return;
            }

            RemoveSelectedRow();
        }

        private void RemoveSelectedRow()
        {
            // Удаление отредактированных данных из списков
            DataGridView dgrid;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        dgrid = dataGridViewRight_Name;
                        break;
                    }
                case 1:
                    {
                        dgrid = dataGridViewRight_Phone;
                        break;
                    }
                case 2:
                    {
                        dgrid = dataGridViewRight_Unic;
                        break;
                    }
                default:
                    return;
            }

            try
            {
                int delet = dgrid.SelectedCells[0].RowIndex;
                dgrid.Rows.RemoveAt(delet);
                dgrid.Refresh();
                textBox_Edit_Name.Text = "";
                textBox_Edit_Phone.Text = "";
                textBox_Edit_Notes.Text = "";
            }
            catch
            {

                MessageBox.Show(@"Сначала загрузите файл и нажмите кнопку Старт");
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            RemoveSelectedRow();

        }

        private void dataGridViewRight_Phone_SelectionChanged(object sender, EventArgs e)
        {
            UpdateTextFields(sender);
        }

        private void dataGridViewRight_Unic_SelectionChanged(object sender, EventArgs e)
        {
            UpdateTextFields(sender);
        }
    }
}



