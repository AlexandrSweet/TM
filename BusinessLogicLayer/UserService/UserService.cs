using AutoMapper;
using BusinessLogicLayer.ModelsDto.UserModel;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.UserService
{
    public class UserService: IUserService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly Mapper _autoMapper;

        public UserService(IApplicationDbContext applicationDbContext)
        {
            
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
            throw new NotImplementedException();
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
    }
}
