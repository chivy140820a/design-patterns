public abstract class SupportHandler
{
    protected SupportHandler _nextHandler;

    public void SetNextHandler(SupportHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void HandleRequest(string issue);
}


public class LevelOneSupport : SupportHandler
{
    public override void HandleRequest(string issue)
    {
        if (issue == "Simple issue")
        {
            Console.WriteLine("Level One Support: Handling simple issue.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(issue);
        }
    }
}

public class LevelTwoSupport : SupportHandler
{
    public override void HandleRequest(string issue)
    {
        if (issue == "Moderate issue")
        {
            Console.WriteLine("Level Two Support: Handling moderate issue.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(issue);
        }
    }
}

public class LevelThreeSupport : SupportHandler
{
    public override void HandleRequest(string issue)
    {
        if (issue == "Complex issue")
        {
            Console.WriteLine("Level Three Support: Handling complex issue.");
        }
        else
        {
            Console.WriteLine("No handler for this issue.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo các handler
        var levelOneSupport = new LevelOneSupport();
        var levelTwoSupport = new LevelTwoSupport();
        var levelThreeSupport = new LevelThreeSupport();

        // Xây dựng chuỗi xử lý
        levelOneSupport.SetNextHandler(levelTwoSupport);
        levelTwoSupport.SetNextHandler(levelThreeSupport);

        // Gửi yêu cầu đến handler đầu tiên
        Console.WriteLine("Client: Reporting 'Simple issue'.");
        levelOneSupport.HandleRequest("Simple issue");

        Console.WriteLine("\nClient: Reporting 'Moderate issue'.");
        levelOneSupport.HandleRequest("Moderate issue");

        Console.WriteLine("\nClient: Reporting 'Complex issue'.");
        levelOneSupport.HandleRequest("Complex issue");

        Console.WriteLine("\nClient: Reporting 'Unspecified issue'.");
        levelOneSupport.HandleRequest("Unspecified issue");
    }
}
