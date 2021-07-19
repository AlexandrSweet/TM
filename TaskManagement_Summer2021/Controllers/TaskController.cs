using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.TaskService;
using BusinessLogicLayer.Models;
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
        Serilog.ILogger _logger = Serilog.Log.ForContext<TaskService>();


        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            
        }

        [HttpPost]
        [Route("AddTask")]
        public ActionResult<TaskDto> CreateTask(TaskDto taskModel)
        {
            TaskDto testTask = new TaskDto()
            {
                Id = "1",
                Title = "TestTitle",
                Description = "Random text"
            };
            try
            {
                Log.Information("First Run");
                return
                    Ok(_taskService.AddTask(testTask));
                                    
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Not good api");
                return
                    BadRequest();
            }
            //if (taskModel.Title != null && taskModel.Description != null)
            //    return _taskService.AddTask(testTask);
            //else
            //    return BadRequest();
        }
    }
}
