using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeKit
{
    public class Pistol : Weapon
    {
        public Pistol(string name, IShootingMode shootingMode) : base(name, shootingMode)
        {
        }
        public override void DisplayWeaponInfo()
        {
            Console.WriteLine($"Weapon: {Name}, Type: Pistol, Current Shooting Mode: {ShootingMode.ShowShootingMode()}");
        }
    }
}
