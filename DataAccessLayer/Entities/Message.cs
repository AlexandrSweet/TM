using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string MessageFrom { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public DateTime Data { get; set; }
    }
}
