using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AssessmentPersonalityTrait
    {
        [JsonProperty(PropertyName = "personality_trait")]
        public PersonalityTrait Personality_Trait { get; set; }
        [JsonProperty(PropertyName="score")]
        public float Score { get; set; }
    }
}
