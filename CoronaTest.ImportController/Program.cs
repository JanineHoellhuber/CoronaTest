using CoronaTest.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTest.ImportController
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await InitDataAsync();

            Console.WriteLine();
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        private static async Task InitDataAsync()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("          Import");
            Console.WriteLine("***************************");
            Console.WriteLine("Import der Test Center in die Datenbank");
            await using var unitOfWork = new UnitOfWork();
            Console.WriteLine("Datenbank löschen");
            await unitOfWork.DeleteDatabaseAsync();
            Console.WriteLine("Datenbank migrieren");
            await unitOfWork.MigrateDatabaseAsync();

            Console.WriteLine("Daten werden von csv-Dateien eingelesen");
            var campaigns = ImportController.ReadFromCsv().ToArray();
            Console.WriteLine($"  {campaigns.Count()} Kampagnen eingelesen");

            await unitOfWork.CampaignRepository.AddRangeAsync(campaigns);

            Console.WriteLine("Kampagnen werden in Datenbank gespeichert (persistiert)");
            await unitOfWork.SaveChangesAsync();


            var cntCampaigns = await unitOfWork.CampaignRepository.GetCountAsync();
            var cntzTestCenters = await unitOfWork.TestCenterRepository.GetCountAsync();

            Console.WriteLine($"  Es wurden {cntCampaigns} Kampagnen gespeichert!");
            Console.WriteLine($"  Es wurden {cntzTestCenters} Test Center gespeichert!");


        }
    }
}
