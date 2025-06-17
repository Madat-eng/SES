using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAL; 

namespace SendingEmaileveryWeek
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Sending emails at: {time}", DateTimeOffset.Now);

                    // You can replace this with your actual email sending logic 
                    EmailService.SendEmailToAll(
                        sender: "noreply@yourdomain.com",
                        subject: "Weekly offers",
                        body: "This is your weekly email update offers."
                    );

                    _logger.LogInformation("Emails sent successfully.");

                  
                    await Task.Delay(TimeSpan.FromDays(7), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while sending weekly emails.");
                
                    await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                }
            }
        }
    }
}
