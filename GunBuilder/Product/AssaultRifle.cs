using System;
using System.Collections.Generic;
using System.Text;

namespace GunBuilder
{
    public class AssaultRifle
    {
        /// <summary>
        /// 突击步枪名称
        /// </summary>
        internal string RifleName { get; set; }
        /// <summary>
        /// 扩容弹夹
        /// </summary>
        internal string ExtendedMagazine { get; set; }
        /// <summary>
        /// 消音器
        /// </summary>
        internal string Silencer { get; set; }
        /// <summary>
        /// 垂直握把
        /// </summary>
        internal string VerticalGrip { get; set; }
        /// <summary>
        /// 瞄准镜
        /// </summary>
        internal string Sight { get; set; }
        /// <summary>
        /// 托腮板
        /// </summary>
        internal string CheekRest { get; set; }
        /// <summary>
        /// 子弹类型
        /// </summary>
        internal string Ammunition { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Assault Rifle: {RifleName}");
            Console.WriteLine($"Extended Magazine: {ExtendedMagazine}");
            Console.WriteLine($"Silencer: {Silencer}");
            Console.WriteLine($"VerticalGrip: {VerticalGrip}");
            Console.WriteLine($"Sight: {Sight}");
            Console.WriteLine($"CheekRest: {CheekRest}");
            Console.WriteLine($"Ammunition: {Ammunition}");
        }
    }
}
