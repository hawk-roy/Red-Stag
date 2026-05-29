using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorKit
{
    public sealed class DisplayVisitor : IWeaponVisitor
    {
        public void Visit(AK47 weapon) => Console.WriteLine($"AK-47, Price=${weapon.Price}");
        public void Visit(AWM weapon) => Console.WriteLine($"AWM, Price=${weapon.Price}");
        public void Visit(P90 weapon) => Console.WriteLine($"P90, Price=${weapon.Price}");
        public void Visit(M1911 weapon) => Console.WriteLine($"Pistol, Price=${weapon.Price}");
    }
}
