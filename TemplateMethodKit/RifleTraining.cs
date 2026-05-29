using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodKit
{
    public sealed class RifleTraining : WeaponTraining
    {
        protected override void CheckWeapon()
        {
            Console.WriteLine("Rifle: Checking safety and barrel...");
        }

        protected override void LoadAmmo()
        {
            Console.WriteLine("Rifle: Loading 30 rounds magazine...");
        }

        protected override void Aim()
        {
            Console.WriteLine("Rifle: Aiming with red dot...");
        }

        protected override void Fire()
        {
            Console.WriteLine("Rifle: BANG! BANG!");
        }
    }
}
