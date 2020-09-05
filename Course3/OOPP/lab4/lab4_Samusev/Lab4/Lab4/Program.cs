using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var plane = new Plane("Plane", 10, 10, 10, 10);
            var expensiveShip = new Ship("ExpensiveShip", 15, 15, 5, 3);
            var ship = new Ship("Ship", 15, 15, 5, 2);
            
            Console.WriteLine($"Plane info: name - {plane.Name}, speed - {plane.Speed}");
            Console.WriteLine($"Ship info: name - {ship.Name}, deckNumber - {ship.DeckNumber}");

            Console.WriteLine($"Total price for plane {plane.CalculateTravelPrice()}");
            Console.WriteLine($"Total price for expensive ship {expensiveShip.CalculateTravelPrice()}");
            Console.WriteLine($"Total price for ship {ship.CalculateTravelPrice()}");
            
            Console.ReadKey();
        }
    }
}