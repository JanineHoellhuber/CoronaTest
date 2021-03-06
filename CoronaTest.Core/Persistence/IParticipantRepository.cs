﻿using CoronaTest.Core;
using CoronaTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Core.Persistence
{
    public interface IParticipantRepository
    {
        Task AddRangeAsync(Participant[] participants);
        Task<int> GetCountAsync();
        Task AddAsync(Participant participant);
        Task AddRangeAsync(Participant participant);

        //void Remove(ParticipantDto participantDto);
        //Task<ParticipantDto> GetByIdAsync(int value);
        public Task<Participant> GetByParticipantBySocialSecurityNumberAndMobileNumberAsync(string socialSecurityNumber);
        Task<Participant> GetByIdAsync(int id);
    }
}
