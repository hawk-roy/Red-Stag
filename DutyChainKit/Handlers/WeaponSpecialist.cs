using System;
using System.Collections.Generic;
using System.Text;

namespace DutyChainKit
{
    public class WeaponSpecialist : WeaponApprovalHandler
    {
        public override void HandleRequest(WeaponRequest request)
        {
            if (request.DangerLevel >= 4 && request.DangerLevel <= 6)
            {
                Console.WriteLine($"[Weapon Specialist] Approved: {request.ApplicantName} can use {request.WeaponType}");
                Console.WriteLine($"  Purpose: {request.Purpose}");
                Console.WriteLine($"  Danger Level: {request.DangerLevel} (Medium Risk)");
                Console.WriteLine($"  Special training required!");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine($"[Weapon Specialist] Cannot handle danger level {request.DangerLevel}, passing to next handler...");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine($"[Weapon Specialist] No one can handle this request!");
            }
        }
    }
}
