using ClassLibrary1.Entities;
using CoronaTest.Core.DTO;
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


        //public async IEnumerable<Examination> GetAllAsync()
        //{
        //    return await _dbContext.Examination.ToArrayAsync();
        //}
        public async Task<Examination[]> GetExaminationByParticipant(int id)
        {
            return await _dbContext.Examination
                .Where(p => p.Participant.Id == id)
                .ToArrayAsync();
                
        }

        public async Task<ExaminationsDto[]> GetExaminationByDate(DateTime? from, DateTime? to)
        {
            return await _dbContext.Examination
               .Include(p => p.Participant)
               .Select(s => new ExaminationsDto(s))
               .ToArrayAsync();


        }


        public async Task<Examination[]> GetExaminationByCampaignIdAsync(int id)
        {
           return await _dbContext.Examination
              .Where(e => e.Campaign.Id == id)
              .ToArrayAsync();
        }

        public async Task<IEnumerable<Examination>> GetExaminationByTestCenterIdAsync(int id)
        {
            return await _dbContext.Examination
               .Where(t => t.Campaign.Id == id)
               .ToArrayAsync();

        }

        public async Task<ExaminationsDto[]> GetExaminationFilterAsync(DateTime? from = null, DateTime? to = null)
        {
            var queryExamination = _dbContext.Examination
               .AsQueryable();

            if (from != null)
            {
                queryExamination = queryExamination
                    .Where(e => e.ExaminationAt.Date >= from.Value.Date);
            }
            if (to != null)
            {
                queryExamination = queryExamination.Where(_ => _.ExaminationAt.Date <= to.Value.Date);
            }

            return await queryExamination
                .Select(e => new ExaminationsDto(e))
                .ToArrayAsync();
        }

       public async Task<IEnumerable<Examination>> GetExaminationsWithFilterByPostCodeAndDateAsync(string postcode, DateTime? from = null, DateTime? to = null)
        {
            var queryExamination = _dbContext.Examination
               .AsQueryable();

            if (postcode != null)
            {
                queryExamination = queryExamination
                    .Where(q => q.TestCenter.Postcode == postcode);
            }
            if (from != null)
            {
                queryExamination = queryExamination
                    .Where(q => q.ExaminationAt.Date >= from.Value.Date);
            }
            if (to != null)
            {
                queryExamination = queryExamination
                    .Where(q => q.ExaminationAt.Date <= to.Value.Date);
            }

            return await queryExamination
                .ToArrayAsync();
        }


    }
}
