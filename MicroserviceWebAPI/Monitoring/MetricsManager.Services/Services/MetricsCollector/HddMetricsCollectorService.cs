using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agent.Client;
using MetricsManager.DB;
using MetricsManager.Entities;
using MetricsManager.Service.Mapper;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.Service.Services.MetricsCollector
{
    public class HddMetricsCollectorService
    {
        private DbRepository<HddMetric> _hddMetricRepository;
        private IAgentClient _agentClient;
        private IMetricsManagerMapper _mapper;

        public HddMetricsCollectorService(
            DbRepository<HddMetric> cpuMetricRepository,
            IAgentClient agentClient,
            IMetricsManagerMapper mapper
        )
        {
            _hddMetricRepository = cpuMetricRepository;
            _agentClient = agentClient;
            _mapper = mapper;
        }

        public async Task LoadMetricsFromAgent(Entities.Agent agent)
        {
            var lastCpuMetric = await _hddMetricRepository
                .GetAll()
                .Where(x => x.AgentId == agent.Id)
                .OrderByDescending(x => x.DateTime)
                .FirstOrDefaultAsync();

            var response =
                await _agentClient.GetCpuMetricBetweenDateAsync(lastCpuMetric.DateTime, DateTime.Now, agent.Address);

            var result = _mapper.Map<IEnumerable<HddMetric>>(response);

            foreach (var hddMetric in result)
            {
                hddMetric.Agent = agent;
            }

            await _hddMetricRepository.AddRangeAsync(result);
        }
    }
}