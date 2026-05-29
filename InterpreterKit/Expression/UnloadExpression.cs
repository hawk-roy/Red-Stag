using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class UnloadExpression : IExpression
    {
        public void Interpret(WeaponContext context)
        {
            if (context.IsLoaded)
            {
                context.IsLoaded = false;
                context.AmmoCount = 0;
                Console.WriteLine($"{context.WeaponName}: Unloaded");
            }
            else
            {
                Console.WriteLine($"{context.WeaponName}: Already unloaded");
            }
        }
    }
}
