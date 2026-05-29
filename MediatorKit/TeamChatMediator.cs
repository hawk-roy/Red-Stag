using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorKit
{
    public class TeamChatMediator : ITeamMediator
    {
        private List<TeamMember> members = new List<TeamMember>();

        public void AddMember(TeamMember member)
        {
            members.Add(member);
            Console.WriteLine($"{member.Name} joined the team chat");
        }

        public void SendMessage(string message, TeamMember sender)
        {
            // 将消息转发给除发送者外的所有成员
            foreach (TeamMember member in members)
            {
                if (member != sender)
                {
                    member.ReceiveMessage(message, sender.Name);
                }
            }
        }
    }
}
