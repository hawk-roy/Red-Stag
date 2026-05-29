using System;
using System.Collections.Generic;
using System.Text;

namespace DutyChainKit
{
    public class SecurityOfficer : WeaponApprovalHandler
    {
        public override void HandleRequest(WeaponRequest request)
        {
            if (request.DangerLevel >= 1 && request.DangerLevel <= 3)
            {
                Console.WriteLine($"[Security Officer] Approved: {request.ApplicantName} can use {request.WeaponType}");
                Console.WriteLine($"  Purpose: {request.Purpose}");
                Console.WriteLine($"  Danger Level: {request.DangerLevel} (Low Risk)");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine($"[Security Officer] Cannot handle danger level {request.DangerLevel}, passing to next handler...");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine($"[Security Officer] No one can handle this request!");
            }
        }
    }
}
