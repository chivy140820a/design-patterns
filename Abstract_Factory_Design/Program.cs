// AbstractProduct: Button
public interface IButton
{
    void Render();
}

// AbstractProduct: Checkbox
public interface ICheckbox
{
    void Render();
}

// ConcreteProduct: Button trên Windows
public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows Button");
    }
}

// ConcreteProduct: Button trên MacOS
public class MacButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering MacOS Button");
    }
}

// ConcreteProduct: Checkbox trên Windows
public class WindowsCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows Checkbox");
    }
}

// ConcreteProduct: Checkbox trên MacOS
public class MacCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering MacOS Checkbox");
    }
}

// AbstractFactory
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// ConcreteFactory: Windows
public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

// ConcreteFactory: MacOS
public class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

// Client
public class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void Render()
    {
        _button.Render();
        _checkbox.Render();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Lựa chọn hệ điều hành
        IGUIFactory factory;

        Console.WriteLine("Enter OS type (Windows/Mac): ");
        string osType = Console.ReadLine();

        if (osType.Equals("Windows", StringComparison.OrdinalIgnoreCase))
        {
            factory = new WindowsFactory();
        }
        else if (osType.Equals("Mac", StringComparison.OrdinalIgnoreCase))
        {
            factory = new MacFactory();
        }
        else
        {
            throw new ArgumentException("Invalid OS type");
        }

        // Khởi tạo ứng dụng
        Application app = new Application(factory);
        app.Render();
    }
}
