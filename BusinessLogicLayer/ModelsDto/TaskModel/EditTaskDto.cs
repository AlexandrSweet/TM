using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ModelsDto.TaskModel
{
    public class EditTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public DateTime Date { get; set; }
        public string Files { get; set; }
        public TaskStatusId StatusId { get; set; }
        public Guid UserId { get; set; }        
    }
}
