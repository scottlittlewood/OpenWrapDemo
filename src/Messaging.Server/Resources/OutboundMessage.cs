using System;

namespace Messaging.Server.Resources
{
    public class OutboundMessage : MessageBase
    {
        public DateTime SubmittedAt { get; set; }
        public string SubmittedBy { get; set; }

    }
}