using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorKit
{
    public class WeaponArsenal : IWeaponCollection
    {
        private List<string> weapons = new List<string>();

        public void AddWeapon(string weapon)
        {
            weapons.Add(weapon);
            Console.WriteLine($"Added weapon: {weapon}");
        }

        public int Count()
        {
            return weapons.Count;
        }

        public IIterator<string> CreateIterator()
        {
            return new WeaponIterator(weapons);
        }
    }
}
