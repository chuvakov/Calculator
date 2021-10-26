using Calculator.Enums;
using Calculator.Infrastructure.Interfaces;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Калькулятор.Models
{
    public class Calculator : ICalculator
    {
        private readonly StringBuilder _expression = new StringBuilder(); // _ - означает, что переменная без Гет и Сет (так только приватные помечаються)
                                     // readonly - как константа, такую переменную нельзя изменить (нельзя положить новый объект (заменить ссылку в переменной))
                                     // константа по умолчанию статичная, а readonly не обязательно
        public double? LeftNumber { get; set; }
        public double? RightNumber { get; set; }

        public List<Operation> Operations { get; set; }

        //public double? Result => LeftNumber;   // => то же самое что Return (это св-во, работает как метод)
        public double? Result { get; private set; }

        public Calculator()
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

        public void Clear()
        {
            _expression.Clear();
        }

        public void CalculateExpression()
        {
            List<string> expSymbols = _expression
                .ToString()
                .Select(x => x.ToString())
                .ToList();                      //цепной вызов (в данном случпаем мы сначала перевели в СТРОКУ, затем в МассивЧаров, затем в Лист.

            while(expSymbols.Count != 1)    // цикл прекратиться, когда количество элементов в нашего ЛистаЧаров будет равна 1 (в листе останется 1 Чар)
            {
                Operation operation = GetPriorityOperation(expSymbols);                
                CalcOperator(expSymbols, operation);                
            }

            Result = Convert.ToDouble(expSymbols[0]);
        }

        private void CalcOperator(List<string> expSymbols, Operation operation)
        {
            int operationIndex = expSymbols.IndexOf(operation.Symbol);

            int leftIndex = operationIndex - 1;
            string leftValue = expSymbols[leftIndex];

            IOperator leftOperand = new Operator(Convert.ToDouble(leftValue));
            expSymbols.RemoveAt(leftIndex);

            IOperator rightOperand = null;

            if (IsNotLastIndex(expSymbols, operation.Symbol))
            {
                int rightIndex = operationIndex + 1;
                string rightValue = expSymbols[rightIndex];

                rightOperand = new Operator(Convert.ToDouble(rightValue));
                expSymbols.RemoveAt(rightIndex);
            }

            IOperator @operator = new Operator(leftOperand, rightOperand, operation);
            @operator.Calculate();

            expSymbols[operationIndex] = @operator.Result.ToString();
        }

        private Operation GetPriorityOperation(List<string> expSymbols)
        {
            int? operationIndex = null;

            if (expSymbols.Contains(Operation.DIVISION.Symbol))
            {
                operationIndex = expSymbols.IndexOf(Operation.DIVISION.Symbol);
            }

            if (expSymbols.Contains(Operation.MULTIPLY.Symbol))
            {
                int multiplyIndex = expSymbols.IndexOf(Operation.MULTIPLY.Symbol);

                if (operationIndex.HasValue)
                {
                    operationIndex = operationIndex < multiplyIndex ? operationIndex : multiplyIndex;
                }
            }

            if (!operationIndex.HasValue)
            {
                if (expSymbols.Contains(Operation.PLUS.Symbol))
                {
                    operationIndex = expSymbols.IndexOf(Operation.PLUS.Symbol);
                }

                if (expSymbols.Contains(Operation.MINUS.Symbol))
                {
                    int minusIndex = expSymbols.IndexOf(Operation.MINUS.Symbol);

                    if (operationIndex.HasValue)
                    {
                        operationIndex = operationIndex < minusIndex ? operationIndex : minusIndex;
                    }
                }
            }

            string operationSymbol = expSymbols[operationIndex.Value];
            return Operation.GetOperation(operationSymbol);
        }

        private bool IsNotLastIndex(List<string> expSymbols, string symbol)
        {
            return expSymbols.IndexOf(symbol) != expSymbols.Count - 1;
        }

        public void UpdateExpression(string symbol)
        {
            _expression.Append(symbol);
        }
    }
}
