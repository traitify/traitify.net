using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace com.traitify.net.TraitifyLibrary
{
    public class Traitify
    {
        private string _host = String.Empty;
        private string _secretKey = String.Empty;
        private string _publicKey = String.Empty;
        private string _version = String.Empty;

        /// <summary>
        /// Traitify Constructor
        /// </summary>
        /// <param name="host">Host URI</param>
        /// <param name="publicKey">Public Key string</param>
        /// <param name="secretKey">Private / Secret Key string</param>
        /// <param name="version">API version number</param>
        public Traitify(string host, string publicKey, string secretKey, string version)
        {
            _host = host;
            _secretKey = secretKey;
            _publicKey = publicKey;
            _version = version;
        }

        /// <summary>
        /// CreateAssesment method
        /// </summary>
        /// <param name="deckId"></param>
        /// <returns>Assessment</returns>
        public Assessment CreateAssesment(string deckId)
        {
            Assessment assessment = default(Assessment);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonDeck =  JsonConvert.SerializeObject(new { deck_id = deckId }); 
                var response = client.PostAsync(_version + "/assessments", new StringContent(jsonDeck, Encoding.UTF8, "application/json")).Result;
                assessment = JsonConvert.DeserializeObject<Assessment>(response.Content.ReadAsStringAsync().Result);
            }

            return assessment;
        }

        /// <summary>
        /// GetAssessment method
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns>Assessment</returns>
        public Assessment GetAssessment(string assessmentId)
        {
            Assessment assessment = default(Assessment);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(_version + "/assessments/" + assessmentId).Result;
                assessment = JsonConvert.DeserializeObject<Assessment>(response.Content.ReadAsStringAsync().Result);
            }
            return assessment;
        }

        /// <summary>
        /// GetSlides method
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns>List<Slide></returns>
        public List<Slide> GetSlides(string assessmentId)
        {
            List<Slide> slides = default(List<Slide>);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(_version + "/assessments/" + assessmentId + "/slides").Result;
                slides = JsonConvert.DeserializeObject<List<Slide>>(response.Content.ReadAsStringAsync().Result);
            }
            return slides;
        }

        /// <summary>
        /// SetSlide method
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <param name="slideId"></param>
        public bool SetSlide(string assessmentId, string slideId)
        {
            bool wasUpdateSuccessful = false;
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PutAsync(_version + "/assessments/" + assessmentId + "/slides/" + slideId, null).Result;
                wasUpdateSuccessful = JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
            }
            return wasUpdateSuccessful;
        }

        /// <summary>
        /// SetSlideUpdate method
        /// </summary>
        /// <param name="assessment_id"></param>
        /// <param name="slide"></param>
        /// <returns></returns>
        public Slide SetSlideUpdate(String assessment_id, Slide slide)
        {
            Slide responseSlide = default(Slide);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                List<Slide> slideList = new List<Slide>();
                slideList.Add(slide);
                var jsonSlides = JsonConvert.SerializeObject(slideList);
                var response = client.PutAsync(_version + "/assessments/" + assessment_id + "/slides", new StringContent(jsonSlides, Encoding.UTF8, "application/json")).Result;
                string jsonSlideResult = response.Content.ReadAsStringAsync().Result;
                responseSlide = JsonConvert.DeserializeObject<Slide>(jsonSlideResult);
            }
            return responseSlide;
        }

        /// <summary>
        /// SetSlideBulkUpdate bulk update method
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <param name="slides"></param>
        /// <returns></returns>
        public List<Slide> SetSlideBulkUpdate(string assessmentId, List<Slide> slides)
        {
            List<Slide> responseSlides = default(List<Slide>);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonSlides = JsonConvert.SerializeObject(slides);
                var response = client.PutAsync(_version + "/assessments/" + assessmentId + "/slides", new StringContent(jsonSlides, Encoding.UTF8, "application/json")).Result;
                responseSlides = JsonConvert.DeserializeObject<List<Slide>>(response.Content.ReadAsStringAsync().Result);
            }
            return responseSlides;
        }

        /// <summary>
        /// GetPersonalityTypes method
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns>List<PersonalityType></returns>
        public AssessmentPersonalityTypes GetPersonalityTypes(string assessmentId)
        {
            //List<PersonalityType> personalityTypes = default(List<PersonalityType>);
            AssessmentPersonalityTypes personalityTypes = default(AssessmentPersonalityTypes);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(_version + "/assessments/" + assessmentId + "/personality_types").Result;
                string personalityTypesJson = response.Content.ReadAsStringAsync().Result;
                personalityTypes = JsonConvert.DeserializeObject<AssessmentPersonalityTypes>(personalityTypesJson);
            }
            return personalityTypes;
        }

        /// <summary>
        /// GetPersonalityTraits method
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns>List of AssessmentPersonalityTrait</returns>
        public List<AssessmentPersonalityTrait> GetPersonalityTraits(string assessmentId)
        {
            List<AssessmentPersonalityTrait> assessmentPersonalityTraits = default(List<AssessmentPersonalityTrait>);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(_version + "/assessments/" + assessmentId + "/personality_traits").Result;
                assessmentPersonalityTraits = JsonConvert.DeserializeObject<List<AssessmentPersonalityTrait>>(response.Content.ReadAsStringAsync().Result);
            }
            return assessmentPersonalityTraits;
        }

        /// <summary>
        /// GetDecks method
        /// </summary>
        /// <returns>List of Deck</returns>
        public List<Deck> GetDecks()
        {
            List<Deck> decks = default(List<Deck>);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(_version + "/decks").Result;
                string results = response.Content.ReadAsStringAsync().Result;
                decks = JsonConvert.DeserializeObject<List<Deck>>(results);
            }
            return decks;
        }
    }
}
