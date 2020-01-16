using System;
using System.Threading;
using System.Windows.Forms;
using PersonsBase.View;

namespace ManhattatProject
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         bool oneonly;
         var mutex = new Mutex(true, "ManhattatProject", out oneonly);

         if (oneonly)
         {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
         }
         else
         {
            MessageBox.Show(@"Это приложение уже запущено");
         }
      }
   }
}
