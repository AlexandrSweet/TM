using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ModelsDto.TaskModel
{
    public class ListViewTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
