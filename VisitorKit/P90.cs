using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorKit
{
    public sealed class P90 : IWeaponElement
    {
        public int Price => 3500;

        public void Accept(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
