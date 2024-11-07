using System;

namespace DataGridView_team4.Standart.Contracts.Models
{
    /// <summary>
    /// Класс для описания путешествия
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// Уникальный идентификатор путешествия
        /// </summary>
        public Guid TripId { get; set; }
        /// <summary>
        /// Локация путешествия (точка назначения)
        /// </summary>
        public Location Location { get; set; }
        /// <summary>
        /// Дата отправления
        /// </summary>
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// Количество ночей
        /// </summary>
        public int Nights { get; set; }
        /// <summary>
        /// Стоимость за одного отдыхающего
        /// </summary>
        public int CostPerPerson { get; set; }
        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        public int ParticipantCount { get; set; }
        /// <summary>
        /// Наличие Wi-Fi
        /// </summary>
        public bool WiFiAvailable { get; set; }
        /// <summary>
        /// Доплаты
        /// </summary>
        public int ExtraCharges { get; set; }
    }
}
