namespace DesignPattern
{
    // Singleton Pattern Demo
    // Ensures a class has only one instance and provides a global point of access to it

    // Basic Singleton Implementation
    public class SingletonBasic
    {
        private static SingletonBasic _instance;
        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation
        private SingletonBasic()
        {
            Console.WriteLine("SingletonBasic instance created!");
        }

        // Thread-safe getInstance method
        public static SingletonBasic GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonBasic();
                    }
                }
            }
            return _instance;
        }

        public void ShowMessage()
        {
            Console.WriteLine($"I am SingletonBasic instance: {GetHashCode()}");
        }
    }

    // Lazy<T> Singleton Implementation (Recommended)
    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> _instance = 
            new Lazy<SingletonLazy>(() => new SingletonLazy());

        // Private constructor
        private SingletonLazy()
        {
            Console.WriteLine("SingletonLazy instance created!");
        }

        public static SingletonLazy Instance => _instance.Value;

        public void ShowMessage()
        {
            Console.WriteLine($"I am SingletonLazy instance: {GetHashCode()}");
        }
    }

    // Static Constructor Singleton (Thread-safe by default in .NET)
    public class SingletonStatic
    {
        private static readonly SingletonStatic _instance = new SingletonStatic();

        // Private constructor
        private SingletonStatic()
        {
            Console.WriteLine("SingletonStatic instance created!");
        }

        public static SingletonStatic Instance => _instance;

        public void ShowMessage()
        {
            Console.WriteLine($"I am SingletonStatic instance: {GetHashCode()}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Singleton Pattern Demo ===\n");

            // Demo 1: Basic Singleton with Double-Check Locking
            Console.WriteLine("--- 1. Basic Singleton (Double-Check Locking) ---");
            var singleton1 = SingletonBasic.GetInstance();
            var singleton2 = SingletonBasic.GetInstance();
            singleton1.ShowMessage();
            singleton2.ShowMessage();
            Console.WriteLine($"Both instances are same: {ReferenceEquals(singleton1, singleton2)}\n");

            // Demo 2: Lazy<T> Singleton
            Console.WriteLine("--- 2. Lazy<T> Singleton ---");
            var lazySingleton1 = SingletonLazy.Instance;
            var lazySingleton2 = SingletonLazy.Instance;
            lazySingleton1.ShowMessage();
            lazySingleton2.ShowMessage();
            Console.WriteLine($"Both instances are same: {ReferenceEquals(lazySingleton1, lazySingleton2)}\n");

            // Demo 3: Static Constructor Singleton
            Console.WriteLine("--- 3. Static Constructor Singleton ---");
            var staticSingleton1 = SingletonStatic.Instance;
            var staticSingleton2 = SingletonStatic.Instance;
            staticSingleton1.ShowMessage();
            staticSingleton2.ShowMessage();
            Console.WriteLine($"Both instances are same: {ReferenceEquals(staticSingleton1, staticSingleton2)}\n");

            Console.WriteLine("=== Summary ===");
            Console.WriteLine("All three implementations ensure only one instance is created.");
            Console.WriteLine("Recommended: Use Lazy<T> or Static Constructor approach for simplicity and thread-safety.");
        }
    }
}
