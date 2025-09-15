using System;

namespace project
{
    // Родительский класс Изделие
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Weight { get; set; }
        public string Manufacturer { get; set; }

        public Product(string name, string code, double weight, string manufacturer)
        {
            Name = name;
            Code = code;
            Weight = weight;
            Manufacturer = manufacturer;
        }
    }

    // Производный класс Деталь
    public class Part : Product
    {
        public string Material { get; set; }

        public Part(string name, string code, double weight, string manufacturer, string material)
            : base(name, code, weight, manufacturer)
        {
            Material = material;
        }
    }

    // Производный класс Узел
    public class Unit : Product
    {
        public int ComponentsCount { get; set; }

        public Unit(string name, string code, double weight, string manufacturer, int componentsCount)
            : base(name, code, weight, manufacturer)
        {
            ComponentsCount = componentsCount;
        }
    }

    // Производный класс Механизм
    public class Mechanism : Product
    {
        public string Function { get; set; }

        public Mechanism(string name, string code, double weight, string manufacturer, string function)
            : base(name, code, weight, manufacturer)
        {
            Function = function;
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание объектов различных типов изделия
            var part = new Part("Вал", "P-001", 1.2, "Завод №1", "Сталь 45");
            var unit = new Unit("Редуктор", "U-100", 9.5, "Завод №1", 4);
            var mechanism = new Mechanism("Редукторный привод", "M-001", 12.0, "Завод №1", "Передача крутящего момента");
        }
    }
}
