using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeKit
{
    public class SingleShotMode : IShootingMode
    {
        public void Shoot()
        {
            Console.WriteLine("Shooting in Single Shot Mode: One shot per trigger pull.");
        }

        public string ShowShootingMode()
        {
            return "Current Shooting Mode: Single Shot";
        }
    }
}
