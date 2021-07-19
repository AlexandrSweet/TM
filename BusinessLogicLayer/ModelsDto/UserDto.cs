using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ModelsDto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public List<TaskDto> TasksDto { get; set; }
        public List<MessageDto> MessagesDto { get; set; }
    }
}
