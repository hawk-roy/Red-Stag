using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public class AK47Kit : IWeaponKit
    {
        public IWeapon CreateWeapon()
        {
            return new AK47();
        }
        public IAccessory CreateAccessory()
        {
            return new ExtendedMag();
        }
    }
}
