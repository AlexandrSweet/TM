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
            TaskDto.Date = DateTime.UtcNow;
            Task newTask = _autoMapper.Map<CreateTaskDto, Task>(TaskDto);

            _applicationDbContext.Tasks.Add(newTask);
            _applicationDbContext.SaveChanges();
            TaskDto = _autoMapper.Map<Task, CreateTaskDto>(newTask);
            return TaskDto;
        }

        public List<ListViewTaskDto> GetTasks(int number)
        {
            var tasks = _applicationDbContext.Tasks?.ToList();
            var resultList = new List<ListViewTaskDto>();

            int? range = tasks.Count();
            if (range < number)
                number = (int)range;

            for (int i = 0; i < number; i++)            
                resultList.Add(_autoMapper.Map<Task, ListViewTaskDto>(tasks[i]));
            
            return resultList;
        }
        
        public TaskDto EditTask(string taskId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(string taskId)
        {
            _applicationDbContext.Tasks.Remove(new Task() { Id = Guid.Parse(taskId) });
            _applicationDbContext.SaveChanges();
        }

    }
}
