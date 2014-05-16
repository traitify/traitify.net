using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.traitify.net.TraitifyLibrary;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TraitifyUnitTests
{
    [TestClass]
    public class TraitifyUnitTests
    {
        [TestMethod]
        public void TestCreateAssessment()
        {
            Traitify trait = new Traitify("https://???", "???", "???", "v1");
            var response = trait.CreateAssesment("???");
        }


        //Get Assessment Slides
        [TestMethod]
        public void TestGetAssessment()
        {
            Traitify trait = new Traitify("???", "???", "???", "v1");
            var response = trait.GetAssessment("????");
        }

        //Get Decks
        [TestMethod]
        public void TestGetDecks()
        {
            Traitify traitify = new Traitify("???", "???", "???", "v1");
            List<Deck> decks = traitify.GetDecks();
            int mycount = decks.Count;
        }
        //Get Assessment Slides

        //Set Assessment Slide

        //Get Assessment Personality Types

    }
}
