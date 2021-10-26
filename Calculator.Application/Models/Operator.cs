using Calculator.Enums;
using Calculator.Infrastructure.Interfaces;

namespace Calculator.Models
{
    public class Operator : IOperator
    {
        public IOperator LeftOperand { get; private set; }
        public IOperator RightOperand { get; private set; }

        public Operation Operation { get; private set; }
        public double? Result { get; private set; }

        public Operator(double result)
        {
            Result = result;
        }

        public Operator(IOperator leftOperand, IOperator rightOperand, Operation operation)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operation = operation;
        }

        public void Calculate()
        {
            switch (Operation.Value)
            {
                case OperationType.Plus:
                    Result = LeftOperand.Result + (RightOperand?.Result ?? 0);
                    break;

                case OperationType.Minus:
                    Result = LeftOperand.Result - (RightOperand?.Result ?? 0);
                    break;

                case OperationType.Division:
                    Result = LeftOperand.Result / (RightOperand?.Result ?? 1);
                    break;

                case OperationType.Multiply:
                    Result = LeftOperand.Result * (RightOperand?.Result ?? 1);
                    break;                
            }
        }
    }
}
