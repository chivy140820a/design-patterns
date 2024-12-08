public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

// PayPal Strategy
public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} through PayPal.");
    }
}

// CreditCard Strategy
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} through Credit Card.");
    }
}

// Bitcoin Strategy
public class BitcoinPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} through Bitcoin.");
    }
}

public class PaymentContext
{
    private readonly IPaymentStrategy _paymentStrategy;

    // Constructor nhận chiến lược thanh toán
    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    // Thực thi chiến lược thanh toán
    public void ExecutePayment(decimal amount)
    {
        _paymentStrategy.Pay(amount);
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Chọn chiến lược PayPal và thực hiện thanh toán
        PaymentContext paypalPayment = new PaymentContext(new PayPalPayment());
        paypalPayment.ExecutePayment(100.50m); // Output: Processing payment of $100.50 through PayPal.

        // Chọn chiến lược Credit Card và thực hiện thanh toán
        PaymentContext creditCardPayment = new PaymentContext(new CreditCardPayment());
        creditCardPayment.ExecutePayment(200.75m); // Output: Processing payment of $200.75 through Credit Card.

        // Chọn chiến lược Bitcoin và thực hiện thanh toán
        PaymentContext bitcoinPayment = new PaymentContext(new BitcoinPayment());
        bitcoinPayment.ExecutePayment(50.30m); // Output: Processing payment of $50.30 through Bitcoin.
    }
}
