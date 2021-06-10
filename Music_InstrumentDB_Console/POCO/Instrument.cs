using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.POCO
{
    public class Instrument
    {
        [JsonProperty("InstrumentId")]
        public int InstrumentId { get; set; }

        [JsonProperty("InstrumentName")]
        public string InstrumentName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Transposition")]
        public string Transposition { get; set; }

        [JsonProperty("FamilyId")]
        public object FamilyId { get; set; }

        [JsonProperty("InstrumentFamilyName")]
        public string InstrumentFamilyName { get; set; }

        [JsonProperty("FamousMusicians")]
        public List<Musician> Musicians { get; set; }
    }
}
