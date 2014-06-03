using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Slide
    {
        [JsonProperty]
        public String id { get; set; }
        [JsonProperty]
        public Nullable<int> position { get; set; }
        [JsonProperty]
        public String caption { get; set; }
        [JsonProperty]
        public String image_desktop { get; set; }
        [JsonProperty]
        public String image_desktop_retina { get; set; }
        [JsonProperty]
        public String image_phone_landscape { get; set; }
        [JsonProperty]
        public String image_phone_portrait { get; set; }
        [JsonProperty]
        public Nullable<Boolean> response { get; set; }
        [JsonProperty]
        public Nullable<Int64> time_taken { get; set; }
        [JsonProperty]
        public Nullable<Int64> completed_at { get; set; }
        [JsonProperty]
        public Nullable<Int64> created_at { get; set; }

        public Nullable<DateTime> TimeTaken
        {
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
                if (this.time_taken.HasValue)
                {
                    return epoch.AddMilliseconds(this.time_taken.Value);
                }
                else
                {
                    return null;
                }
            }
        }

        public Nullable<DateTime> CompletedAt
        {
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
                if (this.time_taken.HasValue)
                {
                    return epoch.AddMilliseconds(this.completed_at.Value);
                }
                else
                {
                    return null;
                }
            }
        }

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

