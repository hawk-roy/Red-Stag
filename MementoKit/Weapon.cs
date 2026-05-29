using System;
using System.Collections.Generic;
using System.Text;

namespace MementoKit
{
    public class Weapon
    {
        public string Name { get; set; }
        public bool IsLoaded { get; set; }
        public int AmmoCount { get; set; }
        public bool IsSafetyOn { get; set; }

        public Weapon(string name)
        {
            Name = name;
            IsLoaded = false;
            AmmoCount = 0;
            IsSafetyOn = true;
        }

        // 创建备忘录
        public WeaponMemento CreateMemento()
        {
            Console.WriteLine($"Creating memento for {Name}...");
            return new WeaponMemento(Name, IsLoaded, AmmoCount, IsSafetyOn);
        }

        // 从备忘录恢复状态
        public void RestoreFromMemento(WeaponMemento memento)
        {
            Console.WriteLine($"Restoring {Name} from memento...");
            Name = memento.Name;
            IsLoaded = memento.IsLoaded;
            AmmoCount = memento.AmmoCount;
            IsSafetyOn = memento.IsSafetyOn;
        }

        // 武器操作方法
        public void Load()
        {
            IsLoaded = true;
            AmmoCount = 30;
            Console.WriteLine($"{Name}: Loaded with 30 rounds");
        }

        public void SafetyOff()
        {
            IsSafetyOn = false;
            Console.WriteLine($"{Name}: Safety OFF");
        }

        public void Fire()
        {
            if (IsLoaded && !IsSafetyOn && AmmoCount > 0)
            {
                AmmoCount--;
                Console.WriteLine($"{Name}: BANG! Ammo: {AmmoCount}");
            }
            else
            {
                Console.WriteLine($"{Name}: Cannot fire");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"{Name} - Loaded: {IsLoaded}, Ammo: {AmmoCount}, Safety: {IsSafetyOn}");
        }
    }
}
