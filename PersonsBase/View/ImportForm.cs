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

        private int PageNum { get; set; } = 1;

        private string NamePerson { get; set; }
        private string Phone { get; set; }
        private string Notes { get; set; }
        private string _path;
        #endregion

        private readonly BindingSource _bindRightName = new BindingSource();
        private readonly BindingSource _bindRightPhone = new BindingSource();
        private readonly BindingSource _bindRightUnic = new BindingSource();

        private List<PersonInfo> _fileOpenedList = new List<PersonInfo>();
        private List<PersonInfo> _duplicateNameList = new List<PersonInfo>();
        private List<PersonInfo> _duplicatePhoneList = new List<PersonInfo>();
        private List<PersonInfo> _unicList = new List<PersonInfo>();

        private readonly SortedList<string, Person> _dataBaseList = DataBaseLevel.GetPersonsList();
        private readonly List<PersonInfo> _dataBaseConverted;

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

            _dataBaseConverted = new List<PersonInfo>(_dataBaseList.Select(x => new PersonInfo(x.Key, x.Value.Phone, string.Empty)).ToList());

            // _bindRightName.DataSource = _dataBaseList.Select(x => new { x.Key, x.Value.Phone, string.Empty }).Take(40);
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
            NamePerson = textBox6.Text;
        }

        private void textBoxPhoneMod_TextChanged(object sender, EventArgs e)
        {
            Phone = textBox5.Text;
        }

        private void textBoxNoteMod_TextChanged(object sender, EventArgs e)
        {
            Notes = textBox4.Text;
        }

        #endregion

        #region Buttons

        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            _path = MyFile.OpenFileDialogStr();
            _dt = null;
            _dt = MyFile.GetFromExcel(_path, 5);
            MyDataGridView.SetSourceDataGridView(dataGridViewLeft, _dt);

            button_start.Enabled = true;
        }

        private async void button_start_Click_1(object sender, EventArgs e)
        {
            try
            {
                _fileOpenedList = new List<PersonInfo>(_dt?.AsEnumerable()?.Select(x =>
                                                            new PersonInfo(x.ItemArray[NameColumn - 1].ToString(),
                                                                x.ItemArray[PhoneColumn - 1].ToString(),
                                                                x.ItemArray[NotesColumn - 1].ToString())).ToList() ?? throw new InvalidOperationException());
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
        //8(999) 000-00-00
        private async Task StartAnalysis()
        {
            var dNames = Import.GetNamesDuplicateListAsync(_dataBaseConverted, _fileOpenedList);
            var dPhone = Import.GetPhonesDuplicateListAsync(_dataBaseConverted, _fileOpenedList);
            var dUnic = Import.GetUnicDuplicateListAsync(_dataBaseConverted, _fileOpenedList);

            _duplicateNameList = (await dNames).ToList();
            _duplicatePhoneList = (await dPhone).ToList();
            _unicList = (await dUnic).ToList();

            _bindRightName.DataSource = _duplicateNameList;
            _bindRightPhone.DataSource = _duplicatePhoneList;
            _bindRightUnic.DataSource = _unicList;
        }



        #endregion
    }

}



