using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.traitify.net.TraitifyLibrary;

namespace TraitifyUnitTests
{
    [TestClass]
    public class TraitifyUnitTests
    {
        [TestMethod]
        public void TestCreateAssessment()
        {
            //Base URL: https://api-staging.traitify.com. 
            //Private/Secret Key: qrn5u1ocl0niru9ntl0160njrc
            //Public Key: qop22g5tmrcgl270nuhel9cq9g
            Traitify trait = new Traitify("https://api-staging.traitify.com", "qop22g5tmrcgl270nuhel9cq9g", "qrn5u1ocl0niru9ntl0160njrc", "v1");
            var response = trait.CreateAssesment("304d0392-4a08-4ef6-a996-224324a9f6f8");
        }

        //Get Assessment Slides
        [TestMethod]
        public void TestGetAssessment()
        {
            Traitify trait = new Traitify("https://api-staging.traitify.com", "qop22g5tmrcgl270nuhel9cq9g", "qrn5u1ocl0niru9ntl0160njrc", "v1");
            var response = trait.GetAssessment("35c80356-9a5c-4ef7-97d9-d46d5d1726d8");
        }

        //Get Assessment Slides

        //Set Assessment Slide

        //Get Assessment Personality Types

    }
}
