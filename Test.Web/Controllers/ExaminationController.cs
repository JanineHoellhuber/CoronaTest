﻿using CoronaTest.Core.Contracts;
using CoronaTest.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.Controllers
{
    /// <summary>
    /// API-Controller für die Abfrage von Kampagnen
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class ExaminationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        
        public ExaminationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Liefert alle Untersuchungen im Zeitraum
        /// </summary>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetExaminationsInPeriodeOfTime(DateTime? from, DateTime? to)
        {
            if (from == null || to == null)
            {
                return BadRequest();
            }

            var examinations = await _unitOfWork.ExaminationRepository.GetExaminationFilterAsync(from, to);

            if (examinations == null)
            {
                return NotFound();
            }

            return Ok(examinations);
        }

        /// <summary>
        /// Liefert alle Untersuchungen in der Gemeinde und im Zeitraum
        /// </summary>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("byPostalCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExaminationDto[]>> GetExaminationsInAreaAndPeriode(string postcode, DateTime? from, DateTime? to)
        {
            if (from == null || to == null)
            {
                return BadRequest();
            }
            ExaminationDto[] examinations = (await _unitOfWork.ExaminationRepository.GetExaminationsWithFilterByPostCodeAndDateAsync(postcode, from.Value, to.Value))
                .Select(_ => new ExaminationDto(_))
                .ToArray();

            return Ok(examinations);
        }

    }
}
