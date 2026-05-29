using System;
using System.Collections.Generic;
using System.Text;

namespace MementoKit
{
    public class WeaponManager
    {
        private List<WeaponMemento> mementos = new List<WeaponMemento>();

        public void SaveMemento(WeaponMemento memento)
        {
            mementos.Add(memento);
            Console.WriteLine($"Memento saved. Total saved: {mementos.Count}");
        }

        public WeaponMemento GetMemento(int index)
        {
            if (index >= 0 && index < mementos.Count)
            {
                return mementos[index];
            }
            throw new IndexOutOfRangeException("Invalid memento index");
        }

        public void ShowAllMementos()
        {
            Console.WriteLine($"\n=== Saved Mementos ({mementos.Count}) ===");
            for (int i = 0; i < mementos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ");
                mementos[i].ShowMementoInfo();
            }
        }

        public int GetMementoCount()
        {
            return mementos.Count;
        }
    }
}
