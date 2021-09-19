using System;

namespace Agent.DB.Entities
{
    public class RamMetric : BaseEntity
    {
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
