using System;
using System.Collections.Generic;
using System.Text;

namespace StateKit
{
    public interface IWeaponState
    {
        void Load(Weapon weapon);
        void Fire(Weapon weapon);
        string Name { get; }
    }
}
