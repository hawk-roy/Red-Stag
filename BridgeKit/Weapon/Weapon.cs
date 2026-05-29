using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeKit
{
    public abstract class Weapon
    {
        public IShootingMode ShootingMode { get; set; }
        public string Name { get; set; }

        public Weapon(string name, IShootingMode shootingMode)
        {
            Name = name;
            ShootingMode = shootingMode;
        }

        public virtual void Fire()
        {
            Console.WriteLine($"{Name} is firing and the shooting mode is {ShootingMode.ShowShootingMode()}");
            ShootingMode.Shoot();
        }

        public void ChangeShootingMode(IShootingMode newShootingMode)
        {
            ShootingMode = newShootingMode;
            Console.WriteLine($"{Name} has changed shooting mode to {ShootingMode.ShowShootingMode()}");
        }

        public abstract void DisplayWeaponInfo();

    }
}
