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
        MusicianService _musicianService = new MusicianService();

        public void ImplementBearerToken(string bearerToken)
        {
            _musicianService.Authorization(bearerToken);
        }

        public void DisplayMusicianById()
        {
            Console.Clear();
            Console.WriteLine("What is the id of the musician you would like to search for?");
            int userInput = Convert.ToInt32(Console.ReadLine());

            Musician musician = _musicianService.GetMusicianAsync(userInput).Result;

            if(musician != null)
            {
                Console.WriteLine($"Musician ID:  {musician.FamousMusicianId} \n" +
                    $"Full Name: {musician.FullName} \n" +
                    $"Instrument they play:  {musician.InstrumentName} \n" +
                    $"Instrument ID:  {musician.InstrumentId} \n" +
                    $"Genre:  {musician.MusicGenre} \n" +
                    $"Description: {musician.Description}");
            }
            else
            {
            Console.WriteLine("We could not find a musician with this id");
            }
        }

        //public void DisplayAllMusicians()
        //{
        //    Console.Clear();
        //    List<Musician> allMusicians = _musicianService.GetAllMusicianAsnc();

        //    foreach (Musician musician in allMusicians)
        //    {
        //        Console.ForegroundColor = (ConsoleColor.Green);
        //        Console.WriteLine($"Musician ID:  {musician.FamousMusicianId} \n" +
        //            $"Full Name: {musician.FullName} \n" +
        //            $"Instrument they play:  {musician.InstrumentName} \n" +
        //            $"Instrument ID:  {musician.InstrumentId} \n" +
        //            $"Genre:  {musician.MusicGenre} \n");
        //        Console.ResetColor();
        //    }
        //}
    }
}
