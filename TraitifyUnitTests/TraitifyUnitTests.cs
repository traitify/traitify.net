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
            Traitify trait = new Traitify("https://???", "???", "???", "v1");
            var response = trait.CreateAssesment("??");
        }

        //Get Assessment Slides
        [TestMethod]
        public void TestGetAssessment()
        {
            Traitify trait = new Traitify("???", "???", "???", "v1");
            var response = trait.GetAssessment("????");
        }

        //Get Assessment Slides

        //Set Assessment Slide

        //Get Assessment Personality Types

    }
}
