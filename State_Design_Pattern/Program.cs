public class Order
{
    public IOrderState CurrentState { get; set; }

    public Order(IOrderState initialState)
    {
        CurrentState = initialState;
    }

    public void TransitionTo(IOrderState state)
    {
        Console.WriteLine($"Transitioning to {state.GetType().Name}");
        CurrentState = state;
    }

    public void HandleRequest()
    {
        CurrentState.Handle(this);
    }
}

public interface IOrderState
{
    void Handle(Order order);
}

// Trạng thái Mới
public class NewOrderState : IOrderState
{
    public void Handle(Order order)
    {
        Console.WriteLine("Order is new. Processing the order.");
        order.TransitionTo(new ProcessedOrderState());  // Chuyển sang trạng thái đã xử lý
    }
}

// Trạng thái Đang xử lý
public class ProcessedOrderState : IOrderState
{
    public void Handle(Order order)
    {
        Console.WriteLine("Order is being processed. Preparing for shipping.");
        order.TransitionTo(new ShippedOrderState());  // Chuyển sang trạng thái đã giao hàng
    }
}

// Trạng thái Đã giao hàng
public class ShippedOrderState : IOrderState
{
    public void Handle(Order order)
    {
        Console.WriteLine("Order is shipped. Preparing for delivery.");
        order.TransitionTo(new DeliveredOrderState());  // Chuyển sang trạng thái đã nhận
    }
}

// Trạng thái Đã nhận
public class DeliveredOrderState : IOrderState
{
    public void Handle(Order order)
    {
        Console.WriteLine("Order has been delivered. The process is complete.");
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo đơn hàng với trạng thái ban đầu là "New"
        Order order = new Order(new NewOrderState());

        // Xử lý đơn hàng
        order.HandleRequest();  // In ra: Order is new. Processing the order.
        order.HandleRequest();  // In ra: Order is being processed. Preparing for shipping.
        order.HandleRequest();  // In ra: Order is shipped. Preparing for delivery.
        order.HandleRequest();  // In ra: Order has been delivered. The process is complete.
    }
}
