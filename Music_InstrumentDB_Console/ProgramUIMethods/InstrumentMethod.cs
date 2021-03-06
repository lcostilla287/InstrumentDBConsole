using Music_InstrumentDB_Console.POCO;
using Music_InstrumentDB_Console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.ProgramUIMethods
{
    public class InstrumentMethod
    {
        private InstrumentService _instrumentService = new InstrumentService();

        public void ImplementBearerToken(string bearerToken)
        {
            _instrumentService.Authorization(bearerToken);
        }

        
        public void CreateAnInstrument()
        {
            Instrument instrument = new Instrument();

            Console.Write("Please enter an instrument name: ");
            instrument.InstrumentName = Console.ReadLine();

            Console.Write("Enter the Description of this instrument: ");
            instrument.Description = Console.ReadLine();

            Console.Write("Enter the transposition of the instrument: ");
            instrument.Transposition = Console.ReadLine();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Write("Does the instrument belong to an instrument family?(y/n)");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        Console.WriteLine("Please enter the family Id that it belongs to: ");
                        instrument.FamilyId = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "n":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;
                }
            }

            bool addedSuccessfully = _instrumentService.PostInstrumentAsync(instrument).Result;
            if (addedSuccessfully)
            {
                Console.WriteLine("The Instrument was successfully added");
            }
            else
            {
                Console.WriteLine("The instrument could not be added");
            }
            Console.ReadKey();
        }

        
        public void GetAllInstruments()
        {
            Console.Clear();
            Console.WriteLine("Here are the instruments currently in the database");
            Console.WriteLine("==================================================");
            List<Instrument> instruments = _instrumentService.GetAllInstrumentsAsync().Result;
            if (instruments.Count > 0)
            {
                Console.WriteLine("ID\t\tInstrument Name");
                Console.WriteLine("----------------------------------");
                foreach (Instrument i in instruments)
                {
                    Console.WriteLine($"{ i.InstrumentId}\t\t{i.InstrumentName}");
                    //Console.Write($"Instrument name: {i.InstrumentName}");
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine("Could not locate instruments");
            }
            Console.ReadKey();
        }

        
        public void GetInstrumentByIdAsync()
        {
            Console.Clear();
            Console.Write("Please enter the Id of the instrument you would like to get:");

            Instrument instrument = _instrumentService.GetInstrumentAsync(Convert.ToInt32(Console.ReadLine())).Result;
            if (instrument != null)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"ID: {instrument.InstrumentId}");
                Console.WriteLine($"InstrumentName: {instrument.InstrumentName}");
                Console.WriteLine($"Description: {instrument.Description}");
                Console.WriteLine($"Transposition: {instrument.Transposition}");
                if (instrument.FamilyId != null)
                {
                    Console.WriteLine($"Instrument Family: {instrument.InstrumentFamilyName}");
                }
                else
                {
                    Console.WriteLine("This instrument has not been put in and instrument family");
                }
                if (instrument.Musicians.Count > 0)
                {
                    Console.Write("Played by:");
                    foreach (Musician m in instrument.Musicians)
                    {
                        Console.Write(m.FullName);
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no instrument by that id");
            }
            Console.ReadKey();
        }
        //look at this in api so we can get all the info back
        public void SearchInstrumentByName()
        {
            Console.Clear();
            Console.Write("What is the name of the instrument that you would like to search for? ");
            string input = Console.ReadLine();
            List<Instrument> instruments = _instrumentService.GetSearchAsync(input).Result;
            if (instruments.Count > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Here are the results of you search");
                Console.WriteLine("==================================");
                foreach (Instrument i in instruments)
                {
                    Console.WriteLine($"ID: {i.InstrumentId}");
                    Console.WriteLine($"Instrument name: {i.InstrumentName}");
                    Console.WriteLine($"Description: {i.Description}");
                    Console.WriteLine($"Transposition: {i.Transposition}");
                    if (i.FamilyId != null)
                    {
                        Console.WriteLine($"Instrument Family: {i.InstrumentFamilyName}");
                    }
                    else
                    {
                        Console.WriteLine("This instrument has not been put in and instrument family");
                    }
                    if (i.Musicians != null)
                    {
                        Console.Write("Played by:");
                        foreach (Musician m in i.Musicians)
                        {
                            Console.Write(m.FullName);
                        }
                    }
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine("There are no instruments by that name");
            }
            Console.ReadKey();
        }

        public void EditAnInstrument()
        {
            Console.Clear();

            Console.WriteLine("Please enter the Id of the instrument you would like to edit.");

            Instrument instrument = _instrumentService.GetInstrumentAsync(Convert.ToInt32(Console.ReadLine())).Result;
            if (instrument != null)
            {
                bool keepRunning = true;
                while (keepRunning)
                {
                    Console.Clear();

                    Console.WriteLine($" You are editing {instrument.InstrumentName}");
                    Console.WriteLine("Is this correct?(y/n)");

                    switch (Console.ReadLine())
                    {
                        case "y":
                            HelpEditInstrument(instrument.InstrumentId);
                            break;
                        case "n":
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Please select a valid option");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no instrument by that id");
            Console.ReadKey();
            }
        }
        //works
        public void HelpEditInstrument(int instrumentId)
        {
            Instrument instrument = _instrumentService.GetInstrumentAsync(instrumentId).Result;

            Console.Write("Please enter a new instrument name: ");
            instrument.InstrumentName = Console.ReadLine();

            Console.Write("Enter the new description of this instrument: ");
            instrument.Description = Console.ReadLine();

            Console.Write("Enter the transposition of the instrument: ");
            instrument.Transposition = Console.ReadLine();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Write("Does the instrument belong to an instrument family?(y/n)");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        Console.WriteLine("Please enter the family Id that it belongs to: ");
                        instrument.FamilyId = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "n":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;
                }
            }
            bool wasUpdated = _instrumentService.PutInstrumentAsync(instrumentId, instrument).Result;
            if (wasUpdated)
            {
                Console.WriteLine($"{instrument.InstrumentName} was successfully updated");
            }
            else
            {
                Console.WriteLine($"{instrument.InstrumentName} could not be updated");
            }
            Console.ReadKey();
        }
        //works
        public void DeleteAnInstrument()
        {
            Console.Write("Please enter the Id of the instrument you want to delete: ");


            bool wasDeleted = _instrumentService.DeleteInstrumentAsync(Convert.ToInt32(Console.ReadLine())).Result;

            if (wasDeleted)
            {
                Console.WriteLine("The instrument was successfully deleted");
            }
            else
            {
                Console.WriteLine("The instrument could not be deleted.");
                Console.WriteLine("Please check to see if you have the correct Instrument ID or get rid of all musicians referencing this instrument.");
            }
            Console.ReadKey();
        }
    }
}
