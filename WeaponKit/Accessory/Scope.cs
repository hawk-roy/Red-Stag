using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public class Scope : IAccessory
    {
        public void Attach(IWeapon weapon)
        {
            Console.WriteLine("The firearm-specific scope: Attached to " + weapon.GetType().Name);
        }
        public void Detach(IWeapon weapon)
        {
            Console.WriteLine("The firearm-specific scope has been removed.");
        }
        public void CheckInfo()
        {
            Console.WriteLine("The Scope is made in Germony");
        }
    }
}
