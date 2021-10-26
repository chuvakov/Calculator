using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Infrastructure.Interfaces
{
    public interface ICalculator
    {
        void Clear();
        void CalculateExpression();
        void UpdateExpression(string symbol);
    }
}
