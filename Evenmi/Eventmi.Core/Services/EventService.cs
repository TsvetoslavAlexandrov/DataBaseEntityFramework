﻿using Eventimi.Infrastructure.Data.Models;
using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Eventmi.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Eventmi.Core.Services
{
    /// <summary>
    /// Услуга за управление на събития
    /// </summary>
    public class EventService : IEventService
    {
        /// <summary>
        /// Достъп до базата данни
        /// </summary>
        private readonly IRepository repo;

        /// <summary>
        /// Инжектиране на зависимости
        /// </summary>
        /// <param name="_repo">Достъп до базата данни</param>
        public EventService(IRepository _repo)
        {
            repo = _repo;
        }

        /// <summary>
        /// Добавяне на събитие
        /// </summary>
        /// <param name="model">Данни за събитие</param>
        /// <returns></returns>
        public async Task AddAsync(EventModel model)
        {
            var entity = new Event()
            {
                Name = model.Name,
                Price = model.Price,
                End = model.End,
                Place = model.Place,
                Start = model.Start
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Изтриване на събитие
        /// </summary>
        /// <param name="id">Идентификатор на събитие</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            await repo.DeleteAsync<Event>(id);

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Преглед на всички събития
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Event>()
                .Select(e => new EventModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    End = e.End,
                    Place = e.Place,
                    Start = e.Start
                })
                .OrderBy(e => e.Start)
                .ToListAsync();
        }

        /// <summary>
        /// Преглед на събитие
        /// </summary>
        /// <param name="id">Идентификатор на събитие</param>
        /// <returns></returns>
        public async Task<EventModel> GetEventAsync(int id)
        {
            var entity = await repo.GetByIdAsync<Event>(id);

            if (entity == null)
            {
                throw new ArgumentException("Невалиден идентификатор", nameof(id));
            }

            return new EventModel()
            {
                Name = entity.Name,
                Price = entity.Price,
                End = entity.End,
                Place = entity.Place,
                Start = entity.Start,
                Id = entity.Id
            };
        }

        /// <summary>
        /// Промяна на събитие
        /// </summary>
        /// <param name="model">Данни за събитие</param>
        /// <returns></returns>
        public async Task UpdateAsync(EventModel model)
        {
            var entity = await repo.GetByIdAsync<Event>(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Невалиден идентификатор", nameof(model.Id));
            }

            entity.End = model.End;
            entity.Place = model.Place;
            entity.Start = model.Start;
            entity.Price = model.Price;
            entity.Name = model.Name;


            await repo.SaveChangesAsync();
        }
    }
}