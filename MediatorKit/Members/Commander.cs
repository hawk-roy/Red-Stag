using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorKit
{
    public class Commander : TeamMember
    {
        public Commander(ITeamMediator mediator, string name) : base(mediator, name)
        {
        }

        public override void SendMessage(string message)
        {
            Console.WriteLine($"[Commander {Name}] broadcasts: {message}");
            mediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message, string senderName)
        {
            Console.WriteLine($"[Commander {Name}] received from {senderName}: {message}");
        }
    }
}
