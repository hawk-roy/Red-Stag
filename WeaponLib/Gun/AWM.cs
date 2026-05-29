using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponLib
{
    public class AWM : AirDropGun
    {
        public override void CheckInfo()
        {
            Console.WriteLine("AWM: Sniper Rifle, 5 Round Magazine, .300 Magnum Ammo");
        }

        public override void Reload()
        {
            Console.WriteLine("AWM Reloaded");
        }

        public override void Shoot()
        {
            Console.WriteLine("AWM Shot Fired");
        }
    }
}
