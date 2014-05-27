using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    //{ 
    //    "id":"ad20511e-f1e6-4e65-b28a-1ca631308dfe",
    //      "deck_id":"304d0392-4a08-4ef6-a996-224324a9f6f8",
    //      "completed_at":null,
    //      "created_at":1400117717972
    //}
    [JsonObject(MemberSerialization.OptIn)]
    public class Assessment
    {
        [JsonProperty]
        public String id { get; set; }
        [JsonProperty]
        public String deck_id { get; set; }
        //[JsonProperty]
        //public String user_id { get; set; }
        [JsonProperty]
        public Nullable<Int64> created_at { get; set; }
        public DateTime CreatedAt { 
            get 
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
                return epoch.AddMilliseconds(this.created_at.Value);
            }
        }
        [JsonProperty]
        public Nullable<Int64> completed_at { get; set; }
    }
}
