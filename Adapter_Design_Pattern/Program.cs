// Target Interface
public interface INewEmailService
{
    void SendEmail(string to, string subject, string body);
}

// Adaptee: Thư viện cũ
public class LegacyEmailService
{
    public void SendMessage(string recipient, string title, string message)
    {
        Console.WriteLine($"Sending Email via Legacy Service: To={recipient}, Subject={title}, Body={message}");
    }
}
// Adapter
public class EmailServiceAdapter : INewEmailService
{
    private readonly LegacyEmailService _legacyEmailService;

    public EmailServiceAdapter(LegacyEmailService legacyEmailService)
    {
        _legacyEmailService = legacyEmailService;
    }

    public void SendEmail(string to, string subject, string body)
    {
        // Chuyển đổi từ giao diện mới sang giao diện cũ
        _legacyEmailService.SendMessage(to, subject, body);
    }
}

// Client
public class EmailClient
{
    private readonly INewEmailService _emailService;

    public EmailClient(INewEmailService emailService)
    {
        _emailService = emailService;
    }

    public void NotifyUser(string email)
    {
        _emailService.SendEmail(email, "Welcome", "Thank you for signing up!");
    }
}
