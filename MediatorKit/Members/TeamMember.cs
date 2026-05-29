using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorKit
{
    public abstract class TeamMember
    {
        protected ITeamMediator mediator;
        public string Name { get; protected set; }

        public TeamMember(ITeamMediator mediator, string name)
        {
            this.mediator = mediator;
            this.Name = name;
        }

        public abstract void SendMessage(string message);
        public abstract void ReceiveMessage(string message, string senderName);
    }
}
