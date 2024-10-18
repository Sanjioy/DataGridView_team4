using System;
using DataGridView_team4.Contracts.Models;

namespace DataGridView_team4
{
    /// <summary>
    /// Генерация данных о поездках
    /// </summary>
    public static class DataGen
    {
        /// <summary>
        /// Создать поездку с возможностью кастомизации
        /// </summary>
        public static Trip CreateTrip(Action<Trip> customizeTrip = null)
        {
            var newTrip = InitializeDefaultTrip();
            ApplyCustomizations(newTrip, customizeTrip);
            return newTrip;
        }

        /// <summary>
        /// Инициализация поездки с дефолтными значениями
        /// </summary>
        private static Trip InitializeDefaultTrip()
        {
            return new Trip
            {
                TripId = Guid.NewGuid(),
                Location = Location.USA,
                DepartureDate = DateTime.Now.AddDays(7), // Отправление через 7 дней
                Nights = 7,
                CostPerPerson = 200,
                ParticipantCount = 2,
                WiFiAvailable = true,
                ExtraCharges = 300
            };
        }

        /// <summary>
        /// Применение кастомных настроек поездки
        /// </summary>
        private static void ApplyCustomizations(Trip trip, Action<Trip> customizeTrip)
        {
            customizeTrip?.Invoke(trip);
        }
    }
}
