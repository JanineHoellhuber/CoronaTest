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


        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Vorname ist verpflichtend")]
        [DisplayName("Vorname")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("Nachname")]
        public string LastName { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("Geburtsdatum")]
        public DateTime Birthdate { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("Geschlecht")]
        public string Gender { get; set; }

        public string Name => $"{LastName} {FirstName}";

        [BindProperty]
        [Required]
        [DisplayName("Sozialversicherungsnummer")]
        public string SocialSecurityNumber { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("Telefonnummer")]
        public string Mobilenumber { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("Straße")]
        public string Street { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("HausNr")]
        public string HouseNr { get; set; }

        [BindProperty]
        [DisplayName("Tür")]
        public string Door { get; set; }

        [BindProperty]
        [DisplayName("Stiege")]
        public string Stair { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("PLZ")]
        public string Postcode { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("Ort")]
        public string Place { get; set; }

        [BindProperty]
        [Required]
        [DisplayName("Stadt")]
        public string City { get; set; }


        public void OnGet()
        {

        }

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


            var participant = new Participant()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Birthdate = Birthdate,
                Gender = Gender,
                SocialSecurityNumber = SocialSecurityNumber,
                Mobilenumber = Mobilenumber,
                Street = Street,
                HouseNr = HouseNr,
                Stair = Stair,
                Door = Door, 
                Place = Place,
                Postcode = Postcode,
                City = City

            };



            await _unitOfWork.ParticipantRepository.AddAsync(participant);



            try
            {
                await _unitOfWork.SaveChangesAsync();

            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
                return Page();
            }

            VerificationToken verificationToken = VerificationToken.NewToken(participant);

            await _unitOfWork.VerificationTokens.AddAsync(verificationToken);
            await _unitOfWork.SaveChangesAsync();
            _smsService.SendSms(Mobilenumber, $"CoronaTest - Token: {verificationToken.Token} !");

            return RedirectToPage("./Login", new { verificationIdentifier = verificationToken.Identifier });
        }


    }
}
