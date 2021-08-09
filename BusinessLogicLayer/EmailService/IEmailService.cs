using BusinessLogicLayer.ModelsDto.TaskModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EmailService
{
    public interface IEmailService
    {
        public Task SendEmailAsync(CreateTaskDto taskDto);
        public Task SendEmailUpdateAsync(EditTaskDto taskDto);
    }
}
