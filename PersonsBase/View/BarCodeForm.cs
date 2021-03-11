using System;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;

namespace PersonsBase.View
{
    public partial class BarCodeForm : Form
    {
        private string _nameFinded = string.Empty;

        private string _barCodeString;
        private string BarCodeString // Хранится строка с номером. При записи вызывается событие
        {
            get { return Logic.NormalizeBarCodeNumber(_barCodeString); }
            set
            {
                _barCodeString = value;
                OnBarcodeStringChanged();
            }
        }

        #region /// СОБЫТИЯ /// Получена строка со сканера
        // Cтрока с номером изменилась. Дальше парсить номер
        [field: NonSerialized]
        public event EventHandler BarcodeStringChanged;
        private void OnBarcodeStringChanged()
        {
            BarcodeStringChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region /// КОНСТРУКТОР ///
        public BarCodeForm()
        {
            InitializeComponent();
            BarcodeStringChanged += BarCodeForm_BarcodeStringChanged;
        }
        #endregion

        #region /// МЕТОДЫ ///

        /// <summary>
        /// Возвращает Найденное в Базе имя клиента. Если найдено. Если нет -в озвращает ""
        /// </summary>
        /// <returns></returns>
        public string GetFindedName()
        {
            return _nameFinded;
        }

        /// <summary>
        /// Обработчик события вызывается когда в переменную BarCodeString записывается текст с номером.
        /// Метод Парсит текст, запускает поиск в коллекции Персон по номеру ID. Если найден - записывает Имя клиента в _nameFinded
        /// и возвращает DialogResult.Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarCodeForm_BarcodeStringChanged(object sender, EventArgs e)
        {
            var isFinded = DataBaseM.FindByPersonalNumber(DataBaseLevel.GetPersonsList(), BarCodeString, out var person);
            if (isFinded)
            {
                _nameFinded = person.Name;
                DialogResult = DialogResult.OK;
            }
            textBox_Code.Text = "";
        }

        #endregion

        // Обработчики стандартные
        private void textBox_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logic.CheckForDigits(e); // Проверка на цифры. Если не цифры отбрасываем

            var t = textBox_Code.Text;
            var numberLen = t.StartsWith("1") ? 13 : 12;
            if (t.Length == numberLen)
            {
                BarCodeString = textBox_Code.Text;
            }
        }
    }
}
