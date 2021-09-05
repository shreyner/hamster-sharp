using System;
using Agent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;

        public RamMetricsControllerUnitTests()
        {
            _controller = new RamMetricsController();
        }

        [Fact]
        public void GetRamLeftMetrics_ReturnOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = _controller.GetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}