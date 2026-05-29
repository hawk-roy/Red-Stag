using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorKit
{
    public sealed class PriceVisitor : IWeaponVisitor
    {
        public int TotalPrice { get; private set; }

        public void Visit(AK47 weapon) => TotalPrice += weapon.Price;
        public void Visit(AWM weapon) => TotalPrice += weapon.Price;
        public void Visit(P90 weapon) => TotalPrice += weapon.Price;
        public void Visit(M1911 weapon) => TotalPrice += weapon.Price;
    }
}
