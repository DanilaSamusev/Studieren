using System;

namespace Lab6
{
    public class Car : IComparable
    {
        public string Brand { get; set; }
        public string Owner { get; set; }
        public int AcquisitionYear { get; set; }
        public double Mileage { get; set; }
        
        public int CompareTo(object obj)
        {
            var car = (Car)obj;
            
            if (Mileage > car.Mileage)
            {
                return 1;
            }
            
            if (Mileage < car.Mileage)
            {
                return -1;
            }
            
            return 0;
        }
    }
}