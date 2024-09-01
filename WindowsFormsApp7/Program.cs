using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
   static class Program
   {
      /// <summary>
      /// Главная точка входа для приложения.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Form2 first = new Form2();
         DateTime end = DateTime.Now + TimeSpan.FromSeconds(5);
         first.Show();
         while (end > DateTime.Now)
            Application.DoEvents();
         first.Close();
         first.Dispose();
         Application.Run(new Form1());
      }
   }
}
