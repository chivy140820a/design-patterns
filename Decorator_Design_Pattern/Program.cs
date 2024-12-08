public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email Notification: {message}");
    }
}

public class NotificationDecorator : INotification
{
    protected readonly INotification _notification;

    public NotificationDecorator(INotification notification)
    {
        _notification = notification;
    }

    public virtual void Send(string message)
    {
        _notification.Send(message);
    }
}

public class SMSNotification : NotificationDecorator
{
    public SMSNotification(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"SMS Notification: {message}");
    }
}

public class PushNotification : NotificationDecorator
{
    public PushNotification(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Push Notification: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Chỉ gửi Email
        INotification emailNotification = new EmailNotification();
        emailNotification.Send("Hello User!");

        Console.WriteLine();

        // Gửi Email + SMS
        INotification emailAndSms = new SMSNotification(new EmailNotification());
        emailAndSms.Send("Hello User!");

        Console.WriteLine();

        // Gửi Email + SMS + Push
        INotification emailSmsPush = new PushNotification(new SMSNotification(new EmailNotification()));
        emailSmsPush.Send("Hello User!");
    }
}
