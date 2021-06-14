using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.POCO
{
    public class Musician
    {
        [JsonProperty("FamousMusicianId")]
        public int FamousMusicianId { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("InstrumentId")]
        public int InstrumentId { get; set; }
        
        [JsonProperty("InstrumentId")]
        public int InstrumentName { get; set; }

        [JsonProperty("MusicGenre")]
        public string MusicGenre { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
