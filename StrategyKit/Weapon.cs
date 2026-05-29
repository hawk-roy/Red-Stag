using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyKit
{
    public sealed class Weapon
    {
        public string Name { get; }
        public IShootStrategy ShootStrategy { get; private set; }

        public Weapon(string name, IShootStrategy strategy)
        {
            Name = name;
            ShootStrategy = strategy;
        }

        public void ChangeStrategy(IShootStrategy strategy)
        {
            ShootStrategy = strategy;
            Console.WriteLine($"{Name}: Strategy changed to [{ShootStrategy.Name}]");
        }

        public void Fire()
        {
            Console.WriteLine($"{Name}: Using [{ShootStrategy.Name}]");
            ShootStrategy.Shoot(Name);
        }
    }
}
