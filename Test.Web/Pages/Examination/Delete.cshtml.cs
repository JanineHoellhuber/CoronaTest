using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.DTO;
using CoronaTest.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Examination
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public ParticipantDto ParticipantDto { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // ParticipantDto = await _unitOfWork.ParticipantRepository.GetByIdAsync(id.Value);
            if (ParticipantDto == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // ParticipantDto = await _unitOfWork.ParticipantRepository.GetByIdAsync(id.Value);
            if (ParticipantDto == null)
            {
                return NotFound();
            }

           // _unitOfWork.ParticipantRepository.Remove(ParticipantDto);
          //  await _unitOfWork.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
