using System;
using System.Collections.Generic;
using System.Text;

namespace GunPrototype
{
    public class WeaponPrototypeMgr
    {
        private Dictionary<string, IWeaponPrototype> _prototypes = new Dictionary<string, IWeaponPrototype>();

        public void RegisterPrototype(string key, IWeaponPrototype prototype)
        {
            _prototypes[key] = prototype;
        }

        public IWeaponPrototype CreateWeapon(string key)
        {
            if (_prototypes.TryGetValue(key, out var prototype))
            {
                return prototype.Clone();
            }

            throw new ArgumentException($"No prototype registered with key: {key}");
        }

        public IEnumerable<string> GetRegisteredKeys()
        {
            return _prototypes.Keys;
        }

    }
}
