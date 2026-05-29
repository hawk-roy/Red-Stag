using System;
using System.Collections.Generic;
using System.Text;

namespace GunPrototype
{
    public class SniperRifle : IWeaponPrototype
    {
        public string RifleName { get; set; }
        public string Scope { get; set; }
        public string Bipod { get; set; }
        public string Silencer { get; set; }
        public string Ammunition { get; set; }

        public SniperRifle()
        {
        }

        public SniperRifle(SniperRifle other)
        {
            RifleName = other.RifleName;
            Scope = other.Scope;
            Bipod = other.Bipod;
            Silencer = other.Silencer;
            Ammunition = other.Ammunition;
        }



        public IWeaponPrototype Clone()
        {
            return new SniperRifle(this);
        }

        public void DisplayInfo()
        {
            Console.WriteLine("=== Sniper Rifle Configuration ===");
            Console.WriteLine($"Rifle: {RifleName ?? "Not Set"}");
            Console.WriteLine($"Scope: {Scope ?? "Not Set"}");
            Console.WriteLine($"Bipod: {Bipod ?? "Not Set"}");
            Console.WriteLine($"Silencer: {Silencer ?? "Not Set"}");
            Console.WriteLine($"Ammunition: {Ammunition ?? "Not Set"}");
            Console.WriteLine("==================================");
        }
    }
}
