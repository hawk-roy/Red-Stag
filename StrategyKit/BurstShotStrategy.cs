using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyKit
{
    public sealed class BurstShotStrategy : IShootStrategy
    {
        public string Name => "Burst (3)";

        public void Shoot(string weaponName)
        {
            Console.WriteLine($"{weaponName}: Bang! Bang! Bang!");
        }
    }
}
