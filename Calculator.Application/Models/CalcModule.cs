using Calculator.Enums;
using Calculator.Models;
using System.Collections.Generic;

namespace Калькулятор.Models
{
    public class CalcModule
    {
        public double? LeftNumber { get; set; }
        public double? RightNumber { get; set; }

        public List<Operation> Operations { get; set; }

        public double? Result => LeftNumber;   // => то же самое что Return (это св-во, работает как метод)

        public CalcModule()
        {
            Operations = new List<Operation>();
        }

        public void Calc()
        {
            if (LeftNumber == null || Operations == null || Operations.Count == 0)
            {
                return;
            }

            OperationPriorityType searchOperationPriority = OperationPriorityType.Second;

            if (Operations.Exists(x => x.Priority == OperationPriorityType.First))  // Лямда выражение (x => x.Priority == OperationPriorityType.First)
                                                                                    // Exist проверяет содержет ли Список операций - операцию у которой
                                                                                    // св-во Priority = First
            {
                searchOperationPriority = OperationPriorityType.First;
            }

            foreach (Operation operation in Operations)
            {
                if (operation.Priority == searchOperationPriority)
                {
                    switch (operation.Value)
                    {
                        case OperationType.Plus:   // получается, что бы обратиться к полям ЕНАМА (что бы выбрать одну из строк енама)
                                                   // нам нужно использовать наименование ЕНАМА "Тип Данных" (в данном случае - OperationType) а не название переменной - Operation?
                            LeftNumber = LeftNumber + (RightNumber ?? LeftNumber);
                            break;

                        case OperationType.Minus:
                            LeftNumber = LeftNumber - (RightNumber ?? LeftNumber);
                            break;

                        case OperationType.Multiply:
                            LeftNumber = LeftNumber * (RightNumber ?? LeftNumber);
                            break;

                        case OperationType.Division:
                            LeftNumber = LeftNumber / (RightNumber ?? LeftNumber);
                            break;
                    }

                    Operations.Remove(operation);
                    return;
                }
            }
        }
    }
}
