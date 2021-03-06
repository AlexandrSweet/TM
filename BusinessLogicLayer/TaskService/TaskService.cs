using System;
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
using System.Net.Mail;
using System.Net;

namespace BusinessLogicLayer.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly Mapper _autoMapper;
        private ILogger<TaskService> _logger;

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
        public Guid AddTask(CreateTaskDto TaskDto)
        {            
            Task newTask = _autoMapper.Map<CreateTaskDto, Task>(TaskDto);
            _applicationDbContext.Tasks.Add(newTask);
            _applicationDbContext.SaveChanges();            
            _logger.LogInformation("New task added");            
            return newTask.Id;
        }

        //Returns a list of a specific number of tasks
        //Index is where displaying list begins, count is how many items will be displayed
        public List<ListViewTaskDto> GetTasks()
        {
            var resultList = new List<ListViewTaskDto>();
            var tasks = _applicationDbContext.Tasks.ToList();
            foreach (var t in tasks)
            {
                var tempUser = _applicationDbContext.Users.Find(t.UserId);
                resultList.Add(new ListViewTaskDto()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Date = t.Date,
                    StatusId = t.StatusId,
                    User = new ModelsDto.UserModel.ListViewUserDto(tempUser)                    
                }) ;
            }
            return resultList;
        }

        //Returns list of tasks assigned to user
        //Requires  user ID
        public List<TaskDto> GetUserTasks(Guid userId)
        {
            var resultList = new List<TaskDto>();
            var tasks = _applicationDbContext.Tasks.Where(u =>  u.UserId == userId).ToList();
            if (tasks==null)
                return resultList;
            resultList = _autoMapper.Map<List<Task>, List<TaskDto>>(tasks.ToList());
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
                return tempTaskDto;                
            }
            tempTaskDto = _autoMapper.Map<Task, TaskDto>(task);
            _logger.LogInformation($"Task displayed, id = {tempTaskDto.Id}");
            return tempTaskDto; 
            
        }

        //Updates existing task
        //Saving requires User ID for current task (guid)
        public EditTaskDto EditTask(EditTaskDto taskDto, Guid taskId)
        {
            taskDto.Id = taskId;
            Task updatedTask = _autoMapper.Map<EditTaskDto, Task>(taskDto);
            _applicationDbContext.Tasks.Update(updatedTask);
            _applicationDbContext.SaveChanges();
            _logger.LogInformation("Task updated");
            return taskDto;
        }

        //Deletes chosen task
        public void DeleteTask(Guid taskId)
        {
            _applicationDbContext.Tasks.Remove(new Task() { Id=taskId});
            _applicationDbContext.SaveChanges();
            _logger.LogInformation("Task deleted");            
        }

    }
}
