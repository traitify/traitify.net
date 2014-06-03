using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.traitify.net.TraitifyLibrary;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Configuration;

namespace TraitifyUnitTests
{
    [TestClass]
    public class TraitifyUnitTests
    {
        private string _host;
        private string _publicKey;
        private string _secretKey;


        [TestInitialize]
        public void Init()
        {
            _host = ConfigurationManager.AppSettings["host"].ToString();
            _publicKey = ConfigurationManager.AppSettings["publicKey"].ToString();
            _secretKey = ConfigurationManager.AppSettings["secretKey"].ToString();

        }

        [TestMethod]
        public void testDeckList()
        {
            List<Deck> decks = listDecks();
            Assert.AreEqual(decks.Count > 0, true); 
        }

        [TestMethod]
        public void TestCreateAssessment()
        {
            Traitify trait = new Traitify(_host, _publicKey, _secretKey, "v1");
            Deck deck = getDeck();

            var response = trait.CreateAssesment(deck.id);
            Assert.AreNotEqual(response, null);
        }


        //Get Assessment Slides
        [TestMethod]
        public void TestGetAssessment()
        {
            Assessment assessment = createAssessment();
            
            Assert.AreNotEqual(assessment.id, null);
        }

        //Get Decks
        [TestMethod]
        public void TestGetDecks()
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1");
            List<Deck> decks = traitify.GetDecks();
            int mycount = decks.Count;
            Assert.AreNotEqual(mycount, 0);
        }
        //Get Assessment Slides
        [TestMethod]
        public void testSlideList()
        {
            List<Slide> slides = listSlides();

            Assert.AreNotEqual(slides.Count, 0);
        }

        [TestMethod]
        public void testSlideBulkUpdate() 
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1");
            
            Assessment assessment = createAssessment();
            List<Slide> slides = listSlides(assessment.id);

            foreach (Slide slide in slides)
            {
                slide.response = true;
                slide.time_taken = 600;
                Assert.AreEqual(slide.completed_at, null);
            }

            slides = traitify.SetSlideBulkUpdate(assessment.id, slides);

            Assert.AreNotEqual(slides, null);

            foreach (Slide slide in slides)
            {
                Assert.AreNotEqual(slide.completed_at, null);
            }
        }

        [TestMethod]
        public void TestSlideUpdate()
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1");

            Assessment assessment = createAssessment();
            List<Slide> slides = listSlides(assessment.id);
            Slide slide = slides[0];

            slide.response = true;
            slide.time_taken = 600;

            slide = traitify.SetSlideUpdate(assessment.id, slide);

            Assert.AreEqual(slide.time_taken, 600);
            Assert.AreEqual(slide.response, true);
            Assert.AreNotEqual(slide.completed_at, null);
        }

        [TestMethod]
        public void TestPersonalityTypes()
        {
            Assessment assessment = createAssessment();

            List<AssessmentPersonalityType> assessmentPersonalityTypes = listAssessmentPersonalityTypes(assessment.id);

            Assert.AreNotEqual(assessmentPersonalityTypes, null);
            Assert.AreNotEqual(assessmentPersonalityTypes.Count, 0);
        }

        [TestMethod]
        public void TestPersonalityTraits()
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1");

            Assessment assessment = createAssessment();

            AssessmentPersonalityType personalityType = getPersonalityType(assessment.id);
            List<AssessmentPersonalityTrait> assessmentPersonalityTraits = traitify.GetPersonalityTraits(assessment.id, personalityType.personality_type.id);

            Assert.AreNotEqual(assessmentPersonalityTraits, null);
            Assert.AreNotSame(assessmentPersonalityTraits.Count, 0);
        }

        private List<Deck> listDecks()
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1");
            return traitify.GetDecks();
        }

        private Deck getDeck()
        {
            List<Deck> decks = listDecks();
            return decks[0];
        }

        private Assessment createAssessment(Deck deck)
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1");
            Assessment assessment = traitify.CreateAssesment(deck.id);
            Assert.AreNotEqual(assessment, null);
            return assessment;
        }

        private Assessment createAssessment() {
            return createAssessment(getDeck());
        }

        private List<Slide> listSlides(String assessment_id)
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1");
            List<Slide> slides = traitify.GetSlides(assessment_id);
            Assert.AreNotEqual(slides, null);
            return slides;
        }

        private List<Slide> listSlides()
        {
            return listSlides(createAssessment().id);
        }

        private List<Slide> updateAllSlides(String assessment_id)
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1"); 

            List<Slide> slides = listSlides(assessment_id);
            Random rng = new Random();
            
            Random random = new Random();
            foreach (Slide slide in slides){
                slide.response = (rng.Next(0, 2) > 0);
                slide.time_taken = 600;
                Assert.AreEqual(slide.completed_at, null);
            }

            return traitify.SetSlideBulkUpdate(assessment_id, slides);
        }

        private List<Slide> updateAllSlides()
        {
            return updateAllSlides(createAssessment().id);
        }

        public List<AssessmentPersonalityType> listAssessmentPersonalityTypes(String assessment_id)
        {
            Traitify traitify = new Traitify(_host, _publicKey, _secretKey, "v1"); 

            updateAllSlides(assessment_id);

            List<AssessmentPersonalityType> personalityTypes = traitify.GetPersonalityTypes(assessment_id).personality_types;

            Assert.AreNotEqual(personalityTypes, null);

            return personalityTypes;
        }

        private AssessmentPersonalityType getPersonalityType(String assessment_id)
        {
            List<AssessmentPersonalityType> assessmentPersonalityTypes = listAssessmentPersonalityTypes(assessment_id);

            Assert.AreNotEqual(assessmentPersonalityTypes, null);

            AssessmentPersonalityType assessmentPersonalityType = assessmentPersonalityTypes[0];
            Assert.AreNotEqual(assessmentPersonalityType, null);

            return assessmentPersonalityType;
        }

    }
}
