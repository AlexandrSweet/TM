using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.TaskService;
using BusinessLogicLayer.ModelsDto;
using Microsoft.Extensions.Logging;
using Serilog;

using Microsoft.Extensions.Configuration;

namespace TaskManagement_Summer2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private ILogger<TaskController> _logger;//= Log.Logger.ForContext<TaskController>();


        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddTask")]
        public ActionResult<TaskDto> CreateTask(TaskDto taskModel)
        {            
            try
            {
                _taskService.AddTask(taskModel);
                //Log.Information("Good Run");
                return
                    Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return
                    BadRequest();
            }
            
        }

        [HttpGet]
        [Route("GetAllTasks")]
        public IEnumerable<TaskDto> GetTasks(string number)
        {
            try
            {
                int tempNumber;
                if(!int.TryParse(number, out tempNumber))
                    throw new Exception("uncorrect input");
                return _taskService.GetTasks(tempNumber);                
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null;
            }
            
        }

        [HttpDelete]
        [Route("DeleteTask")]
        public ActionResult DeleteTask(string taskId)
        {
            try
            {
                _taskService.DeleteTask(taskId);
                //Log.Information("Good Run");
                return
                    Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return
                    BadRequest();
            }
            
        }
    }
}
