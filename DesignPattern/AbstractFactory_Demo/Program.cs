namespace AbstractFactory_Demo
{
    // =============================================================
    // Abstract Factory Pattern
    // - Provides an interface for creating FAMILIES of related objects
    //   without specifying their concrete classes.
    // - Use when: you need to create objects that belong together
    //   (e.g., Windows UI vs Mac UI components).
    // =============================================================

    // Abstract Products
    public interface IButton
    {
        void Render();
        void OnClick();
    }

    public interface ICheckbox
    {
        void Render();
        void OnToggle();
    }

    public interface ITextField
    {
        void Render();
        void OnInput(string text);
    }

    // --- Windows Concrete Products ---
    public class WindowsButton : IButton
    {
        public void Render() => Console.WriteLine("  [WindowsButton] Rendering a Windows-style button.");
        public void OnClick() => Console.WriteLine("  [WindowsButton] Click! Windows button pressed.");
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Render() => Console.WriteLine("  [WindowsCheckbox] Rendering a Windows-style checkbox: [✓]");
        public void OnToggle() => Console.WriteLine("  [WindowsCheckbox] Toggled! Windows checkbox changed.");
    }

    public class WindowsTextField : ITextField
    {
        public void Render() => Console.WriteLine("  [WindowsTextField] Rendering a Windows-style text field: [________]");
        public void OnInput(string text) => Console.WriteLine($"  [WindowsTextField] Input received: \"{text}\"");
    }

    // --- Mac Concrete Products ---
    public class MacButton : IButton
    {
        public void Render() => Console.WriteLine("  [MacButton] Rendering a macOS-style rounded button.");
        public void OnClick() => Console.WriteLine("  [MacButton] Click! macOS button pressed.");
    }

    public class MacCheckbox : ICheckbox
    {
        public void Render() => Console.WriteLine("  [MacCheckbox] Rendering a macOS-style checkbox: (✓)");
        public void OnToggle() => Console.WriteLine("  [MacCheckbox] Toggled! macOS checkbox changed.");
    }

    public class MacTextField : ITextField
    {
        public void Render() => Console.WriteLine("  [MacTextField] Rendering a macOS-style text field: |________|");
        public void OnInput(string text) => Console.WriteLine($"  [MacTextField] Input received: \"{text}\"");
    }

    // Abstract Factory
    public interface IUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
        ITextField CreateTextField();
    }

    // Concrete Factories
    public class WindowsUIFactory : IUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
        public ITextField CreateTextField() => new WindowsTextField();
    }

    public class MacUIFactory : IUIFactory
    {
        public IButton CreateButton() => new MacButton();
        public ICheckbox CreateCheckbox() => new MacCheckbox();
        public ITextField CreateTextField() => new MacTextField();
    }

    // Client code - works with factories and products via abstract interfaces
    public class Application
    {
        private readonly IButton _button;
        private readonly ICheckbox _checkbox;
        private readonly ITextField _textField;

        public Application(IUIFactory factory)
        {
            // Client doesn't know concrete classes - just uses the factory
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
            _textField = factory.CreateTextField();
        }

        public void RenderUI()
        {
            Console.WriteLine("  Rendering UI components:");
            _button.Render();
            _checkbox.Render();
            _textField.Render();
        }

        public void SimulateInteraction()
        {
            Console.WriteLine("  Simulating user interaction:");
            _button.OnClick();
            _checkbox.OnToggle();
            _textField.OnInput("Hello World");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Abstract Factory Pattern Demo ===\n");

            // Windows UI
            Console.WriteLine("--- 1. Windows UI Factory ---");
            IUIFactory windowsFactory = new WindowsUIFactory();
            var windowsApp = new Application(windowsFactory);
            windowsApp.RenderUI();
            windowsApp.SimulateInteraction();
            Console.WriteLine();

            // Mac UI
            Console.WriteLine("--- 2. macOS UI Factory ---");
            IUIFactory macFactory = new MacUIFactory();
            var macApp = new Application(macFactory);
            macApp.RenderUI();
            macApp.SimulateInteraction();

            Console.WriteLine("\n=== Key Points ===");
            Console.WriteLine("1. Abstract Factory creates FAMILIES of related objects (Button + Checkbox + TextField).");
            Console.WriteLine("2. Client code uses only interfaces - completely decoupled from concrete implementations.");
            Console.WriteLine("3. Switching from Windows to Mac UI = just change the factory, no other code changes.");
            Console.WriteLine("4. vs Factory Method: Factory Method creates ONE product, Abstract Factory creates a FAMILY.");
        }
    }
}
