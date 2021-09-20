using System;
using System.Threading.Tasks;
using Agent.DB;
using Agent.DB.Entities;
using Quartz;

namespace Agent.Service.Jobs
{
    public class HddMetricJob : IJob
    {
        private readonly DbRepository<HddMetric> _hddMetricRepository;
        private readonly PerformanceCounter _performanceCounter;

        public HddMetricJob(DbRepository<HddMetric> dbRepository)
        {
            _hddMetricRepository = dbRepository;
            _performanceCounter = new PerformanceCounter();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Call HddMetricJob");
            var hddInPercents = Convert.ToInt32(_performanceCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            Console.WriteLine($"{nameof(HddMetricJob)} Before save");
            await _hddMetricRepository.AddAsync(new HddMetric() { Time = DateTime.Now, Value = hddInPercents });
            Console.WriteLine($"{nameof(HddMetricJob)} After save");
            Console.WriteLine($"{nameof(HddMetricJob)} {hddInPercents} {time}");
        }
    }
}
