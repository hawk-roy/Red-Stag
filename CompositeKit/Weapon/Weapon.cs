using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeKit
{
    public class Weapon : IWeaponComponent
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Weight { get; private set; }
        public int Price { get; private set; }

        public Weapon(string name, string type, int weight, int price)
        {
            Name = name;
            Type = type;
            Weight = weight;
            Price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"  {Type}: {Name} (Weight: {Weight}kg, Value: ${Price})");
        }

        public int GetWeight()
        {
            return Weight;
        }

        public int GetPrice()
        {
            return Price;
        }
    }
}
