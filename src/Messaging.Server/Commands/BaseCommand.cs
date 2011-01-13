using System;

namespace Messaging.Server.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public Guid CommandId { get; private set; }

        protected BaseCommand()
        {
            CommandId = Guid.NewGuid();
        }
    }
}