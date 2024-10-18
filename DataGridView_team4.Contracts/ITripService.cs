using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGridView_team4.Contracts.Models;

namespace DataGridView_team4.Contracts
{
    /// <summary>
    /// Интерфейс для управления турами: создание, чтение, обновление и удаление.
    /// </summary>
    public interface ITripService
    {
        /// <summary>
        /// Получение списка <see cref="Trip"/> в виде неизменяемой коллекции.
        /// </summary>
        /// <returns><see cref="IReadOnlyCollection{Tour}"/> со всеми турами.</returns>
        Task<IReadOnlyCollection<Trip>> GetAllTripsAsync();
        /// <summary>
        /// Добавление нового <see cref="Trip"/>.
        /// </summary>
        /// <param name="trip">Добавляемый экземпляр <see cref="Trip"/>.</param>
        /// <returns>Добавленный <see cref="Trip"/> с уникальным идентификатором.</returns>
        Task<Trip> AddTripAsync(Trip trip);
        /// <summary>
        /// Обновление существующего <see cref="Trip"/>.
        /// </summary>
        /// <param name="trip">Экземпляр <see cref="Trip"/> с измененными данными.</param>
        Task EditTripAsync(Trip trip);
        /// <summary>
        /// Удаление <see cref="Trip"/> по идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор удаляемого <see cref="Trip"/>.</param>
        /// <returns><see cref="bool"/>, указывающий на успешное удаление.</returns>
        Task<bool> DeleteTripAsync(Guid id);
        /// <summary>
        /// Получение объекта <see cref="ITripStats"/> со статистикой туров.
        /// </summary>
        Task<ITripStats> GetTripStatsAsync();
    }
}
