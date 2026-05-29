using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeKit
{
    internal class SignalSystem
    {
        public void SendSignal()
        {
            Console.WriteLine("SignalSystem: Sending signal...");
        }


        public void ReceiveSignal() 
        { 
            Console.WriteLine("SignalSystem: Receiving signal..."); 
        }
    }
}
