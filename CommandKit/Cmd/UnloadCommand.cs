using System;
using System.Collections.Generic;
using System.Text;

namespace CommandKit
{
    public class UnloadCommand : ICommand
    {
        private Weapon weapon;

        public UnloadCommand(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public void Execute()
        {
            weapon.Unload();
        }

        public void Undo()
        {
            weapon.Load();
        }
    }
}
