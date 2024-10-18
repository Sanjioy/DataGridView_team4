using System;
using System.Windows.Forms;
using DataGridView_team4.Memory.Storage;
using DataGridView_team4.Tour.Manager;

namespace DataGridView_team4
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var storage = new MemoryStorage();
            var manager = new TourManager(storage);

            Application.Run(new MainForm(manager));
        }
    }
}
