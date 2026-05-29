using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public class P90Kit : IWeaponKit
    {
        public IWeapon CreateWeapon()
        {
            return new P90();
        }
        public IAccessory CreateAccessory()
        {
            return new Silencer();
        }
    }
}
