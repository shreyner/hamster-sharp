using System;
using System.Threading.Tasks;
using Agent.DB;
using Agent.DB.Entities;
using Quartz;

namespace Agent.Service.Jobs
{
    public class RamMetricJob : IJob
    {
        private readonly DbRepository<RamMetric> _ramMetricRepository;
        private readonly PerformanceCounter _performanceCounter;

        public RamMetricJob(DbRepository<RamMetric> dbRepository)
        {
            _ramMetricRepository = dbRepository;
            _performanceCounter = new PerformanceCounter();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var ramInPercents = Convert.ToInt32(_performanceCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            await _ramMetricRepository.AddAsync(new RamMetric() { Time = DateTime.Now, Value = ramInPercents });
            Console.WriteLine($"{nameof(RamMetricJob)} {ramInPercents} {time}");
        }
    }
}