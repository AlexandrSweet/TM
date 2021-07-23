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
        public ActionResult<TaskDto> CreateTask(CreateTaskDto taskModel)
        {            
            try
            {
                return Ok(_taskService.AddTask(taskModel));
            }
            catch (Exception e)
            {                
                return BadRequest(e.Message);
            }            
        }

        [HttpGet]
        [Route("GetTasks")]
        public IEnumerable<ListViewTaskDto> GetTasks(int numberOfTasks)
        {
            try
            {                
                return _taskService.GetTasks(numberOfTasks);                
            }
            catch (Exception)
            {
                return null;
            }            
        }

        [HttpGet]
        [Route("GetOneTasks")]
        public ActionResult<TaskDto> GetOneTask(string taskId)
        {
            try
            {
                return Ok(_taskService.GetOneTask(taskId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("EditTask")]
        public ActionResult<TaskDto> EditTask(TaskDto taskDto)
        {
            try
            {
                return Ok(_taskService.EditTask(taskDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTask")]
        public ActionResult DeleteTask(string taskId)
        {
            try
            {
                _taskService.DeleteTask(taskId);                
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }
    }
}
