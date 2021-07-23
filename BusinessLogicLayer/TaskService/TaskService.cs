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
            try
            {
                _applicationDbContext.Tasks.Add(newTask);
                _applicationDbContext.SaveChanges();
                TaskDto = _autoMapper.Map<Task, CreateTaskDto>(newTask);
                _logger.LogInformation("New task added");
                return TaskDto;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return TaskDto;
            }
        }

        public List<ListViewTaskDto> GetTasks(int number)
        {
            var tasks = _applicationDbContext.Tasks?.ToList();
            var resultList = new List<ListViewTaskDto>();

            int? range = tasks.Count();
            if (range < number)
                number = (int)range;
            try
            {
                for (int i = 0; i < number; i++)
                    resultList.Add(_autoMapper.Map<Task, ListViewTaskDto>(tasks[i]));
                _logger.LogInformation("List of tasks displayed");
                return resultList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return resultList;
            }
        }

        public TaskDto GetOneTask(string taskId)
        {
            if (taskId == null)
                return new TaskDto();
            else
            {
                TaskDto tempTaskDto = new TaskDto();
                try
                {
                    Task task = _applicationDbContext.Tasks.Find(new Task() { Id = Guid.Parse(taskId) });
                    tempTaskDto = _autoMapper.Map<Task, TaskDto>(task);
                    _logger.LogInformation($"Task displayed, id = {tempTaskDto.Id}");
                    return tempTaskDto;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return tempTaskDto;
                }

            };
        }

        public TaskDto EditTask(TaskDto taskDto)
        {
            if (taskDto.Id == null)
                return null;
            else
            {
                try 
                {
                    Task updatedTask = _autoMapper.Map<TaskDto, Task>(taskDto);
                    //Task task = _applicationDbContext.Tasks.Find(new Task() { Id = taskDto.Id });
                    _applicationDbContext.Tasks.Update(updatedTask);
                    return taskDto;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return taskDto;
                }
                
            };
        }

        public void DeleteTask(string taskId)
        {            
            try
            {
                _applicationDbContext.Tasks.Remove(new Task() { Id = Guid.Parse(taskId) });
                _applicationDbContext.SaveChanges();
                _logger.LogInformation("Task deleted");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

    }
}
