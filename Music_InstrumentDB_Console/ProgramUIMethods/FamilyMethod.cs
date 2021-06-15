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
            Console.Clear();
            InstrumentFamily newFamily = new InstrumentFamily();

            Console.Write("\nPlease enter the name that you would like to assign to the new instrument family:  \n");
            newFamily.FamilyName = Console.ReadLine();

            Console.WriteLine("\nPlease enter a description for this new instrument family:  \n");
            newFamily.Description = Console.ReadLine();

            Console.WriteLine("\nPlease enter a classification for this instrument family:  \n");
            newFamily.Classification = Console.ReadLine();

            Console.WriteLine("\nPlease enter the tuning(s) for this instrument family:  \n");
            newFamily.Tuning = Console.ReadLine();

            bool addSuccess = _familyService.PostFamilyAsync(newFamily).Result;
            if (addSuccess)
            {
                Console.WriteLine("\nCongratulations!  You have successfully created an new instrument family!\n\n" +
                    "Press any key to continue...");                
            }
            else
            {
                Console.WriteLine("The instrument family could not be added.\n\n" +
                    "Please return to the Main Menu by pressing any key...");
            }

            Console.ReadKey();
        }

        public void ViewAllInstrumentFamiliesAsync()
        {
            Console.Clear();
            Console.WriteLine("Returning all instrument families...\n");
            List<InstrumentFamily> instrumentFamily = _familyService.GetAllFamiliesAsync().Result;
            var time = 2000;
            Task<List<InstrumentFamily>>.Delay(time);
            if (instrumentFamily != null)
            {
                foreach (InstrumentFamily family in instrumentFamily)
                {
                    Console.WriteLine("===================================================");
                    Console.WriteLine($"Family ID:  {family.FamilyId}");
                    Console.WriteLine($"Family Name:  {family.FamilyName}");
                    Console.WriteLine($"\nDescription:  \n{ family.Description}\n");
                    Console.WriteLine($"Classification:  { family.Classification}");
                    Console.WriteLine($"Tuning:  {family.Tuning}\n\n");
                }
                Console.WriteLine("Press any key to continue...");
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

            InstrumentFamily famById = _familyService.GetFamilyAsync(Convert.ToInt32(Console.ReadLine())).Result;
            if (famById != null)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"Family ID:  {famById.FamilyId}");
                Console.WriteLine($"Family Name:  {famById.FamilyName}");
                Console.WriteLine($"\nDescription:  \n{ famById.Description}\n");
                Console.WriteLine($"Classification:  { famById.Classification}");
                Console.WriteLine($"Tuning:  {famById.Tuning}\n\n");
                Console.WriteLine("Press any key to continue...");
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
            Console.Write("Please enter the ID of the instrument family you would like to edit:  ");


            InstrumentFamily getFamEdit = _familyService.GetFamilyAsync(Convert.ToInt32(Console.ReadLine())).Result;
            Console.WriteLine("\nPlease select the paramater you would like to update in this instrument family:\n" +
                "1. Family Name\n" +
                "2. Description\n" +
                "3. Classification\n" +
                "4. Tuning\n" +
                "5. Return\n");

            string editFam = Console.ReadLine();
            
            switch (editFam)
            {
                case "1":
                    getFamEdit.FamilyName = Console.ReadLine();
                    bool nameUpdate = _familyService.PutFamilyAsync(getFamEdit.FamilyId, getFamEdit).Result;
                    if (nameUpdate)
                    {
                        Console.WriteLine("The instrument family NAME was updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("The parameter could not be updated.  Please return to the previous menu.\n\n" +
                            "Press any key to continue...");
                    }
                    break;
                case "2":
                    getFamEdit.Description = Console.ReadLine();
                    bool descUp = _familyService.PutFamilyAsync(getFamEdit.FamilyId, getFamEdit).Result;
                    if (descUp)
                    {
                        Console.WriteLine("The instrument family DESCRIPTION was updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("The parameter could not be updated.  Please return to the previous menu.");
                    }
                    break;
                case "3":
                    getFamEdit.Classification = Console.ReadLine();
                    bool classUp = _familyService.PutFamilyAsync(getFamEdit.FamilyId, getFamEdit).Result;
                    if (classUp)
                    {
                        Console.WriteLine("The instrument family CLASSIFICATION was updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("The parameter could not be updated.  Please return to the previous menu.");
                    }
                    break;
                case "4":
                    getFamEdit.Tuning = Console.ReadLine();
                    bool tuneUp = _familyService.PutFamilyAsync(getFamEdit.FamilyId, getFamEdit).Result;
                    if (tuneUp)
                    {
                        Console.WriteLine("The instrument family TUNING was updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("The parameter could not be updated.  Please return to the previous menu.");
                    }
                    break;
                case "5":
                    UpdateInstrumentFamily();
                    break;               
                default:
                    Console.WriteLine("Please enter a valid number");
                    break;
            }

            Console.ReadKey();                
            
            InstrumentFamily editFamily = new InstrumentFamily();
        }

        public void DeleteInstrumentFamily()
        {
            Console.Write("Which instrument family would you like to delete?\n\n" +
                "WARNING:  Please remember that all instruments and related musicians must be removed from the instrument family before deleting the family!\n\n" +
                "Press any key to continue...\n");
            Console.ReadLine();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Would you like to proceed? Y/N");
                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "y":
                        Console.WriteLine("Please enter the ID of the instrument family you would like to delete:  ");
                        bool wasDeleted = _familyService.DeleteFamilyAsync(Convert.ToInt32(Console.ReadLine())).Result;
                        if (wasDeleted)
                        {
                            Console.WriteLine("The instrument family has been successfully removed!");
                        }
                        else
                        {
                            Console.Write("The instrument family could not be deleted; please select another option:  ");
                        }
                        Console.ReadKey();
                        break;
                    case "n":
                        keepRunning = false;
                        break;
                    default:
                        Console.Write("Please select a vaid option:  ");
                        Console.ReadKey();
                        break;
                }

            }

            Console.ReadKey();
        }
    }
}

