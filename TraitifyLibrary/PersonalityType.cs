using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PersonalityType
    {
        [JsonProperty]
        public String id { get; set; }
        [JsonProperty]
        public String name { get; set; }
        [JsonProperty]
        public String description { get; set; }
        [JsonProperty]
        public Badge badge { get; set; }
    }
}
