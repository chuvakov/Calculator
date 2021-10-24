using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    interface IOperator
    {
        IOperator LeftOperand { get; }
        IOperator RightOperand { get; }

        Operation Operation { get; }
        double? Result { get; }
    }
}
