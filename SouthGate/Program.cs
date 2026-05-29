using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthGate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sysInfo = "Wins";

            IFactory factory = FactoryProvider.Create(sysInfo);

            IButton button = factory.CreateButton();
            button.Render();

            ITextBox textBox = factory.CreateTextBox();
            textBox.Render();
        }
    }
}
