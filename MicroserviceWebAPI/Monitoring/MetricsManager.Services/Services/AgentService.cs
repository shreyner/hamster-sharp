using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MetricsManager.Service.Services
{
    public class AgentService
    {
        private readonly List<AgentInfo> _listAgents = new List<AgentInfo>();
        private int _lastIndex = 0;

        public AgentService()
        {
            _listAgents.AddRange(
                Enumerable
                    .Range(1, 5)
                    .Select((_) =>
                    {
                        var index = _lastIndex++;
                        return new AgentInfo
                            { id = index, Address = new Uri($"http://localhost:300{index}") };
                    }));
        }

        public List<AgentInfo> GetAllAgents()
        {
            return _listAgents;
        }
    }
}