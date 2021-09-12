using System;

namespace MetricsManager.Models
{
    public class AgentInfo
    {
        public int id { get; set; }
        public Uri AgentAddress { get; set; }

        public AgentInfo(int id, Uri agentAddress)
        {
            this.id = id;
            AgentAddress = agentAddress;
        }
    }
}