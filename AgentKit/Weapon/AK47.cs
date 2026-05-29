using System;
using System.Collections.Generic;
using System.Text;

namespace AgentKit
{
    internal class AK47 : IWeapon
    {
        public void Fire(string user)
        {
            Console.WriteLine($"{user} fired an AK-47!");
        }
    }
}
