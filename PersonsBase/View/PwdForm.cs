﻿using System;
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

        private Options _options;
        private static readonly string _correctPassword = "1234"; // FIXME Перенести пароль "1234" в Опции
        private static bool _unLocked;
        private static bool UnLocked
        {
            get { return _unLocked; }
            set
            {
                if (_unLocked == value) return;
                _unLocked = value;
                OnLockStateChanged();
            }
        }


        public PwdForm(Options opt)
        {
            InitializeComponent();
            _options = opt;
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

        private bool TryUnLockPassword()
        {
            if (textBox_pwd.Text == _correctPassword)
            {
                UnLocked = true;
                label1.ForeColor = Color.Black;
                label1.Text = @"Введите пароль Администратора";
                Close();
                return true;
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = @"Неправильный пароль";
                UnLocked = false;
                return false;
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
