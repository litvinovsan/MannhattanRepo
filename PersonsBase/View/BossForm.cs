using PBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.View
{
    public partial class BossForm : Form
    {
        private Options _options;
        private DataBaseClass _dataBase;
        private ManhattanInfo _manhattanInfo;

        public BossForm()
        {
            InitializeComponent();
            _options = Options.GetInstance();
            _dataBase = DataBaseClass.GetInstance();
            _manhattanInfo = DataObjects.GetManhattanInfo();
        }
    }
}
