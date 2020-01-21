using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.data;

namespace PersonsBase.myStd
{
    public static class MyListViewEx
    {
        #region /// ОБЩИЕ МЕТОДЫ ДЛЯ LIST VIEW /// 

        // Колонки
        public static void AddColumns(ListView listView, string[] columns)
        {
            var columnHeader = new ColumnHeader();
            foreach (var item in columns)
            {
                columnHeader.Text = item;
                listView.Columns.Add(columnHeader);
            }

            // Подгоняем размер последней колонки по ширине
            listView.Columns[listView.Columns.Count - 1].Width = -2;
        }

        // Группы

        private static void AddGroup(ref ListView listView, string group)
        {
            var listViewGroup = new ListViewGroup(group, HorizontalAlignment.Left);
            listView.Groups.Add(listViewGroup);
        }
        /// <summary>
        /// Возвращает коллекцию: ЗаголовокГруппы - Ссылка на группу
        /// </summary>
        private static Dictionary<string, ListViewGroup> GetGroupsDict(ListView listView)
        {
            var groupsDict = new Dictionary<string, ListViewGroup>();

            for (var i = 0; i < listView.Groups.Count; i++)
            {
                try
                {
                    groupsDict.Add(listView.Groups[i].Header, listView.Groups[i]);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return groupsDict;
        }

        // Работа со списком
        /// <summary>
        /// Добавляет Текст в список с одной колонкой
        /// </summary>
        public static void AddNote(ListView listViewIn, string message)
        {
            listViewIn.Items.Add(new ListViewItem(message));
            listViewIn.Update();
        }
        /// <summary>
        /// Добавляет Текст в список с 2 колонками. Колонки должны быть настроены и должны существовать
        /// </summary>
        public static void AddNote(ListView listViewIn, string messageColumn1, string messageColumn2)
        {
            var item = new ListViewItem { Text = messageColumn1 };
            item.SubItems.Add(messageColumn2);
            listViewIn.Items.Add(item);
            listViewIn.Update();
            EnsureVisible(listViewIn);
        }
        /// <summary>
        /// Заполняет простой  ЛистВью с одной колонкой из коллекции List
        /// </summary>
        public static void AddNotes(ListView listViewIn, List<string> notes)
        {
            if (notes == null || notes.Count == 0) return;

            foreach (var item in notes)
            {
                listViewIn.Items.Add(item);
            }
            listViewIn.Update();
        }

        public static bool GetSelectedItems(ListView lv, ref ListView.SelectedListViewItemCollection selected)
        {
            if (selected == null) throw new ArgumentNullException(nameof(selected));
            var check = (lv.SelectedItems.Count > 0);
            selected = check ? lv.SelectedItems : null;

            return check;
        }

        /// <summary>
        /// Массив содержит текст выбранной строки. Первый элемент это 1ая колонка. Итд..
        /// </summary>
        public static string[] GetSelectedText(ListView lv)
        {
            string[] result = null;
            if (lv.SelectedItems.Count != 0)
            {
                var temp = new List<string>();
                foreach (ListViewItem.ListViewSubItem item in lv.SelectedItems[0].SubItems)
                {
                    temp.Add(item.Text);
                }
                result = temp.ToArray<string>();
            }

            return result;
        }

        /// <summary>
        /// Удаляет выбранный элемент из списка Лист Вью. Автоматическое обновление
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public static bool RemoveSelectedItem(ListView lv)
        {
            var result = false;
            if (lv.SelectedItems.Count > 0)
            {
                var listViewitem = lv.SelectedItems[0];
                lv.Items.Remove(listViewitem);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Задает Полосатый текст в Листе
        /// </summary>
        public static void AlternateColors(ListView listView)
        {
            for (var i = 0; i <= listView.Items.Count - 1; i++)
            {
                listView.Items[i].BackColor = listView.Items[i].Index % 2 == 0 ? Color.White : Color.LightGray;
            }
        }

        private static void EnsureVisible(ListView listView)
        {
            listView?.Items[listView.Items.Count - 1]?.EnsureVisible();
        }

        /// Для автоматического Увеличения размера последней колонки. Подписаться на событие изменения размера формы
        public static void MaximizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }
        public static void MaximizeFirstColumn(ListView lv)
        {
            lv.Columns[0].Width = -2;
        }
        // Пример
        //public static void ListView_Resize_Event1(object sender, EventArgs e)
        //{
        //    MaximizeLastColumn((ListView)sender);
        //}

        #endregion

        #region ///  BOSS Form ///

        public static void AddScheduleNote(ListView listViewIn, ScheduleNote scheduleNote)
        {
            listViewIn.Items.Add(new ScheduleNoteItem(scheduleNote));
            listViewIn.Update();
        }

        public static void AddScheduleNotes(ListView listViewIn, List<ScheduleNote> notes)
        {
            if (notes == null || notes.Count == 0) return;

            foreach (var item in notes)
            {
                listViewIn.Items.Add(new ScheduleNoteItem(item));
            }
            listViewIn.Update();
        }

        #endregion

        public static void AddItemAndGroup(ListView listViewIn, string newGroupName, string text, bool showTime)
        {
            var groups = GetGroupsDict(listViewIn);
            if (!groups.Keys.Contains(newGroupName))
            {
                AddGroup(ref listViewIn, newGroupName);
                groups = GetGroupsDict(listViewIn);
            }

            listViewIn.Items.Add(new NameTimeItem(text, groups[newGroupName], showTime));
            listViewIn.Update();
            EnsureVisible(listViewIn);

        }
    }

    // Вспомогательный класс для добавления Имени и текущего времени в ЛВ
    [Serializable]
    public class NameTimeItem : ListViewItem
    {
        // Доступные варианты строки
        // Время  |  Имя Клиента
        //        |  Имя Клиента

        public NameTimeItem(string name, ListViewGroup group, bool showTime)
        {
            var dateTime = DateTime.Now;
            Text = (showTime) ? dateTime.ToString("HH:mm") : "";
            if (group != null) Group = group;

            SubItems.Add(name);
        }
    }

    #region /// BOSS Form ///
    // Вспомогательный класс для добавления в ЛВ заметок о Времени и Названии групповой тренировки
    [Serializable]
    public class ScheduleNoteItem : ListViewItem
    {
        // Врема начала и название тренировки
        public ScheduleNoteItem(ScheduleNote note)
        {
            Text = note.Time.HourMinuteTime;
            SubItems.Add(note.WorkoutsName);
        }
    }
    #endregion

}

