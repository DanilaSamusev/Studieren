using System;

namespace lab1_Ostapenko
{
    public class Table
    {
        private string name;
        private double square;

        public string Name { get => name; set => name = value; }
        public double Square
        {
            get => square;
            set
            {
                if (value > 0)
                {
                    square = value;
                }
            }
        }

        public Table()
        {
            name = "DefaultTable";
            square = 10000;
        }

        public Table(string name, double square)
        {
            this.name = name;
            this.square = square;
        }

        public double GetPrice()
        {
            return Math.Pow(square, 2) / 3 + 500000;
        }

        public string GetFields()
        {
            return $"Стол {name} с площадью {square} см кв.";
        }
    }
}
