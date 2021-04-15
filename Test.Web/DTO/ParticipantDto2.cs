using ClassLibrary1;
using CoronaTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.DTO
{
    public class ParticipantDto2
    {
        public int Id { get; set; }

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


        public ParticipantDto2(Participant participant)
        {
            Id = participant.Id;
            FirstName = participant.FirstName;
            LastName = participant.LastName;
            Birthdate = participant.Birthdate;
            Gender = participant.Gender;
            SocialSecurityNumber = participant.SocialSecurityNumber;
            Mobilenumber = participant.Mobilenumber;
            Street = participant.Street;
            HouseNr = participant.HouseNr;
            Stair = participant.Stair;
            Door = participant.Door;
            Postcode = participant.Postcode;
            City = participant.City;
        }

        public void SaveParticipant(ref Participant par)
        {
            par.Id = Id;
            par.FirstName = FirstName;
            par.LastName = LastName;
            par.Birthdate = Birthdate;
            par.Gender = Gender;
            par.SocialSecurityNumber = SocialSecurityNumber;
            par.Mobilenumber = Mobilenumber;
            par.Street = Street;
            par.HouseNr = HouseNr;
            par.Stair = Stair;
            par.Place = Place;
            par.Door = Door;
            par.Postcode = Postcode;
            par.City = City;
        }
        public Participant GetNewModel()
        {
            var participant = new Participant();
            SaveParticipant(ref participant);
            return participant;
        }

        public ParticipantDto2()
        {

        }


    }
}
