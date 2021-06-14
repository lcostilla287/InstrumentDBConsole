using Music_InstrumentDB_Console.POCO;
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


        private void InstrumentFamilyAccess()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create Instrument Family" + // Post
                    "2. View All Instrument Families" + // Get
                    "3. View Instrument Families by ID" + // Get By ID
                    "4. Update Instrument Family" + // Put
                    "5. Delete Instrument Family" + // Delete
                    "6. Return");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewInstrumentFamily();
                        break;
                    case "2":
                        ViewAllInstrumentFamilies();
                        break;
                    case "3":
                        ViewInstrumentFamiliesById();
                        break;
                    case "4":
                        UpdateInstrumentFamily();
                        break;
                    case "5":
                        DeleteInstrumentFamily();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
        }

        private void CreateNewInstrumentFamily()
        {
            Console.WriteLine("Please enter the name that you would like to assign to the new instrument family...");
            Console.ReadKey();
        }

        private void ViewAllInstrumentFamilies()
        {
            Console.WriteLine("Returning all instrument families...");
            Console.ReadKey();

        }

        private void ViewInstrumentFamiliesById()
        {
            Console.WriteLine("Returning selected instrument family...");
            Console.ReadKey();
        }

        private void UpdateInstrumentFamily()
        {
            Console.WriteLine("Which instrument family would you like to edit?");
            Console.ReadKey();
        }

        private void DeleteInstrumentFamily()
        {
            Console.WriteLine("Which instrument family would you like to delete?\n\n" +
                "WARNING:  Please remember that all instruments and related musicians must be removed from the instrument family before deleting the family!");
                Console.ReadLine();
                Console.WriteLine("Would you like to proceed?");
                
            Console.ReadKey();
        }
    }
}

