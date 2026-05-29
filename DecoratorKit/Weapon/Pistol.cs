using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorKit
{
    public class Pistol : IWeapon
    {
        public string Name => "This is pistol";

        public int Damage => 100;

        public int Weight => 1;

        public int Price => 600;

        public void Fire()
        {
            Console.WriteLine("Pistol fired! Bang!");
        }
    }
}
