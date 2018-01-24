using System;

namespace FormsRefit
{
    public class ContactModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";
    }
}
