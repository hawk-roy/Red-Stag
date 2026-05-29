using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class FireExpression : IExpression
    {
        public void Interpret(WeaponContext context)
        {
            if (context.IsLoaded && !context.IsSafetyOn && context.AmmoCount > 0)
            {
                context.AmmoCount--;
                Console.WriteLine($"{context.WeaponName}: BANG! Ammo remaining: {context.AmmoCount}");
            }
            else if (!context.IsLoaded)
            {
                Console.WriteLine($"{context.WeaponName}: Cannot fire - Not loaded");
            }
            else if (context.IsSafetyOn)
            {
                Console.WriteLine($"{context.WeaponName}: Cannot fire - Safety is ON");
            }
            else
            {
                Console.WriteLine($"{context.WeaponName}: Cannot fire - No ammo");
            }
        }
    }
}
