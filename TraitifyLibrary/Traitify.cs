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
        /// GetAssessment
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
        /// GetSlides
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
        /// SetSlide
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <param name="slideId"></param>
        public void SetSlide(string assessmentId, string slideId)
        {
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.PutAsync(_version + "/assessments/" + assessmentId + "/slides/" + slideId, null);
            }
        }

        /// <summary>
        /// GetPersonalityTypes
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns>List<PersonalityType></returns>
        public List<PersonalityType> GetPersonalityTypes(string assessmentId)
        {
            List<PersonalityType> personalityTypes = default(List<PersonalityType>);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(_version + "/assessments/" + assessmentId + "/personality_types").Result;
                personalityTypes = JsonConvert.DeserializeObject<List<PersonalityType>>(response.Content.ReadAsStringAsync().Result);
            }
            return personalityTypes;
        }

    }
}
