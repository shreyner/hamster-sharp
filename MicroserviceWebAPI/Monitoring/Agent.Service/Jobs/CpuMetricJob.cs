using System;
using System.Threading.Tasks;
using Agent.DB;
using Agent.DB.Entities;
using Quartz;

namespace Agent.Service.Jobs
{
    public class CpuMetricJob : IJob
    {
        private DbRepository<CpuMetric> _cpuMetricRepository;
        private PerformanceCounter _cpuPerformanceCounter;

        public CpuMetricJob(
            DbRepository<CpuMetric> cpuMetricRepository
        )
        {
            _cpuMetricRepository = cpuMetricRepository;
            _cpuPerformanceCounter = new PerformanceCounter();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercents = Convert.ToInt32(_cpuPerformanceCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            await _cpuMetricRepository.AddAsync(new CpuMetric { Time = DateTime.Now, Value = cpuUsageInPercents });
            Console.WriteLine($"Cpu {cpuUsageInPercents} {time}");
        }
    }
}