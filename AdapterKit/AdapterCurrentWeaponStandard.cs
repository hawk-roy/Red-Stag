using AdapterKit.Previous;
using System;
using System.Collections.Generic;
using System.Text;
using WeaponKit;

namespace AdapterKit
{
    public class AdapterCurrentWeaponStandard : WeaponKit.IWeapon
    {
        Previous.IWeapon weapon;

        public AdapterCurrentWeaponStandard(Previous.IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void CheckInfo()
        {
            this.weapon.DisplayInfo();
        }

        public void Reload()
        {
            this.weapon.ReFillAmmo();
        }

        public void Shoot()
        {
            this.weapon.Fire();
        }
    }
}
