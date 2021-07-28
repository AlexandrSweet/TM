using BusinessLogicLayer.ModelsDto.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.UserService
{
    public interface IUserService
    {
        public bool AddUser(RegisterUserDto userDto);
        public List<ListViewUserDto> ListViewUserDtos();
        public UserDto GetUser(Guid Id);
        public void EditUser(RegisterUserDto userDto);
        public bool DeleteUser(Guid userId);
        public UserDto GetUserByEmail(string email);

    }
}
