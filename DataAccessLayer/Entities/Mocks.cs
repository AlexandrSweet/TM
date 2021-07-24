using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccessLayer.Entities
{
    public class Mocks : IDisposable
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public Mocks(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Dispose()
        {
            
        }

        public void FillBase()
        {
            if (_applicationDbContext.Users.Count() == 0)
            {
                _applicationDbContext.Users.Add(
                   new User()
                   {
                       FirstName = "Tim",
                       LastName = "Rott",
                       RoleId = Role.User,
                       Email = "tim.rott@gmail.com"
                   });
                _applicationDbContext.Users.AddRange(new List<User>() {
                         new User()
                         {
                             FirstName = "Bill",
                             LastName = "Clinton",
                             RoleId = Role.User,
                             Email = "bill.clinton@gmail.com"
                         },
                         new User()
                         {
                             FirstName = "Tom",
                             LastName = "Hanks",
                             RoleId = Role.User,
                             Email = "tom.hanks@gmail.com"
                         },
                         new User()
                         {
                             FirstName = "Vasya",
                             LastName = "Poopkin",
                             RoleId = Role.Customer,
                             Email = "v.poopkin@gmail.com"
                         },
                         new User()
                         {
                             FirstName = "Johnny",
                             LastName = "Depp",
                             RoleId = Role.User,
                             Email = "johnny.depp@gmail.com"
                         },
                         new User()
                         {
                             FirstName = "Eddi",
                             LastName = "Johnes",
                             RoleId = Role.Administrator,
                             Email = "eddie.johnes@gmail.com"
                         },
                     });
                _applicationDbContext.SaveChanges();
            }

            if (_applicationDbContext.Tasks.Count() == 0)
            {
                _applicationDbContext.Tasks.AddRange(new List<Task>()
                {
                    new Task()
                    {
                        Date = DateTime.UtcNow,
                        Title = "first task",
                        Description = "wserdtfghuj"
                    },
                    new Task()
                    {
                        Date = DateTime.UtcNow,
                        Title = "second task",
                        Description = "aghgwtgfa"
                    },
                    new Task()
                    {
                        Date = DateTime.UtcNow,
                        Title = "third task",
                        Description = "tcfvygbuhjnmk,mk"
                    },
                    new Task()
                    {
                        Date = DateTime.UtcNow,
                        Title = "forth task",
                        Description = "jnuytvgbh"
                    },
                    new Task()
                    {
                        Date = DateTime.UtcNow,
                        Title = "fifth task",
                        Description = "njhbiuvyc"
                    },
                });
                _applicationDbContext.SaveChanges();
            }
            
        }
    }
}
