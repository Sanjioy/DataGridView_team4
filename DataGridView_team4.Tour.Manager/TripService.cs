using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataGridView_team4.Contracts;
using DataGridView_team4.Tour.Manager.Models;

namespace DataGridView_team4.Tour.Manager
{
    /// <inheritdoc cref="ITripService />
    public class TripService : ITripService
    {
        private ITripStorage tripStorage;

        public TripService(ITripStorage tripStorage)
        {
            this.tripStorage = tripStorage;
        }

        /// <inheritdoc cref="ITripService.AddTripAsync(Contracts.Models.Trip)" />
        public async Task<Contracts.Models.Trip> AddTripAsync(Contracts.Models.Trip trip)
            => await tripStorage.AddTripAsync(trip);

        /// <inheritdoc cref="ITripService.AddTripAsync(Contracts.Models.Trip)" />
        public async Task<bool> DeleteTripAsync(Guid id)
            => await tripStorage.DeleteTripAsync(id);

        /// <inheritdoc cref="ITripService.EditTripAsync(Contracts.Models.Trip)" />
        public async Task EditTripAsync(Contracts.Models.Trip trip)
            => await tripStorage.EditTripAsync(trip);

        /// <inheritdoc cref="ITripService.GetAllTripsAsync()" />
        public async Task<IReadOnlyCollection<Contracts.Models.Trip>> GetAllTripsAsync()
            => await tripStorage.GetAllTripsAsync();

        /// <inheritdoc cref="ITripService.GetTripStatsAsync()" />
        public async Task<ITripStats> GetTripStatsAsync()
        {
            var allTrips = await tripStorage.GetAllTripsAsync();
            return new TripStats
            {
                TotalTrips = allTrips.Count,
                TotalRevenue = allTrips.Sum(t => (t.CostPerPerson * t.ParticipantCount * t.Nights + t.ExtraCharges)),
                TripsWithExtras = allTrips.Count(t => t.ExtraCharges > 0),
                TotalExtras = allTrips.Sum(t => t.ExtraCharges)
            };
        }
    }
}
