namespace Prototype_Demo
{
    // =============================================================
    // Prototype Pattern
    // - Creates new objects by cloning an existing object (prototype).
    // - Use when: object creation is expensive, or you need copies
    //   of objects with slight modifications.
    // =============================================================

    // Prototype interface
    public interface IPrototype<T>
    {
        T Clone(); // Deep copy
    }

    // Nested object to demonstrate deep vs shallow copy
    public class Color
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public Color(int r, int g, int b) { R = r; G = g; B = b; }

        public Color Clone() => new Color(R, G, B);

        public override string ToString() => $"RGB({R},{G},{B})";
    }

    // Concrete Prototypes
    public class Circle : IPrototype<Circle>
    {
        public double Radius { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Color FillColor { get; set; }

        public Circle(double radius, double x, double y, Color fillColor)
        {
            Radius = radius; X = x; Y = y; FillColor = fillColor;
        }

        // Deep clone - creates new Color object too
        public Circle Clone()
        {
            return new Circle(Radius, X, Y, FillColor.Clone());
        }

        public override string ToString()
            => $"Circle(R={Radius}, Pos=({X},{Y}), Color={FillColor})";
    }

    public class Rectangle : IPrototype<Rectangle>
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Color FillColor { get; set; }

        public Rectangle(double width, double height, double x, double y, Color fillColor)
        {
            Width = width; Height = height; X = x; Y = y; FillColor = fillColor;
        }

        public Rectangle Clone()
        {
            return new Rectangle(Width, Height, X, Y, FillColor.Clone());
        }

        public override string ToString()
            => $"Rectangle(W={Width}, H={Height}, Pos=({X},{Y}), Color={FillColor})";
    }

    // Shape Registry - stores pre-configured prototypes
    public class ShapeRegistry
    {
        private readonly Dictionary<string, IPrototype<object>> _shapes = new();

        public void Register(string key, Circle circle) => _shapes[key] = new CircleWrapper(circle);
        public void Register(string key, Rectangle rect) => _shapes[key] = new RectangleWrapper(rect);

        public object Get(string key) => _shapes[key].Clone();

        // Wrappers to handle generic interface
        private class CircleWrapper : IPrototype<object>
        {
            private readonly Circle _circle;
            public CircleWrapper(Circle circle) { _circle = circle; }
            public object Clone() => _circle.Clone();
        }

        private class RectangleWrapper : IPrototype<object>
        {
            private readonly Rectangle _rect;
            public RectangleWrapper(Rectangle rect) { _rect = rect; }
            public object Clone() => _rect.Clone();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Prototype Pattern Demo ===\n");

            // Demo 1: Basic Cloning
            Console.WriteLine("--- 1. Basic Clone ---");
            var original = new Circle(5.0, 10, 20, new Color(255, 0, 0));
            var cloned = original.Clone();

            Console.WriteLine($"  Original: {original}");
            Console.WriteLine($"  Cloned:   {cloned}");
            Console.WriteLine($"  Same reference? {ReferenceEquals(original, cloned)}");
            Console.WriteLine();

            // Demo 2: Deep Copy proof
            Console.WriteLine("--- 2. Deep Copy Verification ---");
            cloned.FillColor.R = 0;
            cloned.FillColor.B = 255;
            cloned.Radius = 10;

            Console.WriteLine($"  After modifying clone's color and radius:");
            Console.WriteLine($"  Original: {original}  (unchanged!)");
            Console.WriteLine($"  Cloned:   {cloned}  (modified)");
            Console.WriteLine();

            // Demo 3: Clone and modify pattern
            Console.WriteLine("--- 3. Clone-and-Modify Pattern ---");
            var baseRect = new Rectangle(100, 50, 0, 0, new Color(0, 128, 0));
            Console.WriteLine($"  Base:  {baseRect}");

            // Create variations by cloning
            var rect1 = baseRect.Clone();
            rect1.X = 110;
            rect1.FillColor = new Color(0, 0, 128);

            var rect2 = baseRect.Clone();
            rect2.X = 220;
            rect2.FillColor = new Color(128, 0, 128);

            Console.WriteLine($"  Copy1: {rect1}");
            Console.WriteLine($"  Copy2: {rect2}");
            Console.WriteLine();

            // Demo 4: Shape Registry
            Console.WriteLine("--- 4. Prototype Registry ---");
            var registry = new ShapeRegistry();
            registry.Register("red-circle", new Circle(10, 0, 0, new Color(255, 0, 0)));
            registry.Register("blue-rect", new Rectangle(50, 30, 0, 0, new Color(0, 0, 255)));

            var c = (Circle)registry.Get("red-circle");
            var r = (Rectangle)registry.Get("blue-rect");
            Console.WriteLine($"  From registry: {c}");
            Console.WriteLine($"  From registry: {r}");

            Console.WriteLine("\n=== Key Points ===");
            Console.WriteLine("1. Prototype creates new objects by cloning existing ones.");
            Console.WriteLine("2. Deep copy ensures nested objects are also cloned (not shared).");
            Console.WriteLine("3. Useful when object creation is expensive or has many configurations.");
            Console.WriteLine("4. Registry pattern can store pre-configured prototypes for reuse.");
        }
    }
}
