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

        //works
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

        //Work on this
        public void GetAllInstruments()
        {
            Console.WriteLine("We are getting all instruments");
            Instrument instruments = _instrumentService.GetAllInstrumentsAsync().Result;
            if (instruments != null)
            {
                Console.WriteLine(instruments.InstrumentName);
            }
            else
            {
                Console.WriteLine("Could not locate instruments");
            }
            Console.ReadKey();
        }

        //works
        public void GetInstrumentByIdAsync()
        {
            Console.WriteLine("We are getting an instrument by Id");
            Console.WriteLine("Please enter the Id of the instrument you would like to get.");

            Instrument instrument = _instrumentService.GetInstrumentAsync(Convert.ToInt32(Console.ReadLine())).Result;
            if (instrument != null)
            {
                Console.WriteLine(instrument.InstrumentName);
            }
            else
            {
                Console.WriteLine("There is no instrument by that id");
            }
            Console.ReadKey();
        }

        public void EditAnInstrument()
        {
            Console.Clear();
            Console.WriteLine("We are editing an instrument");

            Console.WriteLine("Please enter the Id of the instrument you would like to get.");

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
                            EditAnInstrument();
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
            }
            Console.ReadKey();
        }

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
                Console.WriteLine("The instrument could not be deleted");
            }
            Console.ReadKey();
        }
    }
}
