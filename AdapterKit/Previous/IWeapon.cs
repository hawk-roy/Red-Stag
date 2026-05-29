using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterKit.Previous
{
    public interface IWeapon
    {
        void Fire();

        void ReFillAmmo();

        void DisplayInfo();
    }
}
