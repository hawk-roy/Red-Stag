using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverKit
{
    public class Supply : IObserver
    {
        public string DepartmentName { get; private set; }

        public Supply(string departmentName)
        {
            DepartmentName = departmentName;
        }

        public void Update(string weaponName, string status)
        {
            if (status.Contains("Ammo remaining: 0") || status.Contains("No ammo"))
            {
                Console.WriteLine($"[{DepartmentName}] ALERT: {weaponName} needs ammo resupply!");
            }
            else if (status.Contains("Fired"))
            {
                Console.WriteLine($"[{DepartmentName}] INFO: {weaponName} ammo consumption recorded");
            }
        }
    }
}
