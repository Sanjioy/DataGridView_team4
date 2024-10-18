using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridView_team4.Contracts;
using DataGridView_team4.Tour.Manager.Models;

namespace DataGridView_team4.Tour.Manager
{
    /// <inheritdoc cref="ITourManager />
    public class TourManager : ITourManager
    {
        private ITourStorage tourStorage;

        public TourManager(ITourStorage tourStorage)
        {
            this.tourStorage = tourStorage;
        }

        /// <inheritdoc cref="ITourManager.AddTourAsync(Contracts.Models.Tours)" />
        public async Task<Contracts.Models.Tours> AddTourAsync(Contracts.Models.Tours tour)
            => await tourStorage.AddTourAsync(tour);

        /// <inheritdoc cref="ITourManager.AddTourAsync(Contracts.Models.Tours)" />
        public async Task<bool> DeleteTourAsync(Guid id)
            => await tourStorage.DeleteTourAsync(id);

        /// <inheritdoc cref="ITourManager.EditTourAsync(Contracts.Models.Tours)" />
        public async Task EditTourAsync(Contracts.Models.Tours tour)
            => await tourStorage.EditTourAsync(tour);

        /// <inheritdoc cref="ITourManager.GetAllToursAsync()" />
        public async Task<IReadOnlyCollection<Contracts.Models.Tours>> GetAllToursAsync()
            => await tourStorage.GetAllToursAsync();

        /// <inheritdoc cref="ITourManager.GetStatsAsync()" />
        public async Task<ITourStats> GetStatsAsync()
        {
            var result = await tourStorage.GetAllToursAsync();
            return new TourStats
            {
                TotalCountTours = result.Count,
                TotalSumTours = result.Sum(t => (t.PricePerPerson * t.NumberOfPeople * t.Nights + t.AdditionalFees)),
                CountToursWithDop = result.Count(t => t.AdditionalFees > 0),
                TotalSumDop = result.Sum(t => t.AdditionalFees)
            };
        }
    }
}
