using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGridView_team4.Standart.Contracts;
using DataGridView_team4.Standart.Contracts.Models;
using DataGridView_team4.Standart.Tour.Manager;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace DataGridView_team4.Standart.Tour.Service.Test
{
    [TestClass]
    public class TripServiceTests
    {
        private readonly ITripService tripManager;
        private readonly Mock<ITripStorage> tripStorageMock;
        private readonly Mock<ILogger> loggerMock;

        private readonly Task<IReadOnlyCollection<Trip>> filledDefaultCarlList;

        /// <summary>
        /// Конструктор <see cref="TripServiceTests"/>
        /// </summary>
        public TripServiceTests()
        {
            tripStorageMock = new Mock<ITripStorage>();
            loggerMock = new Mock<ILogger>();


            loggerMock.Setup(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));
            tripManager = new TripService(tripStorageMock.Object, loggerMock.Object);
        }

        /// <summary>
        /// Проверка добавления <see cref="Trip"/>
        /// </summary>
        [Fact]
        public async Task AddShouldWork()
        {
            //Arrange
            var model = new Trip
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
            tripStorageMock.Setup(x => x.AddTripAsync(It.IsAny<Trip>()))
                .ReturnsAsync(new Trip { TripId = model.TripId });

            //Act
            var result = await tripManager.AddTripAsync(model);

            //Assert
            result.Should().NotBeNull().And.BeEquivalentTo(new
            {
                TripId = model.TripId,
            });

            loggerMock.Verify(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ), Times.Once);

            tripStorageMock.Verify(x => x.AddTripAsync(It.Is<Trip>(y => y.TripId == model.TripId)), Times.Once);

            tripStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка удаления <see cref="Trip"/>
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            //Arrange
            var tripId = Guid.NewGuid();
            var nonExistentTripId = Guid.NewGuid();

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
            tripStorageMock.Setup(x => x.DeleteTripAsync(tripId))
                .ReturnsAsync(true);

            tripStorageMock.Setup(x => x.DeleteTripAsync(nonExistentTripId))
                .ReturnsAsync(false);

            //Act
            var result = await tripManager.DeleteTripAsync(tripId);
            var resultFalse = await tripManager.DeleteTripAsync(nonExistentTripId);


            //Assert
            result.Should().BeTrue();
            resultFalse.Should().BeFalse();

            loggerMock.Verify(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ), Times.Exactly(2));

            tripStorageMock.Verify(x => x.DeleteTripAsync(tripId), Times.Once);
            tripStorageMock.Verify(x => x.DeleteTripAsync(nonExistentTripId), Times.Once);

            tripStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка изменения <see cref="Trip"/>
        /// </summary>
        [Fact]
        public async Task EditShouldWork()
        {
            //Arrange
            var model = new Trip
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
            tripStorageMock.Setup(x => x.EditTripAsync(It.IsAny<Trip>()))
                .Returns(Task.CompletedTask);


            //Act
            await tripManager.EditTripAsync(model);

            //Assert
            loggerMock.Verify(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ), Times.Once);

            tripStorageMock.Verify(x => x.EditTripAsync(It.Is<Trip>(y => y.TripId == model.TripId)), Times.Once);

            tripStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка записи <see cref="Trip"/>
        /// </summary>
        [Fact]
        public async Task GetAllAsyncShouldReturnTrip()
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

            var tripList = Task.FromResult<IReadOnlyCollection<Trip>>(
                new List<Trip>
                {
                    trip,
                }
                );

            tripStorageMock.Setup(x => x.GetAllTripsAsync())
                .Returns(tripList);


            //Act
            var result = await tripManager.GetAllTripsAsync();

            //Assert
            result.Count.Should().Be(1);

            tripStorageMock.Verify(x => x.GetAllTripsAsync(), Times.Once);

            tripStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка получения пустоты
        /// </summary>
        [Fact]
        public async Task GetAllAsyncShouldReturnEmpty()
        {
            // Arrange
            tripStorageMock.Setup(x => x.GetAllTripsAsync());

            // Act
            var result = await tripManager.GetAllTripsAsync();

            // Assert
            result.Should().BeNull();

            tripStorageMock.Verify(x => x.GetAllTripsAsync(), Times.Once);
            tripStorageMock.VerifyNoOtherCalls();

            loggerMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Получить поля которые вычисляются
        /// </summary>
        [Fact]
        public async Task GetStatusAsyncTrip()
        {
            // Arrange
            var model = new Trip
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

            var carList = Task.FromResult<IReadOnlyCollection<Trip>>(
                new List<Trip>
                {
                    model,
                }
            );

            tripStorageMock.Setup(x => x.GetAllTripsAsync())
                .Returns(carList);

            // Act
            var result = await tripManager.GetTripStatsAsync();

            // Assert
            result.Should().BeEquivalentTo(new
            {
                TotalTrips = 1,
                TotalRevenue = 3100M,
                TripsWithExtras = 1,
                TotalExtras = 300M
            });

            tripStorageMock.Verify(x => x.GetAllTripsAsync(), Times.Once);
            tripStorageMock.VerifyNoOtherCalls();

            loggerMock.VerifyNoOtherCalls();

        }
    }
}
