using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponLib
{
    public class P90Factory : AirDropGunFactory
    {
        public override AirDropGun CreateGun()
        {
            return new P90();
        }
    }
}
