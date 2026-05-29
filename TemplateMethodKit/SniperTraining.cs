using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodKit
{
    public sealed class SniperTraining : WeaponTraining
    {
        protected override void CheckWeapon()
        {
            Console.WriteLine("Sniper: Checking scope and bolt...");
        }

        protected override void LoadAmmo()
        {
            Console.WriteLine("Sniper: Loading 5 rounds...");
        }

        protected override void Aim()
        {
            Console.WriteLine("Sniper: Holding breath and aiming...");
        }

        protected override void Fire()
        {
            Console.WriteLine("Sniper: BOOM!");
        }

        protected override void Cleanup()
        {
            Console.WriteLine("Cleanup: Collecting shell and recording hit result.\n");
        }
    }
}
