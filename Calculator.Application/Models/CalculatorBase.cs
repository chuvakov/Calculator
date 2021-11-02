using Calculator.Enums;
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
        private readonly string[] _operationSymbols = 
        { 
            Operation.PLUS.Symbol, 
            Operation.MINUS.Symbol, 
            Operation.MULTIPLY.Symbol, 
            Operation.DIVISION.Symbol 
        };

        private bool _isBreakCalc;

        public double? Result { get; private set; }        

        public void Clear()
        {
            _expression.Clear();
            Result = null;
        }

        public void CalculateExpression()
        {
            List<string> expSymbols = _expression
                .ToString()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // удаляет пустые строки из результирущего массива после Сплита
                .ToList();

            while (expSymbols.Count != 1)
            {
                Operation operation = GetPriorityOperation(expSymbols);
                CalcOperator(expSymbols, operation);

                if (_isBreakCalc)
                {                    
                    break;
                }
            }

            Result = GetResult(expSymbols);           
        }

        private double GetResult(List<string> expSymbols)
        {
            if (_isBreakCalc)
            {
                _isBreakCalc = false;

                int lastIndex = expSymbols.Count - 1;
                return Convert.ToDouble(expSymbols[lastIndex]);
            }
            else
            {
                return Convert.ToDouble(expSymbols[0]);
            }
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

            if (@operator.RightOperand == null && @operator.Operation.Priority == OperationPriorityType.First)
            {
                _isBreakCalc = true;
            }
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
            string symbolNormalized = symbol.Trim();
            int lastSymbolIndex = _expression.Length - 2;

            if (lastSymbolIndex >= 0 && _operationSymbols.Contains(_expression[lastSymbolIndex].ToString()) && _operationSymbols.Contains(symbolNormalized))
            {
                _expression[lastSymbolIndex] = char.Parse(symbolNormalized);
            }
            else
            {
                _expression.Append(symbol);
            }            
        }
    }
}
