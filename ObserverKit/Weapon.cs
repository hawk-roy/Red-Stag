using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverKit
{
    public class Weapon : IWeaponSubject
    {
        private List<IObserver> observers = new List<IObserver>();
        public string Name { get; private set; }
        public bool IsLoaded { get; private set; }
        public int AmmoCount { get; private set; }

        public Weapon(string name)
        {
            Name = name;
            IsLoaded = false;
            AmmoCount = 0;
        }

        // 添加观察者
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
            Console.WriteLine($"Observer attached to {Name}. Total observers: {observers.Count}");
        }

        // 移除观察者
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
            Console.WriteLine($"Observer detached from {Name}. Total observers: {observers.Count}");
        }

        // 通知所有观察者
        public void Notify(string status)
        {
            Console.WriteLine($"{Name}: Notifying {observers.Count} observers...");
            foreach (IObserver observer in observers)
            {
                observer.Update(Name, status);
            }
        }

        // 武器操作方法
        public void Load()
        {
            IsLoaded = true;
            AmmoCount = 30;
            Notify($"Loaded with {AmmoCount} rounds");
        }

        public void Fire()
        {
            if (IsLoaded && AmmoCount > 0)
            {
                AmmoCount--;
                Notify($"Fired! Ammo remaining: {AmmoCount}");
            }
            else
            {
                Notify("Cannot fire - No ammo");
            }
        }

        public void Reload()
        {
            AmmoCount = 30;
            Notify($"Reloaded! Ammo: {AmmoCount}");
        }
    }
}
