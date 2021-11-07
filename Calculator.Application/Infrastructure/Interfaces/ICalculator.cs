namespace Calculator.Infrastructure.Interfaces
{
    public interface ICalculator
    {
        /// <summary>
        /// Очистка
        /// </summary>
        void Clear();

        /// <summary>
        /// Расчёт выражения(вычисление)
        /// </summary>
        void CalculateExpression();

        /// <summary>
        /// Обновление выражения
        /// </summary>        
        void UpdateExpression(string symbol);

        /// <summary>
        /// Получение последнего операнда
        /// </summary>        
        string GetLastOperand();
    }
}
