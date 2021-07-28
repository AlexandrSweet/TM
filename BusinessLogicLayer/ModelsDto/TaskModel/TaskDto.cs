using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogicLayer.ModelsDto.TaskModel
{
    

    public class TaskDto
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Requirement { get; set; }//is it necessary?
        public DateTime Date { get; set; }
        public string Files { get; set; }
        public TaskStatusId StatusId { get; set; }//change to enum type value
        public Guid UserId { get; set; }
        public List<MessageDto> MessagesDto { get; set; }
    }
}
