using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorKit
{
    public sealed class AK47 : IWeaponElement
    {
        public int Price => 2700;

        public void Accept(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
