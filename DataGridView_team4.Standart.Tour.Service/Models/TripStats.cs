using DataGridView_team4.Standart.Contracts;

namespace DataGridView_team4.Standart.Tour.Service.Models
{
    /// <inheritdoc cref="ITripStats"/>
    public class TripStats : ITripStats
    {
        /// <inheritdoc cref="ITripStats.TotalTrips"/>
        public int TotalTrips { get; set; }

        /// <inheritdoc cref="ITripStats.TotalRevenue"/>
        public decimal TotalRevenue { get; set; }

        /// <inheritdoc cref="ITripStats.TripsWithExtras"/>
        public int TripsWithExtras { get; set; }

        /// <inheritdoc cref="ITripStats.TotalExtras"/>
        public decimal TotalExtras { get; set; }
    }
}
