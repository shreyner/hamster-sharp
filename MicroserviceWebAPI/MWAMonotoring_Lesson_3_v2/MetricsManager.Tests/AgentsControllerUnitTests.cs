using System;
using System.Collections.Generic;
using MetricsManager.Controllers;
using MetricsManager.Models;
using MetricsManager.Repositories;
using MetricsManager.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using ILogger = Castle.Core.Logging.ILogger;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTests
    {
        private Mock<ILogger<AgentsController>> _logger;
        private AgentsController _agentsController;
        private Mock<IAgentServices> _agentService;

        public AgentsControllerUnitTests()
        {
            _logger = new Mock<ILogger<AgentsController>>();
            _agentService = new Mock<IAgentServices>();
            _agentsController = new AgentsController(
                _logger.Object
            );
        }


        [Fact]
        public void GetAgents_CheckCallService()
        {

            
            _agentService.Setup(services => services.AgentInfos()).Verifiable();
            
            _agentsController.GetAllAgents(_agentService.Object);

            _agentService.Verify(services => services.AgentInfos());
        }
    }
}