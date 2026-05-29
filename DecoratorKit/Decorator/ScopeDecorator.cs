using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorKit
{
    public class ScopeDecorator : WeaponDecorator
    {
        public ScopeDecorator(IWeapon weapon) : base(weapon)
        {
        }

        public override string Name => base.Name + " with ++Scope++";

        public override int Damage => base.Damage + 20;

        public override int Weight => base.Weight + 1;

        public override int Price => base.Price + 200;

        public override void Fire()
        {
            base.Fire();
            Console.WriteLine("Scope activated! Target locked!");
        }
    }
}
