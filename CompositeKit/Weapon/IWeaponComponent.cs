using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeKit
{
    public interface IWeaponComponent
    {
        string Name { get; }
        void ShowInfo();
        int GetWeight();
        int GetPrice();
    }
}
