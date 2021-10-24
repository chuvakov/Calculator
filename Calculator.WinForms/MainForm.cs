﻿using Calculator.Models;
using System;
using System.Text;
using System.Windows.Forms;
using Калькулятор.Models;

namespace Calculator.WinForms
{
    public partial class MainForm : Form
    {
        private CalcModule calcModule;
        private bool isClearDisplay;

        public MainForm()
        {
            InitializeComponent();

            calcModule = new CalcModule();
        }

        StringBuilder result = new StringBuilder();
        string symbol1;
        double result1;
        double result2;
        double sum = 0;


        private void but0_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";  // .Text - свойство ( с большой буквы пишуться только Класс, Методы и Свойства.
                isClearDisplay = false;
            }

            if (DisplayTextBox.Text != "0")
            {
                DisplayTextBox.Text = DisplayTextBox.Text + 0;
            }
        }

        private void but1_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 1;
        }

        private void but2_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 2;
        }

        private void but3_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 3;
        }

        private void but4_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 4;
        }

        private void but5_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 5;
        }

        private void but6_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 6;
        }

        private void but7_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 7;
        }

        private void but8_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 8;
        }

        private void but9_Click(object sender, EventArgs e)
        {
            if (isClearDisplay)
            {
                DisplayTextBox.Text = "";
                isClearDisplay = false;
            }

            DisplayTextBox.Text = DisplayTextBox.Text + 9;
        }

        private void butSymbol_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Text = DisplayTextBox.Text + ',';
        }

        private void butPlus_Click(object sender, EventArgs e)
        {
            int number = int.Parse(DisplayTextBox.Text);

            if (calcModule.LeftNumber == null)
            {
                calcModule.LeftNumber = number;
                calcModule.Operations.Add(Operation.PLUS);
            }
            else
            {
                calcModule.Operations.Add(Operation.PLUS);
                calcModule.RightNumber = number;
                calcModule.Calc();

                if (calcModule.Result != null)
                {
                    DisplayTextBox.Text = calcModule.Result.ToString();
                }
            }

            isClearDisplay = true;
        }

        private void butDivide_Click(object sender, EventArgs e)
        {
            int number = int.Parse(DisplayTextBox.Text);

            if (calcModule.LeftNumber == null)
            {
                calcModule.LeftNumber = number;
                calcModule.Operations.Add(Operation.DIVISION);
            }
            else
            {
                calcModule.Operations.Add(Operation.DIVISION);
                calcModule.RightNumber = number;
                calcModule.Calc();

                if (calcModule.Result != null)
                {
                    DisplayTextBox.Text = calcModule.Result.ToString();
                }
            }

            isClearDisplay = true;
        }

        private void butMultiply_Click(object sender, EventArgs e)
        {
            if (sum == 0)
            {
                string a = result.ToString();
                result1 = double.Parse(a);
                result.Clear();
            }

            symbol1 = "*";
            DisplayTextBox.Text = DisplayTextBox.Text + " * ";
        }

        private void butMinus_Click(object sender, EventArgs e)
        {
            if (sum == 0)
            {
                string a = result.ToString();
                result1 = double.Parse(a);
                result.Clear();
            }

            symbol1 = "-";
            DisplayTextBox.Text = DisplayTextBox.Text + " - ";
        }

        private void butEqual_Click(object sender, EventArgs e)
        {

        }

        private void butAc_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Text = null;
            result1 = 0;
            result2 = 0;
            sum = 0;
            symbol1 = null;
            result.Clear();
        }


    }
}
