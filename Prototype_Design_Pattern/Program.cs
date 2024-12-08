public interface IProductPrototype
{
    IProductPrototype Clone();
}

public class Product : IProductPrototype
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public Product(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    // Phương thức Clone() để sao chép đối tượng
    public IProductPrototype Clone()
    {
        // Tạo một bản sao mới của đối tượng hiện tại
        return new Product(Name, Price, Description);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo một đối tượng sản phẩm gốc
        IProductPrototype originalProduct = new Product("Laptop", 1000m, "High-end laptop");

        // Sao chép sản phẩm gốc để tạo ra sản phẩm mới
        IProductPrototype clonedProduct = originalProduct.Clone();

        // In ra thông tin sản phẩm gốc và sản phẩm sao chép
        Console.WriteLine($"Original Product: {((Product)originalProduct).Name}, {((Product)originalProduct).Price}, {((Product)originalProduct).Description}");
        Console.WriteLine($"Cloned Product: {((Product)clonedProduct).Name}, {((Product)clonedProduct).Price}, {((Product)clonedProduct).Description}");

        // Thay đổi thông tin của sản phẩm sao chép
        ((Product)clonedProduct).Price = 900m;
        ((Product)clonedProduct).Description = "Discounted laptop";

        Console.WriteLine($"Updated Cloned Product: {((Product)clonedProduct).Name}, {((Product)clonedProduct).Price}, {((Product)clonedProduct).Description}");
    }
}

