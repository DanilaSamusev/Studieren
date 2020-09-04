using System;

namespace lab1_Ostapenko
{
    public class Table
    {
        private string _name;
        private double _square;

        public string Name { get => _name; set => _name = value; }
        public double Square { get => _square; set => _square = value; }

        public Table()
        {
            _name = "DefaultTable";
            _square = 10000;
        }

        public Table(string name, double square)
        {
            _name = name;
            _square = square;
        }

        public double GetPrice()
        {
            return Math.Pow(_square, 2) / 3 + 500000;
        }

        public string GetFields()
        {
            return $"Стол {_name} с площадью {_square} см кв.";
        }
    }
}
