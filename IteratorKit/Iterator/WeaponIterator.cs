using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorKit
{
    public class WeaponIterator : IIterator<string>
    {
        private List<string> weapons;
        private int currentIndex = 0;

        public WeaponIterator(List<string> weapons)
        {
            this.weapons = weapons;
        }

        public bool HasNext()
        {
            return currentIndex < weapons.Count;
        }

        public string Next()
        {
            if (HasNext())
            {
                return weapons[currentIndex++];
            }
            throw new InvalidOperationException("No more weapons");
        }

        public void Reset()
        {
            currentIndex = 0;
        }
    }
}
