//Керування автопарком

public interface IVehicle
{
    void Start();
    void Stop();
    void Drive();
}

public class Car : IVehicle
{
    public string Model { get; set; }
    public Car(string model) { Model = model; }

    public void Start() => Console.WriteLine($"{Model} car started.");
    public void Stop() => Console.WriteLine($"{Model} car stopped.");
    public void Drive() => Console.WriteLine($"{Model} car is driving.");
}

public class Motorcycle : IVehicle
{
    public string Brand { get; set; }
    public Motorcycle(string brand) { Brand = brand; }

    public void Start() => Console.WriteLine($"{Brand} motorcycle started.");
    public void Stop() => Console.WriteLine($"{Brand} motorcycle stopped.");
    public void Drive() => Console.WriteLine($"{Brand} motorcycle is driving.");
}

public class Truck : IVehicle
{
    public int LoadCapacity { get; set; }
    public Truck(int loadCapacity) { LoadCapacity = loadCapacity; }

    public void Start() => Console.WriteLine($"Truck with capacity {LoadCapacity} tons started.");
    public void Stop() => Console.WriteLine($"Truck with capacity {LoadCapacity} tons stopped.");
    public void Drive() => Console.WriteLine($"Truck with capacity {LoadCapacity} tons is driving.");
}

public partial class Program
{
    public static void Main(string[] args)
    {
        IVehicle car1 = new Car("Toyota");
        IVehicle car2 = new Car("Honda");
        IVehicle motorcycle1 = new Motorcycle("Yamaha");
        IVehicle motorcycle2 = new Motorcycle("Harley-Davidson");
        IVehicle truck1 = new Truck(10);
        IVehicle truck2 = new Truck(20);

        IVehicle[] vehicles = { car1, car2, motorcycle1, motorcycle2, truck1, truck2 };

        foreach (var vehicle in vehicles)
        {
            vehicle.Start();
            vehicle.Drive();
            vehicle.Stop();
            Console.WriteLine();
        }
    }
}

//Менеджер завдань

public interface ITask
{
    void Start();
    void Complete();
    string GetTaskInfo();
}

public class WorkTask : ITask
{
    public string Description { get; set; }
    public WorkTask(string description) { Description = description; }

    public void Start() => Console.WriteLine("Work task started.");
    public void Complete() => Console.WriteLine("Work task completed.");
    public string GetTaskInfo() => $"Work Task: {Description}";
}

public class PersonalTask : ITask
{
    public string Description { get; set; }
    public PersonalTask(string description) { Description = description; }

    public void Start() => Console.WriteLine("Personal task started.");
    public void Complete() => Console.WriteLine("Personal task completed.");
    public string GetTaskInfo() => $"Personal Task: {Description}";
}

public class StudyTask : ITask
{
    public string Subject { get; set; }
    public StudyTask(string subject) { Subject = subject; }

    public void Start() => Console.WriteLine("Study task started.");
    public void Complete() => Console.WriteLine("Study task completed.");
    public string GetTaskInfo() => $"Study Task: {Subject}";
}

public partial class Program
{
    public static void Main_1(string[] args)
    {
        ITask workTask = new WorkTask("Finish project");
        ITask personalTask = new PersonalTask("Buy groceries");
        ITask studyTask = new StudyTask("Study C# interfaces");

        ITask[] tasks = { workTask, personalTask, studyTask };

        foreach (var task in tasks)
        {
            Console.WriteLine(task.GetTaskInfo());
            task.Start();
            task.Complete();
            Console.WriteLine();
        }
    }
}

//Керування бібліотекою книг

public interface IPrintable
{
    void Print();
}

public interface IBorrowable
{
    void BorrowItem();
    void ReturnItem();
    bool IsAvailable();
}

public class Book : IPrintable, IBorrowable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    private bool available = true;
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public void Print() => Console.WriteLine($"{Title}, by {Author} ({Year})");

    public void BorrowItem()
    {
        if (available)
        {
            available = false;
            Console.WriteLine($"{Title} has been borrowed.");
        }
        else
        {
            Console.WriteLine($"{Title} is not available.");
        }
    }

    public void ReturnItem()
    {
        available = true;
        Console.WriteLine($"{Title} has been returned.");
    }

    public bool IsAvailable() => available;
}

public partial class Program
{
    public static void Main_2(string[] args)
    {
        Book book1 = new Book("1984", "George Orwell", 1949);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 1960);

        book1.Print();
        book1.BorrowItem();
        book1.BorrowItem();
        book1.ReturnItem();
        book1.BorrowItem();

        Console.WriteLine();

        book2.Print();
        book2.BorrowItem();
    }
}

//Музичний програвач

public interface IPlayable
{
    void Play();
    void Pause();
    void Stop();
}

public interface IRecordable
{
    void Record();
}

public class MusicTrack : IPlayable, IRecordable
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Duration { get; set; } 

    public MusicTrack(string title, string artist, int duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }

    public void Play() => Console.WriteLine($"{Title} by {Artist} is playing.");
    public void Pause() => Console.WriteLine($"{Title} has been paused.");
    public void Stop() => Console.WriteLine($"{Title} has stopped playing.");
    public void Record() => Console.WriteLine($"Recording {Title} by {Artist}.");
}

public partial class Program
{
    public static void Main_3(string[] args)
    {
        MusicTrack track1 = new MusicTrack("Song A", "Artist X", 180);
        MusicTrack track2 = new MusicTrack("Song B", "Artist Y", 240);

        track1.Play();
        track1.Pause();
        track1.Record();
        track1.Stop();

        Console.WriteLine();

        track2.Play();
        track2.Stop();
    }
}

//Електронний пристрій інтернет магазину

public interface IProduct
{
    void DisplayInfo();
}

public interface IShoppable
{
    void AddToCart();
}

public class ElectronicDevice : IProduct
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public decimal Price { get; set; }

    public ElectronicDevice(string name, string manufacturer, decimal price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Price = price;
    }

    public void DisplayInfo() => Console.WriteLine($"Product: {Name}, Manufacturer: {Manufacturer}, Price: ${Price}");
}

public class Smartphone : ElectronicDevice, IShoppable
{
    public int BatteryCapacity { get; set; }

    public Smartphone(string name, string manufacturer, decimal price, int batteryCapacity)
        : base(name, manufacturer, price)
    {
        BatteryCapacity = batteryCapacity;
    }

    public void AddToCart() => Console.WriteLine($"{Name} smartphone added to cart.");
}

public class Laptop : ElectronicDevice, IShoppable
{
    public int RAM { get; set; }

    public Laptop(string name, string manufacturer, decimal price, int ram)
        : base(name, manufacturer, price)
    {
        RAM = ram;
    }

    public void AddToCart() => Console.WriteLine($"{Name} laptop added to cart.");
}

public partial class Program
{
    public static void Main_4(string[] args)
    {
        Smartphone smartphone = new Smartphone("Galaxy S21", "Samsung", 799.99m, 4000);
        Laptop laptop = new Laptop("MacBook Air", "Apple", 999.99m, 8);

        smartphone.DisplayInfo();
        smartphone.AddToCart();

        Console.WriteLine();

        laptop.DisplayInfo();
        laptop.AddToCart();
    }
}
