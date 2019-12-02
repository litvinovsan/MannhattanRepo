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
        #region /// CLOSED_XML ОТКРЫТИЕ СОХРАНЕНИЕ ЗАГРУЗКА

        /// <summary>
        /// Получает данные из Excel в таблицу DataTable. Первая строка создает заголовки Таблицы
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataTable GetFromExcel(string path)
        {
            DataTable dt = new DataTable();
            //Open the Excel file using ClosedXML.
            using (var workBook = new XLWorkbook(path))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheets.First();

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
        /// <param name="fileName"></param>
        public static void SaveToExcel(DataTable dt, string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (dt.Columns.Count == 0) return;

            //Exporting to Excel
            //Codes for the Closed XML

            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Список Клиентов");
                ApplyStyles(wb);
                try
                {
                    wb.SaveAs(fileName + ".xlsx");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Файл уже используется!");
                }
            }
        }

        /// <summary>
        /// Сохраняет таблицу в выбранную пользователем папку и файл.
        /// </summary>
        /// <param name="dt"></param>
        public static void SaveToExcel(DataTable dt)
        {
            if (dt.Columns.Count == 0) return;

            var fileToSave = GetSaveFileDirectory();
            if (string.IsNullOrEmpty(fileToSave)) return;

            //Exporting to Excel
            using (var wb = new XLWorkbook())
            {
                // Добавление таблицы.
                wb.Worksheets.Add(dt, "Список Клиентов");
                ApplyStyles(wb);
                try
                {
                    wb.SaveAs(fileToSave);
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Файл уже используется");
                }
            }
        }

        #endregion


        #region /// СТАНДАРНТНЫЕ ДИАЛОГИ ОТКРЫТИЯ / СОХРАНЕНИЯ

        /// <summary>
        /// Вызывает окно Выбора файла для открытия. Возвращает строку с именем файла и адресом.
        /// </summary>
        /// <returns></returns>
        public static string OpenFileDialogStr()
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
            string path = openFileDialog1.FileName;
            return path;
        }

        /// <summary>
        /// Открывает Диалоговое окно сохранения, после выбора файлов возвращает строку с адресом файла
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Создает Директорию, если она не существует
        /// </summary>
        /// <param name="fldrName"></param>
        public static void CreateFolder(string fldrName)
        {
            if (!Directory.Exists(fldrName)) Directory.CreateDirectory(fldrName);
        }

        #endregion


        #region /// РАБОТА со СТРОКАМИ и ЯЧЕЦКАМИ

        /// <summary>
        /// Задает оформление Заголовков итд к Первой вкладке Эксель
        /// </summary>
        /// <param name="wb"></param>
        private static void ApplyStyles(XLWorkbook wb)
        {
            var ws = wb.Worksheets.First();
            var rngTable = ws.RangeUsed();

            // Границы 
            rngTable.Style.Border.OutsideBorder = XLBorderStyleValues.Double;
            rngTable.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            // Adding grid lines
            rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            rngTable.FirstColumn().Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rngTable.FirstColumn().Style.Border.RightBorder = XLBorderStyleValues.Medium;

            ws.SheetView.FreezeColumns(1);

            ws.Columns().AdjustToContents();

            // Adjust column widths to their content
            ws.Columns(2, 25).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Rows(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
        }

        #endregion
    }
}
