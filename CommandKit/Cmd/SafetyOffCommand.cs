using System;
using System.Collections.Generic;
using System.Text;

namespace CommandKit
{
    public class SafetyOffCommand : ICommand
    {
        private Weapon weapon;

        public SafetyOffCommand(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public void Execute()
        {
            weapon.SafetyOff();
        }

        public void Undo()
        {
            weapon.SafetyOn();
        }
    }
}
