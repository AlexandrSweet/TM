﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogicLayer.ModelsDto.TaskModel;
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
                config.CreateMap<Task, EditTaskDto>().ReverseMap();

            });
            _autoMapper = new Mapper(mapperConfig);
        }

        //Creates new task in database
        //Requires minimum of information, no files, user ID or status
        public string AddTask(CreateTaskDto TaskDto)
        {
            TaskDto.Date = DateTime.UtcNow;
            Task newTask = _autoMapper.Map<CreateTaskDto, Task>(TaskDto);
            _applicationDbContext.Tasks.Add(newTask);
            _applicationDbContext.SaveChanges();
            TaskDto = _autoMapper.Map<Task, CreateTaskDto>(newTask);
            _logger.LogInformation("New task added");
            return newTask.Id.ToString();
        }

        //Returns a list of a specific number of tasks
        //Index is where displaying list begins, count is how many items will be displayed
        public List<ListViewTaskDto> GetTasks(int index, int count)
        {
            var resultList = new List<ListViewTaskDto>();
            var tasks = _applicationDbContext.Tasks.ToList();
            if (tasks.Count < count )
            {
                count = tasks.Count;
                if (index>=count)
                {
                    index = count - 1;
                }
            }
            resultList = _autoMapper.Map<List<Task>, List<ListViewTaskDto>>(tasks.GetRange(index,count));
            return resultList;           
        }

        //Returns task from database with all fields (either setted up or not)
        //Requires  ID of existing task
        public TaskDto GetOneTask(Guid taskId)
        {
            TaskDto tempTaskDto = new TaskDto();                
            Task task = _applicationDbContext.Tasks.Find(taskId);
            if (task==null)
            {
                _logger.LogError($"Wrong taskID {taskId}");
                tempTaskDto.Description = "NOT EXIST";
                return tempTaskDto;
            }
            tempTaskDto = _autoMapper.Map<Task, TaskDto>(task);
            _logger.LogInformation($"Task displayed, id = {tempTaskDto.Id}");
            return tempTaskDto; 
            
        }

        //Updates existing task
        //Saving requires User ID for current task (guid)
        public EditTaskDto EditTask(EditTaskDto taskDto)
        {
            Task updatedTask = _autoMapper.Map<EditTaskDto, Task>(taskDto);
            _applicationDbContext.Tasks.Update(updatedTask);
            _applicationDbContext.SaveChanges();
            _logger.LogInformation("Task updated");
            return taskDto;
        }

        public void DeleteTask(Guid taskId)
        {
            _applicationDbContext.Tasks.Remove(new Task() { Id=taskId});
            _applicationDbContext.SaveChanges();
            _logger.LogInformation("Task deleted");
            
        }

    }
}
