using System;
using DataGridView_team4.Contracts.Models;

namespace DataGridView_team4
{
    /// <summary>
    /// Генерация данных о турах
    /// </summary>
    public static class DataGen
    {
        public static Tours CreateTour(Action<Tours> customizeTour = null)
        {
            // Создаем тур с заранее заданными значениями
            var newTour = new Tours
            {
                Id = Guid.NewGuid(),
                Destination = Destination.USA,
                DepartureDate = DateTime.Now.AddDays(7),  // Выезд через 7 дней
                Nights = 7,
                PricePerPerson = 200,
                NumberOfPeople = 2,
                HasWiFi = true,
                AdditionalFees = 300
            };

            // Если передана кастомная логика, применяем её
            customizeTour?.Invoke(newTour);

            return newTour;
        }
    }
}
