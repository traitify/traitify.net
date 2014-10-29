using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Deck
    {
        [JsonProperty]
        public String id { get; set; }
        [JsonProperty]
        public String name { get; set; }
        [JsonProperty]
        public String description { get; set; }
        [JsonProperty]
        public String personality_group { get; set; }
        [JsonProperty]
        public Nullable<Int64> created_at { get; set; }
        public DateTime CreatedAt 
        { 
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
                return epoch.AddMilliseconds(this.created_at.Value); 
            }
        }
        [JsonProperty]
        public Nullable<Int32> slide_count { get; set; }
        [JsonProperty]
        public Nullable<Boolean> active { get; set; }
    }
}
