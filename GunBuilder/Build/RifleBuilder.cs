using System;
using System.Collections.Generic;
using System.Text;

namespace GunBuilder
{
    public abstract class RifleBuilder
    {
        abstract public RifleBuilder BuildRifleName(string rifleName);
        abstract public RifleBuilder BuildExtendedMagazine(string extendedMagazine);
        abstract public RifleBuilder BuildSilencer(string silencer);
        abstract public RifleBuilder BuildVerticalGrip(string verticalGrip);
        abstract public RifleBuilder BuildSight(string sight);
        abstract public RifleBuilder BuildCheekRest(string cheekRest);
        abstract public RifleBuilder BuildReloadAmunition(string amunitionStr);

        abstract public AssaultRifle GetRifle();

    }
}
