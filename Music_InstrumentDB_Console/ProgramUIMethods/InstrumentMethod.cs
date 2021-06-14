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
        InstrumentService _instrumentService = new InstrumentService();

        public void ImplementBearerToken(string bearerToken) 
        {
            _instrumentService.Authorization(bearerToken);
        }

        public void CreateAnInstrument()
        {

        }
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

        public void GetInstrumentById()
        {
            Console.WriteLine("We are getting an instrument by Id");
            Console.ReadKey();
        }

        public void EditAnInstrument()
        {

        }

        public void DeleteAnInstrument()
        {

        }
    }
}
