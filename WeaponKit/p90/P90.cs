using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public class P90 : IWeapon
    {
        public void Shoot()
        {
            Console.WriteLine("P90: Bang!");
        }
        public void Reload()
        {
            Console.WriteLine("P90: Reloading...");
        }
        public void CheckInfo()
        {
            Console.WriteLine("P90: A compact submachine gun with high rate of fire and moderate damage.");
        }
    }
}
