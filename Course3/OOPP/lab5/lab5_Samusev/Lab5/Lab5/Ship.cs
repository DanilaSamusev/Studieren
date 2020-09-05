using System;
using Lab5.ClassLibrary;

namespace Lab5
{
    public class Ship : Vehicle
    {
        private int _deckCount;
        private int _deckNumber;

        public int DeckCount
        {
            get => _deckCount;
            set => _deckCount = value;
        }

        public int DeckNumber
        {
            get => _deckNumber;
            set => _deckNumber = value;
        }

        public Ship(string name, double distance, 
            double price, int deckCount, int deckNumber) :
            base(name, distance, price)
        {
            _deckCount = deckCount;
            _deckNumber = deckNumber;
            
            if (deckNumber == 3 || deckNumber == 4)
            {
                _price += price / 100 * Math.Pow(deckCount, 2);
            }
        }
    }
}