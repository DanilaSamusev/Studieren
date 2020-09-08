using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public class CalculatorParameterException : Exception
    {
        public CalculatorParameterException(string message) : base(message)
        {

        }
    }
}
