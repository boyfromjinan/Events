﻿using Events.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repository.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
    }
}