using System;
using System.Windows.Forms;
using DataGridView_team4.Standart.Memory.Storage;
using DataGridView_team4.Standart.Tour.Manager;
using Microsoft.Extensions.Logging;

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
            var factory = LoggerFactory.Create(buelder => buelder.AddDebug());
            var logger = factory.CreateLogger(nameof(DataGrid));
            var repository = new InMemoryRepository();
            var tripManager = new TripService(repository, logger);
            Application.Run(new MainForm(tripManager));
        }
    }
}
