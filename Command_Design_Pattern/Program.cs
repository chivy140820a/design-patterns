public interface ICommand
{
    void Execute();
}

public class AddDishCommand : ICommand
{
    private readonly Order _order;
    private readonly string _dish;

    public AddDishCommand(Order order, string dish)
    {
        _order = order;
        _dish = dish;
    }

    public void Execute()
    {
        _order.AddDish(_dish);
    }
}

public class RemoveDishCommand : ICommand
{
    private readonly Order _order;
    private readonly string _dish;

    public RemoveDishCommand(Order order, string dish)
    {
        _order = order;
        _dish = dish;
    }

    public void Execute()
    {
        _order.RemoveDish(_dish);
    }
}

public class PayOrderCommand : ICommand
{
    private readonly Order _order;

    public PayOrderCommand(Order order)
    {
        _order = order;
    }

    public void Execute()
    {
        _order.Pay();
    }
}

public class Order
{
    private List<string> _dishes = new List<string>();

    public void AddDish(string dish)
    {
        _dishes.Add(dish);
        Console.WriteLine($"{dish} added to the order.");
    }

    public void RemoveDish(string dish)
    {
        if (_dishes.Contains(dish))
        {
            _dishes.Remove(dish);
            Console.WriteLine($"{dish} removed from the order.");
        }
        else
        {
            Console.WriteLine($"{dish} is not in the order.");
        }
    }

    public void Pay()
    {
        Console.WriteLine("Order is paid.");
    }

    public void ShowOrder()
    {
        Console.WriteLine("Current order:");
        foreach (var dish in _dishes)
        {
            Console.WriteLine($"- {dish}");
        }
    }
}

public class OrderInvoker
{
    private readonly List<ICommand> _commands = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo đối tượng Order
        var order = new Order();

        // Tạo các lệnh
        ICommand addDish = new AddDishCommand(order, "Pizza");
        ICommand removeDish = new RemoveDishCommand(order, "Pizza");
        ICommand payOrder = new PayOrderCommand(order);

        // Tạo đối tượng invoker
        var invoker = new OrderInvoker();

        // Thêm các lệnh vào invoker
        invoker.AddCommand(addDish);
        invoker.AddCommand(removeDish);
        invoker.AddCommand(payOrder);

        // Thực thi các lệnh
        invoker.ExecuteCommands();

        // Hiển thị đơn hàng cuối cùng
        order.ShowOrder();
    }
}
