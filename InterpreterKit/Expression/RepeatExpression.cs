using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class RepeatExpression : IExpression
    {
        private IExpression expression;
        private int repeatCount;

        public RepeatExpression(IExpression expression, int count)
        {
            this.expression = expression;
            this.repeatCount = count;
        }

        public void Interpret(WeaponContext context)
        {
            Console.WriteLine($"Repeating command {repeatCount} times:");
            for (int i = 0; i < repeatCount; i++)
            {
                Console.WriteLine($"  Iteration {i + 1}:");
                expression.Interpret(context);
            }
        }
    }
}
