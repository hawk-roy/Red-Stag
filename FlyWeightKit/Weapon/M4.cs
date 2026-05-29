using System;
using System.Collections.Generic;
using System.Text;

namespace FlyWeightKit
{
    internal class M4 : IWeapon
    {
        private readonly string name = "M4A1";
        private readonly int damage = 35;
        private readonly string ammo = "5.56mm";

        public void DisplayInfo(string owner)
        {
            Console.WriteLine($"{owner} uses {name} (Damage: {damage}, Ammo: {ammo})");
        }
    }
}
