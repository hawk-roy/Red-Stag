using System;
using System.Collections.Generic;
using System.Text;

namespace CommandKit
{
    public class Weapon
    {
        public string Name { get; private set; }
        public bool IsLoaded { get; private set; }
        public bool IsSafetyOn { get; private set; }
        public int AmmoCount { get; private set; }

        public Weapon(string name)
        {
            Name = name;
            IsLoaded = false;
            IsSafetyOn = true;
            AmmoCount = 0;
        }

        // 武器的具体操作方法
        public void Load()
        {
            if (!IsLoaded)
            {
                IsLoaded = true;
                AmmoCount = 30;
                Console.WriteLine($"{Name}: Weapon loaded with 30 rounds");
            }
            else
            {
                Console.WriteLine($"{Name}: Weapon is already loaded");
            }
        }

        public void Unload()
        {
            if (IsLoaded)
            {
                IsLoaded = false;
                AmmoCount = 0;
                Console.WriteLine($"{Name}: Weapon unloaded");
            }
            else
            {
                Console.WriteLine($"{Name}: Weapon is already unloaded");
            }
        }

        public void SafetyOn()
        {
            if (!IsSafetyOn)
            {
                IsSafetyOn = true;
                Console.WriteLine($"{Name}: Safety is ON");
            }
            else
            {
                Console.WriteLine($"{Name}: Safety is already ON");
            }
        }

        public void SafetyOff()
        {
            if (IsSafetyOn)
            {
                IsSafetyOn = false;
                Console.WriteLine($"{Name}: Safety is OFF - Ready to fire");
            }
            else
            {
                Console.WriteLine($"{Name}: Safety is already OFF");
            }
        }

        public void Fire()
        {
            if (IsLoaded && !IsSafetyOn && AmmoCount > 0)
            {
                AmmoCount--;
                Console.WriteLine($"{Name}: BANG! Ammo remaining: {AmmoCount}");
            }
            else
            {
                Console.WriteLine($"{Name}: Cannot fire - Check loading/safety/ammo");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"{Name} Status: Loaded={IsLoaded}, Safety={IsSafetyOn}, Ammo={AmmoCount}");
        }
    }
}
