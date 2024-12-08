// Abstraction
public abstract class Notification
{
    protected readonly IMessageSender _messageSender;

    protected Notification(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public abstract void Send(string message);
}

// Refined Abstraction
public class RegularNotification : Notification
{
    public RegularNotification(IMessageSender messageSender) : base(messageSender)
    {
    }

    public override void Send(string message)
    {
        Console.WriteLine("Sending Regular Notification...");
        _messageSender.SendMessage(message);
    }
}

public class UrgentNotification : Notification
{
    public UrgentNotification(IMessageSender messageSender) : base(messageSender)
    {
    }

    public override void Send(string message)
    {
        Console.WriteLine("Sending Urgent Notification!");
        _messageSender.SendMessage($"[URGENT] {message}");
    }
}

// Implementor
public interface IMessageSender
{
    void SendMessage(string message);
}

// Concrete Implementor: Email
public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

// Concrete Implementor: SMS
public class SmsSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}

// Concrete Implementor: Push Notification
public class PushNotificationSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Push Notification sent: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Regular notification via Email
        IMessageSender emailSender = new EmailSender();
        Notification regularEmailNotification = new RegularNotification(emailSender);
        regularEmailNotification.Send("This is a regular email notification.");

        // Urgent notification via SMS
        IMessageSender smsSender = new SmsSender();
        Notification urgentSmsNotification = new UrgentNotification(smsSender);
        urgentSmsNotification.Send("This is an urgent SMS notification.");

        // Regular notification via Push Notification
        IMessageSender pushNotificationSender = new PushNotificationSender();
        Notification regularPushNotification = new RegularNotification(pushNotificationSender);
        regularPushNotification.Send("This is a regular push notification.");
    }
}
