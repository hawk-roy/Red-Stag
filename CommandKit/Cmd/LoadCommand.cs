using System;
using System.Collections.Generic;
using System.Text;

namespace CommandKit
{
    public class LoadCommand : ICommand
    {
        private Weapon weapon;

        public LoadCommand(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public void Execute()
        {
            weapon.Load();
        }

        public void Undo()
        {
            weapon.Unload();
        }
    }
}
