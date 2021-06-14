using Music_InstrumentDB_Console.POCO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.Services
{
    public class MusicianService
    {
        private HttpClient _httpClient = new HttpClient();
        public void Authorization(string accesstoken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
        }

        public async Task<Musician> GetMusicianAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44363/api/Musician/{id}");

            if (response.IsSuccessStatusCode)
            {
                Musician musician = await response.Content.ReadAsAsync<Musician>();
                return musician;
            }
            return null;
        }

        //public async Task<List<Musician>> GetAllMusicianAsnc()
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44363/api/Musician");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Musician musician = await response.Content.ReadAsAsync<Musician>();
        //        var list = JsonConvert.DeserializeObject<List<Musician>>(musician);
        //        return list;
        //    }
        //    return null;
        //}

        public async Task<bool> PostMusicianAsync (Musician newMusician)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"https://localhost:44363/api/Musician", newMusician);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> PutMusicianAsync(int id, Musician updatedMusician)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"https://localhost:44363/api/Musician", updatedMusician);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMusicianAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:44363/api/Musician/{id}");

            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            return false;
        }
    }
}
