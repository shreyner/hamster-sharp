using System;
using Agent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgentTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _controller;

        public CpuMetricsControllerUnitTests()
        {
            _controller = new CpuMetricsController();
        }


        [Fact]
        public void GetCpuMetrics_ReturnOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = _controller.GetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}