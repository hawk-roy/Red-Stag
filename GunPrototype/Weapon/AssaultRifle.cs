using System;
using System.Collections.Generic;
using System.Text;

namespace GunPrototype
{
    public class AssaultRifle : IWeaponPrototype
    {
        /// <summary>
        /// 突击步枪名称
        /// </summary>
        public string RifleName { get; set; }
        /// <summary>
        /// 扩容弹夹
        /// </summary>
        public string ExtendedMagazine { get; set; }
        /// <summary>
        /// 消音器
        /// </summary>
        public string Silencer { get; set; }
        /// <summary>
        /// 垂直握把
        /// </summary>
        public string VerticalGrip { get; set; }
        /// <summary>
        /// 瞄准镜
        /// </summary>
        public string Sight { get; set; }
        /// <summary>
        /// 托腮板
        /// </summary>
        public string CheekRest { get; set; }
        /// <summary>
        /// 子弹类型
        /// </summary>
        public string Ammunition { get; set; }

        public AssaultRifle()
        {
        }

        public AssaultRifle(AssaultRifle other)
        {
            RifleName = other.RifleName;
            ExtendedMagazine = other.ExtendedMagazine;
            Silencer = other.Silencer;
            VerticalGrip = other.VerticalGrip;
            Sight = other.Sight;
            CheekRest = other.CheekRest;
            Ammunition = other.Ammunition;
        }

        public IWeaponPrototype Clone()
        {
            return new AssaultRifle(this);
        }

        public void DisplayInfo()
        {
            Console.WriteLine("=== Assault Rifle Configuration ===");
            Console.WriteLine($"Rifle: {RifleName ?? "Not Set"}");
            Console.WriteLine($"Extended Magazine: {ExtendedMagazine ?? "Not Set"}");
            Console.WriteLine($"Silencer: {Silencer ?? "Not Set"}");
            Console.WriteLine($"Vertical Grip: {VerticalGrip ?? "Not Set"}");
            Console.WriteLine($"Sight: {Sight ?? "Not Set"}");
            Console.WriteLine($"Cheek Rest: {CheekRest ?? "Not Set"}");
            Console.WriteLine($"Ammunition: {Ammunition ?? "Not Set"}");
            Console.WriteLine("==================================");
        }
    }
}
