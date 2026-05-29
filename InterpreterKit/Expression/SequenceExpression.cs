using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class SequenceExpression : IExpression
    {
        private List<IExpression> expressions;

        public SequenceExpression()
        {
            expressions = new List<IExpression>();
        }

        public void AddExpression(IExpression expression)
        {
            expressions.Add(expression);
        }

        public void Interpret(WeaponContext context)
        {
            Console.WriteLine("Executing sequence of commands:");
            foreach (IExpression expression in expressions)
            {
                expression.Interpret(context);
            }
        }
    }
}
