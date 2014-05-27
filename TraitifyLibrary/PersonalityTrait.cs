using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PersonalityTrait
    {
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "definition")]
        public string Definition { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
