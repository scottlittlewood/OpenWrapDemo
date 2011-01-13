using Messaging.Server.Resources;

namespace Messaging.Server.Commands
{
    public class SendCommunicationCommand : BaseCommand
    {
        public Communicate Communicate { get; private set; }
        public string Username { get; private set; }

        public SendCommunicationCommand(Communicate communicate, string username)
        {
            Communicate = communicate;
            Username = username;
        }
    }
}