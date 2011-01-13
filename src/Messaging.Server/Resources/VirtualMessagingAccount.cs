using System;
using System.Collections.Generic;

namespace Messaging.Server.Resources
{
    public class VirtualMessagingAccount
    {
        public Guid Id { get; set; }
        public string VirtualPhoneNumber { get; set; }

        public List<InboundMessage> InboundMessages { get; set; }
        public List<OutboundMessage> OutboundMessages { get; set; }
    }
}