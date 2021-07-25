using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DataAccessLayer.Entities
{
    public enum TaskStatusId { New, InProgress, Checking, Done };

    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Requirement { get; set; }
        public DateTime Date { get; set; }
        //public string Files { get; set; }
        public TaskStatusId StatusId { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
