using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Agent.Client.Dto;

namespace Agent.Client
{
    public class AgentClient : IAgentClient
    {
        private readonly HttpClient _httpClient;

        public AgentClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IList<CpuMetricResponse>> GetCpuMetricBetweenDateAsync(DateTime fromDate, DateTime toDate, Uri agentAddress)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(agentAddress, $"api/metrics/cpu/from/{fromDate}/to/{toDate}"));
            using var result = await _httpClient.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var stream = await result.Content.ReadAsStreamAsync();
                var metrics = await JsonSerializer.DeserializeAsync<List<CpuMetricResponse>>(stream);

                return metrics;
            }

            return Enumerable.Empty<CpuMetricResponse>().ToList();
        }
        
        

        public async Task<IList<DotNetMetricResponse>> GetDotNetErrorCountMetricBetweenDateAsync(DateTime fromDate, DateTime toDate, Uri agentAddress)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(agentAddress, $"api/metrics/dotnet/error-count/from/{fromDate}/to/{toDate}"));
            using var result = await _httpClient.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var stream = await result.Content.ReadAsStreamAsync();
                var metrics = await JsonSerializer.DeserializeAsync<List<DotNetMetricResponse>>(stream);

                return metrics;
            }

            return Enumerable.Empty<DotNetMetricResponse>().ToList();
        }

        public async Task<IList<HddMetricResponse>> GetHddLeftMetricBetweenDateAsync(DateTime fromDate, DateTime toDate, Uri agentAddress)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(agentAddress, $"api/metrics/hdd/left/from/{fromDate}/to/{toDate}"));
            using var result = await _httpClient.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var stream = await result.Content.ReadAsStreamAsync();
                var metrics = await JsonSerializer.DeserializeAsync<List<HddMetricResponse>>(stream);

                return metrics;
            }

            return Enumerable.Empty<HddMetricResponse>().ToList();
        }

        public async  Task<IList<NetworkMetricResponse>> GetNetworkMetricBetweenDateAsync(DateTime fromDate, DateTime toDate, Uri agentAddress)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(agentAddress, $"api/metrics/network/from/{fromDate}/to/{toDate}"));
            using var result = await _httpClient.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var stream = await result.Content.ReadAsStreamAsync();
                var metrics = await JsonSerializer.DeserializeAsync<List<NetworkMetricResponse>>(stream);

                return metrics;
            }

            return Enumerable.Empty<NetworkMetricResponse>().ToList();
        }

        public async  Task<IList<RamMetricResponse>> GetRamAvailableMetricBetweenDateAsync(DateTime fromDate, DateTime toDate, Uri agentAddress)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(agentAddress, $"api/metrics/ram/available/from/{fromDate}/to/{toDate}"));
            using var result = await _httpClient.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var stream = await result.Content.ReadAsStreamAsync();
                var metrics = await JsonSerializer.DeserializeAsync<List<RamMetricResponse>>(stream);

                return metrics;
            }

            return Enumerable.Empty<RamMetricResponse>().ToList();
        }
    }
}