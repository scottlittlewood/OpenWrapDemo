using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeCode.Core.Commands
{
    public class SendMessageCommand : ICommand
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public string Text { get; private set; }

        public SendMessageCommand(string from, string to, string text)
        {
            From = from;
            To = to;
            Text = text;
        }
    }

    public interface ICommand
    {
    }

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }


    public class MessageSender : ICommandHandler<SendMessageCommand>
    {
        public void Handle(SendMessageCommand command)
        {
            
        }
    }
}
