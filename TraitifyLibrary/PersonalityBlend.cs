using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PersonalityBlend
    {
        [JsonProperty]
        public PersonalityType personality_type_1 { get; set; }

        [JsonProperty]
        public PersonalityType personality_type_2 { get; set; }
    }
}
