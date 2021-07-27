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

        //public void FillBase()
        //{
        //    if (_applicationDbContext.Users.Count() == 0)
        //    {
        //        _applicationDbContext.Users.Add(
        //           new User()
        //           {
        //               FirstName = "Tim",
        //               LastName = "Rott",
        //               RoleId = Role.User,
        //               Email = "tim.rott@gmail.com",
        //               Password = "123"
        //           });
        //        _applicationDbContext.Users.AddRange(new List<User>() {
        //                 new User()
        //                 {
        //                     FirstName = "Bill",
        //                     LastName = "Clinton",
        //                     RoleId = Role.User,
        //                     Email = "bill.clinton@gmail.com",
        //                     Password = "123"

        //                 },
        //                 new User()
        //                 {
        //                     FirstName = "Tom",
        //                     LastName = "Hanks",
        //                     RoleId = Role.User,
        //                     Email = "tom.hanks@gmail.com",
        //                     Password = "123"
        //                 },
        //                 new User()
        //                 {
        //                     FirstName = "Vasya",
        //                     LastName = "Poopkin",
        //                     RoleId = Role.Customer,
        //                     Email = "v.poopkin@gmail.com",
        //                     Password = "123"
        //                 },
        //                 new User()
        //                 {
        //                     FirstName = "Johnny",
        //                     LastName = "Depp",
        //                     RoleId = Role.User,
        //                     Email = "johnny.depp@gmail.com",
        //                     Password = "123"
        //                 },
        //                 new User()
        //                 {
        //                     FirstName = "Eddi",
        //                     LastName = "Johnes",
        //                     RoleId = Role.Administrator,
        //                     Email = "eddie.johnes@gmail.com",
        //                     Password = "123"
        //                 },
        //             });
        //        _applicationDbContext.SaveChanges();
        //    }

        //    if (_applicationDbContext.Tasks.Count() == 0)
        //    {
        //        _applicationDbContext.Tasks.AddRange(new List<Task>()
        //        {
        //            new Task()
        //            {
        //                Date = DateTime.UtcNow,
        //                Title = "first task",
        //                Description = "wserdtfghuj",
        //                StatusId = TaskStatusId.New,
        //                UserId = _applicationDbContext.Users.First(u => u.Email=="tom.hanks@gmail.com").Id
        //            },
        //            new Task()  
        //            {
        //                Date = DateTime.UtcNow,
        //                Title = "second task",
        //                Description = "aghgwtgfa",
        //                StatusId = TaskStatusId.New,
        //                UserId = _applicationDbContext.Users.First(u => u.Email=="johnny.depp@gmail.com").Id
        //            },
        //            new Task()
        //            {
        //                Date = DateTime.UtcNow,
        //                Title = "third task",
        //                Description = "tcfvygbuhjnmk,mk",
        //                StatusId = TaskStatusId.New,
        //                UserId = _applicationDbContext.Users.First(u => u.Email=="johnny.depp@gmail.com").Id
        //            },
        //            new Task()
        //            {
        //                Date = DateTime.UtcNow,
        //                Title = "forth task",
        //                Description = "jnuytvgbh",
        //                StatusId = TaskStatusId.New,
        //                UserId = _applicationDbContext.Users.First(u => u.Email=="johnny.depp@gmail.com").Id
        //            },
        //            new Task()
        //            {
        //                Date = DateTime.UtcNow,
        //                Title = "fifth task",
        //                Description = "njhbiuvyc",
        //                StatusId = TaskStatusId.New,
        //                UserId = _applicationDbContext.Users.First(u => u.Email=="johnny.depp@gmail.com").Id
        //            },
        //        }) ;
        //        _applicationDbContext.SaveChanges();
        //    }
            
        //}
    }
}
