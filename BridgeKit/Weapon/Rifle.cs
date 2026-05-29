using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeKit
{
    public class Rifle : Weapon
    {
        public Rifle(string name, IShootingMode shootingMode) : base(name, shootingMode)
        {
        }

        public override void DisplayWeaponInfo()
        {
            Console.WriteLine($"Weapon: {Name}, Type: Rifle, Current Shooting Mode: {ShootingMode.ShowShootingMode()}");
        }
    }
}
