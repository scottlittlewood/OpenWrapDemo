namespace Messaging.Server
{
    public interface IHandle<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}