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
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> List()
        {
            return Ok(this._userRepository.GetAll().AsEnumerable());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> getUser([FromRoute] long id)
        {
            var user = await this._userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] UserCreateRequest userCreateRequest)
        {
            var user = new User()
            {
                FirstName = userCreateRequest.FirstName,
                MiddleName = userCreateRequest.MiddleName,
                LastName = userCreateRequest.LastName,
                Comment = "",
            };

            await this._userRepository.AddAsync(user);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update([FromRoute] long id, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            var user = await this._userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = userUpdateRequest.FirstName;
            user.MiddleName = userUpdateRequest.MiddleName;
            user.LastName = userUpdateRequest.LastName;

            await this._userRepository.UpdateAsync(user);

            return Ok(user);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Update([FromRoute] long id)
        {
            var user = await this._userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;

            await this._userRepository.UpdateAsync(user);

            return NoContent();
        }

    }
}
