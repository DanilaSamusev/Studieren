using System.Collections;

namespace Lab6
{
    public class CarComparator : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            var car1 = (Car) obj1;
            var car2 = (Car) obj2;
            
            if (car1.Mileage < car2.Mileage)
            {
                return -1;
            }

            if (car1.Mileage > car2.Mileage)
            {
                return 1;
            }
            
            return 0;
        }
    }
}