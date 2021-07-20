using BusinessLogicLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.TaskService
{
    public interface ITaskService
    {
        public TaskDto AddTask(TaskDto task);
        public List<TaskDto> GetTasks(int number);
        public TaskDto EditTask(string taskId);
        public void DeleteTask(string taskId);

    }
}
