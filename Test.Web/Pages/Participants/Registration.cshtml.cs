using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using CoronaTest.Core.Contracts;
using CoronaTest.Core.Models;
using CoronaTest.Core.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Web.DTO;

namespace WebApplication1
{
    public class RegistrationModel : PageModel
    {
         private readonly IUnitOfWork _unitOfWork;
        private readonly ISmsService _smsService;

        public RegistrationModel(IUnitOfWork unitOfWork, ISmsService smsService)
        {
            _unitOfWork = unitOfWork;
            _smsService = smsService;
        }

        [BindProperty]
        public ParticipantDto2 Participant { get; set; }


        public IActionResult OnGet()
        {

          
              //Participant = new ParticipantDto2();
            return Page();
        }

        //public Participant participant = new Participant();


        public async Task<IActionResult> OnPost()
        {



            if (!ModelState.IsValid)
            {
                return Page();
            }

            /* if (!ValidationSVNR.CheckSsnr(Participant.SocialSecurityNumber))
             {
                 ModelState.AddModelError($"{nameof(Participant)}.{nameof(Participant.SocialSecurityNumber)}", $"Die SVNr {Participant.SocialSecurityNumber} ist ungültig");
                 return Page();
             }*/


            //  var p = GetParticipant();

            var p = Participant.GetNewModel();

            await _unitOfWork.ParticipantRepository.AddAsync(p);

            await _unitOfWork.SaveChangesAsync();

            /* try
             {
                 await _unitOfWork.SaveChangesAsync();

             }
             catch(ValidationException ex)
             {
                 ModelState.AddModelError("", $"{ex.Message}");
                 return Page();
             }*/


             VerificationToken verificationToken = VerificationToken.NewToken(p);

             await _unitOfWork.VerificationTokens.AddAsync(verificationToken);
             await _unitOfWork.SaveChangesAsync();
             _smsService.SendSms(Participant.Mobilenumber, $"CoronaTest - Token: {verificationToken.Token} !");


            return RedirectToPage("../Security/Login");//, new { verificationIdentifier = verificationToken.Identifier });
        }

      /* public Participant GetParticipant()
        {
            Participant.SaveParticipant(ref participant);
            return participant;
        }*/
    }
}
