using MailKitDemo.Models;

public interface IEmailService
{
    void Send(MailMessage message);
}
