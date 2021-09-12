using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/metrics/cpu")]
    public class CpuMetricsController : ControllerBase
    {
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
                [FromRoute] int agentId,
                [FromRoute] TimeSpan fromTime,
                [FromRoute] TimeSpan toTime
            ) // Биндингом параметров в Asp.Net Framework занимается model binder. Он старается это делать по название.
            // Позже посмотреть как задать правила валидации для него.
        {
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime
        )
        {
            return Ok();
        }
    }
}