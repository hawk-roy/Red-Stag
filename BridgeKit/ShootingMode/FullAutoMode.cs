using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeKit
{
    public class FullAutoMode : IShootingMode
    {
        public void Shoot()
        {
            Console.WriteLine("Shooting in Full Auto Mode: Continuous fire until the trigger is released.");
        }

        public string ShowShootingMode()
        {
            return "Current Shooting Mode: Full Auto";
        }
    }
}
