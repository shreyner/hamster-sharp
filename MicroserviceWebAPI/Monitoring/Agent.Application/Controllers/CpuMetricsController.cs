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
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<CpuMetric>> GetMetrics(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime,
            [FromServices] DbRepository<CpuMetric> cpuMetricRepository
        )
        {
            return Ok(
                cpuMetricRepository
                    .GetAll()
                    .Where(x => fromTime.CompareTo(x.Time) != -1 && toTime.CompareTo(x.Time) != 1).ToListAsync()
            );
        }
    }
}