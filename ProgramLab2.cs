using System;

namespace project
{
    // --- Интерфейсы (минимальные и простые) ---
    public interface IIdentifiable { string Code { get; set; } }
    public interface IWeighable { double GetTotalMass(); }
    public interface IPrintable { void Print(); }

    // --- Абстрактный базовый класс Изделие ---
    public abstract class Product : IIdentifiable, IWeighable, IPrintable
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Weight { get; set; } // собственная масса

        protected Product(string name, string code, double weight)
        {
            Name = name;
            Code = code;
            Weight = weight;
        }

        // Полиморфизм: виртуальные методы переопределяются в потомках
        public virtual double GetTotalMass() => Weight;
        public virtual void Print()
        {
            Console.WriteLine($"Изделие: {Name} [{Code}], масса: {GetTotalMass():0.###} кг");
        }
    }

    // --- Деталь ---
    public class Part : Product
    {
        public string Material { get; set; }

        public Part(string name, string code, double weight, string material)
            : base(name, code, weight)
        {
            Material = material;
        }

        public override void Print()
        {
            Console.WriteLine($"Деталь: {Name} ({Material}) [{Code}], масса: {GetTotalMass():0.###} кг");
        }
    }

    // --- Узел ---
    public class Unit : Product
    {
        public int ComponentsCount { get; set; }

        public Unit(string name, string code, double weight, int componentsCount)
            : base(name, code, weight)
        {
            ComponentsCount = componentsCount;
        }

        public override void Print()
        {
            Console.WriteLine($"Узел: {Name} (компонентов: {ComponentsCount}) [{Code}], масса: {GetTotalMass():0.###} кг");
        }
    }

    // --- Механизм ---
    public class Mechanism : Product
    {
        public string Function { get; set; }
        public bool IsRunning { get; private set; }

        public Mechanism(string name, string code, double weight, string function)
            : base(name, code, weight)
        {
            Function = function;
        }

        public void Start() { IsRunning = true; }
        public void Stop() { IsRunning = false; }

        public override void Print()
        {
            Console.WriteLine($"Механизм: {Name} — {Function} [{Code}], работает: {IsRunning}, масса: {GetTotalMass():0.###} кг");
        }
    }

    class Program
    {
        static void Main()
        {
            // Создаём объекты
            Product part = new Part("Вал", "P-001", 1.2, "Сталь 45");
            Product unit = new Unit("Редуктор", "U-100", 9.5, 4);
            var mechanism = new Mechanism("Редукторный привод", "M-001", 12.0, "Передача крутящего момента");
            mechanism.Start();

            // Полиморфный вызов через базовый тип
            Product[] products = { part, unit, mechanism };
            foreach (var p in products) p.Print();

            // Полиморфный вызов через интерфейс
            IPrintable[] toPrint = { (IPrintable)part, (IPrintable)unit, (IPrintable)mechanism };
            foreach (var pr in toPrint) pr.Print();

            // Полиморфный расчёт веса через интерфейс
            double sum = 0;
            foreach (var p in products) sum += ((IWeighable)p).GetTotalMass();
            Console.WriteLine("Суммарная масса: " + sum.ToString("0.###") + " кг");
        }
    }
}
