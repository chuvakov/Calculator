using Calculator.Enums;

namespace Calculator.Models
{
    public class Operation
    {
        public OperationType Value { get; private set; }
        public OperationPriorityType Priority { get; private set; }
        public string Symbol { get; private set; }

        public static Operation PLUS = new Operation(OperationType.Plus, OperationPriorityType.Second, "+");
        public static Operation MINUS = new Operation(OperationType.Minus, OperationPriorityType.Second, "-");
        public static Operation DIVISION = new Operation(OperationType.Division, OperationPriorityType.First, "/");
        public static Operation MULTIPLY = new Operation(OperationType.Multiply, OperationPriorityType.First, "*");

        public Operation(OperationType value, OperationPriorityType priority, string symbol)
        {
            Value = value;
            Priority = priority;
            Symbol = symbol;
        }

        public static Operation GetOperation(string symbol)
        {
            switch (symbol)
            {
                case "+":
                    return PLUS;
                case "-":
                    return MINUS;
                case "/":
                    return DIVISION;
                case "*":
                    return MULTIPLY;
                default:
                    return null;
            }
        }
    }
}
