using System;
using System.Collections.Generic;
using System.Text;

namespace MementoKit
{
    public class WeaponMemento
    {
        public string Name { get; private set; }
        public bool IsLoaded { get; private set; }
        public int AmmoCount { get; private set; }
        public bool IsSafetyOn { get; private set; }
        public DateTime SaveTime { get; private set; }

        public WeaponMemento(string name, bool isLoaded, int ammoCount, bool isSafetyOn)
        {
            Name = name;
            IsLoaded = isLoaded;
            AmmoCount = ammoCount;
            IsSafetyOn = isSafetyOn;
            SaveTime = DateTime.Now;
        }

        public void ShowMementoInfo()
        {
            Console.WriteLine($"Memento saved at {SaveTime:HH:mm:ss}");
            Console.WriteLine($"  Name: {Name}, Loaded: {IsLoaded}, Ammo: {AmmoCount}, Safety: {IsSafetyOn}");
        }
    }
}
