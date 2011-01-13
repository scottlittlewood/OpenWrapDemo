using System;

namespace Messaging.Server
{
    /// <summary>
    /// Marker interface
    /// </summary>
    public interface ICommand
    {
        Guid CommandId { get; }
    }
}