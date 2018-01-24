using System;

namespace WebApi
{
    public class Contact
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}