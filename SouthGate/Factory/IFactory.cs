using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthGate
{
    internal interface IFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
    }
}
