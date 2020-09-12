using System;

namespace Lab8
{
    public class Calculator
    {
        public double CalculateFunction(double A0, double Anr, double r)
        {
            double Sn = (A0 - Anr) / (1 - r);
            return Sn;
        }

        public double CalculateFunctionWithCheck(double A0, double Anr, double r)
        {
            if (r == -1)
            {
                throw new Exception($"Invalid parameter: {r}");
            };
            
            return CalculateFunction(A0, Anr, r);
        }

        public double CalculateFunctionWithArgumentCheck(double A0, double Anr, double r)
        {
            if (r == -1)
            {
                throw new ArgumentException($"Invalid parameter: {r}");
            };

            return CalculateFunction(A0, Anr, r);
        }

        public double CalculateFunctionWithCustomException(double A0, double Anr, double r)
        {
            if (r == -1)
            {
                throw new CalculatorParameterException($"Invalid parameter: {r}");
            };

            return CalculateFunction(A0, Anr, r);
        }
    }
}
