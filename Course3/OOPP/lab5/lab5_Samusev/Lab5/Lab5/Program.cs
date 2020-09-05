using System;
using Lab5.ClassLibrary;

namespace Lab5
{
    class Program
    {
        public static void Main(string[] args)
        {
            var plane = new Plane("Plane", 10, 10, 10, 10);
            var expensiveShip = new Ship("ExpensiveShip", 15, 15, 5, 3);
            var ship = new Ship("Ship", 15, 15, 5, 2);
            var vehicle2 = new Vehicle("Vehicle2", 15, 10);
            var vehicle1 = new Vehicle("Vehicle1", 15, 15);
            
            var vehicles = new Vehicle[]
            {
                plane, expensiveShip, ship, vehicle2, vehicle1
            };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Name} total price - {vehicle.CalculateTravelPrice()}");
            }
            
            Task2();
            
            Console.ReadKey();
        }

        public static void Task2()
        {
            var planeTwo1 = new PlaneTwo("Plane1", 10, 10, 11, 10);
            var shipTwo1 = new ShipTwo("Ship1", 15, 15, 5, 3);
            var planeTwo2 = new PlaneTwo("Plane2", 10, 10, 12, 10);
            var shipTwo2 = new ShipTwo("Ship2", 15, 15, 6, 2);
            var planeTwo3 = new PlaneTwo("Plane3", 10, 10, 14, 10);
            
            var vehicles = new BaseVehicle[]
            {
                planeTwo1, shipTwo1, planeTwo2, shipTwo2, planeTwo3
            };
            
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Name} total price - {vehicle.CalculateTravelPrice()}");
            }
            
            Console.ReadKey();
        }
    }
}