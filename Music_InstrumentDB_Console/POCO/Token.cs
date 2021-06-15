﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.POCO
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty(".issued")]
        public string Issued { get; set; }

        [JsonProperty(".expires")]
        public string Expires { get; set; }

    }
}
