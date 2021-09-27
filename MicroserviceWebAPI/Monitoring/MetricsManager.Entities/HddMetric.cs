using System;

namespace MetricsManager.Entities
{
    public class HddMetric : BaseEntity
    {
        public int Value { get; set; }
        public DateTime DateTime { get; set; }
        
        public long AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}
