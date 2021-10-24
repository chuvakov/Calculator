using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калькулятор.Models
{
    public class Operator : IOperator
    {
        public IOperator LeftOperand { get; private set; }
        public IOperator RightOperand { get; private set; }

        public Operation Operation { get; private set; }
        public double? Result { get; private set; }

        public Operator (double result)
        {
            Result = result;
        }
        
        public Operator (IOperator leftOperand, IOperator rightOperand, Operation operation)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operation = operation;
        }
    }
}
