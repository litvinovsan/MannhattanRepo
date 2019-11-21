using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PBase;

namespace PersonsBase.data
{
    /// <summary>
    /// Вспомогательные и универсальные методы, которые неразместить в конкретных классах.
    /// </summary>
    [Serializable]
    public static class Methods
    {
        private const string StrMorning = "Утро";

        /// <summary>
        /// Подготавливает строку с именем, приводит в  заглавный формат Фамилия Имя Отчество вместо  фамилия имя отчество
        /// </summary>
        /// <param name="fio"></param>
        /// <returns></returns>
        public static string PrepareName(string fio)
        {
            string resultName = "";
            var minimumSpaces = Regex.Replace(fio.ToLower().Trim(), @"[^\S\r\n]+", " "); // Уплотняем пробелы
            var lowercase = minimumSpaces.ToLower();

            var fioArray = lowercase.Split(' ');

            foreach (var item in fioArray)
            {
                var c = Char.ToUpper(item[0]);
                resultName += c + item.Remove(0, 1) + " ";
            }

            return resultName.Trim();
        }

        // Сериализация обьектов
        public static bool Serialize<T>(T objectToSerialize, string nameFile)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, objectToSerialize);// Если ошибка, вываливаемся тут и не стираем файл базы
                                                               // Сохраняем в файл поток из памяти
                    using (var fileStream = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        formatter.Serialize(fileStream, objectToSerialize);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Ошибка: " + e.Message, @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeSerialize<T>(ref T objectToDeSerialize, string nameFile)
        {
            try
            {
                var formatter = new BinaryFormatter();

                using (var fileStream = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    objectToDeSerialize = (T)formatter.Deserialize(fileStream);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Ошибка: " + e.Message, @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        #region /// ДЛЯ Создания ТАБЛИЦ на ClientForms /// Подготовка для отображения на Клиентской форме

        public static void LoadShortInfo(GroupBox gbBoxToShow, Person person)
        {
            CreateShortInfo(gbBoxToShow, person);
        }

        private static void CreateShortInfo(GroupBox gbBoxToShow, Person person)
        {
            var labelTextBoxList = CreateLabelTextBoxList(person);

            // Отрисовка Short Info
            var table = CreateTable(labelTextBoxList); // Создаем таблицу c элементами из списка. Таблица: Лэйбл - Текстбокс

            AddTableToGroupBox(table, gbBoxToShow);
        }

        private static void AddTableToGroupBox(TableLayoutPanel table, GroupBox grpBx)
        {
            if (grpBx.Controls.Count != 0)
            {
                grpBx.Controls.Clear();
            }

            grpBx.Controls.Add(table); // Выводим на групбокс нашу новую ShortInfo Table
        }

        private static List<Tuple<Label, Control>> CreateLabelTextBoxList(Person person)
        {
            var labelTextBoxList = new List<Tuple<Label, Control>>();
            if (person.IsAbonementExist())
            {
                labelTextBoxList.AddRange(TupleConverter(person.AbonementCurent.GetShortInfoList()));
                // Добавляем Поле Статуса. Делаем тут потому что Person.abonem не знает об этом.
                var status = person.Status.ToString();
                labelTextBoxList.Insert(1, CreateRowInfo("Текущий статус Клиента", status));
            }
            else
            {
                labelTextBoxList.AddRange(TupleConverter(GetEmptyInfoList(person)));
            }

            return labelTextBoxList;
        }
        public static TableLayoutPanel CreateTable(List<Tuple<Label, Control>> list)
        {// Создает таблицу с элементами из List. Таблица вида: Лэйбл - Значение.
            var tableInfo = new TableLayoutPanel { Dock = DockStyle.Fill };
            // Базовая таблица. 1 стр, 2 стлб
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));

            for (int i = 0; i < list.Count; i++)
            {
                tableInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                tableInfo.Controls.Add(list[i].Item1, 0, i);
                tableInfo.Controls.Add(list[i].Item2, 1, i);
            }

            // Пустые элементы. Без них сьезжает вся разметка.
            tableInfo.Controls.Add(new Panel(), 0, list.Count);
            tableInfo.Controls.Add(new Panel(), 1, list.Count);

            return tableInfo;
        }

        private static IEnumerable<Tuple<string, string>> GetEmptyInfoList(Person person)
        {
            var result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Текущий статус Клиента", person.Status.ToString()),
              new Tuple<string, string>("Абонемент ", "Нет"),
              new Tuple<string, string>("Клубная Карта ", "Нет ")
          };

            return result;
        }

        /// <summary>
        /// Тюпл Сборка ИмяПоля-Поле, содержащие конкретные значения, например, Статус оплаты
        /// </summary>
        /// <param name="label"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        private static Tuple<Label, Control> CreateRowInfo(string label, string info)
        {// Создаем экземпляры Label и TextBox. Настройка отображения и свойст тут
            var lb = new Label
            {
                Text = label,
                Anchor = AnchorStyles.Left,
                AutoSize = true,
                TextAlign = ContentAlignment.TopLeft
            };

            var tb = new TextBox
            {
                BackColor = Color.AliceBlue,
                BorderStyle = BorderStyle.FixedSingle,
                Text = @" " + info.Replace("_", " "),
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 9F)
            };

            // Выделение цветом по какому-либо признакму
            if (info == "Не_Оплачено" || info == StrMorning) tb.BackColor = Color.LightPink;

            return Tuple.Create<Label, Control>(lb, tb);
        }

