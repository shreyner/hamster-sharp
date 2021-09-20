using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agent.DB;
using Agent.DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agent.Application.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        [HttpGet("error-count/from/{fromTime}/to/{toTime}")]
        public async Task<ActionResult<IList<CpuMetric>>> GetErrorCountMetrics(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime,
            [FromServices] DbRepository<DotNetMetric> dotnetMetricRepository
        )
        {
            return Ok(
                await dotnetMetricRepository
                    .GetAll()
                    .Where(x => fromTime.CompareTo(x.Time) != -1 && toTime.CompareTo(x.Time) != 1)
                    .ToListAsync()
            );
        }
    }
}