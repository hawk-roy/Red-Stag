using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverKit
{
    public class Monitor : IObserver
    {
        public string SystemName { get; private set; }

        public Monitor(string systemName)
        {
            SystemName = systemName;
        }

        public void Update(string weaponName, string status)
        {
            Console.WriteLine($"[{SystemName}] LOG: {weaponName} - {status} (Logged at {DateTime.Now:HH:mm:ss})");
        }
    }
}
