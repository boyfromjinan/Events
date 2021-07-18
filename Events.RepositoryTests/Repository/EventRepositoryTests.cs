using Castle.Core.Logging;
using Events.Repository;
using Events.Repository.Models;
using Events.Repository.Repository;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.RepositoryTests.Repository
{
    [TestClass]
    public class EventRepositoryTests
    {
        private readonly EventRepository eventRepository;
        private readonly Mock<ILogger> loggerMock = new Mock<ILogger>();
        private readonly Mock<EventContext> contextMock = new Mock<EventContext>();

        [TestInitialize]
        public void Initialize()
        {
            var dbSetMock = new Mock<DbSet<Event>>();
            dbSetMock.Setup(s => s.Find(It.IsAny<int>())).Returns(new Event() { EventId = 1, Active = true });

            contextMock.Setup(s => s.Set<Event>()).Returns(dbSetMock.Object);
        }

        //[TestMethod]
        //public void GetByValidId_ReturnEvent()
        //{

        //    var sut = new EventRepository(loggerMock.Object);

        //    var eventObject = sut.Get(1);

        //    Assert.IsNotNull(sut.Get(1));
        //}

    }
}