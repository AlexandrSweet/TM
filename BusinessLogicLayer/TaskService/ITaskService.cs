using BusinessLogicLayer.ModelsDto.TaskModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.TaskService
{
    public interface ITaskService
    {
        public string AddTask(CreateTaskDto task);
        public TaskDto GetOneTask(Guid taskId);
        public List<TaskDto> GetTasks(int index);
        public List<TaskDto> GetUserTasks(Guid userId);
        public EditTaskDto EditTask(EditTaskDto taskDto, Guid taskId);
        public void DeleteTask(Guid taskDto);

    }
}
