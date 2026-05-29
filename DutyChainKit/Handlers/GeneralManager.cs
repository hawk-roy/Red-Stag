using System;
using System.Collections.Generic;
using System.Text;

namespace DutyChainKit
{
    public class GeneralManager : WeaponApprovalHandler
    {
        public override void HandleRequest(WeaponRequest request)
        {
            if (request.DangerLevel >= 9 && request.DangerLevel <= 10)
            {
                Console.WriteLine($"[General Manager] APPROVED WITH EXTREME CAUTION: {request.ApplicantName} can use {request.WeaponType}");
                Console.WriteLine($"  Purpose: {request.Purpose}");
                Console.WriteLine($"  Danger Level: {request.DangerLevel} (EXTREME RISK)");
                Console.WriteLine($"  Requires full authorization and emergency protocols!");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine($"[General Manager] Cannot handle danger level {request.DangerLevel}, passing to next handler...");
                nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine($"[General Manager] REQUEST DENIED! Danger level too high or invalid!");
            }
        }
    }
}
