using System;
using System.Collections.Generic;
using System.Text;

namespace GunPrototype
{
    public interface IWeaponPrototype
    {
        IWeaponPrototype Clone();
        void DisplayInfo();
    }
}
