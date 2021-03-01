using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public interface IPersonInfo
    {
        int Id { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Notes { get; set; }
    }

    public class PersonData : IPersonInfo
    {
        public PersonData(string name, string phone, string notes)
        {
            ++Id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Notes = notes ?? throw new ArgumentNullException(nameof(notes));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
    }
    public partial class ImportForm : Form
    {
        private readonly List<IPersonInfo> _personsList = new List<IPersonInfo>();

        private int NameColumn { get; set; }
        private int PhoneColumn { get; set; }
        private int NotesColumn { get; set; }


        public ImportForm()
        {
            // DataBaseM.IsContainsCopyOfValues()
            InitializeComponent();
        }

        public List<IPersonInfo> GetPersonsList()
        {
            return _personsList;
        }

        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            var path = MyFile.OpenFileDialogStr();

            var dt = MyFile.GetFromExcel(path);

            MyDataGridView.SetSourceDataGridView(dataGridView_File, dt);

        }

        #region Text Boxes
        private void textBox_Name_Column_TextChanged(object sender, EventArgs e)
        {
            var isOk = Int32.TryParse(textBox_Name_Column.Text, out int result);
            if (isOk) NameColumn = result;
            else
            {
                MessageBox.Show(@"Введите целое число");
            }
        }

        private void textBox_Phone_Column_TextChanged(object sender, EventArgs e)
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
        #endregion

        private void button_start_Click(object sender, EventArgs e)
        {
            // Set up the data source.
            _personsList.Add(new PersonData("A", "888", "Заметка"));
            _personsList.Add(new PersonData("A", "888", "Заметка"));
            _personsList.Add(new PersonData("A", "888", "Заметка"));
            _personsList.Add(new PersonData("A", "888", "Заметка"));
            _personsList.Add(new PersonData("A", "888", "Заметка"));

            var bindingList = new BindingList<IPersonInfo>(_personsList);
            var source = new BindingSource(bindingList, null);

            bindingSource_Process.DataSource = source;
        }
    }
}
