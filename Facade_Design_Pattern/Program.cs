// Quản lý thanh toán
public class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount}...");
    }
}

// Quản lý kho
public class InventoryService
{
    public void CheckInventory(string productId)
    {
        Console.WriteLine($"Checking inventory for product {productId}...");
    }
}

// Quản lý giao hàng
public class ShippingService
{
    public void ShipProduct(string productId, string address)
    {
        Console.WriteLine($"Shipping product {productId} to address {address}...");
    }
}

public class ECommerceFacade
{
    private readonly PaymentService _paymentService;
    private readonly InventoryService _inventoryService;
    private readonly ShippingService _shippingService;

    public ECommerceFacade()
    {
        _paymentService = new PaymentService();
        _inventoryService = new InventoryService();
        _shippingService = new ShippingService();
    }

    // Phương thức đơn giản để thực hiện một đơn hàng
    public void PlaceOrder(string productId, decimal amount, string shippingAddress)
    {
        Console.WriteLine("Placing order...");
        _inventoryService.CheckInventory(productId);
        _paymentService.ProcessPayment(amount);
        _shippingService.ShipProduct(productId, shippingAddress);
        Console.WriteLine("Order placed successfully!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Khách hàng chỉ cần gọi phương thức duy nhất của facade
        var ecommerceFacade = new ECommerceFacade();
        ecommerceFacade.PlaceOrder("product123", 99.99m, "1234 Elm St.");
    }
}
