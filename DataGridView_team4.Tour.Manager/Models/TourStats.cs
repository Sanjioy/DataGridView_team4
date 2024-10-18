using DataGridView_team4.Contracts;

namespace DataGridView_team4.Tour.Manager.Models
{
    /// <inheritdoc cref="ITourStats"/>
    public class TourStats : ITourStats
    {
        /// <inheritdoc cref="ITourStats.TotalCountTours"/>
        public int TotalCountTours { get; set; }

        /// <inheritdoc cref="ITourStats.TotalSumTours"/>
        public decimal TotalSumTours { get; set; }

        /// <inheritdoc cref="ITourStats.CountToursWithDop"/>
        public int CountToursWithDop { get; set; }

        /// <inheritdoc cref="ITourStats.TotalSumDop"/>
        public decimal TotalSumDop { get; set; }
    }
}
