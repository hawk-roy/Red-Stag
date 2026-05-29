using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorKit
{
    public interface IWeaponElement
    {
        void Accept(IWeaponVisitor visitor);
    }
}
