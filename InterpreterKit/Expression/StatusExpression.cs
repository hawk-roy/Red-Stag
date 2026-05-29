using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class StatusExpression : IExpression
    {
        public void Interpret(WeaponContext context)
        {
            Console.WriteLine("=== Weapon Status ===");
            context.ShowStatus();
            Console.WriteLine("==================");
        }
    }
}
