using Calculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Models
{
    public class CalculatorBase : ICalculator
    {
        private readonly StringBuilder _expression = new StringBuilder();
        public double? Result { get; private set; }

        public void Clear()
        {
            _expression.Clear();
        }

        public void CalculateExpression()
        {
            List<string> expSymbols = _expression
                .ToString()
                .Split(' ')
                .ToList();

            while (expSymbols.Count != 1)
            {
                Operation operation = GetPriorityOperation(expSymbols);
                CalcOperator(expSymbols, operation);
            }

            Result = Convert.ToDouble(expSymbols[0]);
        }

        /// <summary>
        /// Вычисление оператора(на осное операций)
        /// </summary>        
        private void CalcOperator(List<string> expSymbols, Operation operation)
        {
            int leftIndex = GetOperationIndex(expSymbols, operation.Symbol) - 1;
            IOperator leftOperand = GetOperand(expSymbols, leftIndex);

            IOperator rightOperand = null;
            if (IsNotLastIndex(expSymbols, operation.Symbol))
            {
                int rightIndex = GetOperationIndex(expSymbols, operation.Symbol) + 1;
                rightOperand = GetOperand(expSymbols, rightIndex);
            }

            IOperator @operator = new Operator(leftOperand, rightOperand, operation);
            @operator.Calculate();

            expSymbols[GetOperationIndex(expSymbols, operation.Symbol)] = @operator.Result.ToString();
        }

        private IOperator GetOperand(List<string> expSymbols, int index)
        {
            string value = expSymbols[index];
            expSymbols.RemoveAt(index);

            IOperator operand = new Operator(Convert.ToDouble(value));
            return operand;
        }

        private int GetOperationIndex(List<string> expSymbols, string operation)
        {
            return expSymbols.IndexOf(operation);
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
                else
                {
                    operationIndex = multiplyIndex;
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
                    else
                    {
                        operationIndex = minusIndex;
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
