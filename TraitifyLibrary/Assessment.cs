using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.traitify.net.TraitifyLibrary
{
    //{ 
    //    "id":"ad20511e-f1e6-4e65-b28a-1ca631308dfe",
    //      "deck_id":"304d0392-4a08-4ef6-a996-224324a9f6f8",
    //      "user_id":null,
    //      "completed_at":null,
    //      "created_at":1400117717972
    //}
    [Serializable]
    public class Assessment
    {
        public String id { get; set; }
        public String deck_id { get; set; }
        public String user_id { get; set; }
        public Nullable<Int64> created_at { get; set; }
        public Nullable<Int64> completed_at { get; set; }
    }
}
