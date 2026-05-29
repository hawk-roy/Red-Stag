using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorKit
{
    public sealed class AWM : IWeaponElement
    {
        public int Price => 5000;

        public void Accept(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
