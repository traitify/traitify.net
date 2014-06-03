using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AssessmentPersonalityTypes
    {
        [JsonProperty]
        public string personality_blend { get; set; }

        [JsonProperty]
        public List<AssessmentPersonalityType> personality_types { get; set; }
    }
}
