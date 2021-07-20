using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ModelsDto
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public string Date { get; set; }
        public string Files { get; set; }
        public string StatusId { get; set; }
        public string UserId { get; set; }
        public List<MessageDto> MessagesDto { get; set; }
    }
}
