using CoronaTest.Core.Contracts;
using CoronaTest.Core.Entities;
using CoronaTest.Core.Enums;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadExamination
{
    public class LoadExaminations
    {
     
        public  static CoronaTest.Core.Enums.TestResult tr;
        public  static CoronaTest.Core.Enums.ExaminationStates es;

        public static string[] firstNameArray = new string[]
         {
            "Tom",
            "Paul",
            "Tim",
            "Dominik",
            "Lukas",
            "Michael",
            "Leon",
            "Susi",
            "Franz",
            "Lisa",
            "Lili",
            "Andrea",
            "Michaela",
            "Sarah",
            "Tanja",
            "Max",
            "Nina",
            "Stefan"
        };


        public static string[] lastNameArray = new string[]
         {
            "Huber",
            "Steiner",
            "Bauer",
            "Binder",
            "Mayrhofer",
            "Lehner",
            "Lackner",
            "Reiter",
            "Wimmer",
            "Webner",
            "Berger",
            "Fischner",
            "Fuchs",
            "Winkler",
            "Lang",
            "Müller",
            "Gruber",
            "Egger"
        };

        public static string[] streets = new string[]
          {
            "Hausstraße",
            "Steinerweg",
            "Traunstraße",
            "Hauptstraße",
            "Birkenweg",
            "Dorfstraße",
            "Sonnenweg",
            "Wiesenweg",
            "Gartengasse",
            "Mitterweg",
            "Mühlgasse",
            "Kirchenplatz",
            "Auweg",
            "Industriestraße",
            "Feldweg",
            "Erlenweg",
            "Neubaugasse",
            "Rosenweg"
        };

        public static string[] cities = new string[]
        {
            "Linz",
            "Traun",
            "Leonding",
            "Pasching",
            "Puchenau",
            "Urfahr",
            "Nußdorf",
            "Eferding",
            "Wels",
            "Tulln",
            "Wien",
            "Karlsdorf",
            "Eggendorf",
            "Scheibs",
            "Allhartsberg",
            "Sichersdorf",
            "Hochtor",
            "Thernberg"
        };

        public static string[] postcodes = new string[]
        {
            "4030",
            "4020",
            "4070",
            "4060",
            "6543",
            "3040",
            "4090",
            "3200",
            "3270",
            "5030",
            "6767",
            "3222",
            "4545",
            "3001",
            "5200",
            "3434",
            "2010",
            "3440"
        };




        public static async Task<IEnumerable<Examination>> GetExaminationsAsync(IUnitOfWork uow)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            Randomizer randomizer = new Randomizer();
            var examinations = new List<Examination>();
            int count = 0;
            string gen;
            for (int i = 0; i < 100; i++)
            {
                var campains = await uow.CampaignRepository.GetAllAsync();
                var randomCampaign = campains[random.Next(campains.Length)];
                var tc = await uow.TestCenterRepository.GetAllAsync();
                var randomTestCenter = tc[random.Next(tc.Length)];


                if (count % 2 == 0)
                {
                    es = ExaminationStates.New;
                    count++;
                }
                else if (count % 3 == 0)
                {
                    es = ExaminationStates.Registered;
                    count++;
                }
                else
                {
                    es = ExaminationStates.Tested;
                    count++;
                }


                if (count % 2 == 0)
                {
                    tr = CoronaTest.Core.Enums.TestResult.Negative;
                    
                }
                else if (count % 3 == 0)
                {
                    tr = CoronaTest.Core.Enums.TestResult.Positive;
                    
                }
                else
                {
                    tr = CoronaTest.Core.Enums.TestResult.Unknown;
                    
                }


                if (count % 2 == 0)
                {
                    gen = "männlich";
                   
                }
                else
                {
                    gen = "weiblich";
                    
                }



                var participant = new Participant();

                var firstName = firstNameArray[random.Next(firstNameArray.Length)];
                var city = cities[random.Next(cities.Length)];
                var range = TimeSpan.FromDays(random.Next(7300, 29000));
                var postcode = postcodes[random.Next(postcodes.Length)];
                var digitsSVNR = $"{random.Next(100000, 1000000)}";

              

                participant.FirstName = firstName;
                participant.LastName = lastNameArray[random.Next(lastNameArray.Length)];
                participant.Gender = gen;
                participant.Birthdate = DateTime.Now.Subtract(range).Date;
                participant.Mobilenumber = $"+436{random.Next(100000000, 999999999)}";
                var svnr = $"{digitsSVNR}{participant.Birthdate}";
                participant.SocialSecurityNumber = svnr;
                participant.Postcode = postcode;
                participant.City = city;
                participant.Street = streets[random.Next(streets.Length)];
                participant.HouseNr = $"{random.Next(1, 99)}";
                participant.Door = $"{random.Next(1, 65)}";
                participant.Place =
                participant.Stair = $"{random.Next(1, 10)}";


                var examination = new Examination
                {
                    Campaign = randomCampaign,
                    Participant = participant,
                    TestCenter = randomTestCenter,
                    TestResult = tr,
                    State = es,
                  //  ExaminationAt = allSlots.Time,
                    Identifier = randomizer.Next().ToString()
                };
                examinations.Add(examination);
            }
            return examinations;


        }


    }
}
