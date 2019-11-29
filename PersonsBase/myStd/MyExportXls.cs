using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace PersonsBase.myStd
{
    public static class MyExportXls
    {
        #region /// CLOSED_XML

        /// <summary>
        /// Получает данные из Excel. Первая строка создает заголовки Таблицы
        /// </summary>
        /// <param name="path"></param>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        public static DataTable GetFromExcel(string path, dynamic worksheet)
        {
            DataTable dt = new DataTable();
            //Open the Excel file using ClosedXML.
            using (var workBook = new XLWorkbook(path))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(worksheet);

                //Create a new DataTable.

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (!string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }

                        firstRow = false;
                    }
                    else
                    {
                        int i = 0;
                        DataRow toInsert = dt.NewRow();
                        foreach (IXLCell cell in row.Cells(1, dt.Columns.Count))
                        {
                            try
                            {
                                toInsert[i] = cell.Value.ToString();
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                            i++;
                        }

                        dt.Rows.Add(toInsert);
                    }
                }

                return dt;
            }
        }

        /// <summary>
        /// Добавляет таблицу DataTable в Excel. Таблица DataTable должна быть уже с заголовками
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        public static void SaveToExcel(DataTable dt, string path, string fileName)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            var directory = Path.GetDirectoryName(path);
            CreateFolder(directory);

            //Exporting to Excel
            //Codes for the Closed XML
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Список всех Клиентов");
                wb.SaveAs(path + fileName + ".xlsx");
            }
        }

        /// <summary>
        /// Сохраняет таблицу в выбранную пользователем папку и файл.
        /// </summary>
        /// <param name="dt"></param>
        public static void SaveToExcel(DataTable dt)
        {
            var fileToSave = GetSaveFileDirectory();
            // Path.GetFullPath(file);
            if (string.IsNullOrEmpty(fileToSave)) return;

            //Exporting to Excel
            //Codes for the Closed XML
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Список всех Клиентов");
                wb.SaveAs(fileToSave);
            }
        }




        #endregion


        #region /// СТАНДАРНТНЫЕ ДИАЛОГИ ОТКРЫТИЯ / СОХРАНЕНИЯ

        public static object OpenFileDialogStr()
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = @"Excel Documents (.xlsx)|*.xlsx|All files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false
            };
            // Set filter options and filter index

            // Call the ShowDialog method to show the dialog box.
            openFileDialog1.ShowDialog();
            object path = openFileDialog1.FileName;
            return path;
        }

        public static string GetSaveFileDirectory()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"Excel Documents (.xlsx)|*.xlsx|All files (*.*)|*.*",
            };
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;
            return path;
        }

        public static void CreateFolder(string fldrName)
        {
            if (!Directory.Exists(fldrName)) Directory.CreateDirectory(fldrName);
        }

        #endregion


        #region /// РАБОТА со СТРОКАМИ и ЯЧЕЦКАМИ

        public static void ExampleAll(string fileName)
        {
            // Примеры
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sample Sheet");
                worksheet.Cell("A1").Value = "Hello World!";
                worksheet.Cell("A2").FormulaA1 = "=MID(A1, 7, 5)";

                workbook.SaveAs(fileName + ".xlsx");
            }
        }


        #endregion






        //public void ExportToExcel(XLWorkbook xlWorkbook, DataTable dataTable)
        //{
        //    if (xlWorkbook == null) return;

        //    //Название страницы
        //    var worksheet = xlWorkbook.Worksheets.Add("«Sample Sheet»");

        //    //Заполняем ячейки
        //    worksheet.Cell("«A1»").Value = "textBox1.Text";
        //    worksheet.Cell("«A2»").Value = "textBox2.Text";

        //}

        //public MemoryStream GetStream(XLWorkbook excelWorkbook)
        //{
        //    MemoryStream fs = new MemoryStream();
        //    excelWorkbook.SaveAs(fs);
        //    fs.Position = 0;
        //    return fs;
        //}

    }
}
