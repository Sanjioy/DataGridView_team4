using System;
using System.Windows.Forms;
using DataGridView_team4.Standart.Memory.Storage;
using DataGridView_team4.Standart.Tour.Manager;

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
            SetupApplication();
            RunApplication();
        }

        /// <summary>
        /// Настройка приложения
        /// </summary>
        private static void SetupApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        /// <summary>
        /// Запуск основного окна приложения
        /// </summary>
        private static void RunApplication()
        {
            var repository = new InMemoryRepository();
            var tripManager = new TripService(repository);
            Application.Run(new MainForm(tripManager));
        }
    }
}
