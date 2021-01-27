namespace Lab5.ClassLibrary
{
    public class Vehicle
    {
        protected string _name;
        protected double _distance;
        protected double _price;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public double Distance
        {
            get => _distance;
            set => _distance = value;

        }
        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public Vehicle()
        {
            _name = "Bus";
            Distance = 10;
            Price = 10;
        }

        public Vehicle(string name, double distance, double price)
        {
            _name = name;
            Distance = distance;
            Price = price;
        }

        public virtual double CalculateTravelPrice()
        {
            return _distance * _price;
        }
    }
}