using Calculator.Enums;
using Calculator.Models;
using System;
using System.Windows.Forms;

namespace Calculator.WinForms
{
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
        }

        private void DisplayCalcResult()
        {
            _calculator.CalculateExpression();
            DisplayTextBox.Text = _calculator.Result.ToString();

            _isCalc = false;
        }

        private void ClearDisplay()
        {
            if (_isClearDisplay)
            {
                DisplayTextBox.Text = "";
                _isClearDisplay = false;
            }
        }

        private void But0_Click(object sender, EventArgs e)
        {
            ClearDisplay();

            if (DisplayTextBox.Text != "0")
            {
                DisplayTextBox.Text = DisplayTextBox.Text + 0;
            }

            _calculator.UpdateExpression("0");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }      

        private void But1_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 1;

            _calculator.UpdateExpression("1");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But2_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 2;

            _calculator.UpdateExpression("2");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But3_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 3;

            _calculator.UpdateExpression("3");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But4_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 4;

            _calculator.UpdateExpression("4");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But5_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 5;

            _calculator.UpdateExpression("5");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But6_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 6;

            _calculator.UpdateExpression("6");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But7_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 7;

            _calculator.UpdateExpression("7");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But8_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 8;

            _calculator.UpdateExpression("8");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void But9_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayTextBox.Text = DisplayTextBox.Text + 9;

            _calculator.UpdateExpression("9");

            if (_selectOperation.HasValue)
            {
                _isCalc = true;
            }
        }

        private void ButSymbol_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Text = DisplayTextBox.Text + ',';
            _calculator.UpdateExpression(",");
        }

        private void ButPlus_Click(object sender, EventArgs e)
        {            
            _isClearDisplay = true;

            if (_selectOperation.HasValue && _selectOperation.Value == OperationType.Plus && !_isCalc)
            {
                return;
            }

            if (_isCalc)
            {
                DisplayCalcResult();
            }

            _calculator.UpdateExpression(" + ");
            _selectOperation = OperationType.Plus;
        }

        private void ButDivide_Click(object sender, EventArgs e)
        {
            if (_selectOperation != null && (_selectOperation.Value == OperationType.Plus || _selectOperation.Value == OperationType.Minus))
            {
                _isCalc = false;
            }

            _isClearDisplay = true;

            if (_selectOperation.HasValue && _selectOperation.Value == OperationType.Division && !_isCalc)
            {
                return;
            }

            _calculator.UpdateExpression(" / ");
            _selectOperation = OperationType.Division;

            if (_isCalc)
            {
                DisplayCalcResult();
            }               
        }

        private void ButMultiply_Click(object sender, EventArgs e)
        {
            if (_selectOperation != null && (_selectOperation.Value == OperationType.Plus || _selectOperation.Value == OperationType.Minus))
            {
                _isCalc = false;
            }
            
            _isClearDisplay = true;

            if (_selectOperation.HasValue && _selectOperation.Value == OperationType.Multiply && !_isCalc)
            {
                return;
            }

            _calculator.UpdateExpression(" * ");
            _selectOperation = OperationType.Multiply;

            if (_isCalc)
            {
                DisplayCalcResult();
            }               
        }

        private void ButMinus_Click(object sender, EventArgs e)
        {
            _isClearDisplay = true;

            if (_selectOperation.HasValue && _selectOperation.Value == OperationType.Minus && !_isCalc)
            {
                return;
            }

            if (_isCalc)
            {
                DisplayCalcResult();
            }
            
            _calculator.UpdateExpression(" - ");
            _selectOperation = OperationType.Minus;
        }

        private void ButEqual_Click(object sender, EventArgs e)
        {
            DisplayCalcResult();
        }
        
        private void ButAc_Click(object sender, EventArgs e)
        {
            _calculator.Clear();

            DisplayTextBox.Text = null;            
            _selectOperation = null;

            _isCalc = false;
            _isClearDisplay = false;
        }
    }
}
