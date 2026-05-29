using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorKit
{
    public interface IWeaponCollection
    {
        IIterator<string> CreateIterator();
        void AddWeapon(string weapon);
        int Count();
    }
}
