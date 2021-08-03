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
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        //[HttpGet("Get all users in base")]
        [HttpGet]
        [Route("AllUsers")]
        public IEnumerable<ListViewUserDto> GetAll()
        {
            return _userService.ListViewUserDtos();            
        }

        // GET api/<UsersController>/5
        //[HttpGet("Get user by ID")]
        [HttpGet]
        [Route("{userId}")]
        public ActionResult<UserDto> Get(Guid userId)
        {
            UserDto user = _userService.GetUser(userId);
            if (user != null)
                return Ok(user);
            else
                return BadRequest();
        }

        // POST api/<UsersController>
        //[HttpPost("Add new user")]
        [HttpPost]
        [Route("AddNewUser")]
        public ActionResult Post([FromBody] RegisterUserDto userDto)
        {
            if (_userService.AddUser(userDto))
                return Ok($"New user profile created. {userDto.FirstName} {userDto.LastName}");
            else
                return BadRequest();
        }

        
        //[HttpPut("Edit user")]
        [HttpPut]
        [Route("{guid}")]
        public ActionResult Put([FromRoute] Guid guid, RegisterUserDto userDto)
        {
            userDto.Id = guid;
            if (ModelState.IsValid)
            {
                _userService.EditUser(userDto);
                return Ok($"{userDto.FirstName} {userDto.LastName} profile updated");
            }
            else
            {
                return BadRequest("Fill in all fields");
            }
            
        }
        [HttpGet]
        [Route("get-users")]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
        [HttpPut]
        [Route("edit-user")]
        public bool EditUserRole(UserDto user)
        {
            if (user != null)
            {
                _userService.EditUserRole(user);
                return true;
            }
            return false;
        }

    }
}
