using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorKit
{
    public interface IWeapon
    {
        string Name { get; }
        int Damage { get; }

        int Weight { get; }

        int Price { get; }

        void Fire();

    }
}
