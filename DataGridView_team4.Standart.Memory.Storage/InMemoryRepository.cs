using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataGridView_team4.Standart.Contracts;

namespace DataGridView_team4.Standart.Memory.Storage
{
    /// <inheritdoc cref="ITripStorage" />
    public class InMemoryRepository : ITripStorage
    {
        private List<Contracts.Models.Trip> tourList = new List<Contracts.Models.Trip>();

        /// <inheritdoc cref="ITripStorage.AddTripAsync(Contracts.Models.Trip)" />
        public Task<Contracts.Models.Trip> AddTripAsync(Contracts.Models.Trip trip)
        {
            tourList.Add(trip);
            return Task.FromResult(trip);
        }

        /// <inheritdoc cref="ITripStorage.DeleteTripAsync(Guid)" />
        public Task<bool> DeleteTripAsync(Guid id)
        {
            var trip = tourList.FirstOrDefault(x => x.TripId == id);
            if (trip != null)
            {
                tourList.Remove(trip);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        /// <inheritdoc cref="ITripStorage.EditTripAsync(Contracts.Models.Trip)" />
        public Task EditTripAsync(Contracts.Models.Trip trip)
        {
            var target = tourList.FirstOrDefault(x => x.TripId == trip.TripId);
            if (target != null)
            {
                target.Location = trip.Location;
                target.DepartureDate = trip.DepartureDate;
                target.Nights = trip.Nights;
                target.CostPerPerson = trip.CostPerPerson;
                target.ParticipantCount = trip.ParticipantCount;
                target.WiFiAvailable = trip.WiFiAvailable;
                target.ExtraCharges = trip.ExtraCharges;
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ITripStorage.GetAllTripsAsync()" />
        public Task<IReadOnlyCollection<Contracts.Models.Trip>> GetAllTripsAsync()
            => Task.FromResult<IReadOnlyCollection<Contracts.Models.Trip>>(tourList);
    }
}
