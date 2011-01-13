using System.Collections.Generic;
using AutoPoco;
using AutoPoco.Engine;
using Messaging.Server.Handlers;
using Messaging.Server.Resources;
using OpenRasta.Configuration;
using OpenRasta.DI;

namespace Messaging.Server
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                var factory = AutoPocoContainer.Configure(x =>
                {
                    x.Conventions(c =>
                    {
                        c.UseDefaultConventions();
                    });
                    x.AddFromAssemblyContainingType<VirtualMessagingAccount>();
                });

                // Generate one of these per test (factory will be a static variable most likely)
                var session = factory.CreateSession();

                // Get a single user

                // Get a collection of users
                var fakeAccounts = session.List<VirtualMessagingAccount>(100).Get();

                ResourceSpace.Uses.Resolver.AddDependencyInstance(typeof(IList<VirtualMessagingAccount>), fakeAccounts, DependencyLifetime.Singleton);

                ResourceSpace.Has.ResourcesOfType<Home>()
                    .AtUri("/home")
                    .And.AtUri("/")
                    .HandledBy<HomeHandler>();

                ResourceSpace.Has.ResourcesOfType<VirtualMessagingAccount>()
                    .AtUri("/accounts/{vmn}")
                    .HandledBy<VirtualMessagingAccountHandler>()
                    .AsXmlSerializer();

                ResourceSpace.Has.ResourcesOfType<List<VirtualMessagingAccount>>()
                    .AtUri("/accounts")
                    .HandledBy<VirtualMessagingAccountHandler>()
                    .AsXmlSerializer();

                ResourceSpace.Has.ResourcesOfType<Communicate>()
                    .AtUri("/accounts/{vmn}/communicate")
                    .HandledBy<CommunicationHandler>()
                    .AsXmlSerializer();

                ResourceSpace.Has.ResourcesOfType<OutboundMessage>()
                    .AtUri("/accounts/{vmn}/messages/sent/{id}")
                    .HandledBy<CommunicationHandler>()
                    .AsXmlSerializer();

                ResourceSpace.Has.ResourcesOfType<List<MessageBase>>()
                    .AtUri("/accounts/{vmn}/messages/all")
                    .HandledBy<CommunicationHandler>()
                    .AsXmlSerializer();

                ResourceSpace.Has.ResourcesOfType<List<OutboundMessage>>()
                    .AtUri("/accounts/{vmn}/messages/sent/recent")
                    .And.AtUri("/accounts/{vmn}/messages/sent/{year}-{month}-{day}")
                    .HandledBy<OutboundMessageHandler>()
                    .AsXmlSerializer();

                ResourceSpace.Has.ResourcesOfType<List<InboundMessage>>()
                    .AtUri("/accounts/{vmn}/messages/recevied/recent")
                    .And.AtUri("/accounts/{vmn}/messages/recevied/{year}-{month}-{day}")
                    .HandledBy<InboundMessageHandler>()
                    .AsXmlSerializer();

                ResourceSpace.Has.ResourcesOfType<InboundMessage>()
                    .AtUri("/accounts/{vmn}/messages/received/{id}")
                    .HandledBy<InboundMessageHandler>()
                    .AsXmlSerializer();
            }
        }
    }
}