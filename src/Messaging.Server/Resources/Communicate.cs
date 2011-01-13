using System;

namespace Messaging.Server.Resources
{
    public class Communicate
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string MessageText { get; set; }
    }
}