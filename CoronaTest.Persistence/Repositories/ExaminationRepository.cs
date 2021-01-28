using ClassLibrary1.Entities;
using CoronaTest.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Persistence.Repositories
{
    public class ExaminationRepository : IExaminationRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public ExaminationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Examination[]> GetExaminationByParticipant(int id)
        {
            return await _dbContext.Examination
                .Where(p => p.Participant.Id == id)
                .ToArrayAsync();
                
        }

    }
}
