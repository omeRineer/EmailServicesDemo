using MailKitDemo.Models;
using MimeKit;



Console.Write("Subject : ");
var subject = Console.ReadLine();

Console.Write("Body : ");
var inputMessage = Console.ReadLine();



IEmailService emailService = new EmailService();

var message = new MailMessage
{
    From = new List<InternetAddress>
    {
        // Sender
    },
    To = new List<InternetAddress>
    {
        // Recipients
    },
    Subject = subject ?? "",
    Body = inputMessage ?? ""

};

emailService.Send(message);
