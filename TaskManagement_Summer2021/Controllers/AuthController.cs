using TaskManagement_Summer2021.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BusinessLogicLayer.UserService;
using BusinessLogicLayer.ModelsDto.UserModel;

namespace TaskManagement_Summer2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]        
        public IActionResult Login(LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid data");
            }

            UserDto foundUser = _userService.GetUserByEmail(user.Email);

            if(foundUser == null)
            {
                return BadRequest("User with this email non found");
            }

            if (foundUser.Password == user.Password)
            {         
               
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44379",
                    audience: "https://localhost:44379",
                    claims: new List<Claim> { new Claim(ClaimsIdentity.DefaultRoleClaimType, foundUser.RoleId.ToString()),
                    new Claim("firstName", foundUser.FirstName),
                    new Claim("lastName", foundUser.LastName),
                    new Claim("email", foundUser.Email),
                    new Claim("role", foundUser.RoleId.ToString())// роль брать у юсера с базы
                         },
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
