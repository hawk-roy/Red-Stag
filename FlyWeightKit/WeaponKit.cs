using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FlyWeightKit
{
    public class WeaponKit
    {
        private static Dictionary<string, IWeapon> _pool = new Dictionary<string, IWeapon>();

        public IWeapon GetWeapon(string type)
        {
            if (!_pool.ContainsKey(type))
            {
                switch (type.ToLower())
                {
                    case "ak47":
                        _pool[type] = new AK47();
                        break;
                    case "m4":
                        _pool[type] = new M4();
                        break;
                    default:
                        throw new System.ArgumentException("Unknown weapon type");
                }
            }

            return _pool[type];
        }

        public int GetPoolCount() => _pool.Count;
    }
}
