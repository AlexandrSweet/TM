using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public enum Role { User, Customer, Administrator};

    public class User : IdentityUser<Guid>
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }      
        //[Required]
        //MaxLength(20)]
        public string FirstName { get; set; }
        //[MaxLength(20)]
        public string LastName { get; set; }
        //[Required]
        //[MaxLength(50)]
        //public string Email { get; set; }
        //[Required]
        //[MaxLength(16)]
        public string Password { get; set; }
        public Role RoleId { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
