using RestSharp;

namespace NASA.Tests.Common.Helpers
{
    public class ApiClient
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public ApiClient(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _apiKey = apiKey;
        }

        public async Task<RestResponse> GetCmeAsync(string startDate, string endDate)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("/DONKI/CME", Method.Get);

            if (!string.IsNullOrEmpty(startDate)) request.AddQueryParameter("startDate", startDate);
            if (!string.IsNullOrEmpty(endDate)) request.AddQueryParameter("endDate", endDate);

            request.AddQueryParameter("api_key", _apiKey);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetFlrAsync(string startDate, string endDate)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("/DONKI/FLR", Method.Get);

            if (!string.IsNullOrEmpty(startDate)) request.AddQueryParameter("startDate", startDate);
            if (!string.IsNullOrEmpty(endDate)) request.AddQueryParameter("endDate", endDate);

            request.AddQueryParameter("api_key", _apiKey);
            return await client.ExecuteAsync(request);
        }
    }
}
