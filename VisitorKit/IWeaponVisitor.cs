using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorKit
{
    public interface IWeaponVisitor
    {
        void Visit(AK47 weapon);
        void Visit(AWM weapon);
        void Visit(P90 weapon);
        void Visit(M1911 weapon);
    }
}
