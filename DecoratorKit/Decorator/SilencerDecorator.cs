using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorKit
{
    public class SilencerDecorator : WeaponDecorator
    {
        public SilencerDecorator(IWeapon weapon) : base(weapon)
        {
        }

        public override string Name => base.Name + " with ++Silencer++";

        public override int Damage => base.Damage - 5;

        public override int Weight => base.Weight + 1;


        public override int Price => base.Price + 150;


        public override void Fire()
        {
            base.Fire();
            Console.WriteLine("Silencer activated! No sound, no recoil!");
        }
    }
}
