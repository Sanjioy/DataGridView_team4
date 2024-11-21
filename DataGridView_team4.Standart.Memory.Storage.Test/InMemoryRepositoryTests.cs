using System;
using System.Linq;
using System.Threading.Tasks;
using DataGridView_team4.Standart.Contracts;
using DataGridView_team4.Standart.Contracts.Models;
using DataGridView_team4.Standart.Memory.Storage;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace DataGridView_team4.Standart.Tour.Service.Test
{
    [TestClass]
    public class TripServiceTests
    {
        private readonly ITripStorage tripStorage;
        public TripServiceTests()
        {
            tripStorage = new InMemoryRepository();
        }
        /// <summary>
        /// При отправке пустого списка нет ошибок <see cref="ITripStorage.GetAllTripsAsync"/>
        /// </summary>
        [Fact]
        public async Task GetAllShouldNotThrow()
        {
            // Act
            Func<Task> act = () => tripStorage.GetAllTripsAsync();

            // Assert
            await act.Should().NotThrowAsync();
        }

        /// <summary>
        /// Получает пустой список <see cref="ITripStorage.GetAllTripsAsync"/>
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Act
            var result = await tripStorage.GetAllTripsAsync();

            // Assert
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }

        /// <summary>
        /// Проверка работы метода <see cref="ITripStorage.AddTripAsync(Trip)"/>
        /// </summary>
        [Fact]
        public async Task AddShouldReturnValue()
        {
            // Arrange
            var trip = new Trip
            {
                TripId = Guid.NewGuid(),
                Location = Location.USA,
                DepartureDate = DateTime.Now.AddDays(7),
                Nights = 7,
                CostPerPerson = 200,
                ParticipantCount = 2,
                WiFiAvailable = true,
                ExtraCharges = 300
            };

            // Act
            var result = await tripStorage.AddTripAsync(trip);

            // Assert
            result.Should().NotBeNull()
                .And.BeEquivalentTo(new
                {
                    trip.TripId,
                });
        }
        /// <summary>
        /// Проверка работы метода <see cref="ITripStorage.DeleteTripAsync(Guid)"/>
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            // Arrange
            var trip = new Trip
            {
                TripId = Guid.NewGuid(),
                Location = Location.USA,
                DepartureDate = DateTime.Now.AddDays(7),
                Nights = 7,
                CostPerPerson = 200,
                ParticipantCount = 2,
                WiFiAvailable = true,
                ExtraCharges = 300
            };

            await tripStorage.AddTripAsync(trip);

            // Act
            var resultTrue = await tripStorage.DeleteTripAsync(trip.TripId);
            var resultFalse = await tripStorage.DeleteTripAsync(Guid.NewGuid());


            // Assert
            resultTrue.Should().BeTrue();
            resultFalse.Should().BeFalse();
        }

        /// <summary>
        /// Проверка работы метода <see cref="ITripStorage.EditTripAsync(Trip)"/>
        /// </summary>
        [Fact]
        public async Task EditShouldWork()
        {
            var expectedDate = DateTime.Now.AddDays(7).Date;
            // Arrange
            var trip = new Trip
            {
                TripId = Guid.NewGuid(),
                Location = Location.USA,
                DepartureDate = DateTime.Now.AddDays(7),
                Nights = 7,
                CostPerPerson = 200,
                ParticipantCount = 2,
                WiFiAvailable = true,
                ExtraCharges = 300
            };

            await tripStorage.AddTripAsync(trip);

            var updatedTrip = new Trip
            {
                TripId = trip.TripId,
                Location = Location.USA,
                DepartureDate = expectedDate,
                Nights = 52,
                CostPerPerson = 100,
                ParticipantCount = 2,
                WiFiAvailable = true,
                ExtraCharges = 300
            };


            // Act
            await tripStorage.EditTripAsync(updatedTrip);
            var trips = await tripStorage.GetAllTripsAsync();
            var editedTrip = trips.FirstOrDefault(c => c.TripId == updatedTrip.TripId);

            // Assert
            editedTrip.Should().NotBeNull();
            editedTrip.Location.Should().Be(Location.USA);
            editedTrip.DepartureDate.Should().Be(expectedDate);
            editedTrip.Nights.Should().Be(52);
            editedTrip.CostPerPerson.Should().Be(100);
            editedTrip.ParticipantCount.Should().Be(2);
            editedTrip.WiFiAvailable.Should().Be(true);
            editedTrip.ExtraCharges.Should().Be(300);
        }
    }
}
