using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using BusinessLogicLayer.ModelsDto.TaskModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.ModelsDto.UserModel
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        
        [MaxLength(20)]
        public string Password { get; set; }
        public Role RoleId { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public List<MessageDto> Messages { get; set; }
    }
}
