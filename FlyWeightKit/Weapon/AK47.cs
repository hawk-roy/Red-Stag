using System;
using System.Collections.Generic;
using System.Text;

namespace FlyWeightKit
{
    internal class AK47 : IWeapon
    {
        private readonly string name = "AK-47";
        private readonly int damage = 40;
        private readonly string ammo = "7.62mm";

        public void DisplayInfo(string owner)
        {
            Console.WriteLine($"{owner} uses {name} (Damage: {damage}, Ammo: {ammo})");
        }
    }
}
