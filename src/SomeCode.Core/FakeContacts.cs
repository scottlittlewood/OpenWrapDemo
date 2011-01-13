using System;
using System.Linq;
using AutoPoco;

namespace SomeCode.Core
{
    public class FakeContacts
    {
        public FakeContacts()
        {
            // Perform factory set up (once for entire test run)
            var factory = AutoPocoContainer.Configure(x =>
                                                          {
                                                              x.Conventions(c =>
                                                                                {
                                                                                    c.UseDefaultConventions();
                                                                                });
                                                              x.AddFromAssemblyContainingType<Contact>();
                                                          });

            // Generate one of these per test (factory will be a static variable most likely)
            var session = factory.CreateSession();

            // Get a single user
            Contact contact = session.Single<Contact>().Get();

            // Get a collection of users
            var contacts = session.List<Contact>(100).Get();

            // Get a collection of users, but set their role manually
            var moreContacts = session.List<Contact>(10)
                .Impose(x => x.LastName, "Bloggs")
                .Get();

            Console.WriteLine(string.Join(Environment.NewLine, contacts.Select(c=>c.FirstName + " " + c.LastName)));
        }
    }
}