using AutoMapper;
using BusinessLogicLayer.ModelsDto.UserModel;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.UserService
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly Mapper _autoMapper;
        private ILogger<UserService> _logger;

        public UserService(IApplicationDbContext applicationDbContext, ILogger<UserService> logger)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDto>().ReverseMap();
                config.CreateMap<User, RegisterUserDto>().ReverseMap();
                config.CreateMap<User, ListViewUserDto>().ReverseMap();
            
            });
            _autoMapper = new Mapper(mapperConfig);
        }

        public bool AddUser(RegisterUserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Password))
            {
                _logger.LogError("Enter correct password");
                return false;
            }
            if (string.IsNullOrWhiteSpace(userDto.Email))
            {
                _logger.LogError("Enter corrert email");
                return false;
            }
                
            User updatedUser = _autoMapper.Map<RegisterUserDto, User>(userDto);
            _applicationDbContext.Users.Add(updatedUser);
            _applicationDbContext.SaveChanges();
            return true;
        }

        public UserDto GetUser(Guid Id)
        {
            var userContext = _applicationDbContext.Users.Find(Id);
            if (userContext==null)
            {
                Serilog.Log.Error($"User {Id} doesn't exist");
                return null;
            }
            var userDto = _autoMapper.Map<User, UserDto>(userContext);
            return userDto;
        }

        public void EditUser(RegisterUserDto userDto)
        {
            User updatedUser = _autoMapper.Map<RegisterUserDto, User>(userDto);   
            _applicationDbContext.Users.Update(updatedUser);
            _applicationDbContext.SaveChanges();                
            //return userDto;            
        }

        public List<ListViewUserDto> ListViewUserDtos()
        {
            List<ListViewUserDto> userDtos = new List<ListViewUserDto>();
            var dbUsers = _applicationDbContext.Users.ToList();
            userDtos = _autoMapper.Map<List<User>, List<ListViewUserDto>>(dbUsers);
            return userDtos;
        }

        public bool DeleteUser(Guid userId)
        {
            _applicationDbContext.Users.Remove(new User() { Id = userId });
            _applicationDbContext.SaveChanges();
            _logger.LogInformation("User deleted");
            return true;
        }
    }
}
