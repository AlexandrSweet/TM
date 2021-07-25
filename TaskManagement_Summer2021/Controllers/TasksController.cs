using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.TaskService;
using BusinessLogicLayer.ModelsDto.TaskModel;
using Microsoft.Extensions.Logging;

namespace TaskManagement_Summer2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private ILogger<TasksController> _logger;


        public TasksController(ITaskService taskService, ILogger<TasksController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddTask")]
        public ActionResult<string> CreateTask([FromForm] CreateTaskDto taskModel)
        {
            if (ModelState.IsValid)
            {
                string taskId = _taskService.AddTask(taskModel);
                return Ok($"Task created. ID {taskId}");
            }
            return BadRequest("Invalid Data");
        }

        [HttpGet]
        [Route("ViewTasks")]
        public IEnumerable<ListViewTaskDto> GetTasks(int index, int count = 3)
        {
            return _taskService.GetTasks(index, count);
        }

        [HttpGet]
        [Route("{taskId}")]
        public ActionResult<TaskDto> GetOneTask([FromRoute] Guid taskId)
        {
            return Ok(_taskService.GetOneTask(taskId));
        }

        [HttpPut]
        //[ValidateAntiForgeryToken]
        [Route("{taskId}/edit")]
        public ActionResult<EditTaskDto> EditTask([FromForm] EditTaskDto taskDto, [FromRoute] Guid taskId)
        {
            taskDto.Id = taskId;
            return Ok(_taskService.EditTask(taskDto));
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
