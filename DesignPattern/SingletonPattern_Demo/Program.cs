namespace SingletonPattern_Demo
{
    public class Logger
    {
        private static Logger Instance;

        public Logger()
        {
        }

        public static Logger GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Logger();

            }

            return Instance;
        }
        public void Log(string message)
        {
            Console.WriteLine("LOG: " + message);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();
            logger1.Log("Hello");

            Console.WriteLine(logger1 == logger2);
        }
    }
}
