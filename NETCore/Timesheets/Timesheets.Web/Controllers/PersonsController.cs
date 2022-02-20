using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class PersonsController : ControllerBase
    {
        private IRepository<PersonEntity> _repository;
        private Random _random = new Random();

        public PersonsController(IRepository<PersonEntity> PersonRepository)
        {
            _repository = PersonRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetList([FromQuery] int skip, [FromQuery] int take)
        {
            return Ok(_repository.GetAll().ToList().GetRange(skip, take));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetById([FromRoute] long id)
        {
            return Ok(_repository.GetByIdAsync(id));
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Search([FromQuery] string searchTerm)
        {
            return Ok(
                _repository
                    .GetAll()
                    .ToList()
                    .FindAll(entity => $"{entity.FirstName} {entity.LastName}".Contains(searchTerm))
            );
        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> Create([FromBody] CreatePersonDTO createPersonDto)
        {
            var person = new PersonEntity()
            {
                Id = _random.NextInt64(), // TODO: tmp
                Age = createPersonDto.Age,
                FirstName = createPersonDto.FirstName,
                LastName = createPersonDto.LastName,
                Email = createPersonDto.Email,
                Company = createPersonDto.Company
            };

            _repository.AddAsync(person);
            
            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDTO>> Put([FromBody] PersonDTO personDto)
        {
            var person = new PersonEntity()
            {
                Id = _random.NextInt64(), // TODO: tmp
                Age = personDto.Age,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Email = personDto.Email,
                Company = personDto.Company
            };
            
            _repository.UpdateAsync(person);
            
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById([FromRoute] long id)
        {
            _repository.DeleteAsync(new PersonEntity(){Id = id});
            
            return NoContent();
        }
    }
}