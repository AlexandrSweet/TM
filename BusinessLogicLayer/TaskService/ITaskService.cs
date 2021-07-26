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
        public List<ListViewTaskDto> GetTasks(int index, int count);       
        public EditTaskDto EditTask(EditTaskDto taskDto);
        public void DeleteTask(Guid taskDto);

    }
}
