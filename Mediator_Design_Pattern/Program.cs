public interface IChatMediator
{
    void RegisterUser(ChatUser user); // Đăng ký người dùng vào nhóm chat
    void SendMessage(string message, ChatUser sender); // Gửi tin nhắn từ một người dùng
}

public class ChatMediator : IChatMediator
{
    private readonly List<ChatUser> _users = new List<ChatUser>();

    public void RegisterUser(ChatUser user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, ChatUser sender)
    {
        foreach (var user in _users)
        {
            // Không gửi tin nhắn lại cho chính người gửi
            if (user != sender)
            {
                user.ReceiveMessage(message, sender.Name);
            }
        }
    }
}

public abstract class ChatUser
{
    protected readonly IChatMediator _mediator;

    public string Name { get; }

    public ChatUser(IChatMediator mediator, string name)
    {
        _mediator = mediator;
        Name = name;
    }

    public abstract void SendMessage(string message);
    public abstract void ReceiveMessage(string message, string sender);
}

public class User : ChatUser
{
    public User(IChatMediator mediator, string name) : base(mediator, name)
    {
    }

    public override void SendMessage(string message)
    {
        Console.WriteLine($"{Name} gửi tin nhắn: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message, string sender)
    {
        Console.WriteLine($"{Name} nhận tin nhắn từ {sender}: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo Mediator
        IChatMediator chatMediator = new ChatMediator();

        // Tạo người dùng
        ChatUser user1 = new User(chatMediator, "Alice");
        ChatUser user2 = new User(chatMediator, "Bob");
        ChatUser user3 = new User(chatMediator, "Charlie");

        // Đăng ký người dùng vào nhóm chat
        chatMediator.RegisterUser(user1);
        chatMediator.RegisterUser(user2);
        chatMediator.RegisterUser(user3);

        // Giao tiếp thông qua Mediator
        user1.SendMessage("Xin chào mọi người!");
        user2.SendMessage("Chào Alice!");
        user3.SendMessage("Chào cả hai!");
    }
}
