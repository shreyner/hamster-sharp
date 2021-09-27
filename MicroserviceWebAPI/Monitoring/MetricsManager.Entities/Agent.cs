using System;

namespace MetricsManager.Entities
{
    public class Agent : BaseEntity
    {
        public Uri Address { get; set; }
        public bool Enabled { get; set; }
    }
}