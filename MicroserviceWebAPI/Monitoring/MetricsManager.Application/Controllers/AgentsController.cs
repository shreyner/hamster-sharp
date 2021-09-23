using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetricsManager.Service.Dto;
using MetricsManager.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Application.Controllers
{
    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Agent>>> GetAllAgents(
            [FromServices] AgentService agentService
        )
        {
            return Ok(await agentService.GetAll());
        }

        [HttpPost("registry")]
        public async Task<ActionResult<Entities.Agent>> RegistryAgent(
            [FromBody] AgentAddDto newAgent,
            [FromServices] AgentService agentService
        )
        {
            return Ok(await agentService.AddAgent(newAgent));
        }

        [HttpPut("{agentId}/enabled")]
        public async Task<ActionResult> EnabledAgentById(
            [FromRoute] int agentId,
            [FromServices] AgentService agentService
        )
        {
            try
            {
                await agentService.AgentChangeEnabled(agentId, true);

                return NoContent();
            }
            catch (InvalidOperationException e)
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{agentId}/disabled")]
        public async Task<ActionResult> DisabledAgentById(
            [FromRoute] int agentId,
            [FromServices] AgentService agentService
        )
        {
            try
            {
                await agentService.AgentChangeEnabled(agentId, false);

                return NoContent();
            }
            catch (InvalidOperationException e)
            {
                return new NotFoundResult();
            }
        }
    }
}