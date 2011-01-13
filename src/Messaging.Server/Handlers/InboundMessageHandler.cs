using System;
using OpenRasta.Web;

namespace Messaging.Server.Handlers
{
    public class InboundMessageHandler
    {
        public OperationResult Get(string vmn)
        {
            // get all inbound messages
        }

        public OperationResult Get(string vmn, int year, int month, int day)
        {
            // get all inbound messages for a day
        }

        public OperationResult Get(Guid id)
        {
            // get a message
        }
    }
}