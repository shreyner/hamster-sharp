using System;
using System.Threading.Tasks;
using Agent.DB;
using Agent.DB.Entities;
using Quartz;

namespace Agent.Service.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private readonly DbRepository<DotNetMetric> _dotNetMetricRepository;
        private readonly PerformanceCounter _performanceCounter;

        public DotNetMetricJob(DbRepository<DotNetMetric> dbRepository)
        {
            _dotNetMetricRepository = dbRepository;
            _performanceCounter = new PerformanceCounter();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercents = Convert.ToInt32(_performanceCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            await _dotNetMetricRepository.AddAsync(new DotNetMetric() { Time = DateTime.Now, Value = cpuUsageInPercents });
            Console.WriteLine($"{nameof(DotNetMetric)} {cpuUsageInPercents} {time}");
        }
    }
}