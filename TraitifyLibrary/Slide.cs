using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    public class Slide
    {
        public String id { get; set; }
        public int position { get; set; }
        public String caption { get; set; }
        public String image_desktop { get; set; }
        public String image_desktop_retina { get; set; }
        public String image_phone_landscape { get; set; }
        public String image_phone_portrait { get; set; }
        public Boolean response { get; set; }
        public int time_taken { get; set; }
        public DateTime completed_at { get; set; }
        public DateTime created_at { get; set; }
    }
}
