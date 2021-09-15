using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Service;
using MetricsManager.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Application.Controllers
{
    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AgentInfo>> GetAllAgents([FromServices] AgentService agentService)
        {
            return Ok(agentService.GetAllAgents());
        }

        [HttpPost("registry")]
        public ActionResult RegistryAgent()
        {
            return BadRequest();
        }

        [HttpPut("{agentId}/enabled")]
        public ActionResult EnabledAgentById([FromRoute] int agentId)
        {
            return NoContent();
        }

        [HttpPut("{agentId}/disabled")]
        public ActionResult DisabledAgentById([FromRoute] int agentId)
        {
            return NoContent();
        }
        
    }
}