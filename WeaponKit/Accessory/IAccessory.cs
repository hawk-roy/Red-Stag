using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public interface IAccessory
    {
        void Attach(IWeapon weapon);
        void Detach(IWeapon weapon);

        void CheckInfo();
    }
}
