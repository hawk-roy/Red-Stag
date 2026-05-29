using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class LoadExpression : IExpression
    {
        public void Interpret(WeaponContext context)
        {
            if (!context.IsLoaded)
            {
                context.IsLoaded = true;
                context.AmmoCount = 30;
                Console.WriteLine($"{context.WeaponName}: Loaded with 30 rounds");
            }
            else
            {
                Console.WriteLine($"{context.WeaponName}: Already loaded");
            }
        }
    }
}
