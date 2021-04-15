using CoronaTest.Core.Entities;
using CoronaTest.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaTest.Core.DTOs;

namespace CoronaTest.Core.Persistence
{
    public interface IExaminationRepository 
    {
        public Task<Examination[]> GetExaminationByParticipant(int id);
        Task<ExaminationsDto[]> GetExaminationByDate(DateTime? from, DateTime? to);
        Task<Examination[]> GetExaminationByCampaignIdAsync(int id);
        Task<IEnumerable<Examination>> GetExaminationByTestCenterIdAsync(int id);
        //IEnumerable<Examination> GetAllAsync();
        Task<ExaminationsDto[]> GetExaminationFilterAsync(DateTime? from, DateTime? to);
        Task<IEnumerable<Examination>> GetExaminationsWithFilterByPostCodeAndDateAsync(string postcode, DateTime? from, DateTime? to);
        Task<IEnumerable<Examination>> GetExaminationsByFilterAsync(DateTime? from, DateTime? to);
    }
}
