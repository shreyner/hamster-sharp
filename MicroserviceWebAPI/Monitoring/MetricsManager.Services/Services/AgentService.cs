using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DB;
using MetricsManager.Entities;
using MetricsManager.Service.Dto;
using MetricsManager.Service.Mapper;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.Service.Services
{
    public class AgentService
    {
        private DbRepository<Entities.Agent> AgentRepository { get; set; }
        private IMetricsManagerMapper ManagerMapper { get; set; }

        public AgentService(DbRepository<Entities.Agent> agentRepository, IMetricsManagerMapper mapper)
        {
            AgentRepository = agentRepository;
            ManagerMapper = mapper;
        }

        public Task<List<Entities.Agent>> GetAll()
        {
            return AgentRepository.GetAll().ToListAsync();
        }

        public async Task<Entities.Agent> AddAgent(AgentAddDto agentAddDto)
        {
            var agent = ManagerMapper.Map<Entities.Agent>(agentAddDto);

            await AgentRepository.AddAsync(agent);

            return agent;
        }

        public async Task<Entities.Agent> AgentChangeEnabled(int agentId, bool enabled)
        {
            var agent = await AgentRepository.GetById(agentId);

            agent.Enabled = enabled;
            
            await AgentRepository.UpdateAsync(agent);

            return agent;
        }
    }
}
