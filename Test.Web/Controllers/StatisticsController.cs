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

        /// <summary>
        /// Liefert die Teststatistik im Zeitraum
        /// </summary>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StatisticsDto>> GetStatisticsInPeriode(DateTime from, DateTime to)
        {
            var examinations = await _unitOfWork.ExaminationRepository.GetExaminationsByFilterAsync(from, to);

            StatisticsDto statistic = new StatisticsDto();

            if (examinations != null)
            {
                return BadRequest();
            }

            statistic.CountExaminations = examinations.Count();
            statistic.CountUnknownTest = examinations.Count(u => u.TestResult == TestResult.Unknown);
            statistic.CountPositiveTest = examinations.Count(p => p.TestResult == TestResult.Positive);
            statistic.CountNegativeTest = examinations.Count(n => n.TestResult == TestResult.Negative);

            return Ok(statistic);
        }

        /// <summary>
        /// Liefert die Teststatistik in der Gemeinde und im Zeitraum
        /// </summary>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        [HttpGet]
        [Route("byPostalCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StatisticsDto>> GetStatisticsInAreaAndPeriode(string postalCode, DateTime from, DateTime to)
        {
            var examinations = await _unitOfWork.ExaminationRepository.GetExaminationsWithFilterByPostCodeAndDateAsync(postalCode, from, to);

            StatisticsDto statistic = new StatisticsDto();

            if (examinations != null)
            {

                return BadRequest();

            }

            statistic.CountExaminations = examinations.Count();
            statistic.CountUnknownTest = examinations.Count(u => u.TestResult == TestResult.Unknown);
            statistic.CountPositiveTest = examinations.Count(p => p.TestResult == TestResult.Positive);
            statistic.CountNegativeTest = examinations.Count(n => n.TestResult == TestResult.Negative);

            return Ok(statistic);
        }

    }
}
