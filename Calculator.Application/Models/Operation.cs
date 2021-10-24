using Калькулятор.Enums;

namespace Калькулятор.Models
{
    public class Operation
    {
        public OperationType Value { get; private set; }
        public OperationPriorityType Priority { get; private set; }

        public static Operation PLUS = new Operation(OperationType.Plus, OperationPriorityType.Second);
        public static Operation MINUS = new Operation(OperationType.Minus, OperationPriorityType.Second);
        public static Operation DIVISION = new Operation(OperationType.Division, OperationPriorityType.First);
        public static Operation MULTIPLY = new Operation(OperationType.Multiply, OperationPriorityType.First); 

        public Operation(OperationType value, OperationPriorityType priority)
        {
            Value = value;
            Priority = priority;
        }

        public static bool operator >(Operation left, Operation right)   // Переопределяем знак > ??? если я правильно понял, то это читается как:
                                                                         // Переопределить оператор > для класса Operation, принемает левый и правый объекты класса Operation
                                                                         // и возвращает TRUE(bool) если Operation left БОЛЬШЕ(Приоритет) чем Operation right, иначе FALSE ???
        {
            return left.Priority > right.Priority;
        }

        public static bool operator <(Operation left, Operation right)   // Переопределяем знак <
                                                                         // возвращает TRUE(bool) если Operation left МЕНЬШЕ чем Operation right, иначе TRUE ???
        {
            return left.Priority < right.Priority;
        }
    }
}
