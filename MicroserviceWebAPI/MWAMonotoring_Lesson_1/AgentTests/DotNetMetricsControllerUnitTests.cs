using System;
using Agent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AgentTests
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;

        public DotNetMetricsControllerUnitTests()
        {
            _controller = new DotNetMetricsController();
        }

        [Fact]
        public void GetDotNetErrorsCountMetrics_ReturnOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = _controller.GetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}