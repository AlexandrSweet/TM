using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ModelsDto.TaskModel
{
    public class CreateTaskDto
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }//is it necessary?
        public DateTime Date { get; set; }
    }
}
