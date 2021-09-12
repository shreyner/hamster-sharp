using System;
using Agent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController _controller;

        public HddMetricsControllerUnitTests()
        {
            _controller = new HddMetricsController();
        }

        [Fact]
        public void GetHddLeftMetrics_ReturnOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = _controller.GetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}