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

            if (musician != null)
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

        public void DisplayAllMusicians()
        {
            Console.Clear();
            List<Musician> musicians = _musicianService.GetAllMusicianAsnc().Result;

            if (musicians.Count > 0)
            {
                foreach (Musician musician in musicians)
                {
                    Console.WriteLine($"Musician ID:  {musician.FamousMusicianId} \n" +
                    $"Full Name: {musician.FullName} \n" +
                    $"Instrument they play:  {musician.InstrumentName} \n" +
                    $"Instrument ID:  {musician.InstrumentId} \n" +
                    $"Genre:  {musician.MusicGenre} \n");
                }
            }
            else
            {
                Console.WriteLine("Could not find any musicians");
            }
        }

        public void CreateMusician()
        {
            Console.Clear();

            Musician musician = new Musician();

            Console.Write("Please enter the full name of the musician: ");
            musician.FullName = Console.ReadLine();

            Console.Write("Enter the ID of the instrument this musician plays: ");
            musician.InstrumentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a description for this Musician: ");
            musician.Description = Console.ReadLine();

            Console.Write("Enter a genre for this Musician: ");
            musician.MusicGenre = Console.ReadLine();


            bool addedSuccessfully = _musicianService.PostMusicianAsync(musician).Result;
            if (addedSuccessfully)
            {
                Console.WriteLine("The musician was successfully added");
            }
            else
            {
                Console.WriteLine("The musician could not be added");
            }
        }

        public void EditMusician()
        {
            Console.Clear();

            Console.WriteLine("What is the id for the musician you would like to edit?");
            int musicianId = Convert.ToInt32(Console.ReadLine());

            Musician musician = _musicianService.GetMusicianAsync(musicianId).Result;


            Console.Write("Please enter the full name of the musician: ");
            musician.FullName = Console.ReadLine();

            Console.Write("Enter the ID of the instrument this musician plays: ");
            musician.InstrumentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a description for this Musician: ");
            musician.Description = Console.ReadLine();

            Console.Write("Enter a genre for this Musician: ");
            musician.MusicGenre = Console.ReadLine();


            bool addedSuccessfully = _musicianService.PutMusicianAsync(musicianId, musician).Result;
            if (addedSuccessfully)
            {
                Console.WriteLine("The musician was successfully added");
            }
            else
            {
                Console.WriteLine("The musician could not be added");
            }
        }

        public void DeleteMusician()
        {
            Console.Clear();
            Console.WriteLine("Please enter the id of the musician you would like to delete");

            bool wasDeleted = _musicianService.DeleteMusicianAsync(Convert.ToInt32(Console.ReadLine())).Result;

            if(wasDeleted)
            {
                Console.WriteLine("The musician was successfully deleted");
            }
            else
            {
                Console.WriteLine("The musician could not be deleted");
            }
        }
    }
}
