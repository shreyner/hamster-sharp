using System;

namespace MetricsManager.Models
{
    public class AgentInfo
    {
        public int id { get; }
        public Uri AgentAddress { get; }

        public AgentInfo(int id, Uri agentAddress)
        {
            this.id = id;
            AgentAddress = agentAddress;
        }
    }
}