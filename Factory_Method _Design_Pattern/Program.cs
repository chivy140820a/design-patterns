
// Lựa chọn loại thanh toán
PaymentFactory paymentFactory = new PayPalPaymentFactory(); // Hoặc CreditCardPaymentFactory
IPayment payment = paymentFactory.CreatePayment();

// Xử lý thanh toán
payment.ProcessPayment(100.00m);

// Product: Định nghĩa giao diện của thanh toán
public interface IPayment
{
    void ProcessPayment(decimal amount);
}

// ConcreteProduct: Thanh toán bằng thẻ tín dụng
public class CreditCardPayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card Payment of {amount:C}");
    }
}

// ConcreteProduct: Thanh toán qua PayPal
public class PayPalPayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal Payment of {amount:C}");
    }
}

// Creator: Lớp cơ sở khai báo Factory Method
public abstract class PaymentFactory
{
    public abstract IPayment CreatePayment();
}

// ConcreteCreator: Tạo đối tượng CreditCardPayment
public class CreditCardPaymentFactory : PaymentFactory
{
    public override IPayment CreatePayment()
    {
        return new CreditCardPayment();
    }
}

// ConcreteCreator: Tạo đối tượng PayPalPayment
public class PayPalPaymentFactory : PaymentFactory
{
    public override IPayment CreatePayment()
    {
        return new PayPalPayment();
    }
}


// Factory Method là một Creational Design Pattern cung cấp một giao diện để tạo đối tượng, cho phép các lớp con quyết định kiểu đối tượng sẽ được khởi tạo.
// Mẫu thiết kế này giúp giảm sự phụ thuộc giữa các lớp cụ thể bằng cách sử dụng một phương thức chung để tạo đối tượng.