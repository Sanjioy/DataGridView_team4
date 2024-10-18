﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridView_team4.Contracts.Models;

namespace DataGridView_team4.Contracts
{
    /// <summary>
    /// Управление хранилищем туров с выполнением CRUD-операций:  
    /// создание, чтение, обновление и удаление.
    /// </summary>
    public interface ITourStorage
    {
        /// <summary>
        /// Получение списка <see cref="Tours"/> в виде неизменяемой коллекции.
        /// </summary>
        /// <returns><see cref="IReadOnlyCollection{Tour}"/> со всеми доступными турами.</returns>
        Task<IReadOnlyCollection<Tours>> GetAllToursAsync();

        /// <summary>
        /// Добавление нового <see cref="Tours"/> в хранилище.
        /// </summary>
        /// <param name="tour">Добавляемый экземпляр <see cref="Tours"/>.</param>
        /// <returns>Добавленный <see cref="Tours"/> с уникальным идентификатором.</returns>
        Task<Tours> AddTourAsync(Tours tour);

        /// <summary>
        /// Обновление данных существующего <see cref="Tours"/>.
        /// </summary>
        /// <param name="tour">Экземпляр <see cref="Tours"/> с измененными данными.</param>
        Task EditTourAsync(Tours tour);

        /// <summary>
        /// Удаление <see cref="Tours"/> по идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор удаляемого <see cref="Tours"/>.</param>
        /// <returns><see cref="bool"/>, указывающий на успешное удаление.</returns>
        Task<bool> DeleteTourAsync(Guid id);
    }
}
