using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public enum Role { User, Customer, Administrator};

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }      
        //[Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        public string Password { get; set; }
        public Role RoleId { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
