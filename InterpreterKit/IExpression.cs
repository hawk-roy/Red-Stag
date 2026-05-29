using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public interface IExpression
    {
        void Interpret(WeaponContext context);
    }
}
