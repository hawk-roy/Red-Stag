using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponKit
{
    public class ExtendedMag : IAccessory
    {
        public void Attach(IWeapon weapon)
        {
            Console.WriteLine("Extended Mag: Attached to " + weapon.GetType().Name);
        }

        public void Detach(IWeapon weapon)
        {
            Console.WriteLine("Extended Mag: Detached from " + weapon.GetType().Name);
        }

        public void CheckInfo()
        {
            Console.WriteLine("Extended Mag: Increases magazine capacity, allowing for more shots before needing to reload.");
        }
    }
}
