using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterKit
{
    public class WeaponContext
    {
        public string WeaponName { get; set; }
        public bool IsLoaded { get; set; }
        public bool IsSafetyOn { get; set; }
        public int AmmoCount { get; set; }
        public Dictionary<string, string> Variables { get; set; }

        public WeaponContext()
        {
            WeaponName = "Unknown";
            IsLoaded = false;
            IsSafetyOn = true;
            AmmoCount = 0;
            Variables = new Dictionary<string, string>();
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Weapon: {WeaponName}");
            Console.WriteLine($"Loaded: {IsLoaded}");
            Console.WriteLine($"Safety: {(IsSafetyOn ? "ON" : "OFF")}");
            Console.WriteLine($"Ammo: {AmmoCount}");
        }
    }
}
