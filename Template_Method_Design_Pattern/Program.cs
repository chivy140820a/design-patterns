public abstract class PaymentProcessor
{
    // Template method
    public void ProcessPayment(decimal amount)
    {
        AuthorizePayment(amount);
        ProcessTransaction(amount);
        SendReceipt();
    }

    // Các bước chung (có thể thay đổi tùy thuộc vào phương thức thanh toán)
    protected abstract void AuthorizePayment(decimal amount);
    protected abstract void ProcessTransaction(decimal amount);

    // Bước chung không thay đổi (hook method)
    protected virtual void SendReceipt()
    {
        Console.WriteLine("Sending receipt...");
    }
}


public class CreditCardPaymentProcessor : PaymentProcessor
{
    protected override void AuthorizePayment(decimal amount)
    {
        Console.WriteLine($"Authorizing credit card payment of {amount:C}...");
    }

    protected override void ProcessTransaction(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount:C}...");
    }
}

public class PayPalPaymentProcessor : PaymentProcessor
{
    protected override void AuthorizePayment(decimal amount)
    {
        Console.WriteLine($"Authorizing PayPal payment of {amount:C}...");
    }

    protected override void ProcessTransaction(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount:C}...");
    }

    // Override hook method to customize receipt sending
    protected override void SendReceipt()
    {
        Console.WriteLine("Sending PayPal-specific receipt...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo đối tượng thanh toán bằng thẻ tín dụng và thực thi
        PaymentProcessor creditCardPayment = new CreditCardPaymentProcessor();
        creditCardPayment.ProcessPayment(100.00m);

        Console.WriteLine();

        // Tạo đối tượng thanh toán qua PayPal và thực thi
        PaymentProcessor paypalPayment = new PayPalPaymentProcessor();
        paypalPayment.ProcessPayment(200.00m);
    }
}
