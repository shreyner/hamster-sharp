using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agent.Client.Dto;

namespace Agent.Client
{
    public interface IAgentClient
    {
        Task<IList<CpuMetricResponse>> GetCpuMetricBetweenDateAsync(DateTime fromDate, DateTime toTime, Uri agentAddress);
        Task<IList<DotNetMetricResponse>> GetDotNetErrorCountMetricBetweenDateAsync(DateTime fromDate, DateTime toTime, Uri agentAddress);
        Task<IList<HddMetricResponse>> GetHddLeftMetricBetweenDateAsync(DateTime fromDate, DateTime toTime, Uri agentAddress);
        Task<IList<NetworkMetricResponse>> GetNetworkMetricBetweenDateAsync(DateTime fromDate, DateTime toTime, Uri agentAddress);
        Task<IList<RamMetricResponse>> GetRamAvailableMetricBetweenDateAsync(DateTime fromDate, DateTime toTime, Uri agentAddress);
    }
}