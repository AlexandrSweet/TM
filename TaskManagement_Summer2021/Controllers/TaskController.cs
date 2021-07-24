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
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private ILogger<TaskController> _logger;


        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddTask")]
        public ActionResult<string> CreateTask(CreateTaskDto taskModel)
        {
            if (taskModel.Title.Length>=0 && taskModel.Description.Length >= 0)
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
        public ActionResult<TaskDto> GetOneTask(Guid taskId)
        {
            return Ok(_taskService.GetOneTask(taskId));
        }

        [HttpPut]
        [Route("{taskDto.Id}/edit")]
        public ActionResult<EditTaskDto> EditTask(EditTaskDto taskDto)
        {
            return Ok(_taskService.EditTask(taskDto));
        }

        [HttpDelete]
        [Route("DeleteTask/{taskId}")]
        public ActionResult DeleteTask(Guid taskId)
        {
            _taskService.DeleteTask(taskId);                
            return Ok();
        }
    }
}
