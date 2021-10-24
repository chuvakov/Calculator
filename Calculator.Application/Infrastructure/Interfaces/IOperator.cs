using Calculator.Models;

namespace Calculator.Infrastructure.Interfaces
{
    public interface IOperator
    {
        IOperator LeftOperand { get; }
        IOperator RightOperand { get; }

        Operation Operation { get; }
        double? Result { get; }
    }
}
