using System;
using System.Collections.Generic;
using System.Text;

namespace StateKit
{
    public sealed class Weapon
    {
        private IWeaponState _state;

        public string Name { get; }
        public int Ammo { get; internal set; }

        public Weapon(string name)
        {
            Name = name;
            Ammo = 0;
            _state = new EmptyState(); // 初始为空弹状态
        }

        internal void SetState(IWeaponState state)
        {
            _state = state;
        }

        public void Load() => _state.Load(this);
        public void Fire() => _state.Fire(this);

        public void ShowState()
        {
            Console.WriteLine($"{Name}: State={_state.Name}, Ammo={Ammo}");
        }
    }
}
