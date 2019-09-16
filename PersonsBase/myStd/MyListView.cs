﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.ListViewItem;

namespace PBase
{
    public class MyListViewEx
    {
        #region /// ОБЩИЕ МЕТОДЫ ДЛЯ LIST VIEW /// 

        // Колонки
        public static void AddColumns(ListView listView, string[] columns)
        {
            ColumnHeader columnHeader = new ColumnHeader();
            foreach (var item in columns)
            {
                columnHeader.Text = item;
                listView.Columns.Add(columnHeader);
            }

            // Подгоняем размер последней колонки по ширине
            listView.Columns[listView.Columns.Count - 1].Width = -2;
        }

        // Группы
        public static void AddGroups(ListView listView, string[] groups)
        {
            listView.ShowGroups = true;
            ListViewGroup listViewGroup = new ListViewGroup();
            foreach (var item in groups)
            {
                listViewGroup.Header = item;
                listViewGroup.HeaderAlignment = HorizontalAlignment.Left;
                listView.Groups.Add(listViewGroup);
            }
        }
        public static void AddGroup(ListView listView, string group)
        {
            ListViewGroup listViewGroup = new ListViewGroup(group, HorizontalAlignment.Left);
            listView.Groups.Add(listViewGroup);
        }
        /// <summary>
        /// Возвращает коллекцию: ЗаголовокГруппы - Ссылка на группу
        /// </summary>
        public static Dictionary<string, ListViewGroup> GetGroupsDict(ListView listView)
        {
            Dictionary<string, ListViewGroup> groupsDict = new Dictionary<string, ListViewGroup>();

            for (int i = 0; i < listView.Groups.Count; i++)
            {
                try
                {
                    groupsDict.Add(listView.Groups[i].Header, listView.Groups[i]);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    throw new ArgumentException(e.Message, listView.Groups[i].Header);
                }
            }

            return groupsDict;
        }

        // Работа со списком
        /// <summary>
        /// Добавляет Текст в список с одной колонкой
        /// </summary>
        /// <param name="listViewIn"></param>
        /// <param name="message"></param>
        public static void AddNote(ListView listViewIn, string message)
        {
            listViewIn.Items.Add(new ListViewItem(message));
            listViewIn.Update();
        }
        public static void AddNote(ListView listViewIn, string messageColumn1, string messageColumn2)
        {
            ListViewItem item = new ListViewItem();
            item.Text = messageColumn1;
            item.SubItems.Add(messageColumn2);

            listViewIn.Items.Add(item);
            listViewIn.Update();
        }
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
            bool check = (lv.SelectedItems.Count > 0);
            selected = check ? lv.SelectedItems : null;

            return check;
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
        public static void ListView_Resize_Event1(object sender, EventArgs e)
        {
            MaximizeLastColumn((ListView)sender);
        }

        /// <summary>
        /// Массив содержит текст выбранной строки. Первый элемент это 1ая колонка. Итд..
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public static string[] GetSelectedText(ListView lv)
        {
            string[] result = null;
            if (lv.SelectedItems.Count != 0)
            {
                List<string> temp = new List<string>();
                foreach (ListViewSubItem item in lv.SelectedItems[0].SubItems)
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
            bool result = false;
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
            for (int i = 0; i <= listView.Items.Count - 1; i++)
            {
                if (listView.Items[i].Index % 2 == 0)
                    listView.Items[i].BackColor = Color.White;
                else
                    listView.Items[i].BackColor = Color.LightGray;
            }
        }
        #endregion

        #region /// ДОБАВЛЕНИЕ ИМЕНИ И ВРЕМЕНИ В КОЛОНКИ LIST VIEW на главной форме /// 

        public static void AddNameTime(ListView listViewIn, ListViewGroup toGroup, string personName, bool showTime)
        {
            if (!listViewIn.Groups.Contains(toGroup))
                AddGroup(listViewIn, toGroup.Header);

            listViewIn.Items.Add(new NameTimeItem(personName, toGroup, showTime));

            listViewIn.Update();
        }
        public static void AddNameTime(ListView listViewIn, string newGroupName, string personName, bool showTime)
        {
            var groups = GetGroupsDict(listViewIn);
            if (!groups.Keys.Contains(newGroupName))
            {
                AddGroup(listViewIn, newGroupName);
            }
            listViewIn.Items.Add(new NameTimeItem(personName, GetGroupsDict(listViewIn)[newGroupName], showTime));

            listViewIn.Update();
        }
        public static void AddNameTime(ListView listViewIn, string personName, bool showTime)
        {
            listViewIn.Items.Add(new NameTimeItem(personName, showTime));
            listViewIn.Update();
        }
        #endregion

        #region /// ДОБАВЛЕНИЕ Времени И Названия тренировки В КОЛОНКИ LIST VIEW /// 

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
    }

    // Вспомогательный класс для добавления Имени и текущего времени в ЛВ
    public class NameTimeItem : ListViewItem
    {
        // Доступные варианты строки
        // Время  |  Имя Клиента
        //        |  Имя Клиента
        private string _message;

        public NameTimeItem(string name)
        {
            var dateTime = DateTime.Now;
            _message = name;

            Text = dateTime.ToString("HH:mm");
            // SubItems.Add(messageType.ToString());
            SubItems.Add(name);
        }
        public NameTimeItem(string name, ListViewGroup group, bool showTime)
        {
            var dateTime = DateTime.Now;
            _message = name;
            Text = (showTime) ? dateTime.ToString("HH:mm") : "";
            if (group != null) Group = group;

            SubItems.Add(name);
        }
        public NameTimeItem(string name, bool showTime)
        {
            var dateTime = DateTime.Now;
            _message = name;
            Text = (showTime) ? dateTime.ToString("HH:mm") : "";

            SubItems.Add(name);
        }
    }

    // Вспомогательный класс для добавления в ЛВ заметок о Времени и Названии групповой тренировки
   public class ScheduleNoteItem : ListViewItem
    {
        // Врема начала и название тренировки
        public ScheduleNoteItem(ScheduleNote note)
        {
            Text = note.Time.HourMinuteTime;
            SubItems.Add(note.WorkoutsName);
        }
    }
}
