using System.Threading.Tasks;
using MetricsManager.DB;
using MetricsManager.Service.Services;
using Quartz;

namespace MetricsManager.Service.Jobs
{
    public class MetricsCollectorJob : IJob
    {
        private MetricsCollectorService _metricsCollectorService;

        public MetricsCollectorJob(
            MetricsCollectorService metricsCollectorService
        )
        {
            _metricsCollectorService = metricsCollectorService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _metricsCollectorService.GetAllMetricsFromAgents();
        }
    }
}