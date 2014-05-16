using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PersonalityGroup
    {
        [JsonProperty]
        public String id { get; set; }
        [JsonProperty]
        public String name { get; set; }
        [JsonProperty]
        public Nullable<Boolean> active { get; set; }
        [JsonProperty]
        public List<Deck> decks { get; set; }
        [JsonProperty]
        public List<PersonalityType> personality_types { get; set; }
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
    }
}
