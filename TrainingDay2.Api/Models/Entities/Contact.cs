using System;
using System.Collections.Generic;

namespace TrainingDay2.Api.Models.Entities
{
    public partial class Contact
    {
        public Contact()
        {
            ContactTag = new HashSet<ContactTag>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }

        public ICollection<ContactTag> ContactTag { get; set; }
    }
}
