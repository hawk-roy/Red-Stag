using System;
using System.Collections.Generic;
using System.Text;

namespace CommandKit
{
    public class FireCommand : ICommand
    {
        private Weapon weapon;
        private bool wasFired = false;

        public FireCommand(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public void Execute()
        {
            int ammoBefore = weapon.AmmoCount;
            weapon.Fire();
            wasFired = (weapon.AmmoCount < ammoBefore); // 检查是否真的开火了
        }

        public void Undo()
        {
            if (wasFired)
            {
                Console.WriteLine($"{weapon.Name}: Cannot undo firing - bullet already fired");
            }
            else
            {
                Console.WriteLine($"{weapon.Name}: No firing to undo");
            }
        }
    }
}
