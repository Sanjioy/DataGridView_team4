namespace DataGridView_team4.Contracts
{
    /// <summary>
    /// Интерфейс, определяющий статистические данные по турам.
    /// Позволяет получить ключевые показатели для анализа туров.
    /// </summary>
    public interface ITripStats
    {
        /// <summary>
        /// Общее количество туров.
        /// </summary>
        int TotalTrips { get; }

        /// <summary>
        /// Общая сумма стоимости всех туров.
        /// </summary>
        decimal TotalRevenue { get; }

        /// <summary>
        /// Количество туров с дополнительными услугами.
        /// </summary>
        int TripsWithExtras { get; }

        /// <summary>
        /// Общая сумма дополнительных услуг по всем турам.
        /// </summary>
        decimal TotalExtras { get; }
    }
}
