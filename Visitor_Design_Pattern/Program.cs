// Interface cho các phần tử (sản phẩm)
public interface IProduct
{
    void Accept(ITaxVisitor visitor);
}

// ConcreteElement cho các loại sản phẩm cụ thể
public class FoodProduct : IProduct
{
    public decimal Price { get; set; }

    public void Accept(ITaxVisitor visitor)
    {
        visitor.VisitFoodProduct(this);
    }
}

public class ElectronicProduct : IProduct
{
    public decimal Price { get; set; }

    public void Accept(ITaxVisitor visitor)
    {
        visitor.VisitElectronicProduct(this);
    }
}

// Visitor Interface
public interface ITaxVisitor
{
    void VisitFoodProduct(FoodProduct foodProduct);
    void VisitElectronicProduct(ElectronicProduct electronicProduct);
}

// ConcreteVisitor cho việc tính thuế
public class TaxCalculator : ITaxVisitor
{
    public void VisitFoodProduct(FoodProduct foodProduct)
    {
        // Tính thuế cho sản phẩm thực phẩm (ví dụ: 5% thuế)
        decimal taxAmount = foodProduct.Price * 0.05m;
        Console.WriteLine($"Food product tax: {taxAmount:C}");
    }

    public void VisitElectronicProduct(ElectronicProduct electronicProduct)
    {
        // Tính thuế cho sản phẩm điện tử (ví dụ: 15% thuế)
        decimal taxAmount = electronicProduct.Price * 0.15m;
        Console.WriteLine($"Electronic product tax: {taxAmount:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo các sản phẩm cụ thể
        IProduct foodProduct = new FoodProduct { Price = 100 };
        IProduct electronicProduct = new ElectronicProduct { Price = 200 };

        // Tạo đối tượng Visitor
        ITaxVisitor taxVisitor = new TaxCalculator();

        // Gọi phương thức Accept để visitor xử lý các phần tử
        foodProduct.Accept(taxVisitor);
        electronicProduct.Accept(taxVisitor);
    }
}

