using CoronaTest.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LoadExamination
{
    public class Program
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
            await using var unitOfWork = new UnitOfWork();


            Console.WriteLine("Untersuchungen werden eingelesen");
            var examinations = (await LoadExaminations.GetExaminationsAsync(unitOfWork)).ToArray();
            Console.WriteLine($"  {examinations.Count()} Untersuchungen eingelesen");

            await unitOfWork.ExaminationRepository.AddRangeAsync(examinations);

            Console.WriteLine("Untersuchungen werden in Datenbank gespeichert (persistiert)");
            await unitOfWork.SaveChangesAsync();


            var cntExaminations = await unitOfWork.ExaminationRepository.GetCountAsync();

            Console.WriteLine($"  Es wurden {cntExaminations} Kampagnen gespeichert!");

            
        }
    }
}
