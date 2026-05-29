using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public class AK47 : IWeapon
    {
        public void Shoot()
        {
            Console.WriteLine("AK47: Bang!");
        }
        public void Reload()
        {
            Console.WriteLine("AK47: Reloading...");
        }
        public void CheckInfo()
        {
            Console.WriteLine("AK47: A powerful AUTO rifle with high damage and long range.");
        }
    }
}
