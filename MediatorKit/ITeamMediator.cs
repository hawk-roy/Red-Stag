using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorKit
{
    public interface ITeamMediator
    {
        void SendMessage(string message, TeamMember sender);
        void AddMember(TeamMember member);
    }
}
