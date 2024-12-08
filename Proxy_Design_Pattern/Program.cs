public interface IDataService
{
    string GetData();
}

public class RealDataService : IDataService
{
    public string GetData()
    {
        // Giả sử đây là một yêu cầu tốn kém như gọi đến API ngoài
        Console.WriteLine("Fetching data from the external source...");
        return "Data from external source";
    }
}

public class CachingDataServiceProxy : IDataService
{
    private readonly RealDataService _realDataService;
    private string _cachedData;

    public CachingDataServiceProxy(RealDataService realDataService)
    {
        _realDataService = realDataService;
    }

    public string GetData()
    {
        // Kiểm tra xem có dữ liệu trong cache không
        if (_cachedData == null)
        {
            Console.WriteLine("No cache, fetching data...");
            _cachedData = _realDataService.GetData();
        }
        else
        {
            Console.WriteLine("Returning cached data...");
        }

        return _cachedData;
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo đối tượng thật và Proxy
        var realDataService = new RealDataService();
        var dataServiceProxy = new CachingDataServiceProxy(realDataService);

        // Lần đầu tiên gọi, sẽ lấy dữ liệu từ nguồn bên ngoài
        Console.WriteLine(dataServiceProxy.GetData());  // Output: Fetching data from the external source...
                                                        // Data from external source

        // Lần thứ hai gọi, sẽ lấy dữ liệu từ cache
        Console.WriteLine(dataServiceProxy.GetData());  // Output: Returning cached data...
                                                        // Data from external source
    }
}
