using System;
using System.Collections.Generic;
using System.Text;

namespace CommandKit
{
    public class SafetyOnCommand : ICommand
    {
        private Weapon weapon;

        public SafetyOnCommand(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public void Execute()
        {
            weapon.SafetyOn();
        }

        public void Undo()
        {
            weapon.SafetyOff();
        }
    }
}
