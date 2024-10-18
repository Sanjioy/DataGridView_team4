using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataGridView_team4.Contracts.Models
{
    /// <summary>
    /// Класс для горячего тура
    /// </summary>
    public class Tours
    {
        /// <summary>
        /// Уникальный идентификатор тура
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Направление тура (точка назначения)
        /// </summary>
        [Required]
        [DisplayName("Назначение")]
        public Destination Destination { get; set; }
        /// <summary>
        /// Дата вылета
        /// </summary>
        [DisplayName("Дата вылета")]
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// Количество ночей
        /// </summary>
        [DisplayName("Кол-во ночей")]
        [Range(1, 31)]
        public int Nights { get; set; }
        /// <summary>
        /// Стоимость за одного отдыхающего
        /// </summary>
        [DisplayName("Цена за человека")]
        [Range(1, 50000)]
        public int PricePerPerson { get; set; }
        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        [DisplayName("Кол-во отдыхающих")]
        [Range(1, 10)]
        public int NumberOfPeople { get; set; }
        /// <summary>
        /// Наличие Wi-Fi
        /// </summary>
        [DisplayName("Наличие Wi-Fi")]
        public bool HasWiFi { get; set; }
        /// <summary>
        /// Доплаты
        /// </summary>
        [DisplayName("Доплаты")]
        [Range(1, 50000)]
        public int AdditionalFees { get; set; }
        /// <summary>
        /// Общая стоимость тура
        /// </summary>
        // public decimal TotalCost => (PricePerPerson * NumberOfPeople) + AdditionalFees;
    }
}
