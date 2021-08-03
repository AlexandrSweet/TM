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

        private static async void SendEmail(string text)
        {            
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("TaskManagement.summer.2021@gmail.com", "Notifier");
            // кому отправляем
            MailAddress to = new MailAddress("molozhenko2011@gmail.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);            
            // тема письма
            m.Subject = "Test";
            // письмо представляет код html
            m.Body = $"<h2>{text}</h2>";
            m.IsBodyHtml = true;

            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                // логин и пароль
                Credentials = new NetworkCredential("TaskManagement.summer.2021@gmail.com", "G2WAjhku6yWmFRh"),
                EnableSsl = true
            };
           
            await smtp.SendMailAsync(m);
        }

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
            //TaskDto.Date = DateTime.UtcNow;
            Task newTask = _autoMapper.Map<CreateTaskDto, Task>(TaskDto);
            _applicationDbContext.Tasks.Add(newTask);
            _applicationDbContext.SaveChanges();
            //TaskDto = _autoMapper.Map<Task, CreateTaskDto>(newTask);
            _logger.LogInformation("New task added");
            SendEmail("New task added");
            return newTask.Id.ToString();
        }

        //Returns a list of a specific number of tasks
        //Index is where displaying list begins, count is how many items will be displayed
        public List<TaskDto> GetTasks(int index)
        {
            int count = 5;
            var resultList = new List<TaskDto>();
            var tasks = _applicationDbContext.Tasks.ToList();
            if (tasks.Count < index )
            {
                index = tasks.Count-count;
                if ((index+ count )>tasks.Count)
                {
                    count = tasks.Count-index;
                }                
            }
            if(index>0)
                resultList = _autoMapper.Map<List<Task>, List<TaskDto>>(tasks.GetRange(index,count));
            else
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
                //tempTaskDto.Description = "NOT EXIST";
                return tempTaskDto;
                //throw new Exception($"Wrong taskID {taskId}");
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
