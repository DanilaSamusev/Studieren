using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class ObjectChild
    {
        private int _a;
        private int _b;
        private string _operation;

        public int C
        {
            get
            {
                switch (_operation)
                {
                    case "+":
                        return _a + _b;                       
                    case "-":
                        return _a - _b;
                    case "*":
                        return _a * _b;
                }

                return 0;
            }
        }

        public ObjectChild()
        {
            _a = 1;
            _b = 2;
            _operation = "+";
        }

        public override bool Equals(object obj)
        {
            var cast = obj as ObjectChild;
            return this.C == cast.C;
        }

        public override string ToString()
        {
            return $"a: {_a}, b: {_b}, operation: {_operation}";
        }
    }
}
