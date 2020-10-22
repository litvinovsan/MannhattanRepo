using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PersonsBase.myStd
{
    public static class MyDataGridView
    {
        // FIXME Перенести создание в метод. Не зачем делать это статическим, вдруг несколько мест использ будет
        private static readonly BindingSource BindingSource1 = new BindingSource();

        #region /// ИНИЦИАЛИЗАЦИЯ ИСТОЧНИКА ДАННЫХ

        /// <summary>
        /// Инициализация DataGridView через BindingSource. На вход подается DataTable. Заголовок подключается автоматически
        /// если в датаТэйбл прописан заголовок. 
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="dataTable"></param>
        public static void SetSourceDataGridView(DataGridView dataGridView1, DataTable dataTable)
        {
            void Action(DataTable table)
            {
                try
                {
                    // Automatically generate the DataGridView columns.
                    dataGridView1.AutoGenerateColumns = true;

                    // Set up the data source.
                    BindingSource1.DataSource = table;
                    dataGridView1.DataSource = BindingSource1;

                    // Automatically resize the visible rows.
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action<DataTable>(Action), dataTable);
            }
            else
            {
                Action(dataTable);
            }
        }

        /// <summary>
        /// Инициализация DataGridView из коллекции List T . T может быть классом с полями.
        /// Метод не тестирован.!!!!!!!!!!!!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView1"></param>
        /// <param name="dataList"></param>
        public static void SetSourceDataGridView<T>(DataGridView dataGridView1, List<T> dataList)
        {
            if (dataGridView1 == null) return;
            if (dataList == null) return;

            try
            {
                // Set up the data source.
                var bindingList = new BindingList<T>(dataList);
                var source = new BindingSource(bindingList, null);
                dataGridView1.DataSource = source;

                // Automatically generate the DataGridView columns.
                dataGridView1.AutoGenerateColumns = true;
            }
            catch (Exception)
            {
                // ignored
            }
        }
        /// <summary>
        /// Инициализация простым присваиванием DataSource.  На вход подается DataTable. Заголовок подключается автоматически если он есть в таблице
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="dataTable"></param>
        public static void SetSourceDataGridViewSimple(DataGridView dataGridView1, DataTable dataTable)
        {
            //Задаем источник данных, для которого объект
            //System.Windows.Forms.DataGridView отображает данные.
            dataGridView1.DataSource = dataTable;
        }

        /// <summary>
        /// Добавляет заголовки из массива в датагрид.
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="columnHeaders"></param>
        public static void AddHeaders(DataGridView dataGrid, string[] columnHeaders)
        {
            try
            {
                //Задаем текст ячейки заголовка столбца.
                for (var i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGrid.Columns[i].HeaderText = columnHeaders[i];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления заголовка " + e);
            }

        }

        /// <summary>
        /// Добавляет Подсказки к заголовкам при наведении указателя мыши.
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="toolTipsHeaders"></param>
        public static void AddHeaderToolTips(DataGridView dataGrid, string[] toolTipsHeaders)
        {
            //Задаем текст ячейки заголовка столбца.
            var len = (toolTipsHeaders.Length < dataGrid.Columns.Count)
                ? toolTipsHeaders.Length
                : dataGrid.Columns.Count;

            for (var i = 0; i < len; i++)
            {
                dataGrid.Columns[i].ToolTipText = toolTipsHeaders[i];
            }
        }

        #endregion

        #region /// КОЛОНКИ и СТРОКИ и ВНЕШНИЙ ВИД

        public static void AddColumn(DataGridView dataGridView, string columnName, string columnHeader)
        {
            dataGridView.Columns.Add(columnName, columnHeader);
        }

        public static void AddValuesToRow(object[] n, DataGridView grid)
        {
            //пока столбцов не будет достаточное количество добавляем их
            while (n.Length > grid.ColumnCount)
            {
                //если колонок нехватает добавляем их пока их будет хватать
                grid.Columns.Add("", "");
            }
            //заполняем строку
            grid.Rows.Add(n);
        }
        private static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null) pi.SetValue(dgv, setting, null);
        }

        /// <summary>
        /// Применяет к датагриду настройки оформления. Автосайз, цвет.И т д
        /// </summary>
        public static void ImplementStyle(DataGridView dataGridView1)
        {
            void Action(DataGridView dtgrd)
            {
                DoubleBuffered(dtgrd, true);
                // Automatically resize the visible rows.
                dtgrd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgrd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Set the DataGridView control's settings
                dtgrd.BorderStyle = BorderStyle.Fixed3D;
                dtgrd.AllowUserToOrderColumns = true;
                dtgrd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (dtgrd.Columns.Count != 0)
                    dtgrd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;// AllCellsExceptHeader;

                // Внешний вид заголовка
                dtgrd.EnableHeadersVisualStyles = false;
                dtgrd.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Bold /*| FontStyle.Italic*/); //жирный курсив размера 16
                dtgrd.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige; //цвет ячейки
                dtgrd.ColumnHeadersDefaultCellStyle.ForeColor = Color.MidnightBlue; //цвет текста
            }

            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action<DataGridView>(Action), dataGridView1);
            }
            else
            {
                Action(dataGridView1);
            }
        }
        #endregion
    }

    [Serializable]
    public class DataGridItem
    {
        public string HeaderName;
        public string Value;
        public string HeaderToolTipHelp;

        public DataGridItem(string header, string value, string helpText)
        {
            HeaderName = header;
            Value = value;
            HeaderToolTipHelp = helpText;
        }

    }
}
