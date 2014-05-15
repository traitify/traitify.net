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

        public Traitify(string host, string publicKey, string secretKey, string version)
        {
            _host = host;
            _secretKey = secretKey;
            _publicKey = publicKey;
            _version = version;
        }

        //createAssessment: function(deckId, callBack){
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

        //getAssessment: function(assessmentId, callBack){
        public Assessment GetAssessment(string assessmentId)
        {
            Assessment assessment = default(Assessment);
            using (var client = new HttpClient(new AuthHandler(_secretKey)) { BaseAddress = new Uri(_host) })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(_version + "/assessments/" + assessmentId).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                assessment = JsonConvert.DeserializeObject<Assessment>(response.Content.ReadAsStringAsync().Result);
            }
            return assessment;
        }

        //getSlides: function(assessmentId, callBack){
        public List<Slide> GetSlides(string assessmentId)
        {
            return new List<Slide>();
        }

        //setSlide: function(assessmentId, slideId, params, callBack){
        public void SetSlide(string assessmentId, string slideId)
        {

        }

        //getPersonalityTypes: function(assessmentId, callBack){
        public List<PersonalityType> GetPersonalityTypes(string assessmentId)
        {
            return new List<PersonalityType>();
        }

    }
}
