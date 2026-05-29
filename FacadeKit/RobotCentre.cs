using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeKit
{
    public class RobotCentre
    {
        private CheckSystem checkSystem;
        private SportSystem sportSystem;
        private SignalSystem signalSystem;
        public RobotCentre()
        {
            checkSystem = new CheckSystem();
            sportSystem = new SportSystem();
            signalSystem = new SignalSystem();
        }
        public void StartRobot()
        {
            Console.WriteLine("RobotCentre: Starting robot...");
            signalSystem.ReceiveSignal();
            checkSystem.Check();
            sportSystem.StartSport();
            Console.WriteLine();
        }
        public void StopRobot()
        {
            Console.WriteLine("RobotCentre: Stopping robot...");
            sportSystem.StopSport();
            signalSystem.SendSignal();
            checkSystem.UploadCheckingResult();
        }
    }
}
