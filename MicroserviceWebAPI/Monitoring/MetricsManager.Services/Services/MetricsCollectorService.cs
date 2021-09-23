using System;
using System.Linq;
using System.Threading.Tasks;
using Agent.Client;
using MetricsManager.DB;
using MetricsManager.Service.Services.MetricsCollector;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.Service.Services
{
    public class MetricsCollectorService
    {
        private DbRepository<Entities.Agent> _agentRepository;
        private CpuMetricsCollectorService _cpuMetricsCollectorService;
        private HddMetricsCollectorService _hddMetricsCollectorService;
        private IAgentClient _agentClient;

        public MetricsCollectorService(
            DbRepository<Entities.Agent> agentRepository,
            IAgentClient agentClient,
            CpuMetricsCollectorService cpuMetricsCollectorService,
            HddMetricsCollectorService hddMetricsCollectorService 
        )
        {
            _agentRepository = agentRepository;
            _agentClient = agentClient;
            _cpuMetricsCollectorService = cpuMetricsCollectorService;
            _hddMetricsCollectorService = hddMetricsCollectorService;
        }

        public async Task GetAllMetricsFromAgents()
        {
            var agents = await _agentRepository.GetAll().Where(x => x.Enabled == true).ToListAsync();

            await Task.WhenAll(
                new[]
                {
                    Task.WhenAll(
                        agents.Select(agent => _hddMetricsCollectorService.LoadMetricsFromAgent(agent))
                    ),
                    Task.WhenAll(
                        agents.Select(agent => _cpuMetricsCollectorService.LoadMetricsFromAgent(agent))
                    ),
                }
            );
        }
    }
}