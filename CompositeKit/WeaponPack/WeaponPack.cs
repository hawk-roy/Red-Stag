using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeKit
{
    public class WeaponPack : IWeaponComponent
    {
        public string Name { get; private set; }
        private List<IWeaponComponent> components = new List<IWeaponComponent>();

        public WeaponPack(string name)
        {
            Name = name;
        }


        public void AddComponent(IWeaponComponent component)
        {
            components.Add(component);
        }


        public int GetPrice()
        {
            int totalPrice = 0;
            foreach (var component in components)
            {
                totalPrice += component.GetPrice();
            }

            return totalPrice;
        }

        public int GetWeight()
        {
            int totalWeight = 0;
            foreach (var component in components)
            {
                totalWeight += component.GetWeight();
            }
            return totalWeight;
        }

        public void ShowInfo()
        {
            foreach (var component in components)
            {
                component.ShowInfo();
            }
        }
    }
}
