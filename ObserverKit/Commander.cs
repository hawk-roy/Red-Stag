using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverKit
{
    public class Commander : IObserver
    {
        public string Name { get; private set; }

        public Commander(string name)
        {
            Name = name;
        }

        public void Update(string weaponName, string status)
        {
            Console.WriteLine($"[Commander {Name}] {weaponName} status: {status}");
        }
    }
}
