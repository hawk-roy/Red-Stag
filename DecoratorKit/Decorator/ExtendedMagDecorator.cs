using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorKit
{
    public class ExtendedMagDecorator : WeaponDecorator
    {
        public ExtendedMagDecorator(IWeapon weapon) : base(weapon)
        {
        }

        public override string Name => base.Name + " with ++Extended Mag++";

        public override int Damage => base.Damage;

        public override int Weight => base.Weight + 1;

        public override int Price => base.Price + 50;

        public override void Fire()
        {
            base.Fire();
            Console.WriteLine("Extended Mag activated! More bullets, more fun!");
        }
    }
}
