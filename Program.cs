using System;
using System.Windows.Forms;
using DataGridView_team4.Standart.Storage.Database;
using DataGridView_team4.Standart.Tour.Manager;
using Serilog;
using Serilog.Extensions.Logging;

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
            var serilogLogger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Seq("http://localhost:5341/", apiKey: "jpeBjemf6H0uJ7diYcUs")
                .CreateLogger();

            var logger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger("datagrid");
            var repository = new DatabaseTourStorage();
            var tripManager = new TripService(repository, logger);
            Application.Run(new MainForm(tripManager));
        }
    }
}
