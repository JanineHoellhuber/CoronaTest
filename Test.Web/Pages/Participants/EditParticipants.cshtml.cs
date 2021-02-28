using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using CoronaTest.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Web.Pages.Participants
{
    public class EditParticipantsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Participant Participant { get; set; }

        public EditParticipantsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGet()
        {

            // Participant = new Participant();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var participantInDb = await _unitOfWork.ParticipantRepository.GetByIdAsync(Participant.Id);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
                return Page();
            }
            return RedirectToPage("./Participants/LogIn");
        }
    }
}
