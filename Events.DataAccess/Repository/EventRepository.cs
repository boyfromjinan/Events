using Events.Repository.Models;
using log4net;
using System;
using System.Linq;

namespace Events.Repository.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext eventContext;
        private readonly ILog logger;

        public EventRepository(ILog logger, EventContext context)
        {
            eventContext = context;
            this.logger = logger;
        }

        public Event Create(Event entity)
        {
            try
            {
                eventContext.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                var entity = Get(id);
                if (entity != null)
                    eventContext.Remove(entity);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public Event Get(int id)
        {
            try
            {
                return eventContext.Events.Find(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public IQueryable<Event> GetAll()
        {
            try
            {
                return eventContext.Events;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public void Update(Event entity)
        {
            try
            {
                eventContext.Events.Update(entity);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}
