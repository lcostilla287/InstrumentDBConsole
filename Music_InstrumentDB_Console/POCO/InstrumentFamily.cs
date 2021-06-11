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
        [JsonProperty("family_id")]
        public int FamilyId { get; set; }
        
        [JsonProperty("owner_id")]
        public Guid OwnerId { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("tuning")]
        public string Tuning { get; set; }

        //[JsonProperty("instruments")]
        //public virtual List<Instrument> Instruments { get; set; } = new List<Instrument>();
    }
}
