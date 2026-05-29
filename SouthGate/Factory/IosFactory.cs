using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthGate
{
    internal class IosFactory : IFactory
    {
        public IButton CreateButton()
        {
            return new IosButton();
        }

        public ITextBox CreateTextBox()
        {
            return new IosTextBox();
        }
    }
}
