using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorytmGenetyczny
{
    public class MyFunction : IFunction
    {
        public double GetResult(double x, double y)
        {
            var temp1 = System.Math.Sin(System.Math.Sqrt(x * x + y * y));
            var temp2 = 1 + 0.001 * (x * x + y * y);
            var result = 0.5 + (temp1 * temp1 - 0.5) / (temp2 * temp2);
            return result;
        }
    }
}
