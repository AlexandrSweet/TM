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
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace TaskManagement_Summer2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {       
        private readonly UserManager<User> _userManager;       
        public AuthController(UserManager<User> userManager)
        {          
            _userManager = userManager;          
        }

        [HttpPost]
        [Route("login")]        
        public async Task<IActionResult> Login(LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid data");
            }

            var foundUser = await _userManager.FindByEmailAsync(user.Email);            

            if(foundUser == null)
            {
                return BadRequest("User with this email non found");
            }
            
            var password = await _userManager.CheckPasswordAsync(foundUser, user.Password);

            if (password)
            {         
               
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44379",
                    audience: "https://localhost:44379",
                    claims: new List<Claim> 
                    { 
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, foundUser.RoleId.ToString()),
                        new Claim("firstName", foundUser.FirstName),
                        new Claim("lastName", foundUser.LastName),
                        new Claim("email", foundUser.Email),
                        new Claim("role", foundUser.RoleId.ToString()),// роль брать у юсера с базы
                        new Claim("id", foundUser.Id.ToString())
                    },
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                string roleUser = foundUser.RoleId.ToString();
                return Ok(new { 
                    Token = tokenString, roleUser
                    
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
