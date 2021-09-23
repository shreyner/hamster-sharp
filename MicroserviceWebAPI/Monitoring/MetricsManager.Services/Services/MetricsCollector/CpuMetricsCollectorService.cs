using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agent.Client;
using Agent.Client.Dto;
using MetricsManager.DB;
using MetricsManager.Entities;
using MetricsManager.Service.Mapper;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.Service.Services.MetricsCollector
{
    public class CpuMetricsCollectorService
    {
        private DbRepository<CpuMetric> _cpuMetricRepository;
        private IAgentClient _agentClient;
        private IMetricsManagerMapper _mapper;

        public CpuMetricsCollectorService(
            DbRepository<CpuMetric> cpuMetricRepository,
            IAgentClient agentClient,
            IMetricsManagerMapper mapper
        )
        {
            _cpuMetricRepository = cpuMetricRepository;
            _agentClient = agentClient;
            _mapper = mapper;
        }

        public async Task LoadMetricsFromAgent(Entities.Agent agent)
        {
            var lastCpuMetric = await _cpuMetricRepository
                .GetAll()
                .Where(x => x.AgentId == agent.Id)
                .OrderByDescending(x => x.DateTime)
                .FirstOrDefaultAsync();

            var response =
                await _agentClient.GetCpuMetricBetweenDateAsync(lastCpuMetric.DateTime, DateTime.Now, agent.Address);

            var result = _mapper
                .Map<IEnumerable<CpuMetric>>(response);

            foreach (var cpuMetric in result)
            {
                cpuMetric.Agent = agent;
            }

            await _cpuMetricRepository.AddRangeAsync(result);
        }
    }
}