using BusinessLogicLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.TaskService
{
    public interface ITaskService
    {
        public CreateTaskDto AddTask(CreateTaskDto task);
        public TaskDto GetOneTask(string taskId);
        public List<ListViewTaskDto> GetTasks(int number);       
        public TaskDto EditTask(TaskDto taskDto);
        public void DeleteTask(string taskId);

    }
}
