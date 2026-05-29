using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterKit.Previous
{
    public class Thompson : IWeapon
    {
        public void DisplayInfo()
        {
            Console.WriteLine("Thompson: A powerful submachine gun with high speed damage.");
        }

        public void Fire()
        {
            Console.WriteLine("Thompson: Da da da da !");
        }

        public void ReFillAmmo()
        {
            Console.WriteLine("Thompson: ReFillAmmo ...");
        }
    }
}
