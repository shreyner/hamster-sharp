using System;
using System.Threading.Tasks;
using Agent.DB;
using Agent.DB.Entities;
using Quartz;

namespace Agent.Service.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private readonly DbRepository<NetworkMetric> _networkMetricRepository;
        private readonly PerformanceCounter _performanceCounter;

        public NetworkMetricJob(DbRepository<NetworkMetric> dbRepository)
        {
            _networkMetricRepository = dbRepository;
            _performanceCounter = new PerformanceCounter();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var networkInPercents = Convert.ToInt32(_performanceCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            await _networkMetricRepository.AddAsync(new NetworkMetric() { Time = DateTime.Now, Value = networkInPercents });
            Console.WriteLine($"{nameof(NetworkMetricJob)} {networkInPercents} {time}");
        }
    }
}