using Calculator.Enums;
using Calculator.Models;
using System;
using System.Windows.Forms;

namespace Calculator.WinForms
{
    // TODO: инсталятор.
    public partial class MainForm : Form
    {
        private CalculatorBase _calculator;
        private OperationType? _selectOperation;

        private bool _isClearDisplay;
        private bool _isCalc;
       
        public MainForm()
        {
            InitializeComponent();

            _calculator = new CalculatorBase();
            _calculator.UpdateExpression("0");
        }

        /// <summary>
        /// Отображение результата вычислений на дисплее калькулятора
        /// </summary>
        private void DisplayCalcResult()
        {
            _calculator.CalculateExpression();
            DisplayTextBox.Text = _calculator.Result.ToString();

            _isCalc = false;
        }

        /// <summary>
        /// Очистка дисплея калькулятора
        /// </summary>
        private void ClearDisplay()
        {
            if (_isClearDisplay)
            {
                DisplayTextBox.Text = "";
                _isClearDisplay = false;
            }
        }

        /// <summary>
        /// Событие при нажатии на кнопку цифры
        /// </summary>        
        private void EventNumClick(int num)
        {
            ClearDisplay();

            if (DisplayTextBox.Text == "0")
            {
                DisplayTextBox.Text = null;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + num;

            _calculator.UpdateExpression(num.ToString());

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But0_Click(object sender, EventArgs e)
        {
            EventZeroClick();
        }

        /// <summary>
        /// Событие при нажатии кнопки ноль
        /// </summary>
        private void EventZeroClick()
        {
            ClearDisplay();

            if (DisplayTextBox.Text != "0")
            {
                DisplayTextBox.Text = DisplayTextBox.Text + 0;
                _calculator.UpdateExpression("0");
            }

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But1_Click(object sender, EventArgs e)
        {
            EventNumClick(1);
        }

        private void But2_Click(object sender, EventArgs e)
        {
            EventNumClick(2);
        }

        private void But3_Click(object sender, EventArgs e)
        {
            EventNumClick(3);
        }

        private void But4_Click(object sender, EventArgs e)
        {
            EventNumClick(4);
        }

        private void But5_Click(object sender, EventArgs e)
        {
            EventNumClick(5);
        }

        private void But6_Click(object sender, EventArgs e)
        {
            EventNumClick(6);
        }

        private void But7_Click(object sender, EventArgs e)
        {
            EventNumClick(7);
        }

        private void But8_Click(object sender, EventArgs e)
        {
            EventNumClick(8);
        }

        private void But9_Click(object sender, EventArgs e)
        {
            EventNumClick(9);
        }

        private void ButDecimal_Click(object sender, EventArgs e)
        {
            EventDecimalClick();
        }

        /// <summary>
        /// Событие при нажатии на кнопку запятой
        /// </summary>
        private void EventDecimalClick()
        {
            string lastOperand = _calculator.GetLastOperand();

            if (string.IsNullOrEmpty(lastOperand) || lastOperand.Contains(","))
            {
                return;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + ',';
            _calculator.UpdateExpression(",");
        }

        /// <summary>
        /// Событие при нажатии на кнопку операции 2го приоритета
        /// </summary>        
        private void EventOperationPrioritySecondClick(Operation operation)
        {
            _isClearDisplay = true;

            if (_selectOperation.HasValue && _selectOperation.Value == operation.Value && !_isCalc)
            {
                return;
            }

            if (_isCalc)
            {
                DisplayCalcResult();
            }

            _calculator.UpdateExpression($" {operation.Symbol.Trim()} ");
            _selectOperation = operation.Value;
        }

        private void ButPlus_Click(object sender, EventArgs e)
        {
            EventOperationPrioritySecondClick(Operation.PLUS);
        }        

        private void ButMinus_Click(object sender, EventArgs e)
        {
            EventOperationPrioritySecondClick(Operation.MINUS);
        }

        /// <summary>
        /// Событие при нажатии на кнопку операции 1го приоритета
        /// </summary>        
        private void EventOperationPriorityFirstClick(Operation operation)
        {
            if (_selectOperation != null && (_selectOperation.Value == OperationType.Plus || _selectOperation.Value == OperationType.Minus))
            {
                _isCalc = false;
            }

            _isClearDisplay = true;

            if (_selectOperation.HasValue && _selectOperation.Value == operation.Value && !_isCalc)
            {
                return;
            }

            _calculator.UpdateExpression($" {operation.Symbol.Trim()} ");
            _selectOperation = operation.Value;

            if (_isCalc)
            {
                DisplayCalcResult();
            }
        }

        private void ButDivide_Click(object sender, EventArgs e)
        {
            EventOperationPriorityFirstClick(Operation.DIVISION);
        }        

        private void ButMultiply_Click(object sender, EventArgs e)
        {
            EventOperationPriorityFirstClick(Operation.MULTIPLY);
        }        

        private void ButEqual_Click(object sender, EventArgs e)
        {
            DisplayCalcResult();
        }

        private void ButAc_Click(object sender, EventArgs e)
        {
            EventAcClick();
        }

        /// <summary>
        /// Событие при нажатии на клавишу стирание
        /// </summary>
        private void EventAcClick()
        {
            _calculator.Clear();
            _calculator.UpdateExpression("0");

            DisplayTextBox.Text = "0";
            _selectOperation = null;

            _isCalc = false;
            _isClearDisplay = false;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    EventZeroClick();
                    break;

                case Keys.NumPad1:
                    EventNumClick(1);
                    break;

                case Keys.NumPad2:
                    EventNumClick(2);
                    break;

                case Keys.NumPad3:
                    EventNumClick(3);
                    break;

                case Keys.NumPad4:
                    EventNumClick(4);
                    break;

                case Keys.NumPad5:
                    EventNumClick(5);
                    break;

                case Keys.NumPad6:
                    EventNumClick(6);
                    break;

                case Keys.NumPad7:
                    EventNumClick(7);
                    break;

                case Keys.NumPad8:
                    EventNumClick(8);
                    break;

                case Keys.NumPad9:
                    EventNumClick(9);
                    break;

                case Keys.Decimal:
                    EventDecimalClick();
                    break;

                case Keys.Multiply:
                    EventOperationPriorityFirstClick(Operation.MULTIPLY);
                    break;

                case Keys.Divide:
                    EventOperationPriorityFirstClick(Operation.DIVISION);
                    break;

                case Keys.Add:
                    EventOperationPrioritySecondClick(Operation.PLUS);
                    break;

                case Keys.Subtract:
                    EventOperationPrioritySecondClick(Operation.MINUS);
                    break;

                case Keys.Back:
                    EventAcClick();
                    break;

                case Keys.Enter:
                    DisplayCalcResult();
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
