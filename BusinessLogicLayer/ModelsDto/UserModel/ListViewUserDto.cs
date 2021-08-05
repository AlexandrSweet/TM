using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ModelsDto.UserModel
{
    public class ListViewUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public Role RoleId { get; set; }

        public ListViewUserDto() { }

        public ListViewUserDto(User v)
        {
            Id = v.Id;
            FirstName = v.FirstName;
            LastName = v.LastName;
            RoleId = v.RoleId;

        }
    }
}

