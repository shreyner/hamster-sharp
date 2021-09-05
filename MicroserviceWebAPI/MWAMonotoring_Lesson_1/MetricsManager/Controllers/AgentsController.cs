using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] RegistryAgent agentInfo)
        {
            return Ok();
        }

        [HttpPut("{agentId}/enabled")]
        public IActionResult EnabledAgentById([FromRoute] int agentId)
        {
            return NoContent();
        }

        [HttpPut("{agentId}/disabled")]
        public IActionResult DisabledAgentById([FromRoute] int agentId)
        {
            return NoContent();
        }
    }
}