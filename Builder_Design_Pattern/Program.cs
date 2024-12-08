public class Email
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<string> Attachments { get; set; } = new List<string>();

    public override string ToString()
    {
        return $"To: {To}\nSubject: {Subject}\nBody: {Body}\nAttachments: {string.Join(", ", Attachments)}";
    }
}

public interface IEmailBuilder
{
    IEmailBuilder SetRecipient(string to);
    IEmailBuilder SetSubject(string subject);
    IEmailBuilder SetBody(string body);
    IEmailBuilder AddAttachment(string attachment);
    Email Build();
}

public class EmailBuilder : IEmailBuilder
{
    private readonly Email _email = new Email();

    public IEmailBuilder SetRecipient(string to)
    {
        _email.To = to;
        return this;
    }

    public IEmailBuilder SetSubject(string subject)
    {
        _email.Subject = subject;
        return this;
    }

    public IEmailBuilder SetBody(string body)
    {
        _email.Body = body;
        return this;
    }

    public IEmailBuilder AddAttachment(string attachment)
    {
        _email.Attachments.Add(attachment);
        return this;
    }

    public Email Build()
    {
        return _email;
    }
}

public class EmailDirector
{
    private readonly IEmailBuilder _builder;

    public EmailDirector(IEmailBuilder builder)
    {
        _builder = builder;
    }

    public Email BuildWelcomeEmail(string recipient)
    {
        return _builder
            .SetRecipient(recipient)
            .SetSubject("Welcome!")
            .SetBody("Thank you for joining our platform.")
            .Build();
    }

    public Email BuildPromotionalEmail(string recipient)
    {
        return _builder
            .SetRecipient(recipient)
            .SetSubject("Special Offer!")
            .SetBody("Check out our latest promotions!")
            .AddAttachment("promotions.pdf")
            .Build();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Sử dụng trực tiếp Builder
        IEmailBuilder builder = new EmailBuilder();
        Email customEmail = builder
            .SetRecipient("user@example.com")
            .SetSubject("Custom Email")
            .SetBody("This is a custom email.")
            .AddAttachment("custom-attachment.pdf")
            .Build();

        Console.WriteLine("Custom Email:");
        Console.WriteLine(customEmail);

        // Sử dụng Director
        var director = new EmailDirector(new EmailBuilder());
        Email welcomeEmail = director.BuildWelcomeEmail("newuser@example.com");
        Email promotionalEmail = director.BuildPromotionalEmail("user@example.com");

        Console.WriteLine("\nWelcome Email:");
        Console.WriteLine(welcomeEmail);

        Console.WriteLine("\nPromotional Email:");
        Console.WriteLine(promotionalEmail);
    }
}
