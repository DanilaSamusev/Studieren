using Lab5.ClassLibrary;

namespace Lab5
{
    public class PlaneTwo : BaseVehicle
    {
        private double _height;
        private double _speed;
        
        public PlaneTwo(string name, double distance, double price, double height, double speed)
        {
            _name = name;
            _distance = distance;
            _price = price;
            _height = height;
            _speed = speed;
        }

        public override double CalculateTravelPrice()
        {
            _price *= _height * _speed;
            
            return _distance * _price;
        }
    }
}