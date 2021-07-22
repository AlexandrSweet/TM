using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogicLayer.ModelsDto;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;
using System.Linq;


namespace BusinessLogicLayer.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly Mapper _autoMapper;
        private ILogger<TaskService> _logger;// = Log.ForContext<TaskService>();


        public TaskService(IApplicationDbContext applicationDbContext, ILogger<TaskService> logger)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Task, TaskDto>().ReverseMap();
                config.CreateMap<Task, CreateTaskDto>().ReverseMap();
                config.CreateMap<Task, ListViewTaskDto>().ReverseMap();

            });
            _autoMapper = new Mapper(mapperConfig);
        }

        public CreateTaskDto AddTask(CreateTaskDto TaskDto)
        {
            try
            {
                /*if (_applicationDbContext.Users.Count() == 0)
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
                }*/
                var temp = _applicationDbContext.Users.FirstOrDefault(u =>
                u.FirstName == "Tom"&&u.Email== "tom.hanks@gmail.co").Id;
                //TaskDto.Id = Guid.NewGuid().ToString();
                TaskDto.Date = DateTime.UtcNow;
                Task newTask = _autoMapper.Map<CreateTaskDto, Task>(TaskDto);
                
                _applicationDbContext.Tasks.Add(newTask);
                _applicationDbContext.SaveChanges();
                TaskDto = _autoMapper.Map<Task, CreateTaskDto>(newTask);
                return TaskDto;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                if (e.InnerException!=null)
                {
                    _logger.LogError(e.InnerException, e.InnerException.Message);
                }
                return new CreateTaskDto();
            }
            
        }

        public List<ListViewTaskDto> GetTasks(int number)
        {
            try
            {
                //var tasks = _applicationDbContext.Tasks?.ToList();
                int? range = _applicationDbContext.Tasks?.ToList().Count();
                if (range > number)
                    number = (int)range;
                //var resultList = _autoMapper.Map<List<Task>, List<TaskDto>>(tasks);
                //resultList.RemoveRange(number, resultList.Count);
                var resultList = new List<ListViewTaskDto>();
                for (int i = 0; i < number; i++)
                {
                    resultList.Add(_autoMapper.Map<Task, ListViewTaskDto>(_applicationDbContext.Tasks?.ToList()[i]));
                }
                return resultList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new List<ListViewTaskDto>();
            }
            
        }
        
        public TaskDto EditTask(string taskId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(string taskId)
        {
            try
            {
                //Guid actualGuid = Guid.Parse(taskId);
                _applicationDbContext.Tasks.Remove(new Task() { Id = Guid.Parse(taskId) });
                _applicationDbContext.SaveChanges();
                _logger.LogInformation("Task Service");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

        }

    }
}
