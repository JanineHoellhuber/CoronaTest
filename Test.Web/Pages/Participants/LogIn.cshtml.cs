using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary1.DTO;
using ClassLibrary1.Entities;
using CoronaTest.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Participants
{
    public class LogInModel : PageModel
    {
       
         private readonly IUnitOfWork _unitOfWork;

         public Examination[] Examinations { get; set; }

        [BindProperty]
        public Participant Participant { get; set; }


        public LogInModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGet()
        {
            Examinations = await _unitOfWork.ExaminationRepository.GetExaminationByParticipant(Participant.Id);

            return Page();
        }

        public IActionResult OnPostNewExaminationBtn_Click()
        {
            //TODO: Benutzer in Db speichern
            return RedirectToPage("./Examination/Create");
        }

        public IActionResult OnPostCancelBtn_Click()
        {
            return RedirectToPage("../Index");
        }
    }
}
