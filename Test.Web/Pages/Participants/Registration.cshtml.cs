using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using CoronaTest.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class RegistrationModel : PageModel
    {
         private readonly IUnitOfWork _unitOfWork;

        public RegistrationModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Participant Participant {get; set; }


        public void OnGet()
        {
            Participant = new Participant();

        }

        public async Task<IActionResult> OnPost()
        {

            await _unitOfWork.ParticipantRepository.AddAsync(Participant);
            try
            {
                await _unitOfWork.SaveChangesAsync();

            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
                return Page();
            }
            return RedirectToPage("../Index");
        }

     
    }
}
