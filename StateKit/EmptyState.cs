using System;
using System.Collections.Generic;
using System.Text;

namespace StateKit
{
    public sealed class EmptyState : IWeaponState
    {
        public string Name => "Empty";

        public void Load(Weapon weapon)
        {
            weapon.Ammo = 3;
            weapon.SetState(new LoadedState());
            Console.WriteLine($"{weapon.Name}: Loaded. Ammo={weapon.Ammo}");
        }

        public void Fire(Weapon weapon)
        {
            Console.WriteLine($"{weapon.Name}: Click... (no ammo)");
        }
    }
}
