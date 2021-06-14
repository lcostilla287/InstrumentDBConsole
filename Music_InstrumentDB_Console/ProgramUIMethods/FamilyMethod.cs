using Music_InstrumentDB_Console.POCO;
using Music_InstrumentDB_Console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.ProgramUIMethods
{
    public class FamilyMethod
    {
        //private Authentication authentication = new Authentication();
        private HttpClient httpClient = new HttpClient();

        FamilyService _familyService = new FamilyService();
        public void ImplementBearerToken(string bearerToken)
        {
            _familyService.Authorization(bearerToken);
        }

        public void CreateNewInstrumentFamily()
        {
            Console.WriteLine("Please enter the name that you would like to assign to the new instrument family...");
            Console.ReadKey();
        }

        public void ViewAllInstrumentFamiliesAsync()
        {
            Console.WriteLine("Returning all instrument families...");
            List<InstrumentFamily> instrumentFamily = _familyService.GetAllFamiliesAsync().Result;
            if (instrumentFamily != null)
            {
                foreach (InstrumentFamily family in instrumentFamily)
            {
                    Console.WriteLine(family.FamilyId);
                    Console.WriteLine(family.FamilyName);
                    Console.WriteLine(family.Description);
                    Console.WriteLine(family.Classification);
                    Console.WriteLine(family.Tuning);
                }
            }
            else
            {
                Console.WriteLine("WARNING:  The instrument family could not be located; please select another option.");
            }

        }

        public void ViewInstrumentFamiliesById()
        {
            Console.Clear();
            Console.Write("Please enter the ID of the instrument family you would like to view:  ");

            InstrumentFamily instrumentFamily = _familyService.GetFamilyAsync(Convert.ToInt32(Console.ReadLine())).Result;
            if (instrumentFamily != null)
            {
                Console.WriteLine(instrumentFamily.FamilyId);
                Console.WriteLine(instrumentFamily.FamilyName);
                Console.WriteLine(instrumentFamily.Description);
                Console.WriteLine(instrumentFamily.Classification);
                Console.WriteLine(instrumentFamily.Tuning);
                Console.WriteLine(instrumentFamily.Instruments);
            }
            else
            {
                Console.Write("WARNING: The selected instrument family could not be located; please select another option:  ");
            }
            Console.ReadKey();
        }

        public void UpdateInstrumentFamily()
        {
            Console.Clear();
            ViewAllInstrumentFamiliesAsync();
            Console.WriteLine("Please select the paramater you would like to update in this instrument family:\n" +
                "1. Family Name\n" +
                "2. Description\n" +
                "3. Classification\n" +
                "4. Tuning\n" +
                "5. Return");

            Console.ReadLine();
            Console.ReadKey();

            Console.WriteLine("Which instrument family would you like to edit?");

            string familyParameter = Console.ReadLine();

            InstrumentFamily editFamily = new InstrumentFamily();
        }

        public void DeleteInstrumentFamily()
        {
            Console.WriteLine("Which instrument family would you like to delete?\n\n" +
                "WARNING:  Please remember that all instruments and related musicians must be removed from the instrument family before deleting the family!");
            Console.ReadLine();
            Console.WriteLine("Would you like to proceed?");

            Console.ReadKey();
        }
    }
}

