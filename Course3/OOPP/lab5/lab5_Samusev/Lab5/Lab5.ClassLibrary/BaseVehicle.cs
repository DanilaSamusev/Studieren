namespace Lab5.ClassLibrary
{
    public abstract class BaseVehicle
    {
        protected string _name;
        protected double _distance;
        protected double _price;
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        public abstract double CalculateTravelPrice();
    }
}