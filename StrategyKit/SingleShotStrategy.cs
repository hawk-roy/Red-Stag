using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyKit
{
    public sealed class SingleShotStrategy : IShootStrategy
    {
        public string Name => "Single Shot";

        public void Shoot(string weaponName)
        {
            Console.WriteLine($"{weaponName}: Bang!");
        }
    }
}
