
using CoronaTest.Core.DTOs;
using CoronaTest.Core.Entities;
using CoronaTest.Core.Enums;
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

        TestResult[] t = 
            {
                TestResult.Unknown,
                TestResult.Negative,
                TestResult.Positive
            };

        private readonly ApplicationDbContext _dbContext;

        public ExaminationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> NegativTests()
        {
            return await _dbContext.Examination
                .Where(s => s.TestResult == TestResult.Negative)
                .CountAsync();
               

        }


        public async Task AddRangeAsync(Examination[] examinations)
        {
             await _dbContext.Examination.AddRangeAsync(examinations);
        }
        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Examination.CountAsync();
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

        public async Task<ExaminationsDto[]> GetExaminationByDate(DateTime? from = null, DateTime? to = null)
        {
            var query = _dbContext
              .Examination
              .Include(_ => _.Participant)
              .Include(_ => _.TestCenter)
              .Include(_ => _.Campaign)
              .AsQueryable();

            if (from != null)
            {
                query = query.Where(e => e.ExaminationAt.Date >= from.Value.Date);
            }
            if (to != null)
            {
                query = query.Where(e => e.ExaminationAt.Date <= to.Value.Date);
            }

           
     
            return await query.Select( s => new ExaminationsDto
            {

                Name = s.Participant.Name,
                TestResult = s.TestResult,
                ExaminationAt = s.ExaminationAt,
                Identifier = s.Identifier

            } ).ToArrayAsync();


    }
        public async Task<Examination> GetByIdentifierAsync(string examinationIdentifier)
        {
            return await _dbContext.Examination
                .Include(p => p.Participant)
                .Include(t => t.TestCenter)
                .Where(s => s.Identifier == examinationIdentifier)
                .SingleOrDefaultAsync();
        }

        public async Task<Examination> GetByIdAsync(int id)
        {
            return await _dbContext.Examination
                .SingleOrDefaultAsync(s => s.Id == id);
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
        public async Task<IEnumerable<Examination>> GetExaminationsByFilterAsync(DateTime? from, DateTime? to)
        {
            var query = _dbContext.Examination
               .AsQueryable();

            if (from != null)
            {
                query = query.Where(_ => _.ExaminationAt.Date >= from.Value.Date);
            }
            if (to != null)
            {
                query = query.Where(_ => _.ExaminationAt.Date <= to.Value.Date);
            }

            return await query
                .OrderBy(_ => _.ExaminationAt)
                .ToArrayAsync();
        }

        public void Remove(Examination examination)
        {
            _dbContext
                .Examination
                .Remove(examination);
        }
    }

    }