        private static IEnumerable<Tuple<Label, Control>> TupleConverter(IEnumerable<Tuple<string, string>> data)
        {// Преобразует Список вида List<Tuple<string, string>> в универсальный Список: List<Tuple<Label, Control>>
            List<Tuple<Label, Control>> result = data.Select(item => CreateRowInfo(item.Item1, item.Item2)).ToList();

            // Выделяем жирным первую строку
            result[0].Item1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            result[0].Item2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            result[0].Item1.ForeColor = Color.FromArgb(0, 64, 64);
            result[0].Item2.ForeColor = Color.FromArgb(0, 64, 64);

            return result;
        }
        #endregion

        // Методы по оформлению контролов На WinForm
        #region ///  ВСПОМОГАТЕЛЬНЫЕ МЕТДЫ ///  Оформление, подготовка времени и тд
        /// <summary>
        /// Задает Цвет Текстбоксам и другим элементам. Зеленый если == , Красный если != аргументы. 
        /// </summary>
        public static void SetFontColor(Control ctrl, string actual, string expected)
        {
            ctrl.ForeColor = actual == expected ? Color.Green : Color.Red;
        }
        /// <summary>
        /// // Задает Цвет clrSuccess если == , И clrFail если != аргументы.
        /// </summary>
        public static void SetControlBackColor(Control ctrl, string current, string expected, Color clrSuccess, Color clrFail)
        {
            ctrl.BackColor = current == expected ? clrSuccess : clrFail;
        }
        /// <summary>
        /// // Задает Цвет SystemColors.Window если == , И Yellow если != аргументы.
        /// </summary>
        public static void SetControlBackColor(Control ctrl, string current, string expected)
        {
            Color clrSuccess = SystemColors.Window;
            Color clrFail = Color.Yellow;
            ctrl.BackColor = current == expected ? clrSuccess : clrFail;
        }
        /// <summary>  
        /// Задает Цвет clr если == , Красный если != аргументы.
        /// </summary>
        public static void SetControlBackColor(Control ctrl, string current, string expected, Color clrFail)
        { // Задает Цвет clrFail если != аргументы.
            if (current != expected)
            {
                ctrl.BackColor = clrFail;
            } // SystemColors.Window
        }
        /// <summary>
        /// Перебираем все контролы рекурсивно. Выполняем для каждого действие action
        /// </summary>
        public static void ForAllControls(Control parent, Action<Control> action)
        {
            foreach (Control c in parent.Controls)
            {
                action(c);
                ForAllControls(c, action);
            }
        }
        /// <summary>
        /// Снимает выделение по всем контролам в групбоксе
        /// </summary>
        public static void ClearSelection(Control control)
        {
            ForAllControls(control, x =>
            {
                if (!(x is ComboBox box)) return;
                box.SelectionLength = 0;
                box.Select(0, 0);
                box.BackColor = SystemColors.Window;
            });
        }
        public static void SetControlsColorDefault(Control control)
        {
            ForAllControls(control, x =>
            {
                if (x is ComboBox)
                {
                    (x as ComboBox).BackColor = SystemColors.Window;
                }
                if (x is TextBox)
                {
                    (x as TextBox).BackColor = SystemColors.Window;
                }
            });
        }

        // Часы. Подготовка строки 
        public static string ClockFormating()
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string time = "";
            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }

            time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }

            time += ":";

            if (s < 10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }

            return time;
        }
        public static string ClockFormating(int hour, int minute)
        {
            int h = hour;
            int m = minute;

            string time = "";
            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }

            time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }
            return time;
        }
        #endregion
    }
}
