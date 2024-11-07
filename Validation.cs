using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataGridView_team4.Standart.Contracts.Models;

namespace DataGridView_team4
{
    /// <summary>
    /// Класс для описания путешествия
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Уникальный идентификатор путешествия
        /// </summary>
        public Guid TripId { get; set; }
        /// <summary>
        /// Локация путешествия (точка назначения)
        /// </summary>
        [Required]
        [DisplayName("Назначение")]
        public Location Location { get; set; }
        /// <summary>
        /// Дата отправления
        /// </summary>
        [DisplayName("Дата вылета")]
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// Количество ночей
        /// </summary>
        [DisplayName("Количество ночей")]
        public int Nights { get; set; }
        /// <summary>
        /// Стоимость за одного отдыхающего
        /// </summary>
        [DisplayName("Цена за человека")]
        public int CostPerPerson { get; set; }
        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        [DisplayName("Количество отдыхающих")]
        public int ParticipantCount { get; set; }
        /// <summary>
        /// Наличие Wi-Fi
        /// </summary>
        [DisplayName("Wi-Fi")]
        public bool WiFiAvailable { get; set; }
        /// <summary>
        /// Доплаты
        /// </summary>
        [DisplayName("Доплаты")]
        public int ExtraCharges { get; set; }
    }
}
