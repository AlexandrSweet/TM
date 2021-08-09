using System;
using System.Collections.Generic;
using System.Text;
using SendGrid;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using BusinessLogicLayer.ModelsDto.TaskModel;
using DataAccessLayer;

namespace BusinessLogicLayer.EmailService
{
    public class EmailService : IEmailService
    {
        
        private readonly string apiKey = "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";
        private readonly IApplicationDbContext _applicationDbContext;
        
        public EmailService( ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }
        
        public async Task SendEmailAsync(CreateTaskDto taskDto)
        {
            var userTo = _applicationDbContext.Users.Find(taskDto.UserId);
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("TaskManagement.summer.2021@gmail.com", "Notifier");
            var subject = "You have a new task";
            var to = new EmailAddress(userTo.Email);
            var htmlContent = $"<div>Hi {userTo.FirstName} {userTo.LastName}.</div> " +
                $"<div>Check your dashboard for a new task!</div>" +
                $"<div>{taskDto.Title}</div>";
            var spamCheck = new SendGrid.Helpers.Mail.SpamCheck().Enable;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendEmailUpdateAsync(EditTaskDto taskDto)
        {
            var userTo = _applicationDbContext.Users.Find(taskDto.UserId);
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("TaskManagement.summer.2021@gmail.com", "Notifier");
            var subject = "There are some updates";
            var to = new List<EmailAddress>() {
                new EmailAddress(userTo.Email)                
            };
            var htmlContent = $"<div>Hi {userTo.FirstName} {userTo.LastName}.</div> "+
                $"<div>The task '{taskDto.Title}' has been modified. So let's check what's new!</div> ";
            var spamCheck = new SendGrid.Helpers.Mail.SpamCheck().Enable;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, htmlContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }
}
