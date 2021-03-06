﻿using CoronaTest.Core;
using CoronaTest.Core.Entities;
using CoronaTest.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Persistence.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ParticipantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRangeAsync(Participant[] participants)
        {
            await _dbContext.Participant.AddRangeAsync(participants);
        }
        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Participant.CountAsync();
        }

        public async Task AddAsync(Participant participant)
        {
             await _dbContext.Participant
                .AddAsync(participant);
        }

        public async Task AddRangeAsync(Participant participant)
        {
            await _dbContext.Participant.AddRangeAsync(participant);
        }


        public async Task<Participant> GetByParticipantBySocialSecurityNumberAndMobileNumberAsync(string socialSecurityNumber)
        {
           return await _dbContext.Participant
                .Where(p => p.SocialSecurityNumber == socialSecurityNumber).SingleOrDefaultAsync();
        }

        public async Task<Participant> GetByIdAsync(int id)
        {
            return await _dbContext.Participant
                .Where(p => p.Id == id).SingleOrDefaultAsync();
        }

    }
}
