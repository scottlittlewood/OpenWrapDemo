using System;
using System.Collections.Generic;
using System.Text;
using AutoPoco.Engine;

namespace SomeCode.Core
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
