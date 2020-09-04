using System;

namespace Lab1.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicle = new Vehicle();
            Console.WriteLine($"Default vehicle: {vehicle.GetFields()}");

            vehicle = new Vehicle("Car", 15, 5);
            Console.WriteLine($"Vehicle: {vehicle.GetFields()}");
            vehicle.Name = "Electric car";
            Console.WriteLine($"Changed name: {vehicle.Name}");

            Console.WriteLine($"Total price {vehicle.CalculateTravelPrice()}");

            Console.ReadKey();
        }
    }
}
