using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponLib
{
    public class AWMFactory : AirDropGunFactory
    {
        public override AirDropGun CreateGun()
        {
            return new AWM();
        }
    }
}
