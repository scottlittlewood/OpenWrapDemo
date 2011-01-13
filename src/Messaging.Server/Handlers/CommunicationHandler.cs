using System;
using System.Collections.Generic;
using Messaging.Server.Commands;
using Messaging.Server.Resources;
using OpenRasta.Web;

namespace Messaging.Server.Handlers
{
    public class CommunicationHandler
    {
        private readonly IHandle<SendCommunicationCommand> _handler;
        public ICommunicationContext Context { get; set; }

        public CommunicationHandler(IHandle<SendCommunicationCommand> handler)
        {
            _handler = handler;
        }

        public OperationResult Post(Communicate communicate)
        {
            var theUser = Context.User.Identity.Name;

            // store the communication for reporting

            var command = new SendCommunicationCommand(communicate, theUser);

            _handler.Handle(command);

            return new OperationResult.SeeOther { RedirectLocation = typeof(List<OutboundMessage>).CreateUri() };
        }

        public OperationResult Get(Guid id)
        {

        }
    }
}