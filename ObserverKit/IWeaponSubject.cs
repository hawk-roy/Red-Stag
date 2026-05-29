using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverKit
{
    public interface IWeaponSubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string status);
    }
}
