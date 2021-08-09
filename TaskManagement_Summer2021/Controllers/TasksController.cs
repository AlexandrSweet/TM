using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.TaskService;
using BusinessLogicLayer.ModelsDto.TaskModel;
using Microsoft.Extensions.Logging;
using BusinessLogicLayer.EmailService;

namespace TaskManagement_Summer2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {        
        private readonly ITaskService _taskService;
        private readonly IEmailService _emailService;
        private ILogger<TasksController> _logger;


        public TasksController(ITaskService taskService, ILogger<TasksController> logger, IEmailService emailService)
        {
            _taskService = taskService;
            _logger = logger;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("AddTask")]
        public ActionResult CreateTask( CreateTaskDto taskModel)
        {
            if (ModelState.IsValid)
            {
                Guid taskId = _taskService.AddTask(taskModel);
                _emailService.SendEmailAsync(taskModel);
                return Ok(taskId);
            }
            else
                throw new ArgumentException("Enter valid data");
        }

        [HttpGet]
        [Route("ViewTasks")]
        public IEnumerable<ListViewTaskDto> GetTasks()//!!![FromRoute] Guid userId,
        {
            return _taskService.GetTasks();
        }

        [HttpGet]
        [Route("UserTasks/{userId}")]
        public IEnumerable<TaskDto> GetUserTasks([FromRoute] Guid userId)//!!![FromRoute] Guid userId,
        {

            return _taskService.GetUserTasks(userId);
        }

        [HttpGet("{taskId}")]
        //[Route("{userId}/")]
        public ActionResult<TaskDto> GetOneTask( [FromRoute] Guid taskId)//!!![FromRoute] Guid userId,
        {
            return Ok(_taskService.GetOneTask(taskId));
        }

        [HttpPut]
        //[ValidateAntiForgeryToken]
        [Route("{taskId}/edit")]
        public ActionResult<EditTaskDto> EditTask( EditTaskDto taskDto, [FromRoute] Guid taskId)//[FromForm]
        {
            if (ModelState.IsValid)
            {
                var task = _taskService.EditTask(taskDto, taskId);
                _emailService.SendEmailUpdateAsync(task);
                return Ok(task);
            }                
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("{taskId}")]
        public ActionResult DeleteTask([FromRoute] Guid taskId)
        {
            _taskService.DeleteTask(taskId);                
            return Ok();
        }
    }
}
