namespace Events.EventAPI.Controllers
{
    using Events.Domain.Models;
    using Events.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]/[action]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly ICosmosDBRepo<Event> _repo;

        public EventsController(ILogger<EventsController> logger, ICosmosDBRepo<Event> repo)
        {
            this._logger = logger;
            this._repo = repo;
        }

        [HttpGet]
        public Event Get(Guid id)
        {
            return this._repo.GetItemByIdAsync(id).Result;
        }

        [HttpGet]
        public IEnumerable<Event> Search(string query)
        {
            return this._repo.GetItemsAsync(query).Result;
        }

        [HttpPost]
        public async Task Add([FromBody] Event eventObject)
        {
            await this._repo.AddItemAsync(eventObject);
        }

        [HttpPut]
        public async Task Update([FromBody] Event eventObject)
        {
            await this._repo.UpdateItemAsync(eventObject.Id, eventObject);
        }

        [HttpDelete]
        public async Task Delete([FromBody] Guid Id)
        {
            await this._repo.DeleteItemByIdAsync(Id);
        }

        [HttpPost]
        public async Task AddDefault()
        {
            var eventObj = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Test Event 01",
                Description = "description 01",
                Active = true,
                StartDate = new DateTime(2022, 3, 1),
                EndDate = new DateTime(2022, 3, 3),
                Venue = new Venue { Id = Guid.NewGuid(), Address1 = "80 Bulkeley Avenue", Town = "Windsor", County = "Berkshire", PostCode = "SL4 3NE", Country = "United Kingdom" }
            };

            await this._repo.AddItemAsync(eventObj);
        }
    }
}