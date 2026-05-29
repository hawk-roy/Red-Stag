using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponLib
{
    public class P90 : AirDropGun
    {
        public override void CheckInfo()
        {
            Console.WriteLine("P90: Submachine Gun, 50 Round Magazine, 5.7mm Ammo");
        }

        public override void Reload()
        {
            Console.WriteLine("P90 Reloaded");
        }
        public override void Shoot()
        {
            Console.WriteLine("P90 Shot Fired");
        }
    }
}
