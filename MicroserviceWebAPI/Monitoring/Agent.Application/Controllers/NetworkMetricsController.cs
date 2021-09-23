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
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public async Task<ActionResult<IList<NetworkMetric>>> GetMetrics(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime,
            [FromServices] DbRepository<NetworkMetric> networkMetricRepository
        )
        {
            return Ok(
                await networkMetricRepository
                    .GetAll()
                    .Where(x => fromTime.CompareTo(x.Time) == -1 && toTime.CompareTo(x.Time) == 1)
                    .ToListAsync()
            );
        }
    }
}