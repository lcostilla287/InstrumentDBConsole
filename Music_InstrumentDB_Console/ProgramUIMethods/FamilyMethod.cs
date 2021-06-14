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
        

        public void CreateNewInstrumentFamily()
        {
            Console.WriteLine("Please enter the name that you would like to assign to the new instrument family...");
            Console.ReadKey();
        }

        public void ViewAllInstrumentFamiliesAsync()
        {
            Console.WriteLine("Returning all instrument families...");
            InstrumentFamily instrumentFamily = _familyService.GetAllFamiliesAsync().Result;
            if (instrumentFamily != null)
            {
                Console.WriteLine($"Family Name: {instrumentFamily.FamilyName}\n" +
                    $"Description: {instrumentFamily.Description}\n" +
                    $"Classification: {instrumentFamily.Classification}\n" +
                    $"Tuning: {instrumentFamily.Tuning}\n");
            }
            else
            {
                Console.WriteLine("Sorry...no instrument families exist!");
            }
            Console.ReadKey();

        }

        public void ViewInstrumentFamiliesById()
        {
            Console.WriteLine("Returning selected instrument family...");
            Console.ReadKey();
        }

        public void UpdateInstrumentFamily()
        {
            Console.WriteLine("Which instrument family would you like to edit?");
            Console.ReadKey();
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

