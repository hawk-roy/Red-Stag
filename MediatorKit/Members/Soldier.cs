using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorKit
{
    public class Soldier : TeamMember
    {
        public Soldier(ITeamMediator mediator, string name) : base(mediator, name)
        {
        }

        public override void SendMessage(string message)
        {
            Console.WriteLine($"[{Name}] sends: {message}");
            mediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message, string senderName)
        {
            Console.WriteLine($"[{Name}] received from {senderName}: {message}");
        }
    }
}
