using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace PBase
{
    public class MyListView
    {
        public static void AddColumns(ListView listView, string[] columns)
        {
            ColumnHeader columnHeader = new ColumnHeader();
            foreach (var item in columns)
            {
                columnHeader.Text = item;
                listView.Columns.Add(columnHeader);
            }
            // 
            listView.Columns[listView.Columns.Count - 1].Width = -2;
        }

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
        /// <param name="listView"></param>
        /// <returns></returns>
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

        public static void AddTextToList(ListView listViewIn, ListViewGroup toGroup, string message, bool showTime)
        {
            //listViewIn.Items.Add(new ListViewItem(message, toGroup));
            if (!listViewIn.Groups.Contains(toGroup))
                AddGroup(listViewIn, toGroup.Header);

            listViewIn.Items.Add(new NameItem(message, toGroup, showTime));

            listViewIn.Update();
        }
        public static void AddTextToList(ListView listViewIn, string newGroupName, string message, bool showTime)
        {
            var groups = GetGroupsDict(listViewIn);
            if (!groups.Keys.Contains(newGroupName))
            {
                AddGroup(listViewIn, newGroupName);
            }
            listViewIn.Items.Add(new NameItem(message, GetGroupsDict(listViewIn)[newGroupName], showTime));

            listViewIn.Update();
        }
        public static void AddTextToList(ListView listViewIn, string message, bool showTime)
        {
            listViewIn.Items.Add(new NameItem(message, showTime));
            listViewIn.Update();
        }

        /// <summary>
        /// Задает Полосатый текст в Листе
        /// </summary>
        /// <param name="listView"></param>
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

        class NameItem : ListViewItem
        {
            // Доступные варианты строки
            // Время  |  Имя Клиента
            //        |  Имя Клиента
            private DateTime _dateTime;
            private string _message;

            public NameItem(string name)
            {
                _dateTime = DateTime.Now;
                _message = name;

                Text = _dateTime.ToString("HH:mm");
                // SubItems.Add(messageType.ToString());
                SubItems.Add(name);
            }
            public NameItem(string name, ListViewGroup group, bool showTime)
            {
                _dateTime = DateTime.Now;
                _message = name;
                Text = (showTime) ? _dateTime.ToString("HH:mm") : "";
                if (group != null) Group = group;

                SubItems.Add(name);
            }
            public NameItem(string name, bool showTime)
            {
                _dateTime = DateTime.Now;
                _message = name;
                Text = (showTime) ? _dateTime.ToString("HH:mm") : "";

                SubItems.Add(name);
            }
        }

        /// Для автоматического изменения размера последней колонки. Подписаться на событие 
        public static void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }
        public static void ListView_Resize_Event1(object sender, EventArgs e)
        {
            SizeLastColumn((ListView)sender);
        }
    }

}

