using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public interface IWeapon
    {
        void Shoot();
        void Reload();
        void CheckInfo();
    }
}
