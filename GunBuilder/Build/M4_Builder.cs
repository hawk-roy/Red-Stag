using System;
using System.Collections.Generic;
using System.Text;

namespace GunBuilder
{
    public class M4_Builder : RifleBuilder
    {
        public AssaultRifle m4 = new AssaultRifle();

        public override RifleBuilder BuildCheekRest(string cheekRest)
        {
           m4.CheekRest = cheekRest;
           return this;
        }

        public override RifleBuilder BuildExtendedMagazine(string extendedMagazine)
        {
            m4.ExtendedMagazine = extendedMagazine;
            return this;
        }

        public override RifleBuilder BuildReloadAmunition(string amunitionStr)
        {
            m4.Ammunition = amunitionStr;
            return this;
        }

        public override RifleBuilder BuildRifleName(string rifleName)
        {
            m4.RifleName = rifleName;
            return this;
        }

        public override RifleBuilder BuildSight(string sight)
        {
            m4.Sight = sight;
            return this;
        }

        public override RifleBuilder BuildSilencer(string silencer)
        {
            m4.Silencer = silencer;
            return this;
        }

        public override RifleBuilder BuildVerticalGrip(string verticalGrip)
        {
            m4.VerticalGrip = verticalGrip;
            return this;
        }

        public override AssaultRifle GetRifle()
        {
            return m4;
        }
    }
}
