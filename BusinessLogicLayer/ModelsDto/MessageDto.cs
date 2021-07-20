using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ModelsDto
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string MessageFrom { get; set; }
        public string UserId { get; set; }
        public string TaskId { get; set; }
        public string Data { get; set; }
    }
}
