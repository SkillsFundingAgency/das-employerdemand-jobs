using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SFA.DAS.EmployerDemand.Jobs.Domain.Configuration;
using SFA.DAS.EmployerDemand.Jobs.Domain.Interfaces;

namespace SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api
{
    public class ApiClient : IApiClient
    {
        private readonly EmployerDemandJobsApiConfiguration _config;
        private readonly HttpClient _client;

        public ApiClient(HttpClient client, IOptions<EmployerDemandJobsApiConfiguration> config)
        {   
            _client = client;
            _config = config.Value;
            _client.BaseAddress = new Uri(_config.BaseUrl);
        }

        public async Task<TResponse> Get<TResponse>(IGetApiRequest request)
        {
            AddHeaders();

            var response = await _client.GetAsync(request.GetUrl).ConfigureAwait(false);

            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default;
            }

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TResponse>(json);    
            }
            
            response.EnsureSuccessStatusCode();
            
            return default;
        }

        public async Task<TResponse> Post<TResponse>(IPostApiRequest request)
        {
            AddHeaders();
            
            var response = await _client.PostAsync(request.PostUrl, null)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TResponse>(json);    
        }

        private void AddHeaders()
        {
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config.Key);
            _client.DefaultRequestHeaders.Add("X-Version", "1");
        }
    }
}