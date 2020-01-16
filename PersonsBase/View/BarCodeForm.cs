using System;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;

namespace PersonsBase.View
{
    public partial class BarCodeForm : Form
    {
        private static int _charsCount; // Счетчик количества цифр. Нужен потому что сканер вставляет цифры в текстовое поле по символьно
        private const int NumsInBarString = 12; // Всего в считанном номере 13 позиций
        private string _nameFinded = string.Empty;

        private string _barCodeString;
        private string BarCodeString // Хранится строка с номером. При записи вызывается событие
        {
            get { return _barCodeString; }
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
            var isSuccess = int.TryParse(BarCodeString, out var number);
            if (!isSuccess)
            {
                MessageBox.Show(@"Ошибка Распознавания Номера.", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var isFinded = DataBaseM.FindByPersonalNumber(DataBaseLevel.GetListPersons(), number, out var person);
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
        {   // FIXME Удалить эту проверку на цифры если не работает со сканером
            Logic.CheckForDigits(e); // Проверка на цифры. Если не цифры отбрасываем

            if (_charsCount < NumsInBarString)
            {
                _charsCount++;
                return; // Если не получили все символы строки
            }
            _charsCount = 0;
            BarCodeString = textBox_Code.Text;
        }
    }
}
