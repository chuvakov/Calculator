﻿using Calculator.Models;
using System;
using System.Windows.Forms;

namespace Calculator.WinForms
{
    public partial class MainForm : Form
    {
        private CalculatorBase _calculator;
        private bool isClearDisplay;

        public MainForm()
        {
            InitializeComponent();

            _calculator = new CalculatorBase();
        }

        private void but0_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";  // .Text - свойство ( с большой буквы пишуться только Класс, Методы и Свойства.
            //    isClearDisplay = false;
            //}

            //if (DisplayTextBox.Text != "0")
            //{
            //    DisplayTextBox.Text = DisplayTextBox.Text + 0;
            //}
            _calculator.UpdateExpression("0");
        }

        private void but1_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 1;
            _calculator.UpdateExpression("1");
        }

        private void but2_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 2;
            _calculator.UpdateExpression("2");
        }

        private void but3_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 3;
            _calculator.UpdateExpression("3");
        }

        private void but4_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 4;
            _calculator.UpdateExpression("4");
        }

        private void but5_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 5;
            _calculator.UpdateExpression("5");
        }

        private void but6_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 6;
            _calculator.UpdateExpression("6");
        }

        private void but7_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 7;
            _calculator.UpdateExpression("7");
        }

        private void but8_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 8;
            _calculator.UpdateExpression("8");
        }

        private void but9_Click(object sender, EventArgs e)
        {
            //if (isClearDisplay)
            //{
            //    DisplayTextBox.Text = "";
            //    isClearDisplay = false;
            //}

            //DisplayTextBox.Text = DisplayTextBox.Text + 9;
            _calculator.UpdateExpression("9");
        }

        private void butSymbol_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Text = DisplayTextBox.Text + ',';
            _calculator.UpdateExpression(",");
        }

        private void butPlus_Click(object sender, EventArgs e)
        {
            //int number = int.Parse(DisplayTextBox.Text);

            //if (calcModule.LeftNumber == null)
            //{
            //    calcModule.LeftNumber = number;
            //    calcModule.Operations.Add(Operation.PLUS);
            //}
            //else
            //{
            //    calcModule.Operations.Add(Operation.PLUS);
            //    calcModule.RightNumber = number;
            //    calcModule.Calc();

            //    if (calcModule.Result != null)
            //    {
            //        DisplayTextBox.Text = calcModule.Result.ToString();
            //    }
            //}

            //isClearDisplay = true;
            _calculator.UpdateExpression(" + ");
        }

        private void butDivide_Click(object sender, EventArgs e)
        {
            //int number = int.Parse(DisplayTextBox.Text);

            //if (calcModule.LeftNumber == null)
            //{
            //    calcModule.LeftNumber = number;
            //    calcModule.Operations.Add(Operation.DIVISION);
            //}
            //else
            //{
            //    calcModule.Operations.Add(Operation.DIVISION);
            //    calcModule.RightNumber = number;
            //    calcModule.Calc();

            //    if (calcModule.Result != null)
            //    {
            //        DisplayTextBox.Text = calcModule.Result.ToString();
            //    }
            //}

            isClearDisplay = true;
            _calculator.UpdateExpression(" / ");
        }

        private void butMultiply_Click(object sender, EventArgs e)
        {            
            DisplayTextBox.Text = DisplayTextBox.Text + " * ";
            _calculator.UpdateExpression(" * ");
        }

        private void butMinus_Click(object sender, EventArgs e)
        {            
            DisplayTextBox.Text = DisplayTextBox.Text + " - ";
            _calculator.UpdateExpression(" - ");
        }

        private void butEqual_Click(object sender, EventArgs e)
        {
            _calculator.CalculateExpression();
            DisplayTextBox.Text = _calculator.Result.ToString();
        }

        private void butAc_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Text = null;
            _calculator.Clear();
        }
    }
}
