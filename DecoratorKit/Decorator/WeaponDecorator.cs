using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorKit
{
    public class WeaponDecorator : IWeapon
    {
        private IWeapon _weapon;

        public WeaponDecorator(IWeapon weapon)
        {
            _weapon = weapon;
        }


        public virtual string Name => _weapon.Name;

        public virtual int Damage => _weapon.Damage;

        public virtual int Weight => _weapon.Weight;

        public virtual int Price => _weapon.Price;

        public virtual void Fire()
        {
            _weapon.Fire();
        }
    }
}
