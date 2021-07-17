using Events.Repository.Models;
using Events.Repository.Repository;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Events.EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILog _logger;

        public EventController(IEventRepository eventRepository, ILog logger)
        {
            _eventRepository = eventRepository;
            _logger = logger;
        }

        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _eventRepository.GetAll();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _eventRepository.Get(id);
        }

        // POST api/<EventController>
        [HttpPost]
        public Event Post([FromBody] Event value)
        {
            try
            {
                return _eventRepository.Create(value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            try
            {
                _eventRepository.Update(value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _eventRepository.Remove(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
    }
}
