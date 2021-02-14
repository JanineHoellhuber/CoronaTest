using ClassLibrary1.Entities;
using CoronaTest.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Core.Persistence
{
    public interface IExaminationRepository 
    {
        public Task<Examination[]> GetExaminationByParticipant(int id);
        Task<ExaminationDto[]> GetExaminationByDate(DateTime from, DateTime to);
    }
}
