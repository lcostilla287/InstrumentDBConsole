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
    public class MusicianMethod
    {
        MusicianService musicianService = new MusicianService();

        public void DisplayMusicianById()
        {
            Console.Clear();
            Console.WriteLine("What is the id of the musician you would like to search for?");
            int userInput = Convert.ToInt32(Console.ReadLine());

            Musician musician = musicianService.GetMusicianAsync(userInput).Result;

            if(musician != null)
            {
                Console.WriteLine(musician.FullName);
            }
            Console.WriteLine("We could not find a musician with this id");
        }
    }
}
