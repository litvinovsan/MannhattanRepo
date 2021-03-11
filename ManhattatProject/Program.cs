using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using PersonsBase.View;

namespace ManhattatProject
{

    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hwnd, WinStyle style);

        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(string lpClassName, string lpWindowName);

        private enum WinStyle
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
                using (var mutex = new Mutex(true, "ManhattatProject"))
                {
                    if (mutex.WaitOne(10000, false))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm());
                    }
                    else
                    {
                        var wndHandle = FindWindowByCaption(null, "Manhattan Fitness Club");
                        ShowWindow(wndHandle, WinStyle.ShowNormal);  //выносим окно на передний план
                        SetForegroundWindow(wndHandle); //делаем окно активным
                    }
                }
            
           
        }
    }
}
