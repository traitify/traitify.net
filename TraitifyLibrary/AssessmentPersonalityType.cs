using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    public class AssessmentPersonalityType
    {
        [JsonProperty]
        public PersonalityType personality_type { get; set; }

        [JsonProperty]
        public Nullable<float> score { get; set; }
    }
}
