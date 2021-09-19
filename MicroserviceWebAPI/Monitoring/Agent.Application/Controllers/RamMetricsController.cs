using System;
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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<RamMetric>> GetAvailableMetrics(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime,
            [FromServices] DbRepository<RamMetric> ramMetricRepository
        )
        {
            return Ok(
                ramMetricRepository
                    .GetAll()
                    .Where(x => fromTime.CompareTo(x.Time) != -1 && toTime.CompareTo(x.Time) != 1)
                    .ToListAsync()
            );
        }
    }
}