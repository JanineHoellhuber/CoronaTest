using CoronaTest.Core.Contracts;
using CoronaTest.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Web.DTO;

namespace Test.Web.Controllers
{
    /// <summary>
    /// API-Controller für die Abfrage von Statistiken
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatisticsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      /*  /// <summary>
        /// Liefert die Teststatistik im Zeitraum
        /// </summary>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StatisticsDto>> GetStatisticsInPeriode(DateTime from, DateTime to)
        {
            var examinations = await _unitOfWork.ExaminationRepository.GetExaminationsByFilterAsync(null, from, to);

            StatisticsDto statistic = new StatisticsDto();

            if (examinations != null)
            {
                statistic.CountExaminations = examinations.Count();
                statistic.CountUnknownTest = examinations.Count(u => u.Result == TestResult.Unknown);
                statistic.CountPositiveTest = examinations.Count(p => p.Result == TestResult.Positive);
                statistic.CountNegativeTest = examinations.Count(n => n.Result == TestResult.Negative);
            }

            return Ok(statistic);
        }*/
    }
}
