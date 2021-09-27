using System;

namespace MetricsManager.Service.Jobs
{
    public class JobSchedule
    {
        public Type JobType;
        public string CronExpression;
        
        public JobSchedule(Type jobType, string cronExpression)
        {
            JobType = jobType;
            CronExpression = cronExpression;
        }
    }
}