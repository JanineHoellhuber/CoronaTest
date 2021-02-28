using ClassLibrary1.Entities;
using CoronaTest.Core.Contracts;
using CoronaTest.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class CampaignController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

     
        public CampaignController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Liefert alle vorhanden Kampagnen
        /// </summary>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CampaignDto[]>> GetCampaigns()
        {
            return Ok((await _unitOfWork.CampaignRepository.GetAllAsync())
                .Select(cd => new CampaignDto(cd))
                .ToArray());


        }

        /// <summary>
        /// Hinzufügen einer neuen Kampagne
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostCampaign(CampaignDto campaignDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            if (campaignDto == null)
            {
                return BadRequest();
            }

            var campaign = campaignDto.ToCampaign();
            await _unitOfWork.CampaignRepository.AddAsync(campaign);


            try
            {

                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var result = new
            {
                Id = campaign.Id,
                Name = campaign.Name,
                From = campaign.From,
                To = campaign.To
            };

            return Ok(result);
        }

        /// <summary>
        /// Abfrage einer bestimmten Kampagne
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCampaignById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var campaign = await _unitOfWork.CampaignRepository.GetByIdAsync(id.Value);

            if (campaign == null)
            {
                return NotFound();
            }

            return Ok(new CampaignDto(campaign));
        }

        /// <summary>
        /// Änderung einer Kampagne
        /// </summary>
        /// <param name="id"></param>
        /// <param name="campaignName"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PutCampaign(int? id, string campaignName)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            Campaign campaign = await _unitOfWork.CampaignRepository.GetByIdAsync(id.Value);
           
            if (campaign == null)
            {
                return NotFound();
            }

            campaign.Name = campaignName;

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
        /// Löschen einer Kampagne
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCampaign(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Campaign campaign = await _unitOfWork.CampaignRepository.GetByIdAsync(id.Value);
            
            if (campaign == null)
            {
                return NotFound();
            }

            _unitOfWork.CampaignRepository.Delete(campaign);

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
        /// Abfrage der Untersuchungen einer bestimmten Kampagne
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("{id}/Examinations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExaminationDto[]>> GetExaminationsByCampaignId(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Campaign campaign = await _unitOfWork.CampaignRepository.GetByIdAsync(id.Value);
            
            if (campaign == null)
            {
                return NotFound();
            }

            ExaminationDto[] examinations = (await _unitOfWork.ExaminationRepository.GetExaminationByCampaignIdAsync(campaign.Id))
               .Select(e => new ExaminationDto(e))
               .ToArray();

            return Ok(new CampaignDto(campaign));
        }

        /// <summary>
        /// Abfrage der TestCenter einer bestimmten Kampagne
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("{id}/TestCenters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExaminationDto[]>> GetTestCentersByCampaignId(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var campaign = await _unitOfWork.CampaignRepository.GetByIdAsync(id.Value);
            if (campaign == null)
            {
                return NotFound();
            }

            TestCenterDto[] testCenters = (await _unitOfWork.TestCenterRepository.GetTestcCenterByCampaignIdAsync(campaign.Id))
                .Select(t => new TestCenterDto(t))
                .ToArray();

            return Ok(testCenters);
        }


        /// <summary>
        /// Schaltet ein Testcenter für eine Kampagne frei
        /// </summary>
        /// <param name="id">campaignId</param>
        /// <param name="testCenterIdToAdd">testCenterId</param>
        /// <returns>CampaignDto</returns>
        [HttpPost("{id}/TestCenters/{testCenterIdToAdd}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostTestCenterToCampaign(int? id, int? testCenterId)
        {
            if (id == null || testCenterId == null)
            {
                return BadRequest();
            }

            var campaign = await _unitOfWork.CampaignRepository.GetByIdAsync(id.Value);

            if (campaign == null)
            {
                return NotFound();
            }

            var testCenter = await _unitOfWork.TestCenterRepository.GetTestCenterByIdAsync(testCenterId.Value);

            if (campaign == null || testCenter == null)
            {
                return NotFound();
            }

            testCenter.AvailableInCampaigns.Add(campaign);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(
                nameof(GetCampaignById),
                new { id = campaign.Id },
                new CampaignDto(campaign));
        }

        /// <summary>
        /// Entfernt ein Testcenter von einer bestimmten Kampagne
        /// </summary>
        /// <param name="id">campaignId</param>
        /// <param name="testCenterIdToRemove">testCenterId</param>
        /// <returns></returns>
        [HttpDelete("{id}/TestCenters/{testCenterIdToRemove}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTestCenerFromCampaign(int? id, int? testCenterId)
        {
            if (id == null || testCenterId == null)
            {
                return BadRequest();
            }

            var campaign = await _unitOfWork.CampaignRepository.GetByIdAsync(id.Value);

            if (campaign == null)
            {
                return NotFound();
            }

            var testCenter = await _unitOfWork.TestCenterRepository.GetTestCenterByIdAsync(testCenterId.Value);

            if (testCenter == null)
            {
                return NotFound();
            }

            if (campaign == null || testCenter == null)
            {

                return NotFound();
            }

            testCenter.AvailableInCampaigns.Remove(campaign);

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
    }
}
