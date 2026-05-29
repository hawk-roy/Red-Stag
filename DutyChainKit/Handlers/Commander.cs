using System;
using System.Collections.Generic;
using System.Text;

namespace DutyChainKit
{
    public class Commander : WeaponApprovalHandler
    {
        public override void HandleRequest(WeaponRequest request)
        {
            if (request.DangerLevel >= 7 && request.DangerLevel <= 8)
            {
                Console.WriteLine($"[Commander] Approved: {request.ApplicantName} can use {request.WeaponType}");
                Console.WriteLine($"  Purpose: {request.Purpose}");
                Console.WriteLine($"  Danger Level: {request.DangerLevel} (High Risk)");
                Console.WriteLine($"  Requires supervision and mission briefing!");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine($"[Commander] Cannot handle danger level {request.DangerLevel}, passing to next handler...");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine($"[Commander] No one can handle this request!");
            }
        }
    }
}
