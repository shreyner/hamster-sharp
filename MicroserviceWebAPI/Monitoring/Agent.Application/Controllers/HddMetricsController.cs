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
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public async Task<ActionResult<IList<HddMetric>>> GetLeftMetrics(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime,
            [FromServices] DbRepository<HddMetric> hddMetricRepository
        )
        {
            return Ok(
                await hddMetricRepository
                    .GetAll()
                    .Where(x => fromTime.CompareTo(x.Time) == -1 && toTime.CompareTo(x.Time) == 1)
                    .ToListAsync()
            );
        }
    }
}