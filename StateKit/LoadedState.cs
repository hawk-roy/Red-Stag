using System;
using System.Collections.Generic;
using System.Text;

namespace StateKit
{
    public sealed class LoadedState : IWeaponState
    {
        public string Name => "Loaded";

        public void Load(Weapon weapon)
        {
            Console.WriteLine($"{weapon.Name}: Already loaded. Ammo={weapon.Ammo}");
        }

        public void Fire(Weapon weapon)
        {
            weapon.Ammo--;

            Console.WriteLine($"{weapon.Name}: BANG! Ammo={weapon.Ammo}");

            if (weapon.Ammo <= 0)
            {
                weapon.SetState(new EmptyState());
                Console.WriteLine($"{weapon.Name}: Out of ammo -> State=Empty");
            }
        }
    }
}
