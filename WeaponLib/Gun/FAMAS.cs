using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponLib
{
    public class FAMAS : AirDropGun
    {
        public override void CheckInfo()
        {
            Console.WriteLine("FAMAS: Assault Rifle, 25 Round Magazine, 5.56mm Ammo");
        }

        public override void Reload()
        {
            Console.WriteLine("FAMAS Reloaded");
        }

        public override void Shoot()
        {
            Console.WriteLine("FAMAS Shooting");
        }
    }
}
