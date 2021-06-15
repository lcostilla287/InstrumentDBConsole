using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.POCO
{
    public class InstrumentFamily
    {
        [JsonProperty("FamilyId")]
        public int FamilyId { get; set; }      
    
        [JsonProperty("FamilyName")]
        public string FamilyName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Classification")]
        public string Classification { get; set; }

        [JsonProperty("Tuning")]
        public string Tuning { get; set; }

        [JsonProperty("Instruments")]
        public List<Instrument> Instruments { get; set; }
    }
}
