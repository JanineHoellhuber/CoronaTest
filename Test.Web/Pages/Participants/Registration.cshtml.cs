using System;
using System.Collections.Generic;
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


        public IActionResult OnGet()
        {
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
          
            return Page();
        }

        public async Task<ActionResult> OnPostLogInBtn_Click()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _unitOfWork.ParticipantRepository.AddAsync(Participant);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToPage("./Index");


            return Page();
            //TODO: Benutzer in Db speichern
            //return RedirectToPage("./Participant/Login");
        }

        public IActionResult OnPostCancelBtn_Click()
        {
            return RedirectToPage("../Index");
        }
    }
}
