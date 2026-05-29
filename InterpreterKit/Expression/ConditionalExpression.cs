using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class ConditionalExpression : IExpression
    {
        private string condition;
        private IExpression trueExpression;
        private IExpression falseExpression;

        public ConditionalExpression(string condition, IExpression trueExpr, IExpression falseExpr = null)
        {
            this.condition = condition;
            this.trueExpression = trueExpr;
            this.falseExpression = falseExpr;
        }

        public void Interpret(WeaponContext context)
        {
            bool conditionResult = EvaluateCondition(context, condition);

            Console.WriteLine($"Evaluating condition: {condition} = {conditionResult}");

            if (conditionResult && trueExpression != null)
            {
                trueExpression.Interpret(context);
            }
            else if (!conditionResult && falseExpression != null)
            {
                falseExpression.Interpret(context);
            }
        }

        private bool EvaluateCondition(WeaponContext context, string condition)
        {
            switch (condition.ToLower())
            {
                case "loaded":
                    return context.IsLoaded;
                case "unloaded":
                    return !context.IsLoaded;
                case "safe":
                    return context.IsSafetyOn;
                case "unsafe":
                    return !context.IsSafetyOn;
                case "hasAmmo":
                    return context.AmmoCount > 0;
                default:
                    return false;
            }
        }
    }
}
