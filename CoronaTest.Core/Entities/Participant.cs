using CoronaTest.Core.Entities;
using CoronaTest.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoronaTest.Core.Entities
{
    public class Participant : EntityObject
    {


        [Required(ErrorMessage = "Vorname ist verpflichtend")]
        [DisplayName("Vorname")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Nachname")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Geburtsdatum")]
        public DateTime Birthdate { get; set; }

        [Required]
        [DisplayName("Geschlecht")]
        public string Gender { get; set; }

        public string Name => $"{LastName} {FirstName}";

        [Required]
        [DisplayName("Sozialversicherungsnummer")]
        public string SocialSecurityNumber { get; set; }

        [Required]
        [DisplayName("Telefonnummer")]
        public string Mobilenumber { get; set; }

        [Required]
        [DisplayName("Straße")]
        public string Street { get; set; }

        [Required]
        [DisplayName("HausNr")]
        public string HouseNr { get; set; }


        [DisplayName("Tür")]
        public string Door { get; set; }


        [DisplayName("Stiege")]
        public string Stair { get; set; }

        [Required]
        [DisplayName("PLZ")]
        public string Postcode { get; set; }

        [Required]
        [DisplayName("Ort")]
        public string Place { get; set; }

        [Required]
        [DisplayName("Stadt")]
        public string City { get; set; }

       public List<VerificationToken> Verifications { get; set; }
        public Participant()
        {

        }


      

    }
}
