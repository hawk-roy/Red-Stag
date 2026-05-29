using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class SafetyOnExpression : IExpression
    {
        public void Interpret(WeaponContext context)
        {
            if (!context.IsSafetyOn)
            {
                context.IsSafetyOn = true;
                Console.WriteLine($"{context.WeaponName}: Safety ON");
            }
            else
            {
                Console.WriteLine($"{context.WeaponName}: Safety already ON");
            }
        }
    }
}
