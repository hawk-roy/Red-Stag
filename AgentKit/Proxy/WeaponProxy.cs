using System;
using System.Collections.Generic;
using System.Text;

namespace AgentKit
{
    public class WeaponProxy : IWeapon
    {
        private AK47 _ak47 = new AK47();
        private HashSet<string> _authorizedUsers = new HashSet<string> { "Alice", "Bob" };

        public void Fire(string user)
        {
            if (_authorizedUsers.Contains(user))
            {
                Console.WriteLine($"[Proxy] {user} is authorized.");
                _ak47.Fire(user);
            }
            else
            {
                Console.WriteLine($"[Proxy] {user} is NOT authorized to fire the weapon!");
            }
        }
    }
}
