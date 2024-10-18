using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridView_team4.Contracts;

namespace DataGridView_team4.Memory.Storage
{
    /// <inheritdoc cref="ITourStorage" />
    public class MemoryStorage : ITourStorage
    {
        private List<Contracts.Models.Tours> tourList = new List<Contracts.Models.Tours>();

        /// <inheritdoc cref="ITourStorage.AddTourAsync(Contracts.Models.Tours)" />
        public Task<Contracts.Models.Tours> AddTourAsync(Contracts.Models.Tours tour)
        {
            tourList.Add(tour);
            return Task.FromResult(tour);
        }

        /// <inheritdoc cref="ITourStorage.DeleteTourAsync(Guid)" />
        public Task<bool> DeleteTourAsync(Guid id)
        {
            var tour = tourList.FirstOrDefault(x => x.Id == id);
            if (tour != null)
            {
                tourList.Remove(tour);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        /// <inheritdoc cref="ITourStorage.EditTourAsync(Contracts.Models.Tours)" />
        public Task EditTourAsync(Contracts.Models.Tours tour)
        {
            var target = tourList.FirstOrDefault(x => x.Id == tour.Id);
            if (target != null)
            {
                target.Destination = tour.Destination;
                target.DepartureDate = tour.DepartureDate;
                target.Nights = tour.Nights;
                target.PricePerPerson = tour.PricePerPerson;
                target.NumberOfPeople = tour.NumberOfPeople;
                target.HasWiFi = tour.HasWiFi;
                target.AdditionalFees = tour.AdditionalFees;
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ITourStorage.GetAllToursAsync()" />
        public Task<IReadOnlyCollection<Contracts.Models.Tours>> GetAllToursAsync()
            => Task.FromResult<IReadOnlyCollection<Contracts.Models.Tours>>(tourList);
    }
}
