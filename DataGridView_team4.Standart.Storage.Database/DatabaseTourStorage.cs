using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using DataGridView_team4.Standart.Contracts;
using DataGridView_team4.Standart.Contracts.Models;

namespace DataGridView_team4.Standart.Storage.Database
{
    public class DatabaseTourStorage : ITripStorage
    {
        public async Task<Trip> AddTripAsync(Trip trip)
        {
            using (var context = new DataGridContext())
            {
                context.Trip.Add(trip);
                await context.SaveChangesAsync();
            }
            return trip;
        }

        public async Task<bool> DeleteTripAsync(Guid id)
        {
            using (var context = new DataGridContext())
            {
                var item = await context.Trip.FirstOrDefaultAsync(x => x.TripId == id);
                if (item != null)
                {
                    context.Trip.Remove(item);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public async Task EditTripAsync(Trip trip)
        {
            using (var context = new DataGridContext())
            {
                var target = await context.Trip.FirstOrDefaultAsync(x => x.TripId == trip.TripId);
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
                await context.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyCollection<Trip>> GetAllTripsAsync()
        {
            using (var context = new DataGridContext())
            {
                var item = await context.Trip
                    .OrderBy(x => x.Location)
                    .ThenByDescending(x => x.CostPerPerson)
                    .ToListAsync();

                return item;
            }
        }
    }
}
