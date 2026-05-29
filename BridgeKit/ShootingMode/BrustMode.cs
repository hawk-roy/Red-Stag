using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeKit
{
    public class BrustMode : IShootingMode
    {
        public void Shoot()
        {
            Console.WriteLine("Shooting in Brust Mode: Fires a burst of 3 rounds per trigger pull.");
        }

        public string ShowShootingMode()
        {
            return "Current Shooting Mode: Brust";
        }
    }
}
