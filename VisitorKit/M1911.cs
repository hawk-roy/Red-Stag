using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorKit
{
    public sealed class M1911 : IWeaponElement
    {
        public int Price => 600;

        public void Accept(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
