using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BusinessLogicLayer.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly Mapper _autoMapper;
        Serilog.ILogger _logger = Log.ForContext<TaskService>();
        

        public TaskService(IApplicationDbContext applicationDbContext)
        {
            
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
                Task newTask = _autoMapper.Map<TaskDto, Task>(TaskDto);
                _applicationDbContext.Tasks.Add(newTask);
                _applicationDbContext.SaveChanges();
                TaskDto = _autoMapper.Map<Task, TaskDto>(newTask);
                return TaskDto;
            }
            catch (Exception e)
            {
                _logger.Information(e, e.Message);
                return null;
            }
        }

        public void DeleteTask(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
