using System;
using System.Collections.Generic;
using System.Linq;
using MetricsManager.Models;

namespace MetricsManager.Services
{
    public class AgentServices
    {
        private readonly List<AgentInfo> _agentInfos = new List<AgentInfo>();

        public AgentServices()
        {
            _agentInfos.AddRange(
                Enumerable
                    .Range(1, 5)
                    .Select(
                        index => new AgentInfo(index, new Uri($"http://localhost:300{index}"))
                    )
            );
        }

        public List<AgentInfo> AgentInfos()
        {
            return _agentInfos;
        }
    }
}