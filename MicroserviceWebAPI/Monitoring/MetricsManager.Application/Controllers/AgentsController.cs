using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Entities;
using MetricsManager.Service;
using MetricsManager.Service.Dto;
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
        public async Task<ActionResult<List<Action>>> GetAllAgents([FromServices] AgentService agentService)
        {
            return Ok(await agentService.GetAll());
        }

        [HttpPost("registry")]
        public async Task<ActionResult<Agent>> RegistryAgent(
            [FromBody] AgentAddDto newAgent,
            [FromServices] AgentService agentService
        )
        {
            return Ok(await agentService.AddAgent(newAgent));
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