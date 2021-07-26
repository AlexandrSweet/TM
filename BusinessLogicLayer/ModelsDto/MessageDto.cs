using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ModelsDto
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string MessageFrom { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public DateTime Data { get; set; }
    }
}
