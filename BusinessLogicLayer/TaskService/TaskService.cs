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

            });
            _autoMapper = new Mapper(mapperConfig);
        }

        public TaskDto AddTask(TaskDto TaskDto)
        {            
            try
            {
                if (TaskDto.Id == null)
                    return null;
                else
                {
                    TaskDto.Id = Guid.NewGuid();
                    Task newTask = _autoMapper.Map<TaskDto, Task>(TaskDto);
                    _applicationDbContext.Tasks.Add(newTask);
                    _applicationDbContext.SaveChanges();
                    TaskDto = _autoMapper.Map<Task, TaskDto>(newTask);
                    return TaskDto;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null;
                throw e;
            }
        }

        public List<TaskDto> GetTasks(int number)
        {
            var tasks = _applicationDbContext.Tasks?.ToList();
            //var resultList = _autoMapper.Map<List<Task>, List<TaskDto>>(tasks);
            //resultList.RemoveRange(number, resultList.Count);
            var resultList = new List<TaskDto>();
            for (int i = 0; i < number; i++)
            {
                resultList.Add(_autoMapper.Map<Task, TaskDto>(tasks[i]));
            }
            return resultList;
        }
        
        public TaskDto EditTask(string taskId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(string taskId)
        {
            try
            {
                Guid actualGuid = Guid.Parse(taskId);
                _applicationDbContext.Tasks.Remove(new Task() { Id = actualGuid });
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
