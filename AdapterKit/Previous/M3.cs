using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterKit.Previous
{
    public class M3 : IWeapon
    {
        public void DisplayInfo()
        {
            Console.WriteLine("M3: A powerful submachine gun with high speed damage.");
        }

        public void Fire()
        {
            Console.WriteLine("M3: Da da da da !");
        }

        public void ReFillAmmo()
        {
            Console.WriteLine("M3: ReFillAmmo ...");
        }
    }
}
