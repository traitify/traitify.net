using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Badge
    {
        [JsonProperty]
        public String image_small { get; set; }
        [JsonProperty]
        public String image_medium { get; set; }
        [JsonProperty]
        public String image_large { get; set; }
        [JsonProperty]
        public String font_color { get; set; }
        [JsonProperty]
        public String color_1 { get; set; }
        [JsonProperty]
        public String color_2 { get; set; }
        [JsonProperty]
        public String color_3 { get; set; }
    }
}
