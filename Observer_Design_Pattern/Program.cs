public interface IObserver
{
    void Update(float temperature);
}


public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}


public class WeatherStation : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private float _temperature;

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature);
        }
    }

    public void SetTemperature(float temperature)
    {
        _temperature = temperature;
        NotifyObservers();  // Thông báo cho các observer khi nhiệt độ thay đổi
    }
}

public class MobileApp : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"Mobile App: The temperature has changed to {temperature}°C.");
    }
}

public class Website : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"Website: The temperature has changed to {temperature}°C.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo ConcreteSubject (WeatherStation)
        WeatherStation weatherStation = new WeatherStation();

        // Khởi tạo ConcreteObservers
        MobileApp mobileApp = new MobileApp();
        Website website = new Website();

        // Đăng ký observers
        weatherStation.RegisterObserver(mobileApp);
        weatherStation.RegisterObserver(website);

        // Thay đổi nhiệt độ và thông báo cho các observers
        weatherStation.SetTemperature(25);  // Output: Mobile App: The temperature has changed to 25°C.
                                            //         Website: The temperature has changed to 25°C.

        // Thay đổi nhiệt độ và thông báo lại cho các observers
        weatherStation.SetTemperature(30);  // Output: Mobile App: The temperature has changed to 30°C.
                                            //         Website: The temperature has changed to 30°C.
    }
}
