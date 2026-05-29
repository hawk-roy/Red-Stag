using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public class Silencer : IAccessory
    {
        public void Attach(IWeapon weapon)
        {
            Console.WriteLine("The silencer: Attached to " + weapon.GetType().Name);
        }
        public void Detach(IWeapon weapon)
        {
            Console.WriteLine("The silencer has been removed.");
        }
        public void CheckInfo()
        {
            Console.WriteLine("The silencer is made in USA");
        }
    }
}
