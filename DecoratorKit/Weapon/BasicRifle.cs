using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorKit
{
    public class BasicRifle : IWeapon
    {
        public string Name => "This is basic rifle";

        public int Damage => 300;

        public int Weight => 5;

        public int Price => 1200;

        public void Fire()
        {
            Console.WriteLine("Basic rifle fired! Bang! Bang......");
        }
    }
}
