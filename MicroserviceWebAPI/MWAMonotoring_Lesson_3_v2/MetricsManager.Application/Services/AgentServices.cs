using System;
using System.Collections.Generic;
using System.Linq;
using MetricsManager.Models;
using MetricsManager.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Services
{
    public interface IAgentServices
    {
        public List<AgentInfo> AgentInfos();
    }
    
    public class AgentServices : IAgentServices
    {
        private readonly AgentRepository _agentRepository;

        public AgentServices(
                AgentRepository agentRepository
            )
        {
            _agentRepository = agentRepository;
        }

        public List<AgentInfo> AgentInfos()
        {
            return _agentRepository.GetAll();
        }
    }
}