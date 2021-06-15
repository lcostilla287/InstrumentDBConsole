using Music_InstrumentDB_Console.POCO;
using Music_InstrumentDB_Console.ProgramUIMethods;
using Music_InstrumentDB_Console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console
{
    public class ProgramUI
    {
        private Authentication authentication = new Authentication();

        FamilyMethod _familyMethod = new FamilyMethod();


        private MusicianMethod _musicianMethod = new MusicianMethod();

        private InstrumentMethod _instrumentMethod = new InstrumentMethod();
        


        public void Run()
        {
            Login();
        }

        private void Login()
        {
            bool login = true;
            while (login)
            {
                Console.Clear();
                Console.WriteLine("1. Login\n" +
                    "2. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        EnterLogin();
                        login = false;
                        break;
                    case "2":
                        login = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void EnterLogin()
        {
            int loginAttempt = 1;
            while (loginAttempt <= 3)
            {
            Console.Clear();
            Console.Write("Username: ");
            string userName = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

                Token token = authentication.GetToken(userName, password);
                if (token.AccessToken != null)
                {

                    Console.WriteLine("\n\nWelcome!\n\n");
                    _familyMethod.ImplementBearerToken(token.AccessToken);
                    Console.WriteLine("Press any key to continue...");

                    _musicianMethod.ImplementBearerToken(token.AccessToken);

                    _instrumentMethod.ImplementBearerToken(token.AccessToken);


                    Console.ReadKey();

                    Menu();
                }
                else
                {
                    Console.WriteLine("Incorrect username or password");
                    loginAttempt++;
                    Console.ReadKey();
                }
            }
            if (loginAttempt > 3)
            {
                Console.WriteLine("You have failed 3 login attempts. The program will now end.");
                SystemSounds.Hand.Play();
                Console.ReadKey();
            }
        }

        private void Menu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Access Instrument Families\n" +
                    "2. Access Instruments\n" +
                    "3. Access Musicians\n" +
                    "4. Log Out");

                switch (Console.ReadLine())
                {
                    case "1":
                        InstrumentFamilyAccess();
                        break;
                    case "2":
                        InstrumentAccess();
                        break;
                    case "3":
                        MusicianAccess();
                        break;
                    case "4":
                        runMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        Menu();
                        break;
                }
            }
        }
        public void InstrumentFamilyAccess()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("You are now accessing Instrument Familes. What would you like to do?");
                Console.WriteLine("\nSelect a menu option:\n" +
                    "1. Create Instrument Family\n" + // Post
                    "2. View All Instrument Families\n" + // Get
                    "3. View Instrument Families by ID\n" + // Get By ID
                    "4. Update Instrument Family\n" + // Put
                    "5. Delete Instrument Family\n" + // Delete
                    "6. Return to the Main Menu\n");


                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _familyMethod.CreateNewInstrumentFamily(); 
                        break;
                    case "2":
                        _familyMethod.ViewAllInstrumentFamiliesAsync();
                        break;
                    case "3":
                        _familyMethod.ViewInstrumentFamiliesById();
                        break;
                    case "4":
                        _familyMethod.UpdateInstrumentFamily();
                        break;
                    case "5":
                        _familyMethod.DeleteInstrumentFamily();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.ReadKey();
            }
        }

        private void InstrumentAccess()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("You are now accessing instruments. What would you like to do?");
                Console.WriteLine("1. Create an instrument\n" +
                    "2. View instrument by id\n" +
                    "3. View all instruments\n" +
                    "4. Edit an instrument\n" +
                    "5. Delete an instrument\n" +
                    "6. Search Instrument by name\n" +
                    "7. Go Back");

                switch (Console.ReadLine())
                {
                    case "1":
                        _instrumentMethod.CreateAnInstrument();
                        break;
                    case "2":
                        _instrumentMethod.GetInstrumentByIdAsync();
                        break;
                    case "3":
                        _instrumentMethod.GetAllInstruments();
                        break;
                    case "4":
                        _instrumentMethod.EditAnInstrument();
                        break;
                    case "5":
                        _instrumentMethod.DeleteAnInstrument();
                        break;
                    case "6":
                        _instrumentMethod.SearchInstrumentByName();
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        Menu();
                        break;
                }
            }
        }
        private void MusicianAccess()

        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("You are now accessing musicians. What would you like to do?");
                Console.WriteLine("1. Create a musician\n" +
                    "2. View a musician by id\n" +
                    "3. View all musicians\n" +
                    "4. Edit a musician\n" +
                    "5. Delete a musician\n" +
                    "6. Search for a musician by name\n" +
                    "7. Go back");

                switch (Console.ReadLine())
                {
                    case "1":
                        _musicianMethod.CreateMusician();
                        break;
                    case "2":
                        _musicianMethod.DisplayMusicianById();
                        break;
                    case "3":
                        _musicianMethod.DisplayAllMusicians();
                        break;
                    case "4":
                        _musicianMethod.EditMusician();
                        break;
                    case "5":
                        _musicianMethod.DeleteMusician();
                        break;
                    case "6":
                        _musicianMethod.SearchMusicianByName();
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        Menu();
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
