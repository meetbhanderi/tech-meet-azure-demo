using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using TechMeet_BE.Domain;
using TechMeet_BE.Services.Interfaces;

namespace TechMeet_BE.Services.Services
{
    public class EventsService : IEventsService
    {
        private readonly TechMeetDbContext _dbContext = new();

        public async Task<List<Event>> GetEventList()
        {
            return await _dbContext.Events.ToListAsync();
        }

    }
}
