using ClassLibrary1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CoronaTest.ImportController
{
    public class ImportController
    {
         
        public static IEnumerable<Campaign> ReadFromCsv()
        {

            var csvCampaign = "Campaign.csv".ReadStringMatrixFromCsv(true);
            var csvTestCenter = "TestCenter.csv".ReadStringMatrixFromCsv(true);

            var testCenters = csvTestCenter
                .Select(grp => new TestCenter 
                { 
                    Name = grp[0],
                    City = grp[1],
                    Postcode = grp[2],
                    Street = grp[3],
                    SlotCapacity = Int32.Parse(grp[4])
                })
                .ToList();
            var campagins = csvCampaign
                .Select(grp => new Campaign 
                { 
                    Examinations = Int32.Parse(grp[0]),
                    From = DateTime.Parse(grp[1]),
                    To = DateTime.Parse(grp[2]),
                    Name = grp[3],
                    AvailableTestCenters = grp[4].Select(t => testCenters[t]).ToList()
                })
                .ToList();
            
            return campagins;
        }

    }
}
