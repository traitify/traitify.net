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
        public String id { get; set; }
        public Nullable<int> position { get; set; }
        public String caption { get; set; }
        public String image_desktop { get; set; }
        public String image_desktop_retina { get; set; }
        public String image_phone_landscape { get; set; }
        public String image_phone_portrait { get; set; }
        public Boolean response { get; set; }
        public Nullable<int> time_taken { get; set; }
        public Nullable<DateTime> completed_at { get; set; }
        public Nullable<DateTime> created_at { get; set; }
    }
}
