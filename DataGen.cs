using System;
using DataGridView_team4.Contracts.Models;

namespace DataGridView_team4
{
    /// <summary>
    /// Генерация данных о поездках
    /// </summary>
    public static class DataGen
    {
        public static Trip CreateTrip(Action<Trip> customizeTrip = null)
        {
            // Создаем поездку с заранее заданными значениями
            var newTrip = new Trip
            {
                TripId = Guid.NewGuid(),
                Location = Location.USA,
                DepartureDate = DateTime.Now.AddDays(7),  // Отправление через 7 дней
                Nights = 7,
                CostPerPerson = 200,
                ParticipantCount = 2,
                WiFiAvailable = true,
                ExtraCharges = 300
            };

            // Если передана кастомная логика, применить
            customizeTrip?.Invoke(newTrip);

            return newTrip;
        }
    }
}
