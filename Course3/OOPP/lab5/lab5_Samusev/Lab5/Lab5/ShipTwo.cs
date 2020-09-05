using System;
using Lab5.ClassLibrary;

namespace Lab5
{
    public class ShipTwo : BaseVehicle
    {
        private int _deckCount;
        private int _deckNumber;
        
        public ShipTwo(string name, double distance, double price, int deckCount, int deckNumber)
        {
            _name = name;
            _distance = distance;
            _price = price;
            _deckCount = deckCount;
            _deckNumber = deckNumber;
        }

        public override double CalculateTravelPrice()
        {
            if (_deckNumber == 3 || _deckNumber == 4)
            {
                _price += _price / 100 * Math.Pow(_deckCount, 2);
            }
            
            return _distance * _price;
        }
    }
}