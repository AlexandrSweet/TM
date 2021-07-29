using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, Guid>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            //Database.EnsureCreated();
            //Mocks mocks = new Mocks(this);
            //mocks.FillBase();
        }
        public DbSet<Task> Tasks { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }    
}
