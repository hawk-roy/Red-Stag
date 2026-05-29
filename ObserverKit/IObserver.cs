using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverKit
{
    public interface IObserver
    {
        void Update(string weaponName, string status);
    }
}
