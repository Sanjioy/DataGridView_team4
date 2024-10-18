using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView_team4.Contracts
{
    /// <summary>
    /// Интерфейс, определяющий статистические данные по турам.
    /// Позволяет получить ключевые показатели для анализа туров.
    /// </summary>
    public interface ITourStats
    {
        /// <summary>
        /// Общее количество туров.
        /// </summary>
        int TotalCountTours { get; }

        /// <summary>
        /// Общая сумма стоимости всех туров.
        /// </summary>
        decimal TotalSumTours { get; }

        /// <summary>
        /// Количество туров с дополнительными услугами.
        /// </summary>
        int CountToursWithDop { get; }

        /// <summary>
        /// Общая сумма дополнительных услуг по всем турам.
        /// </summary>
        decimal TotalSumDop { get; }
    }
}
