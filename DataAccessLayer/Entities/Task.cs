﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DataAccessLayer.Entities
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public string Date { get; set; }
        public string Files { get; set; }
        public string StatusId { get; set; }
        public string UserId { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}