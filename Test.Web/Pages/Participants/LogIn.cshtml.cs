using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary1.DTO;
using ClassLibrary1.Entities;
using CoronaTest.Core.Contracts;
using CoronaTest.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Web.DTO;

namespace WebApplication1.Pages.Participants
{
    public class LogInModel : PageModel
    {
       
         private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
         public Examination[] Examinations { get; set; }

       [BindProperty]
        public ParticipantDto2 Participant { get; set; }


        public LogInModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGet(Guid? verificationIdentifier)
        {

            if (verificationIdentifier == null)
            {
                return RedirectToPage("../Security/TokenError");
            }
            VerificationToken verificationToken = await _unitOfWork.VerificationTokens.GetTokenByIdentifierAsync(verificationIdentifier.Value);
          
            Participant = new ParticipantDto2(verificationToken.Participant); //id null?
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
