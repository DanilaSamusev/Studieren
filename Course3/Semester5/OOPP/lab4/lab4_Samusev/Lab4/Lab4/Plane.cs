namespace Lab4
{
    public class Plane : Vehicle
    {
        private double _height;
        private double _speed;

        public double Height
        {
            get => _height;
            set => _height = value;
        }

        public double Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public Plane(string name, double distance, 
            double price, double height, double speed) : 
            base(name, distance, price)
        {
            _price *= height * speed;
            _height = height;
            _speed = speed;
        }
    }
}