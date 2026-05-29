using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class SafetyOffExpression : IExpression
    {
        public void Interpret(WeaponContext context)
        {
            if (context.IsSafetyOn)
            {
                context.IsSafetyOn = false;
                Console.WriteLine($"{context.WeaponName}: Safety OFF - Ready to fire");
            }
            else
            {
                Console.WriteLine($"{context.WeaponName}: Safety already OFF");
            }
        }
    }
}
