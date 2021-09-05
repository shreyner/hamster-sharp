using System;
using Agent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgentTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController _controller;

        public NetworkMetricsControllerUnitTests()
        {
            _controller = new NetworkMetricsController();
        }

        [Fact]
        public void GetNetworkMetrics_ReturnOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = _controller.GetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}