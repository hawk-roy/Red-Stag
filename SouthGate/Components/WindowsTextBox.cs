using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthGate
{
    internal class WindowsTextBox : ITextBox
    {
        public void Render()
        {
            Console.WriteLine("Rendering Windows TextBox");
        }
    }
}
