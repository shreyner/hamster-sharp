namespace Agent.Service.Jobs
{
    public class CronExpression
    {
        public string Value { get; private set; }

        private CronExpression(string value)
        {
            Value = value;
        }

        public static CronExpression Every5Second => new CronExpression("0/5 * * * * ?");
    }
}