using System;

namespace Messaging.Server.Resources
{
    public class InboundMessage : MessageBase
    {
        public DateTime ReceivedAt { get; set; }
    }

    public abstract class MessageBase
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string MessageText { get; set; }
    }
}