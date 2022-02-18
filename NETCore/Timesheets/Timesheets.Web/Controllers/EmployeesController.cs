using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DB;
using Timesheets.DB.Entities;
using Timesheets.Web.DTOs;

namespace Timesheets.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> _emploeeRepository;
        private readonly IRepository<User> _userRepository;

        public EmployeesController(
            IRepository<Employee> repository,
            IRepository<User> userRepository
        )
        {
            _emploeeRepository = repository;
            _userRepository = userRepository;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return this._emploeeRepository.GetAll().AsEnumerable();
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Employee>> Get([FromRoute] long id)
        {
            var emploee = await this._emploeeRepository.GetByIdAsync(id);

            if (emploee == null)
            {
                return NotFound();
            }

            return Ok(emploee);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] EmploeeCreateRequest value)
        {
            var user = await this._userRepository.GetByIdAsync(value.UserId);

            if (user == null)
            {
                return NotFound(user);
            }

            var employy = new Employee()
            {
                User = user
            };

            await this._emploeeRepository.AddAsync(employy);

            return employy;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put([FromRoute] long id, [FromBody] EmploeeUpdateRequest value)
        {
            var user = await this._userRepository.GetByIdAsync(value.UserId);
            var employy = await this._emploeeRepository.GetByIdAsync(id);

            if (user == null || employy == null)
            {
                return NotFound();
            }

            employy.User = user;

            await this._emploeeRepository.UpdateAsync(employy);

            return employy;
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            var employy = await this._emploeeRepository.GetByIdAsync(id);

            if (employy == null)
            {
                return NotFound();
            }

            employy.isDeleted = true;

            await this._emploeeRepository.UpdateAsync(employy);

            return NoContent();
            
        }
    }
}