using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using BusinessLogicLayer.ModelsDto.TaskModel;

namespace BusinessLogicLayer.ModelsDto.UserModel
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role RoleId { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public List<MessageDto> Messages { get; set; }
    }
}
