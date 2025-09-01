using NUnit.Framework;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using NASA.Tests.Common.Helpers;
using System;
using System.Threading.Tasks;

namespace NASA.Tests.API.Steps
{
    [Binding]
    public class CmeFlrSteps
    {
        private readonly ScenarioContext _context;
        private ApiClient _apiClient;
        private RestResponse _lastResponse;
        private string _startDate;
        private string _endDate;
        private string _baseUrl;
        private string _apiKey;

        public CmeFlrSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the NASA DONKI base URL is ""(.*)""")]
        public void GivenTheNasaDonkiBaseUrlIs(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        [Given(@"the API key is set to ""(.*)""")]
        public void GivenTheApiKeyIsSetTo(string apiKey)
        {
            _apiKey = Environment.GetEnvironmentVariable("NASA_API_KEY") ?? apiKey;
        }

        [Given(@"startDate ""(.*)"" and endDate ""(.*)""")]
        public void GivenStartDateAndEndDate(string startDate, string endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        [Given(@"endDate ""(.*)""")]
        public void GivenEndDate(string endDate)
        {
            _startDate = null;
            _endDate = endDate;
        }

        [When(@"I request CME data")]
        public async Task WhenIRequestCmeData()
        {
            _apiClient = new ApiClient(_baseUrl, _apiKey);
            _lastResponse = await _apiClient.GetCmeAsync(_startDate, _endDate);
        }

        [When(@"I request FLR data")]
        public async Task WhenIRequestFlrData()
        {
            _apiClient = new ApiClient(_baseUrl, _apiKey);
            _lastResponse = await _apiClient.GetFlrAsync(_startDate, _endDate);
        }

        [When(@"I request FLR data with missing startDate")]
        public async Task WhenIRequestFlrDataWithMissingStartDate()
        {
            _apiClient = new ApiClient(_baseUrl, _apiKey);
            _lastResponse = await _apiClient.GetFlrAsync(null, _endDate);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_lastResponse.StatusCode,
                $"Expected {expectedStatusCode}, but got {(int)_lastResponse.StatusCode}. Body: {_lastResponse.Content}");
        }

        [Then(@"the response should be a JSON array with at least one item")]
        public void ThenTheResponseShouldBeAJsonArrayWithAtLeastOneItem()
        {
            var json = JToken.Parse(_lastResponse.Content);
            Assert.IsTrue(json is JArray, "Response is not a JSON array");
            Assert.IsTrue(((JArray)json).Count > 0, "Response array is empty");
        }

        [Then(@"the response should be a JSON array with (.*) items")]
        public void ThenTheResponseShouldBeAJSONArrayWithItems(int expectedCount)
        {
            var j = JToken.Parse(_lastResponse.Content);           // parse JSON
            Assert.IsTrue(j is JArray, "Response is not an array"); // verify array
            Assert.AreEqual(expectedCount, ((JArray)j).Count,      // check count
                $"Expected {expectedCount} items but got {((JArray)j).Count}");
        }

        [Then(@"the response should contain flare entries")]
        public void ThenTheResponseShouldContainFlareEntries()
        {
            var json = JToken.Parse(_lastResponse.Content);
            Assert.IsTrue(json is JArray, "Response is not a JSON array");
            Assert.IsTrue(((JArray)json).Count > 0, "Response contains no flare entries");
        }
    }
}
