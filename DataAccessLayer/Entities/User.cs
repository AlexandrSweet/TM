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
        public string FirstName { get; set; }        
        public string LastName { get; set; }       
        public string Password { get; set; }
        public Role RoleId { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
