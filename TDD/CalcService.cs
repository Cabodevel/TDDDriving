using System;

namespace TDD
{
    public class CalcService
    {
        public int Sum(int num1, int num2)
        {
            if(num1 == 0) throw new ArgumentException(nameof(num1));
            if(num2 == 0) throw new ArgumentException(nameof(num2));
            return num1 + num2;
        }
    }
}
