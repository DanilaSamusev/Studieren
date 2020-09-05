using System;
using System.Collections;
using System.Linq;

namespace Lab6
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            var x = new ClassX();
            var y = new ClassY();
            
            (x as Ix).F0(1, out string message);
            Console.WriteLine(message);
            (y as Ix).F1(1);
            Console.WriteLine(y.Message);
            
            Ix newX = new ClassX();
            newX.F1(1);
            Console.WriteLine(((ClassX) newX).Message);
            
            Console.WriteLine(x.F0(1));
            
            Task2();
        }

        public static void Task2()
        {
            var car1 = new Car
            {
                Brand = "Auto1",
                Owner = "Owner1",
                AcquisitionYear = 2000,
                Mileage = 130
            };
            
            var car2 = new Car
            {
                Brand = "Auto2",
                Owner = "Owner2",
                AcquisitionYear = 1998,
                Mileage = 120
            };
            
            var car3 = new Car
            {
                Brand = "Auto3",
                Owner = "Owner3",
                AcquisitionYear = 1990,
                Mileage = 140
            };

            var cars = new ArrayList {car1, car2, car3};
            var newCars = new ArrayList();

            foreach (var car in cars)
            {
                if ((car as Car).AcquisitionYear < 2001)
                {
                    newCars.Add(car);
                } 
            }
            
            var comparer = new CarComparator();
            
            newCars.Sort(comparer);

            foreach (var obj in newCars)
            {
                var car = obj as Car;
                
                Console.WriteLine($"{car.Brand}: {car.Mileage}");
            }
        }
    }
}