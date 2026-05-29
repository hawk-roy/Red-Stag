using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyKit
{
    public interface IShootStrategy
    {
        void Shoot(string weaponName);
        string Name { get; }
    }
}
