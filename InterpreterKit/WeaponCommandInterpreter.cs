using InterpreterKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class WeaponCommandInterpreter
    {
        private WeaponContext context;

        public WeaponCommandInterpreter()
        {
            context = new WeaponContext();
        }

        public void SetWeaponName(string name)
        {
            context.WeaponName = name;
        }

        // 解析并执行命令
        public void InterpretCommand(string command)
        {
            IExpression expression = ParseCommand(command);
            if (expression != null)
            {
                expression.Interpret(context);
            }
            else
            {
                Console.WriteLine($"Unknown command: {command}");
            }
        }

        // 执行复杂表达式
        public void InterpretExpression(IExpression expression)
        {
            expression.Interpret(context);
        }

        private IExpression ParseCommand(string command)
        {
            switch (command.ToLower().Trim())
            {
                case "load":
                    return new LoadExpression();
                case "unload":
                    return new UnloadExpression();
                case "safety_on":
                    return new SafetyOnExpression();
                case "safety_off":
                    return new SafetyOffExpression();
                case "fire":
                    return new FireExpression();
                case "status":
                    return new StatusExpression();
                default:
                    return null;
            }
        }

        public WeaponContext GetContext()
        {
            return context;
        }
    }
}
