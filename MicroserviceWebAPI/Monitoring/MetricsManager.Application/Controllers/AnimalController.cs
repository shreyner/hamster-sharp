using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DB;
using MetricsManager.DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll([FromServices] AppDbContext appDbContext)
        {
            // return appDbContext.Animals.Select({}).ToListAsync();
            return Ok(Enumerable.Empty<Animal>());
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [FromServices] AppDbContext appDbContext
        )
        {
            var bob = new Animal { Name = "bob", Age = 4 };

            await appDbContext.Animals.AddAsync(bob);
            await appDbContext.SaveChangesAsync();

            return Ok(bob);
        }
    }
}