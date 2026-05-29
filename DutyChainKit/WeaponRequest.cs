using System;
using System.Collections.Generic;
using System.Text;

namespace DutyChainKit
{
    public class WeaponRequest
    {
        public string ApplicantName { get; set; }
        public string WeaponType { get; set; }
        public int DangerLevel { get; set; } // 危险等级 1-10
        public string Purpose { get; set; }

        public WeaponRequest(string applicantName, string weaponType, int dangerLevel, string purpose)
        {
            ApplicantName = applicantName;
            WeaponType = weaponType;
            DangerLevel = dangerLevel;
            Purpose = purpose;
        }
    }
}
