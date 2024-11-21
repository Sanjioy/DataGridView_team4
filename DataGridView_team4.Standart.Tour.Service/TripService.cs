using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using DataGridView_team4.Standart.Contracts;
using DataGridView_team4.Standart.Contracts.Models;
using DataGridView_team4.Standart.Tour.Service.Models;
using Microsoft.Extensions.Logging;

namespace DataGridView_team4.Standart.Tour.Manager
{
    /// <inheritdoc cref="ITripService />
    public class TripService : ITripService
    {
        private readonly ILogger logger;
        private const string StopwatchTemplate = "Операция {Operation} c id {Id} выполнялась {Milliseconds} мс";
        private const string StopwatchNon = "Операция {Operation} c id {Id}  НЕ выполнилась";
        private ITripStorage tripStorage;

        public TripService(ITripStorage tripStorage, ILogger logger)
        {
            this.tripStorage = tripStorage;
            this.logger = logger;
        }

        /// <inheritdoc cref="ITripService.AddTripAsync(Trip)" />
        public async Task<Trip> AddTripAsync(Trip trip)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Trip result = null;
            try
            {
                result = await tripStorage.AddTripAsync(trip);
                logger.LogInformation(StopwatchTemplate, nameof(ITripService.AddTripAsync), trip, stopWatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                logger.LogInformation(StopwatchNon, nameof(ITripService.AddTripAsync), trip);
            }
            stopWatch.Stop();
            return result;
        }

        /// <inheritdoc cref="ITripService.AddTripAsync(Trip)" />
        public async Task<bool> DeleteTripAsync(Guid id)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            bool result = false;
            try
            {
                result = await tripStorage.DeleteTripAsync(id);
                logger.LogInformation(StopwatchTemplate, nameof(ITripService.AddTripAsync), id, stopWatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                logger.LogInformation(StopwatchNon, nameof(ITripService.AddTripAsync), id);
            }
            stopWatch.Stop();
            return result;
        }



        /// <inheritdoc cref="ITripService.EditTripAsync(Trip)" />
        public async Task EditTripAsync(Trip trip)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                await tripStorage.EditTripAsync(trip);
                logger.LogInformation(StopwatchTemplate, nameof(ITripService.AddTripAsync), trip, stopWatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                logger.LogInformation(StopwatchNon, nameof(ITripService.AddTripAsync), trip);
            }
            stopWatch.Stop();
        }

        /// <inheritdoc cref="ITripService.GetAllTripsAsync()" />
        public async Task<IReadOnlyCollection<Trip>> GetAllTripsAsync()
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
