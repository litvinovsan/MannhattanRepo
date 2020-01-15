using System;
using System.Drawing;
using System.Windows.Forms;
using PersonsBase.data;

namespace PersonsBase.View
{
    public partial class PwdForm : Form
    {
        // Событие ИЗМЕНЕНИЕ Состояния блокировки
        public delegate void LockChangedDelegate();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        public static event LockChangedDelegate LockChangedEvent;
        private static void OnLockStateChanged()
        {
            var tmp = LockChangedEvent;
            tmp?.Invoke();
        }

        private static bool _unLocked;

        private static bool UnLocked
        {
            set
            {
                if (_unLocked == value) return;
                _unLocked = value;
                OnLockStateChanged();
            }
        }

        public PwdForm()
        {
            InitializeComponent();
        }
        public static bool IsPassUnLocked()
        {
            return _unLocked;
        }
        /// <summary>
        /// Запрещает доступ босса без ввода пароля
        /// </summary>
        public static void LockPassword()
        {
            UnLocked = false;
        }

        private void PwdForm_Load(object sender, EventArgs e)
        {
            SelectNextControl(textBox_pwd, false, true, true, false);
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            TryUnLockPassword();
        }

        private void TryUnLockPassword()
        {
            if (textBox_pwd.Text == Options.CorrectPassword)
            {
                UnLocked = true;
                label1.ForeColor = Color.Black;
                label1.Text = @"Введите пароль Администратора";
                Close();
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = @"Неправильный пароль";
                UnLocked = false;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) // Если нажат Enter
            {
                TryUnLockPassword();
            }
        }
    }
}
