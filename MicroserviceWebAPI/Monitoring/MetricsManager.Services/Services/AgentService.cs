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
        private DbRepository<Agent> AgentRepository { get; set; }
        private IMetricsManagerMapper ManagerMapper { get; set; }

        public AgentService(DbRepository<Agent> agentRepository, IMetricsManagerMapper mapper)
        {
            AgentRepository = agentRepository;
            ManagerMapper = mapper;
        }

        public Task<List<Agent>> GetAll()
        {
            return AgentRepository.GetAll().ToListAsync();
        }

        public async Task<Agent> AddAgent(AgentAddDto agentAddDto)
        {
            var agent = ManagerMapper.Map<Agent>(agentAddDto);

            await AgentRepository.AddAsync(agent);

            return agent;
        }
    }
}