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
        public int Nights { get; set; }
        /// <summary>
        /// Стоимость за одного отдыхающего
        /// </summary>
        [DisplayName("Цена за человека")]
        public int PricePerPerson { get; set; }
        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        [DisplayName("Кол-во отдыхающих")]
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
        public int AdditionalFees { get; set; }
    }
}
