using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.ProgramUIMethods
{
    public class InstrumentMethod
    {
        public void InstrumentAccess()
        {
            InstrumentMenu();
        }

        public void InstrumentMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. Get all instruments\n" +
                    "2. Get instrument by ID\n" +
                    "3. Go Back");

                switch (Console.ReadLine())
                {
                    case "1":
                        GetAllInstruments();
                        break;
                    case "2":
                        GetInstrumentById();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void GetAllInstruments()
        {
            Console.WriteLine("We are getting all instruments");
            Console.ReadKey();
            InstrumentMenu();
        }

        private void GetInstrumentById()
        {
            Console.WriteLine("We are getting an instrument by Id");
            Console.ReadKey();
        }
    }
}
