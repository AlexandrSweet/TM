using BusinessLogicLayer.ModelsDto.UserModel;
using BusinessLogicLayer.UserService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement_Summer2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<ListViewUserDto> GetAll()
        {
            return _userService.ListViewUserDtos();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(Guid id)
        {
            if (_userService.GetUser(id) != null)
                return Ok();
            else
                return BadRequest();
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] RegisterUserDto userDto)
        {
            if (_userService.AddUser(userDto))
                return Ok($"New user profile created. {userDto.FirstName} {userDto.LastName}");
            else
                return BadRequest();
        }

        // PUT api/<UsersController>/5 1dc95143-949e-43c3-8f7a-08d94ea28798
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // PUT api/<UsersController>/5 1dc95143-949e-43c3-8f7a-08d94ea28798
        [HttpPut("{guid}")]
        public ActionResult Put([FromRoute] Guid guid, [FromForm] RegisterUserDto userDto)
        {
            userDto.Id = guid;
            _userService.EditUser(userDto);
            return Ok($"{userDto.FirstName} {userDto.LastName} profile updated");
        }
        /*
        // DELETE api/<UsersController>/5
        [HttpDelete("{userId}")]
        public ActionResult Delete([FromRoute] Guid userId)
        {
            if (_userService.DeleteUser(userId))
                return Ok($"User deleted, ID {userId}");
            else
                return BadRequest();
        }*/
    }
}
