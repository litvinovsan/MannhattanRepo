using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinListTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          //  SizeLastColumn(listView1);
        }

        // List view
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.ShowGroups = true;
            MyListView.AddTextToList(listView1, "Test", true);
            MyListView.AddTextToList(listView1, "Test2", false);
            MyListView.AddTextToList(listView1, "Test3", true);


            MyListView.AddGroup(listView1, "Group 1");
            MyListView.AddGroup(listView1, "Group 2");
            MyListView.AddGroup(listView1, "Group 3");
            var grps = MyListView.GetGroupsDict(listView1);

            MyListView.AddTextToList(listView1, grps["Group 1"], "Проверка Группы1", true);
            MyListView.AddTextToList(listView1, grps["Group 1"], "Проверка Группы1", false);

            MyListView.AddTextToList(listView1, grps["Group 2"], "Проверка Группы2", true);
            MyListView.AddTextToList(listView1, grps["Group 2"], "Проверка Группы2", true);
            MyListView.AddTextToList(listView1, grps["Group 2"], "Проверка Группы2", true);

            MyListView.AddTextToList(listView1, grps["Group 3"], "Проверка Группы3", true);
            MyListView.AddTextToList(listView1, grps["Group 3"], "Проверка Группы3", true);
            MyListView.AddTextToList(listView1, grps["Group 3"], "Проверка Группы3", false);
            MyListView.AddTextToList(listView1, grps["Group 3"], "Проверка Группы3", true);





            var k = grps.Keys;

            

            //listView1.Items.Add(new ListViewItem(new string[] { "cccc", "cccc", "cccc" }));
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.ShowGroups = true;


        }


 

    }
}
