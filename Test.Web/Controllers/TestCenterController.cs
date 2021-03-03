using ClassLibrary1.Entities;
using CoronaTest.Core.Contracts;
using CoronaTest.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.Controllers
{
    /// <summary>
    /// API-Controller für die Abfrage von den TestCentern
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestCenterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestCenterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Liefert alle vorhandenen TestCenter
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Die Abfrage war erfolgreich</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TestCenterDto[]>> GetTestCenter()
        {
            return Ok((await _unitOfWork.TestCenterRepository.GetAllAsync())
                .Select(t => new TestCenterDto(t))
                .ToArray());
        }

        /// <summary>
        /// Hinzufügen eines neuen TestCenters
        /// </summary>
        /// <param name="testCenterDto"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostTestCenter(TestCenterDto testCenterDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (testCenterDto == null)
            {
                return BadRequest();
            }

            var testCenter = testCenterDto.ToTestCenter();

            await _unitOfWork.TestCenterRepository.AddAsync(testCenter);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return CreatedAtAction(
                   nameof(GetTestCenter),
                   new { id = testCenter.Id },
                   new TestCenterDto(testCenter));

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex);
            }
           

        }
        /// <summary>
        /// Liefert alle vorhandenen TestCenter eines bestimmten Bezirks
        /// </summary>
        /// <param name="postalcode"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet()]
        [Route("byPostalCode/{postalcode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTestCenterByPostalcode(string postalcode)
        {
            if (postalcode == null)
            {
                return BadRequest();
            }

            var testCenters = await _unitOfWork.TestCenterRepository.GetTestCenterByPostcodeAsync(postalcode);

            if (testCenters == null)
            {
                return NotFound();
            }

            return Ok(testCenters);
        }

        /// <summary>
        /// Abfrage eines bestimmten TestCenters
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestCenterDto>> GetTestCenterById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var testCenter = await _unitOfWork.TestCenterRepository.GetTestCenterByIdAsync(id.Value);

            if (testCenter == null)
            {
                return NotFound();
            }

            return Ok(new TestCenterDto(testCenter));
        }

        /// <summary>
        /// Änderung eines TestCenters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testCenterDto"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PutTestCenter(int? id, TestCenterDto testCenterDto)
        {
            if (id == null)
            {
                return BadRequest();
            }

            TestCenter testCenter = await _unitOfWork.TestCenterRepository.GetTestCenterByIdAsync(id.Value);
           
            if (testCenter == null)
            {
                return NotFound();
            }

            testCenter.Name = testCenterDto.Name;
            testCenter.City = testCenterDto.City;
            testCenter.Postcode = testCenterDto.Postcode;
            testCenter.Street = testCenterDto.Street;
            testCenter.SlotCapacity = testCenterDto.SlotCapacity;

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
        /// <summary>
        /// Löschen eines TestCenters
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTestCenter(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            TestCenter testCenter = await _unitOfWork.TestCenterRepository.GetTestCenterByIdAsync(id.Value);
           
            if (testCenter == null)
            {
                return NotFound();
            }

            _unitOfWork.TestCenterRepository.Delete(testCenter);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
        /// <summary>
        /// Abfrage eines bestimmten TestCenters
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet()]
        [Route("{id}/Examinations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExaminationDto[]>> GetExaminationsByTestCenterId(int id)
        {
            TestCenter testCenter = await _unitOfWork.TestCenterRepository.GetTestCenterByIdAsync(id);
            if (testCenter == null)
            {
                return NotFound();
            }

            ExaminationDto[] examinations = (await _unitOfWork.ExaminationRepository.GetExaminationByTestCenterIdAsync(testCenter.Id))
                .Select(e => new ExaminationDto(e))
                .ToArray();

            return Ok(examinations);
        }
    }
}
