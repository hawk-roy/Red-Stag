using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodKit
{
    public abstract class WeaponTraining
    {
        // 模板方法：流程固定，不建议子类改（所以不声明 virtual）
        public void Run()
        {
            CheckWeapon();
            LoadAmmo();
            Aim();
            Fire();
            Cleanup();
        }

        // 固定步骤（可由子类实现）
        protected abstract void CheckWeapon();
        protected abstract void LoadAmmo();
        protected abstract void Aim();
        protected abstract void Fire();

        // 可选步骤：提供默认实现，子类可选择性重写
        protected virtual void Cleanup()
        {
            Console.WriteLine("Cleanup: Training finished.\n");
        }
    }
}
