using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogicLayer.ModelsDto.TaskModel
{
    public class CreateTaskDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
