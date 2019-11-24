using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace PersonsBase.myStd
{
    public static class MyDataGrid
    {
        private static readonly BindingSource BindingSource1 = new BindingSource();

        #region /// ИНИЦИАЛИЗАЦИЯ

        /// <summary>
        /// Инициализация DataGridView через BindingSource. На вход подается DataTable. Заголовок подключается автоматически
        /// если в датаТэйбл прописан заголовок. 
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="dataTable"></param>
        public static void InitializeDataGridView(DataGridView dataGridView1, DataTable dataTable)
        {
            try
            {
                // Automatically generate the DataGridView columns.
                dataGridView1.AutoGenerateColumns = true;

                // Set up the data source.
                BindingSource1.DataSource = dataTable;
                dataGridView1.DataSource = BindingSource1;

                // Automatically resize the visible rows.
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                // Set up the DataGridView.
                // dataGridView1.Dock = DockStyle.Fill;

                // Put the cells in edit mode when user enters them.
                // dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

                // Чтобы изменения вступили в силу.
                //BindingSource1.ResetBindings(true);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /// <summary>
        /// Инициализация DataGridView из коллекции List T . T может быть классом с полями.
        /// Метод не тестирован.!!!!!!!!!!!!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView1"></param>
        /// <param name="dataList"></param>
        public static void InitializeDataGridView<T>(DataGridView dataGridView1, List<T> dataList)
        {
            try
            {
                // Set up the data source.
                var bindingList = new BindingList<T>(dataList);
                var source = new BindingSource(bindingList, null);
                dataGridView1.DataSource = source;

                // Automatically generate the DataGridView columns.
                dataGridView1.AutoGenerateColumns = true;

                // Automatically resize the visible rows.
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;
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
        public static void InitializeDataGridViewSimple(DataGridView dataGridView1, DataTable dataTable)
        {
            // Automatically resize the visible rows.
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Set the DataGridView control's border.
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;

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
            //Задаем текст ячейки заголовка столбца.
            for (var i = 0; i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].HeaderText = columnHeaders[i];
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
            for (var i = 0; i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].ToolTipText = toolTipsHeaders[i];
            }
        }

        #endregion

        #region /// КОЛОНКИ и СТРОКИ

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

        #endregion
    }
}
