using System;

namespace Agent.DB.Entities
{
    public class NetworkMetric : BaseEntity
    {
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
