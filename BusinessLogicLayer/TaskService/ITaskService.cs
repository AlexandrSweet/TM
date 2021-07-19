using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.TaskService
{
    public interface ITaskService
    {
        public TaskDto AddTask(TaskDto task);
        public void DeleteTask(int taskId);

    }
}
