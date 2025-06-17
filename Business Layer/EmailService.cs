using System.Collections.Generic;
using DAL;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace BAL
{
    public static class EmailService
    {
        public static void AddEmail(string emailAddress)
        {
            EmailRepository.AddEmail(emailAddress);
        }

        public static void DeleteEmailById(int id)
        {
            EmailRepository.DeleteEmailById(id);
        }

        public static void DeleteEmailByAddress(string email)
        {
            EmailRepository.DeleteEmailByAddress(email);
        }

        public static List<EmailDTO> GetAllEmails()
        {
            return EmailRepository.GetAllEmails();
        }

        public static List<EmailTransactionDTO> GetAllEmailTransactions()
        {
            return EmailRepository.GetAllEmailTransactions();
        }

        public static void SendEmailToAll(string sender, string subject, string body)
        {
            var emails = EmailRepository.GetAllEmails();
            foreach (var email in emails)
            {
                SendUsingOutlook(email.EmailAddress, subject, body);
            }

            EmailRepository.SendEmailToAll(sender, subject, body);
        }

        private static void SendUsingOutlook(string to, string subject, string body)
        {
            var outlookApp = new Outlook.Application();
            var mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

            mailItem.To = to;
            mailItem.Subject = subject;
            mailItem.Body = body;
            mailItem.Send();
        }
    }
}
